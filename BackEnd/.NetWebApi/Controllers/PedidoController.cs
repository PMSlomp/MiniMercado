using Microsoft.AspNetCore.Mvc;
using _NetWebApi.Data;
using System.Threading.Tasks;
using System;
using _NetWebApi.Models;

namespace _NetWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase {

        private readonly IRepository _repo;
        public PedidoController(IRepository repo) {
            _repo = repo;
        }

        [HttpGet()]
        public async Task<IActionResult> Get() {

            try {
                var result = await _repo.GetAllPedidosAsync(true);
                return Ok(result);

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{pedidoId}")]
        public async Task<IActionResult> GetByPedidoId(int pedidoId) {

            try {
                var result = await _repo.GetPedidoAsyncById(pedidoId, false);
                return Ok(result);

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> post(Pedido model) {

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

        [HttpPut("{pedidoId}")]
        public async Task<IActionResult> put(int pedidoId, Pedido model) {

            try {
                var pedido = await _repo.GetPedidoAsyncById(pedidoId, false);
                if(pedido == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()) {
                    return Ok(model);
                }

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Não esperado");
        }

        [HttpDelete("{pedidoId}")]
        public async Task<IActionResult> delete(int pedidoId) {

            try {
                var pedido = await _repo.GetPedidoAsyncById(pedidoId, false);
                if(pedido == null) return NotFound();

                _repo.Delete(pedido);
                
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