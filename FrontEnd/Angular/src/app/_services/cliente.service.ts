import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../_models/Cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  baseUrl = 'http://localhost:5000/cliente';

  constructor(private http: HttpClient) { }

  getAllCliente(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl);
  }

  getClienteId(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.baseUrl}/${id}`);
  }

  postCliente(cliente: Cliente) {
    return this.http.post(`${this.baseUrl}`, cliente);
  }

  putCliente(cliente: Cliente) {
    return this.http.put(`${this.baseUrl}/${cliente.id}`, cliente);
  }

  deleteCliente(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}