import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CiudadesService } from 'src/app/services/ciudades.service';
import { Ciudad } from 'src/app/models/ciudad';
import { Ciudadano } from 'src/app/models/ciudadano';
import { CiudadanosService } from 'src/app/services/ciudadanos.service';

@Component({
  selector: 'app-crear-ciudadano',
  templateUrl: './crear-ciudadano.component.html',
  styleUrls: ['./crear-ciudadano.component.css']
})
export class CrearCiudadanoComponent implements OnInit {
  ciudades: Ciudad[];
  ciudadano: Ciudadano;

  constructor(private _ciudadesService: CiudadesService, 
    private _ciudadanosService:CiudadanosService,
    private router: Router) { 
      this.ciudadano = new Ciudadano();
    }

  ngOnInit(): void {
    
    this._ciudadesService.obtenerCiudades().subscribe(res =>{
      this.ciudades = res;
  })
}
  crearCiudadano()
  {
    if(this.ciudadano)
    {
      this._ciudadanosService.crearCiudadano(this.ciudadano).subscribe(() =>{
        this.router.navigate(['/ciudadanos'])
      })
    }
  }
  cancelar()
  {
    this.router.navigate(['/ciudadanos'])
  }

}
