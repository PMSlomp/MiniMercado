import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Pedido } from '../_models/Pedido';
import { PedidoService } from '../_services/pedido.service';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ptBrLocale } from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {
  
  pedidos: Pedido[] = [];
  pedido!: Pedido;
  novoPedido!: Pedido;
  _filtro!: string;
  pedidosFiltrados: Pedido[] = [];
  registerForm!: FormGroup;
  bodyDeletarPedido = '';

  constructor(
      private pedidoService: PedidoService,
      private modalService: BsModalService,
      private formBuilder: FormBuilder,
      private localeService: BsLocaleService
    ) { 
      this.localeService.use('pt-br');
    }

  ngOnInit() {
    this.getPedidos();
    this.registerForm = this.formBuilder.group({
      data: ['', [Validators.required]],
      clienteId: ['', [Validators.required]],
      desconto: ['', [Validators.required]],
    })
  }

  //get filtro() {
  //  return this._filtro;
  //}
  //set filtro(value: string) {
  //  this._filtro = value;
  //  this.pedidosFiltrados = this._filtro ? this.filtrarPedidos(this.filtro) : this.pedidos;
  //}
//
  //filtrarPedidos(filtro: string): any {
//
  //  return this.pedidos.filter(
  //    pedido => pedido.data.indexOf(filtro) !== -1
  //  );
  //}

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  salvarAlteracao(template: any) {
    if(this.registerForm.valid){
      this.pedido = Object.assign({}, this.registerForm.value);
      this.pedidoService.postPedido(this.pedido).subscribe(
        (novoPedido) => {
          console.log(novoPedido);
          template.hide();
          this.getPedidos();
        }, error => {console.log(error)}
      );
    }
  }

  excluir(pedido: Pedido, template: any) {
    this.openModal(template);
    this.pedido = pedido;
    this.bodyDeletarPedido = `Tem certeza que deseja excluir o pedido da ${pedido.data} do cliente: `;
  }
  
  confirmeDelete(template: any) {
    this.pedidoService.deletePedido(this.pedido.id).subscribe(
      () => {
          template.hide();
          this.getPedidos();
        }, error => {
          console.log(error);
        }
    );
  }

  get f() { return this.registerForm.controls; }

  getPedidos() {
    this.pedidoService.getAllPedido().subscribe(
      (_pedidos: Pedido[]) => {
        this.pedidos = _pedidos;
        this.pedidosFiltrados = this.pedidos;
        console.log(_pedidos);
      }, error => {
        console.log("error")
      }
    );
  }

}
