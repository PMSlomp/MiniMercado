import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cliente } from 'src/app/_models/Cliente';
import { ClienteService } from '../_services/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent implements OnInit {

  clientes: Cliente[] = [];
  cliente!: Cliente;
  novoCliente!: Cliente;
  clientesFiltrados: Cliente[] = [];
  registerForm!: FormGroup;
  modo!: string;
  bodyDeletarCliente = '';

  constructor(
    private clienteService: ClienteService,
    private modalService: BsModalService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.getClientes();
    this.registerForm = this.formBuilder.group({
      nome: ['',
        [Validators.required, Validators.minLength(3)]],
      email: ['',
        [Validators.required, Validators.email]],
    })
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  salvarAlteracao(template: any) {
    if(this.registerForm.valid){
      if(this.modo === "post") {
        this.cliente = Object.assign({}, this.registerForm.value);
        this.clienteService.postCliente(this.cliente).subscribe(
          (novoCliente) => {
            console.log(novoCliente);
            template.hide();
            this.getClientes();
          }, error => {console.log(error)}
        );
      } else {
        this.cliente = Object.assign({id: this.cliente.id}, this.registerForm.value);
        console.log(this.cliente);
        this.clienteService.putCliente(this.cliente).subscribe(
          (novoCliente) => {
            console.log(novoCliente);
            template.hide();
            this.getClientes();
          }, error => {console.log(error)}
        );
      }
    
    }
  }

  editar(cliente: Cliente, template: any) {
    this.modo = "put";
    this.openModal(template);
    this.cliente = cliente;
    this.registerForm.patchValue(cliente);
  }

  novo(template: any) {
    this.modo = "post";
    this.openModal(template);
  }

  excluir(cliente: Cliente, template: any) {
    this.openModal(template);
    this.cliente = cliente;
    this.bodyDeletarCliente = `Tem certeza que deseja excluir o cliente: ${cliente.nome}`;
  }
  
  confirmeDelete(template: any) {
    this.clienteService.deleteCliente(this.cliente.id).subscribe(
      () => {
          template.hide();
          this.getClientes();
        }, error => {
          console.log(error);
        }
    );
  }

  get f() { return this.registerForm.controls; }

  getClientes() {
    this.clienteService.getAllCliente().subscribe(
      (_clientes: Cliente[]) => {
        this.clientes = _clientes;
        this.clientesFiltrados = this.clientes;
        console.log(_clientes);
      }, error => {
        console.log("error")
      }
    );
  }

}
