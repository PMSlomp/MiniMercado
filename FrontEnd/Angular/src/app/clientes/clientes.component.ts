import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { runInThisContext } from 'vm';
import { Cliente } from '../models/cliente';
import { ClienteService } from './cliente.service';

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
  public modo = 'post';
  public clientes!: Cliente[];

  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private clienteService: ClienteService) { 
    this.criarForm();
  }

  ngOnInit() {
    this.carregarClientes();
  }

  carregarClientes() {
    this.clienteService.getAll().subscribe(
      (clientes: Cliente[]) => {
        this.clientes = clientes;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  criarForm() {
    this.clienteForm = this.fb.group({
      id: [''],
      nome:['', Validators.required],
      mail: ['', Validators.required]
    });
  }

  clienteSubmit() {
    this.salvarCliente(this.clienteForm.value);
  }

  salvarCliente(cliente: Cliente) {
    (cliente.id != 0) ? this.modo = 'put' : this.modo = "post";
    this.clienteService[this.modo](cliente).subscribe(
      (model: Cliente) => {
        console.log(model);
        this.carregarClientes();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  clienteSelect(cliente: Cliente) {
    this.clienteSelecionado = cliente;
    this.clienteForm.patchValue(cliente);
  }

  clienteCadastro() {
    this.clienteSelecionado = new Cliente;
    this.clienteForm.patchValue(this.clienteSelecionado);
  }

  voltar() {
    this.clienteSelecionado = null;
  }
  
  deletar(id: number) {
    this.clienteService.delete(id).subscribe(
      (model) => {
        console.log('deletado');
        this.carregarClientes();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }
}
