import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Pedido } from '../models/pedido';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {

  public modalRef!: BsModalRef;
  public pedidoForm!: FormGroup;
  public titulo = 'Pedidos';
  public pedidoSelecionado!: Pedido;
  public textoTemp!: string;

  pedidos = [
    {id: 1, cliente:'Pedro', data: '', valor: 1, desconto: 1, valorFinal: 0},
    {id: 2, cliente: 'João', data: '', valor: 2, desconto: 1, valorFinal: 0},
    {id: 3, cliente:'Paula', data: '', valor: 3, desconto: 1, valorFinal: 0},
  ]
  
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder, 
              private modalService: BsModalService) { 
    this.criarForm();
  }

  ngOnInit(): void {
  }

  criarForm() {
    this.pedidoForm = this.fb.group({
      cliente:['', Validators.required],
      data: ['', Validators.required],
      valor: ['', Validators.required],
      desconto: ['', Validators.required],
      valorFinal: ['',]
    });
  }

  pedidoSubmit() {
    console.log(this.pedidoForm.value)
  }

  pedidoSelect(pedido: Pedido) {
    this.pedidoSelecionado = pedido;
    this.pedidoForm.patchValue(pedido);
  }

  voltar() {
    this.pedidoSelecionado = null;
  }
}
