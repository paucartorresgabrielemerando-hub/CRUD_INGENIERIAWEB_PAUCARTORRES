import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { PersonaService } from '../../../services/persona/persona.service';
import { PersonaEmpleoService } from '../../../services/persona-empleo/persona-empleo.service';
import { PersonaDto } from '../../../models/persona/PersonaDto.model';
import { PersonaEmpleoDto } from '../../../models/persona-empleo/PersonaEmpleoDto.model';
import { MantenimientoPersonaEmpleoEditarComponent } from '../mantenimiento-persona-empleo-editar/mantenimiento-persona-empleo-editar.component';

@Component({
  selector: 'app-mantenimiento-persona-empleo-list',
  imports: [MantenimientoPersonaEmpleoEditarComponent],
  templateUrl: './mantenimiento-persona-empleo-list.component.html',
  styleUrls: ['./mantenimiento-persona-empleo-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MantenimientoPersonaEmpleoListComponent implements OnInit {
  private readonly personaService = inject(PersonaService);
  private readonly empleoService = inject(PersonaEmpleoService);

  personas = signal<PersonaDto[]>([]);
  selectedPersonaId = signal<number | null>(null);
  empleos = signal<PersonaEmpleoDto[]>([]);

  mostrarModal = false;
  modoEdicion: 'crear' | 'editar' = 'crear';
  itemSeleccionado: PersonaEmpleoDto | null = null;

  ngOnInit(): void {
    this.personaService.getAll().subscribe({
      next: (data) => {
        this.personas.set(data);
        const firstId = data?.[0]?.id ?? null;
        this.selectedPersonaId.set(firstId);
        if (firstId) this.cargarEmpleos(firstId);
      },
    });
  }

  onPersonaChange(value: string): void {
    const id = value ? Number(value) : null;
    this.selectedPersonaId.set(id);
    if (id) this.cargarEmpleos(id);
    else this.empleos.set([]);
  }

  cargarEmpleos(personaId: number): void {
    this.empleoService.getAll(personaId).subscribe({
      next: (data) => this.empleos.set(data),
      error: () => this.empleos.set([]),
    });
  }

  abrirAgregar(): void {
    this.modoEdicion = 'crear';
    this.itemSeleccionado = null;
    this.mostrarModal = true;
  }

  abrirEditar(item: PersonaEmpleoDto): void {
    this.modoEdicion = 'editar';
    this.itemSeleccionado = { ...item };
    this.mostrarModal = true;
  }

  cerrarModal(): void {
    this.mostrarModal = false;
    this.itemSeleccionado = null;
  }

  onGuardado(): void {
    this.cerrarModal();
    const pid = this.selectedPersonaId();
    if (pid) this.cargarEmpleos(pid);
  }

  eliminar(item: PersonaEmpleoDto): void {
    const confirmado = window.confirm(`¿Eliminar el empleo en "${item.empresa}"?`);
    if (!confirmado) return;

    this.empleoService.delete(item.id).subscribe({
      next: () => {
        const pid = this.selectedPersonaId();
        if (pid) this.cargarEmpleos(pid);
      },
    });
  }
}

