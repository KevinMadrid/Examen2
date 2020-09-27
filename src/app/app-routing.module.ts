import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CiudadanosComponent } from './features/ciudadanos/ciudadanos.component';
import { CiudadesComponent } from './features/ciudades/ciudades.component';
import { CrearCiudadComponent } from './features/crear-ciudad/crear-ciudad.component';
import { CrearCiudadanoComponent } from './features/crear-ciudadano/crear-ciudadano.component';
import { EditarCiudadComponent } from './features/editar-ciudad/editar-ciudad.component';
import { EditarCiudadanoComponent } from './features/editar-ciudadano/editar-ciudadano.component';
import { InicioComponent } from './features/inicio/inicio.component';
import { PaginaNoSeEncuentraComponent } from './features/pagina-no-se-encuentra/pagina-no-se-encuentra.component';

const routes: Routes = [
{ path :'ciudadanos',component:CiudadanosComponent},
{ path: 'ciudadanos/crear', component:CrearCiudadanoComponent },
{ path: 'ciudadanos/editar/:id', component:EditarCiudadanoComponent},
{ path: 'ciudades', component:CiudadesComponent},
{ path: 'ciudades/crear', component:CrearCiudadanoComponent },
{ path: 'ciudades/editar/:id', component:EditarCiudadanoComponent},
{ path:'',component:InicioComponent  },
{path :'**', component:PaginaNoSeEncuentraComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
