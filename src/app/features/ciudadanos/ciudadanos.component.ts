import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {CiudadanosService} from 'src/app/services/ciudadanos.service';
import {Ciudadano} from 'src/app/models/ciudadano';

@Component({
  selector: 'app-ciudadanos',
  templateUrl: './ciudadanos.component.html',
  styleUrls: ['./ciudadanos.component.css']
})
export class CiudadanosComponent implements OnInit {
  ciudadanos: Ciudadano[];

  constructor(private _ciudadanosService: CiudadanosService, private router: Router) { }

  ngOnInit() 
  {
    this.obtenerCiudadanos();
  }
 
  obtenerCiudadanos()
  {
    this._ciudadanosService.obtenerCiudadanos().subscribe(data => 
      {this.ciudadanos=data;
    });
  }
  crearCiudadano()
  {
    this.router.navigate(['/ciudadanos/crear'])
  }
  editarCiudadano(id:Number)
  {
    this.router.navigate(['/ciudadanos/editar', id])
  }
  eliminarCiudadano(id: Number)
  {
    const res = confirm("Desea eliminar el ciudadano?");
    if(res){
      this._ciudadanosService.eliminarCiudadano(id).subscribe(() => {
        this.obtenerCiudadanos();
      })
    }
  }

}
