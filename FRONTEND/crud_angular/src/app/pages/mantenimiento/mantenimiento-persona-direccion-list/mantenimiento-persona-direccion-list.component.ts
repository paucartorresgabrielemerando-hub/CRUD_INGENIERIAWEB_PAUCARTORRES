import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { PersonaService } from '../../../services/persona/persona.service';
import { PersonaDireccionService } from '../../../services/persona-direccion/persona-direccion.service';
import { PersonaDto } from '../../../models/persona/PersonaDto.model';
import { PersonaDireccionDto } from '../../../models/persona-direccion/PersonaDireccionDto.model';
import { MantenimientoPersonaDireccionEditarComponent } from '../mantenimiento-persona-direccion-editar/mantenimiento-persona-direccion-editar.component';

@Component({
  selector: 'app-mantenimiento-persona-direccion-list',
  imports: [MantenimientoPersonaDireccionEditarComponent],
  templateUrl: './mantenimiento-persona-direccion-list.component.html',
  styleUrls: ['./mantenimiento-persona-direccion-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MantenimientoPersonaDireccionListComponent implements OnInit {
  private readonly personaService = inject(PersonaService);
  private readonly direccionService = inject(PersonaDireccionService);

  personas = signal<PersonaDto[]>([]);
  selectedPersonaId = signal<number | null>(null);
  direcciones = signal<PersonaDireccionDto[]>([]);

  mostrarModal = false;
  modoEdicion: 'crear' | 'editar' = 'crear';
  itemSeleccionado: PersonaDireccionDto | null = null;

  ngOnInit(): void {
    this.personaService.getAll().subscribe({
      next: (data) => {
        this.personas.set(data);
        const firstId = data?.[0]?.id ?? null;
        this.selectedPersonaId.set(firstId);
        if (firstId) this.cargarDirecciones(firstId);
      },
    });
  }

  onPersonaChange(value: string): void {
    const id = value ? Number(value) : null;
    this.selectedPersonaId.set(id);
    if (id) this.cargarDirecciones(id);
    else this.direcciones.set([]);
  }

  cargarDirecciones(personaId: number): void {
    this.direccionService.getAll(personaId).subscribe({
      next: (data) => this.direcciones.set(data),
      error: () => this.direcciones.set([]),
    });
  }

  abrirAgregar(): void {
    this.modoEdicion = 'crear';
    this.itemSeleccionado = null;
    this.mostrarModal = true;
  }

  abrirEditar(item: PersonaDireccionDto): void {
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
    if (pid) this.cargarDirecciones(pid);
  }

  eliminar(item: PersonaDireccionDto): void {
    const confirmado = window.confirm(`¿Eliminar la dirección "${item.direccion}"?`);
    if (!confirmado) return;

    this.direccionService.delete(item.id).subscribe({
      next: () => {
        const pid = this.selectedPersonaId();
        if (pid) this.cargarDirecciones(pid);
      },
    });
  }
}

