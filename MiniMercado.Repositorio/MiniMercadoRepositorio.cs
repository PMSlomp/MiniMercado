using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniMercado.Dominio;

namespace MiniMercado.Repositorio
{
    public class MiniMercadoRepositorio : IMiniMercadoRepositorio
    {
        public MiniMercadoContext _context { get; }
        public MiniMercadoRepositorio(MiniMercadoContext _context) 
        {
            this._context = _context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
   
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

        //TASK CLIENTE
        public async Task<Cliente[]> GetAllClientesAsync(bool includePedidos = false)
        {
            IQueryable<Cliente> query = _context.Clientes;
                
            if(includePedidos)
            {   
                query = query
                .Include(pp => pp.Pedidos);
            }

            query = query.OrderBy(c => c.Nome);

            return await query.ToArrayAsync();
        }
        public async Task<Cliente[]> GetAllClientesAsyncByName(string clienteNome, bool includePedidos = false)
        {
            IQueryable<Cliente> query = _context.Clientes;
                
            if(includePedidos)
            {   
                query = query
                    .Include(pp => pp.Pedidos);
            }

            query = query.OrderBy(c => c.Nome)
                    .Where(c => c.Nome.ToLower().Contains(clienteNome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Cliente> GetClienteAsyncById(int clienteId, bool includePedidos = false)
        {
            IQueryable<Cliente> query = _context.Clientes;

            if(includePedidos)
            {   
                query = query
                .Include(pp => pp.Pedidos);
            }

            query = query.Where(c => c.Id == clienteId);

            return await query.FirstOrDefaultAsync();
        }

        //TASK PEDIDO
        public async Task<Pedido[]> GetAllPedidosAsync(bool includeProdutos = false)
        {
            IQueryable<Pedido> query = _context.Pedidos;
                //.Include(c => c.Cliente);
                
            if(includeProdutos)
            {   
                query = query
                    .Include(pp => pp.PedidoProdutos)
                    .ThenInclude(p => p.Produto);
            }

            query = query.OrderBy(c => c.Data);

            return await query.ToArrayAsync();
        }
        public async Task<Pedido[]> GetAllPedidosAsyncByCliente(string cliente, bool includeProdutos)
        {
            IQueryable<Pedido> query = _context.Pedidos
                .Include(c => c.Cliente)
                .Include(pp => pp.PedidoProdutos)
                .ThenInclude(p => p.Produto);

            query = query.OrderByDescending(c => c.Data)
                    .Where(c => c.Cliente.Nome.ToLower().Contains(cliente.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Pedido> GetPedidoAsyncById(int pedidoId, bool includeProdutos)
        {
            IQueryable<Pedido> query = _context.Pedidos
                .Include(c => c.Cliente)
                .Include(pp => pp.PedidoProdutos)
                .ThenInclude(p => p.Produto);

            query = query.Where(c => c.Id == pedidoId);

            return await query.FirstOrDefaultAsync();
        }

        //TASK PRODUTO
        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.OrderBy(c => c.Nome);

            return await query.ToArrayAsync();
        }
        public async Task<Produto[]> GetAllProdutosAsyncByName(string produtoNome)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.OrderBy(c => c.Nome)
                    .Where(c => c.Nome.ToLower().Contains(produtoNome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Produto> GetProdutoAsyncById(int produtoId)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.Where(c => c.Id == produtoId);

            return await query.FirstOrDefaultAsync();
        }
    
    }
}