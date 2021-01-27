import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Produto } from '../models/produto';

@Injectable({
    providedIn: 'root'  
})
export class ProdutoService {
    
    url = `${environment.UrlP}/api/produto`;

    constructor(private http: HttpClient) {    }

    getAll(): Observable<Produto[]> {
        return this.http.get<Produto[]>(`${this.url}`);
    }

    getById(id: number): Observable<Produto> {
        return this.http.get<Produto>(`${this.url}/${id}`);
    }

    post(produto: Produto) {
        return this.http.post(`${this.url}`, produto)
    }

    put(produto: Produto) {
        return this.http.put(`${this.url}/${produto.id}`, produto)
    }

    delete(id: number) {
        return this.http.delete(`${this.url}/${id}`);
    }
}