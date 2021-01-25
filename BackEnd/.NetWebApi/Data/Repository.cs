using System.Threading.Tasks;
using _NetWebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _NetWebApi.Data
{
    public class Repository : IRepository {

        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //CLIENTE
        public async Task<Cliente> GetClienteAsyncById(int clienteId)
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.AsNoTracking()
                         .OrderBy(cliente => cliente.id)
                         .Where(cliente => cliente.id == clienteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente[]> GetAllClientesAsync()
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }

        //PRODUTO
        public async Task<Produto> GetProdutoAsyncById(int produtoId)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking()
                         .OrderBy(produto => produto.id)
                         .Where(produto => produto.id == produtoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos;
        
            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }

        //PEDIDO 
        public async Task<Pedido[]> GetAllPedidosAsync(bool includeItens = true)
        {
            IQueryable<Pedido> query = _context.Pedidos;

            if (includeItens)
            {
                query = query.Include(c => c.Itens);
            }

            query = query.AsNoTracking()
                         .OrderBy(pedido => pedido.id);

            return await query.ToArrayAsync();
        }
        public async Task<Pedido> GetPedidoAsyncById(int pedidoId, bool includeItens = true)
        {
            IQueryable<Pedido> query = _context.Pedidos;

            if (includeItens)
            {
                query = query.Include(pe => pe.Itens);
            }

            query = query.AsNoTracking()
                         .OrderBy(pedido => pedido.id)
                         .Where(pedido => pedido.id == pedidoId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Pedido[]> GetPedidosAsyncByProdutoId(int produtoId, bool includeItem){
            IQueryable<Pedido> query = _context.Pedidos;

            if (includeItem)
            {
                query = query.Include(p => p.Itens);
            }

            query = query.AsNoTracking()
                         .OrderBy(produto => produto.id);

            return await query.ToArrayAsync();
        }
        
        
    }
}