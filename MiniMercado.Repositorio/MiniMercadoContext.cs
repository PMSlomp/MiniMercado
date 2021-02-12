using Microsoft.EntityFrameworkCore;
using MiniMercado.Dominio;

namespace MiniMercado.Repositorio
{
    public class MiniMercadoContext : DbContext
    {
        public MiniMercadoContext(DbContextOptions<MiniMercadoContext> options) : base (options) {}

        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<PedidoProduto> PedidoProdutos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoProduto>()
                .HasKey(PP => new {PP.PedidoId, PP.ProdutoId});
        }
    }
}