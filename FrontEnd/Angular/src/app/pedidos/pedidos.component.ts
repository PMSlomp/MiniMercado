import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Pedido } from '../models/pedido';
import { PedidoService } from './pedido.service';

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

  public pedidos!: Pedido[]
  
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder, 
              private modalService: BsModalService,
              private pedidoService: PedidoService) { 
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarPedidos();
  }

  carregarPedidos() {
    this.pedidoService.getAll().subscribe(
      (pedidos: Pedido[]) => {
        this.pedidos = pedidos;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  criarForm() {
    this.pedidoForm = this.fb.group({
      id: [''],
      cliente:['', Validators.required],
      data: ['', Validators.required],
      valor: ['', Validators.required],
      desconto: ['', Validators.required],
      valorFinal: ['',]
    });
  }

  pedidoSubmit() {
    this.salvarPedido(this.pedidoForm.value);
  }

  salvarPedido(pedido: Pedido) {
    this.pedidoService.put(pedido.id, pedido).subscribe(
      (model: Pedido) => {
        console.log(model);
        this.carregarPedidos();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  pedidoSelect(pedido: Pedido) {
    this.pedidoSelecionado = pedido;
    this.pedidoForm.patchValue(pedido);
  }

  voltar() {
    this.pedidoSelecionado = null;
  }
}
