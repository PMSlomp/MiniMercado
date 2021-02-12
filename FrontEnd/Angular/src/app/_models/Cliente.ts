import { Pedido } from './Pedido';

export interface Cliente {

    id: number;
    nome: string;
    email: string;
    pedidos: Pedido;

}
