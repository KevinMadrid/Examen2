import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CiudadanosComponent } from './features/ciudadanos/ciudadanos.component';
import { CiudadesComponent } from './features/ciudades/ciudades.component';
import { InicioComponent } from './features/inicio/inicio.component';
import { PaginaNoSeEncuentraComponent } from './features/pagina-no-se-encuentra/pagina-no-se-encuentra.component';
import { NavegacionComponent } from './features/navegacion/navegacion.component';
import { CrearCiudadanoComponent } from './features/crear-ciudadano/crear-ciudadano.component';
import { EditarCiudadanoComponent } from './features/editar-ciudadano/editar-ciudadano.component';
import { CrearCiudadComponent } from './features/crear-ciudad/crear-ciudad.component';
import { EditarCiudadComponent } from './features/editar-ciudad/editar-ciudad.component';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    CiudadanosComponent,
    CiudadesComponent,
    InicioComponent,
    PaginaNoSeEncuentraComponent,
    NavegacionComponent,
    CrearCiudadanoComponent,
    EditarCiudadanoComponent,
    CrearCiudadComponent,
    EditarCiudadComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
