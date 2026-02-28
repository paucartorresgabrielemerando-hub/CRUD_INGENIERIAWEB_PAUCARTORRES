import {
  ChangeDetectionStrategy,
  Component,
  effect,
  inject,
  input,
  output,
} from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { PersonaDireccionDto } from '../../../models/persona-direccion/PersonaDireccionDto.model';
import { PersonaDireccionService } from '../../../services/persona-direccion/persona-direccion.service';

@Component({
  selector: 'app-mantenimiento-persona-direccion-editar',
  imports: [ReactiveFormsModule],
  templateUrl: './mantenimiento-persona-direccion-editar.component.html',
  styleUrls: ['./mantenimiento-persona-direccion-editar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MantenimientoPersonaDireccionEditarComponent {
  item = input<PersonaDireccionDto | null>(null);
  personaId = input<number | null>(null);
  modo = input<'crear' | 'editar'>('crear');

  cancelado = output<void>();
  guardado = output<void>();

  private readonly service = inject(PersonaDireccionService);
  private readonly formBuilder = inject(FormBuilder);

  readonly form = this.formBuilder.group({
    tipo: ['CASA', [Validators.required]],
    direccion: ['', [Validators.required]],
    ciudad: [''],
    region: [''],
    codigoPostal: [''],
  });

  cargando = false;

  constructor() {
    effect(() => {
      const current = this.item();
      this.form.reset({
        tipo: current?.tipo ?? 'CASA',
        direccion: current?.direccion ?? '',
        ciudad: current?.ciudad ?? '',
        region: current?.region ?? '',
        codigoPostal: current?.codigoPostal ?? '',
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

    const payload: PersonaDireccionDto = {
      id: current?.id ?? 0,
      idPersona: pid,
      tipo: valores.tipo ?? 'CASA',
      direccion: valores.direccion ?? '',
      ciudad: valores.ciudad ?? '',
      region: valores.region ?? '',
      codigoPostal: valores.codigoPostal ?? '',
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

