import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Ciudadano} from '../models/ciudadano';

@Injectable({
  providedIn: 'root'
})
export class CiudadanosService {
  apiURL='https://localhost:44332/api/ciudadano';

  constructor(private http: HttpClient) { }
  obtenerCiudadano(id:Number)
  {
    return this.http.get<Ciudadano>(this.apiURL + '/' +id);
  }
  obtenerCiudadanos()
    {
      return this.http.get<Ciudadano[]>(this.apiURL);
    }
    crearCiudadano(ciudadano: Ciudadano)
    {
      return this.http.post<Ciudadano>(this.apiURL, ciudadano);
    }
    editarCiudadano(ciudadano: Ciudadano)
    {
      return this.http.put<Ciudadano>(this.apiURL + '/' + ciudadano.id, ciudadano);
    }
    eliminarCiudadano(id: Number)
    {
      return this.http.delete(this.apiURL + "/" + id);
    }
}
