import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cliente } from '../models/cliente';

@Injectable({
    providedIn: 'root'  
})
export class ClienteService {
    
    url = `${environment.UrlP}/api/cliente`;

    constructor(private http: HttpClient) {    }

    getAll(): Observable<Cliente[]> {
        return this.http.get<Cliente[]>(`${this.url}`);
    }

    getById(id: number): Observable<Cliente> {
        return this.http.get<Cliente>(`${this.url}/${id}`);
    }

    post(cliente: Cliente) {
        return this.http.post(`${this.url}`, cliente)
    }

    put(cliente: Cliente) {
        return this.http.put(`${this.url}/${cliente.id}`, cliente)
    }

    delete(id: number) {
        return this.http.delete(`${this.url}/${id}`);
    }
}