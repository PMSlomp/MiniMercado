using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMercado.Dominio;
using MiniMercado.Repositorio;

namespace BackEnd.AspNetApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMiniMercadoRepositorio _repo;

        public ClienteController(IMiniMercadoRepositorio repo)
        {
            _repo = repo;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult> Get()
        {   
            try 
            {
                var resultados = await _repo.GetAllClientesAsync(true);
                
                return Ok(resultados);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
            
        }
        [HttpGet("{ClienteId}")]
        public async Task<ActionResult> Get(int ClienteId)
        {   
            try 
            {
                var resultados = await _repo.GetClienteAsyncById(ClienteId, true);
                
                return Ok(resultados);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
            
        }
        [HttpGet("getbyName/{nome}")]
        public async Task<ActionResult> Get(string nome)
        {   
            try 
            {
                var resultados = await _repo.GetAllClientesAsyncByName(nome, true);
                
                return Ok(resultados);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
            
        }

        //POST
        [HttpPost]
        public async Task<ActionResult> Post(Cliente model)
        {   
            try 
            {
                _repo.Add(model);
                
                if(await _repo.SaveChangesAsync()) {

                    return Created($"/cliente/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }

            return BadRequest("");
            
        }

        //PUT
        [HttpPut]
        public async Task<ActionResult> Put(int clienteId, Cliente model)
        {   
            try 
            {   
                var cliente = await _repo.GetClienteAsyncById(clienteId, false);
                if(cliente == null) return NotFound();

                _repo.Update(model);
                
                if(await _repo.SaveChangesAsync()) {

                    return Created($"/cliente/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }

            return BadRequest();
            
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int clienteId)
        {   
            try 
            {
                var cliente = await _repo.GetClienteAsyncById(clienteId, false);
                if(cliente == null) return NotFound();

                _repo.Delete(cliente);
                
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