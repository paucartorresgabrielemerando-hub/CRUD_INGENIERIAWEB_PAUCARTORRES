import {
  ChangeDetectionStrategy,
  Component,
  effect,
  inject,
  input,
  output,
} from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { PersonaCorreoDto } from '../../../models/persona-correo/PersonaCorreoDto.model';
import { PersonaCorreoService } from '../../../services/persona-correo/persona-correo.service';

@Component({
  selector: 'app-mantenimiento-persona-correo-editar',
  imports: [ReactiveFormsModule],
  templateUrl: './mantenimiento-persona-correo-editar.component.html',
  styleUrls: ['./mantenimiento-persona-correo-editar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MantenimientoPersonaCorreoEditarComponent {
  item = input<PersonaCorreoDto | null>(null);
  personaId = input<number | null>(null);
  modo = input<'crear' | 'editar'>('crear');

  cancelado = output<void>();
  guardado = output<void>();

  private readonly service = inject(PersonaCorreoService);
  private readonly formBuilder = inject(FormBuilder);

  readonly form = this.formBuilder.group({
    correo: ['', [Validators.required, Validators.email]],
    esPrincipal: [false],
  });

  cargando = false;

  constructor() {
    effect(() => {
      const current = this.item();
      this.form.reset({
        correo: current?.correo ?? '',
        esPrincipal: current?.esPrincipal ?? false,
      });
    });
  }

  onCancelar(): void {
    this.cancelado.emit();
  }

  onGuardar(): void {
    this.form.markAllAsTouched();
    if (this.form.invalid || this.cargando) return;

    const current = this.item();
    const pid = this.personaId() ?? current?.idPersona ?? 0;
    if (!pid) return;

    this.cargando = true;
    const nowIso = new Date().toISOString();
    const valores = this.form.getRawValue();

    const payload: PersonaCorreoDto = {
      id: current?.id ?? 0,
      idPersona: pid,
      correo: valores.correo ?? '',
      esPrincipal: !!valores.esPrincipal,
      userCreate: current?.userCreate ?? 1,
      userUpdate: 1,
      dateCreated: current?.dateCreated ?? nowIso,
      dateUpdate: nowIso,
    };

    const request$ =
      this.modo() === 'editar' && payload.id > 0 ? this.service.update(payload) : this.service.create(payload);

    request$.subscribe({
      next: () => this.guardado.emit(),
      error: () => (this.cargando = false),
      complete: () => (this.cargando = false),
    });
  }
}

