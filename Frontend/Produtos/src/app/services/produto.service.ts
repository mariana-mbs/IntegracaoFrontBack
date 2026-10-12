import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../models/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  private apiUrl = 'http://localhost:5036/api/Produtos';

  constructor(private http: HttpClient) {}

  obterTodos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.apiUrl);
  }

  adicionar(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this.apiUrl, produto);
  }

  atualizar(produto: Produto): Observable<Produto> {
    return this.http.put<Produto>(
      `${this.apiUrl}/${produto.id}`,
      produto
    );
  }

  remover(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}