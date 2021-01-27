import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Produto } from '../models/produto';
import { ProdutoService } from './produto.service';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  public produtoForm!: FormGroup;
  public titulo = "Produtos";
  public produtoSelecionado!: Produto;
  public modo = 'post';
  public produtos!: Produto[];

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private produtoService: ProdutoService) { 
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarProdutos();
  }

  carregarProdutos() {
    this.produtoService.getAll().subscribe(
      (produtos: Produto[]) => {
        this.produtos = produtos;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  criarForm() {
    this.produtoForm = this.fb.group({
      id: [''],
      nome:['', Validators.required],
      preco: ['', Validators.required]
    });
  }

  produtoSubmit() {
    this.salvarProduto(this.produtoForm.value);
  }

  salvarProduto(produto: Produto) {
    (produto.id != 0) ? this.modo = 'put' : this.modo = "post";
    this.produtoService[this.modo](produto).subscribe(
      (model: Produto) => {
        console.log(model);
        this.carregarProdutos();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  produtoSelect(produto: Produto) {
    this.produtoSelecionado = produto;
    this.produtoForm.patchValue(produto);
  }

  produtoCadastro() {
    this.produtoSelecionado = new Produto;
    this.produtoForm.patchValue(this.produtoSelecionado);
  }

  voltar() {
    this.produtoSelecionado = null;
  }

  deletar(id: number) {
    this.produtoService.delete(id).subscribe(
      (model) => {
        console.log(model);
        this.carregarProdutos();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

}
