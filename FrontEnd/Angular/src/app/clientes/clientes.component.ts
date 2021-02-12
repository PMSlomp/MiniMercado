import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/_models/Cliente';
import { ClienteService } from '../_services/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent implements OnInit {

  clientes: Cliente[] = [];
  clientesFiltrados: Cliente[] = [];

  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
    this.getClientes();
  }

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
