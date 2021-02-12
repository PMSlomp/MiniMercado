using System.Collections.Generic;

namespace MiniMercado.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Pedido> Pedidos { get; set; }

    }
}