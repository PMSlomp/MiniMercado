import { Pedido } from './Pedido';

export interface Produto {
    id: number;
    nome: string;
    imagemUrl: string;
    quantidade: number;
    preco: number;
    desconto: number;
    pedidoProdutos: Pedido[];

}
