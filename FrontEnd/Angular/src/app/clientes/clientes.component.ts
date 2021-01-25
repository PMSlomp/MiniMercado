import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { runInThisContext } from 'vm';
import { Cliente } from '../models/cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  public clienteForm!: FormGroup;
  public titulo = 'Cliente';
  public clienteSelecionado!: Cliente;
  public textoTemp!: string;

  clientes = [
    {id: 1, nome:'Pedro', mail: 'jjj@jjjj'},
    {id: 2, nome: 'João', mail: 'aaa@jjjj'},
    {id: 3, nome:'Paula', mail: 'bbb@jjjj'},
  ]

  constructor(private fb: FormBuilder) { 
    this.criarForm();
  }

  ngOnInit(): void {
  }

  criarForm() {
    this.clienteForm = this.fb.group({
      nome:['', Validators.required],
      mail: ['', Validators.required]
    });
  }

  clienteSubmit() {
    console.log(this.clienteForm.value)
  }

  clienteSelect(cliente: Cliente) {
    this.clienteSelecionado = cliente;
    this.clienteForm.patchValue(cliente);
  }

  voltar() {
    this.clienteSelecionado = null;
  }
  
}
