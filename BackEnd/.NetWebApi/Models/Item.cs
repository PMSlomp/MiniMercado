namespace _NetWebApi.Models
{
    public class Item {
        public Item() {}

        public Item(int id, int pedidoId, int produtoId, double valorUni,
                    int quantidade, double desconto) {
            
            this.id = id;
            this.pedidoId = pedidoId;
            this.produtoId = produtoId;
            this.valorUni = valorUni;
            this.quantidade = quantidade;
            this.desconto = desconto;
            
            this.valor = quantidade * valorUni;
            this.valorFinal = valor - desconto;
        }
        public int id { get; set; }
        public int pedidoId { get; set; }
        public Pedido pedido { get; set; }
        public int produtoId { get; set; }
        public Produto produto { get; set; }
        public double valorUni { get; set; }
        public int quantidade { get; set; }
        public double valor  { get; set; }
        public double desconto { get; set; }
        public double valorFinal { get; set; }

    }
}