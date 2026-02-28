import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { PersonaService } from '../../../services/persona/persona.service';
import { PersonaCorreoService } from '../../../services/persona-correo/persona-correo.service';
import { PersonaDto } from '../../../models/persona/PersonaDto.model';
import { PersonaCorreoDto } from '../../../models/persona-correo/PersonaCorreoDto.model';
import { MantenimientoPersonaCorreoEditarComponent } from '../mantenimiento-persona-correo-editar/mantenimiento-persona-correo-editar.component';

@Component({
  selector: 'app-mantenimiento-persona-correo-list',
  imports: [MantenimientoPersonaCorreoEditarComponent],
  templateUrl: './mantenimiento-persona-correo-list.component.html',
  styleUrls: ['./mantenimiento-persona-correo-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MantenimientoPersonaCorreoListComponent implements OnInit {
  private readonly personaService = inject(PersonaService);
  private readonly correoService = inject(PersonaCorreoService);

  personas = signal<PersonaDto[]>([]);
  selectedPersonaId = signal<number | null>(null);
  correos = signal<PersonaCorreoDto[]>([]);

  mostrarModal = false;
  modoEdicion: 'crear' | 'editar' = 'crear';
  itemSeleccionado: PersonaCorreoDto | null = null;

  ngOnInit(): void {
    this.personaService.getAll().subscribe({
      next: (data) => {
        this.personas.set(data);
        const firstId = data?.[0]?.id ?? null;
        this.selectedPersonaId.set(firstId);
        if (firstId) this.cargarCorreos(firstId);
      },
    });
  }

  onPersonaChange(value: string): void {
    const id = value ? Number(value) : null;
    this.selectedPersonaId.set(id);
    if (id) this.cargarCorreos(id);
    else this.correos.set([]);
  }

  cargarCorreos(personaId: number): void {
    this.correoService.getAll(personaId).subscribe({
      next: (data) => this.correos.set(data),
      error: () => this.correos.set([]),
    });
  }

  abrirAgregar(): void {
    this.modoEdicion = 'crear';
    this.itemSeleccionado = null;
    this.mostrarModal = true;
  }

  abrirEditar(item: PersonaCorreoDto): void {
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
    if (pid) this.cargarCorreos(pid);
  }

  eliminar(item: PersonaCorreoDto): void {
    const confirmado = window.confirm(`¿Eliminar el correo "${item.correo}"?`);
    if (!confirmado) return;

    this.correoService.delete(item.id).subscribe({
      next: () => {
        const pid = this.selectedPersonaId();
        if (pid) this.cargarCorreos(pid);
      },
    });
  }
}

