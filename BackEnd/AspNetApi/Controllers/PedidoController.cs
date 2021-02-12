using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMercado.Dominio;
using MiniMercado.Repositorio;

namespace BackEnd.AspNetApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMiniMercadoRepositorio _repo;

        public PedidoController(IMiniMercadoRepositorio repo)
        {
            _repo = repo;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult> Get()
        {   
            try 
            {
                var resultados = await _repo.GetAllPedidosAsync(true);
                
                return Ok(resultados);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
            
        }
        [HttpGet("{PedidoId}")]
        public async Task<ActionResult> Get(int PedidoId)
        {   
            try 
            {
                var resultados = await _repo.GetPedidoAsyncById(PedidoId, true);
                
                return Ok(resultados);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
            
        }
        [HttpGet("getbyCliente/{cliente}")]
        public async Task<ActionResult> Get(string cliente)
        {   
            try 
            {
                var resultados = await _repo.GetAllPedidosAsyncByCliente(cliente, true);
                
                return Ok(resultados);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
            
        }

        //POST
        [HttpPost]
        public async Task<ActionResult> Post(Pedido model)
        {   
            try 
            {
                _repo.Add(model);
                
                if(await _repo.SaveChangesAsync()) {

                    return Created($"/pedido/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }

            return BadRequest();
            
        }

        //PUT
        [HttpPut]
        public async Task<ActionResult> Put(int pedidoId, Pedido model)
        {   
            try 
            {   
                var pedido = await _repo.GetPedidoAsyncById(pedidoId, false);
                if(pedido == null) return NotFound();

                _repo.Update(model);
                
                if(await _repo.SaveChangesAsync()) {

                    return Created($"/pedido/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }

            return BadRequest();
            
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int pedidoId)
        {   
            try 
            {
                var pedido = await _repo.GetPedidoAsyncById(pedidoId, false);
                if(pedido == null) return NotFound();

                _repo.Delete(pedido);
                
                if(await _repo.SaveChangesAsync()) {

                    return Ok();
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }

            return BadRequest();
            
        }
    }
}