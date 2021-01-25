using System.Collections.Generic;

namespace _NetWebApi.Models
{
    public class Pedido {

        public Pedido() {}

        public Pedido(int id, int clienteId, string data,
                      double desconto) {
            this.id = id;
            this.clienteId = clienteId;
            this.data = data;
            this.desconto = desconto;
        }

        public int id { get; set; }
        public int clienteId { get; set; }
        public Cliente cliente { get; set; }
        public IEnumerable<Item> Itens { get; set; }
        public string data { get; set; }
        public double valor { get; set; }
        public double desconto { get; set; }
        public double valorFinal { get; set; }
    }
}