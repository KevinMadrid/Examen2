import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Ciudad } from '../models/ciudad';

@Injectable({
  providedIn: 'root'
})
export class CiudadesService {
  apiURL='https://localhost:44332/api/ciudad';

  constructor(private http: HttpClient) { }
  obtenerCiudades()
{
  return this.http.get<Ciudad[]>(this.apiURL);
}
}
