import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Produto } from './models/produto';
import { ProdutoService } from './services/produto.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  produtos: Produto[] = [];
  produtoAtual: Produto = { id: 0, nome: '', preco: 0 };
  editando = false;
  mensagem = '';
  erro = '';

  constructor(private produtoService: ProdutoService) {}

  ngOnInit(): void {
    this.carregarProdutos();
  }

  carregarProdutos(): void {
    this.produtoService.obterTodos().subscribe({
      next: (produtos: Produto[]) => {
        this.produtos = produtos;
      },
      error: () => {
        this.erro = 'Não foi possível carregar os produtos.';
      }
    });
  }

  salvar(): void {
    this.mensagem = '';
    this.erro = '';

    if (this.editando) {
      this.produtoService.atualizar(this.produtoAtual).subscribe({
        next: () => {
          this.mensagem = 'Produto atualizado.';
          this.limparFormulario();
          this.carregarProdutos();
        },
        error: () => {
          this.erro = 'Não foi possível atualizar o produto.';
        }
      });
      return;
    }

    this.produtoService.adicionar(this.produtoAtual).subscribe({
      next: () => {
        this.mensagem = 'Produto cadastrado.';
        this.limparFormulario();
        this.carregarProdutos();
      },
      error: (erro) => {
        this.erro = erro.status === 409
          ? 'Já existe um produto com esse nome.'
          : 'Não foi possível cadastrar o produto.';
      }
    });
  }

  editar(produto: Produto): void {
    this.produtoAtual = { ...produto };
    this.editando = true;
    this.mensagem = '';
    this.erro = '';
  }

  excluir(produto: Produto): void {
    if (!confirm(`Deseja excluir "${produto.nome}"?`)) {
      return;
    }

    this.produtoService.remover(produto.id).subscribe({
      next: () => {
        this.mensagem = 'Produto excluído.';
        this.carregarProdutos();
      },
      error: () => {
        this.erro = 'Não foi possível excluir o produto.';
      }
    });
  }

  cancelarEdicao(): void {
    this.limparFormulario();
  }

  private limparFormulario(): void {
    this.produtoAtual = { id: 0, nome: '', preco: 0 };
    this.editando = false;
  }
}