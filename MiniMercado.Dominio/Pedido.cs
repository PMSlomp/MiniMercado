using System;
using System.Collections.Generic;

namespace MiniMercado.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
        public List<PedidoProduto> PedidoProdutos { get; set; }
        
    }
}