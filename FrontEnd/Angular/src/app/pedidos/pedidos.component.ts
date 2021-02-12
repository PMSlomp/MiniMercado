import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Pedido } from '../_models/Pedido';
import { PedidoService } from '../_services/pedido.service';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {
  
  pedidos: Pedido[] = [];
  _filtro!: string;
  pedidosFiltrados: Pedido[] = [];
  modalRef!: BsModalRef;

  constructor(
      private pedidoService: PedidoService,
      private modalService: BsModalService
    ) { }

  ngOnInit() {
    this.getPedidos();
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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

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
