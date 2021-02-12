import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pedido } from '../_models/Pedido';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  baseUrl = 'http://localhost:5000/pedido';

  constructor(private http: HttpClient) { }

  getAllPedido(): Observable<Pedido[]> {
    return this.http.get<Pedido[]>(this.baseUrl);
  }

  getPedidoId(id: number): Observable<Pedido> {
    return this.http.get<Pedido>(`${this.baseUrl}/${id}`);
  }

  getPedidoCliente(cliente: string): Observable<Pedido[]> {
    return this.http.get<Pedido[]>(`${this.baseUrl}/getbyCliente/${cliente}`);
  }
}
