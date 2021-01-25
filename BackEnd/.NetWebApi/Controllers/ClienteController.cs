using Microsoft.AspNetCore.Mvc;
using _NetWebApi.Data;
using System.Threading.Tasks;
using System;
using _NetWebApi.Models;

namespace _NetWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase {
        
        private readonly IRepository _repo;

        public ClienteController(IRepository repo) {
            _repo = repo;
        }

        [HttpGet()]
        public async Task<IActionResult> Get() {

            try {
                var result = await _repo.GetAllClientesAsync();
                return Ok(result);

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetByClienteId(int clienteId) {

            try {
                var result = await _repo.GetClienteAsyncById(clienteId);
                return Ok(result);

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> post(Cliente model) {

            try {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()) {
                    return Ok(model);
                }

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Não esperado");
        }

        [HttpPut("{clienteId}")]
        public async Task<IActionResult> put(int clienteId, Cliente model) {

            try {
                var cliente = await _repo.GetClienteAsyncById(clienteId);
                if(cliente == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()) {
                    return Ok(model);
                }

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Não esperado");
        }

        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> delete(int clienteId) {

            try {
                var cliente = await _repo.GetClienteAsyncById(clienteId);
                if(cliente == null) return NotFound();

                _repo.Delete(cliente);
                
                if(await _repo.SaveChangesAsync()) {
                    return Ok();
                }

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Não esperado");
        }
    }
}