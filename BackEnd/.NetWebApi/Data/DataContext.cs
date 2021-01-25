using Microsoft.EntityFrameworkCore;
using _NetWebApi.Models;
using System.Collections.Generic;

namespace _NetWebApi.Data
{
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
//            builder.Entity<Item>()
//                .HasKey(AD => new { AD.pedidoId, AD.produtoId });

//            builder.Entity<Pedido>()
//                .HasKey(AD => new { AD.clienteId});

            builder.Entity<Cliente>()
                .HasData(new List<Cliente>(){
                    new Cliente(1, "Lauro", "aaa@aa.com"),
                    new Cliente(2, "Roberto", "bbb@aa.com"),
                    new Cliente(3, "Ronaldo", "ccc@aa.com"),
                    new Cliente(4, "Rodrigo", "ddd@aa.com"),
                    new Cliente(5, "Alexandre", "eee@aa.com"),
                });
            
            builder.Entity<Produto>()   
                .HasData(new List<Produto>{
                    new Produto(1, "Macarrão", 1.10),
                    new Produto(2, "Feijão", 2.00),
                    new Produto(3, "Azeitona", 3.50),
                });

            builder.Entity<Pedido>()
                .HasData(new List<Pedido>{
                    new Pedido(1, 1, "01", 1.00),
                    new Pedido(2, 3, "04", 0.00),
                    new Pedido(3, 4, "14", 5.00),
                });
            
            builder.Entity<Item>()
                .HasData(new List<Item>(){
                    new Item(1, 1, 1, 1.10, 2, 0.0),
                    new Item(2, 1, 2, 2.00, 1, 0.5),
                    new Item(3, 1, 3, 3.50, 1, 1.0),
                    new Item(4, 2, 1, 1.1, 2, 0.0),
                    new Item(5, 2, 3, 3.50, 4, 1.0),
                    new Item(6, 3, 2, 2.00, 5, 2.0),
                });
        }
    }
}