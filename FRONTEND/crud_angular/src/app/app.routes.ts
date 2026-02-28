import { Routes } from '@angular/router';
import { MantenimientoPersonaListComponent } from './pages/mantenimiento/mantenimiento-persona-list/mantenimiento-persona-list.component';
import { AppShellComponent } from './layout/app-shell/app-shell.component';
import { MantenimientoPersonaCorreoListComponent } from './pages/mantenimiento/mantenimiento-persona-correo-list/mantenimiento-persona-correo-list.component';
import { MantenimientoPersonaDireccionListComponent } from './pages/mantenimiento/mantenimiento-persona-direccion-list/mantenimiento-persona-direccion-list.component';
import { MantenimientoPersonaEmpleoListComponent } from './pages/mantenimiento/mantenimiento-persona-empleo-list/mantenimiento-persona-empleo-list.component';

export const routes: Routes = [

  {
    path: '',
    component: AppShellComponent,
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'personas' },
      { path: 'personas', component: MantenimientoPersonaListComponent },
      { path: 'correos', component: MantenimientoPersonaCorreoListComponent },
      { path: 'direcciones', component: MantenimientoPersonaDireccionListComponent },
      { path: 'empleos', component: MantenimientoPersonaEmpleoListComponent },
    ],
  },
  { path: '**', redirectTo: '' },

];
