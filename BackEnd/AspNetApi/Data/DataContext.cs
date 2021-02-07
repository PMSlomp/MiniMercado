using Microsoft.EntityFrameworkCore;
using BackEnd.AspNetApi.Model;

namespace BackEnd.AspNetApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Pedido> Pedidos {get; set;}
    }
}