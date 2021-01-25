using System.Threading.Tasks;
using _NetWebApi.Models;

namespace _NetWebApi.Data
{
    public interface IRepository {

         //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<Cliente[]> GetAllClientesAsync();        
        Task<Cliente> GetClienteAsyncById(int clienteId);
        
        //PRODUTO
        Task<Produto[]> GetAllProdutosAsync();        
        Task<Produto> GetProdutoAsyncById(int produtoId);

        //PEDIDO
        Task<Pedido[]> GetAllPedidosAsync(bool inclueProduto);
        Task<Pedido> GetPedidoAsyncById(int pedidoId, bool includeProduto);
    }
}