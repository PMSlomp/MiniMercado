using System.Collections.Generic;

namespace MiniMercado.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
        public List<PedidoProduto> PedidoProdutos { get; set; }
        
    }
}