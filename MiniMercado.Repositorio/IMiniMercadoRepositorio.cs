using System.Threading.Tasks;
using MiniMercado.Dominio;

namespace MiniMercado.Repositorio
{
    public interface IMiniMercadoRepositorio
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Pedidos
        Task<Pedido[]> GetAllPedidosAsyncByCliente(string cliente, bool includeProdutos);
        Task<Pedido[]> GetAllPedidosAsync(bool includeProdutos);
        Task<Pedido> GetPedidoAsyncById(int PedidoId, bool includeProdutos);

        //Clientes
        Task<Cliente[]> GetAllClientesAsyncByName(string clienteNome, bool includePedidos);
        Task<Cliente[]> GetAllClientesAsync(bool includePedidos);
        Task<Cliente> GetClienteAsyncById(int ClienteId, bool includePedidos);

        //Produtos
        Task<Produto[]> GetAllProdutosAsyncByName(string produtoNome);
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto> GetProdutoAsyncById(int ProdutoId);
    }
}