import {
  ChangeDetectionStrategy,
  Component,
  effect,
  inject,
  input,
  output,
} from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { PersonaEmpleoDto } from '../../../models/persona-empleo/PersonaEmpleoDto.model';
import { PersonaEmpleoService } from '../../../services/persona-empleo/persona-empleo.service';

function toDateInputValue(value: string | null | undefined): string {
  if (!value) return '';
  return value.length >= 10 ? value.slice(0, 10) : value;
}

@Component({
  selector: 'app-mantenimiento-persona-empleo-editar',
  imports: [ReactiveFormsModule],
  templateUrl: './mantenimiento-persona-empleo-editar.component.html',
  styleUrls: ['./mantenimiento-persona-empleo-editar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MantenimientoPersonaEmpleoEditarComponent {
  item = input<PersonaEmpleoDto | null>(null);
  personaId = input<number | null>(null);
  modo = input<'crear' | 'editar'>('crear');

  cancelado = output<void>();
  guardado = output<void>();

  private readonly service = inject(PersonaEmpleoService);
  private readonly formBuilder = inject(FormBuilder);

  readonly form = this.formBuilder.group({
    empresa: ['', [Validators.required]],
    cargo: [''],
    fechaInicio: ['', [Validators.required]],
    fechaFin: [''],
    salario: [null as number | null],
  });

  cargando = false;

  constructor() {
    effect(() => {
      const current = this.item();
      this.form.reset({
        empresa: current?.empresa ?? '',
        cargo: current?.cargo ?? '',
        fechaInicio: toDateInputValue(current?.fechaInicio),
        fechaFin: toDateInputValue(current?.fechaFin),
        salario: current?.salario ?? null,
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
    const v = this.form.getRawValue();

    const payload: PersonaEmpleoDto = {
      id: current?.id ?? 0,
      idPersona: pid,
      empresa: v.empresa ?? '',
      cargo: v.cargo ?? '',
      fechaInicio: v.fechaInicio ?? '',
      fechaFin: v.fechaFin ? v.fechaFin : null,
      salario: v.salario ?? null,
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

