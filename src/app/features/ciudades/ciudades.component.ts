import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { Ciudad } from 'src/app/models/ciudad';
import {CiudadesService} from 'src/app/services/ciudades.service';

@Component({
  selector: 'app-ciudades',
  templateUrl: './ciudades.component.html',
  styleUrls: ['./ciudades.component.css']
})
export class CiudadesComponent implements OnInit {
  ciudades: Ciudad[];

  constructor(private _ciudadanosService: CiudadesService) { }

  ngOnInit() 
  {
    this.obtenerCiudades();
  }
 
  obtenerCiudades()
  {
    this._ciudadanosService.obtenerCiudades().subscribe(data => 
      {this.ciudades=data;
    });
  }
}
