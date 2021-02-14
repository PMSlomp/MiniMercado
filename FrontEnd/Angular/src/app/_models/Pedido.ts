import { Cliente } from './Cliente';
import { Produto } from './Produto';

export interface Pedido {
    id: number;
    data: Date;
    clienteId: number;
    preco: number;
    desconto: number;
    pedidoProdutos: Produto[];
}
