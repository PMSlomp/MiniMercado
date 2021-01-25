import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Produto } from '../models/produto';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  public produtoForm!: FormGroup;
  public titulo = "Produtos";
  public produtoSelecionado!: Produto;

  produtos = [
    {id: 1, nome: "leite"   , preco: 1.1},
    {id: 2, nome: "limão"   , preco: 2.1},
    {id: 3, nome: "macarrão", preco: 4.1}
  ]

  constructor(private fb: FormBuilder) { 
    this.criarForm();
  }

  ngOnInit(): void {
  }

  criarForm() {
    this.produtoForm = this.fb.group({
      nome:['', Validators.required],
      preco: ['', Validators.required]
    });
  }

  produtoSubmit() {
    console.log(this.produtoForm.value)
  }

  produtoSelect(produto: Produto) {
    this.produtoSelecionado = produto;
    this.produtoForm.patchValue(produto);
  }

  voltar() {
    this.produtoSelecionado = null;
  }

  

}
