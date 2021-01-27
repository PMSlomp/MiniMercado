import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Pedido } from '../models/pedido';

@Injectable({
    providedIn: 'root'  
})
export class PedidoService {
    
    url = `${environment.UrlP}/api/pedido`;

    constructor(private http: HttpClient) {    }

    getAll(): Observable<Pedido[]> {
        return this.http.get<Pedido[]>(`${this.url}`);
    }

    getById(id: number): Observable<Pedido> {
        return this.http.get<Pedido>(`${this.url}/${id}`);
    }

    post(pedido: Pedido) {
        return this.http.put(`${this.url}`, pedido)
    }

    put(id: number, pedido: Pedido) {
        return this.http.put(`${this.url}/${id}`, pedido)
    }

    delete(id: number) {
        return this.http.delete(`${this.url}/${id}`);
    }
}