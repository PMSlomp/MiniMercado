using Microsoft.AspNetCore.Mvc;
using _NetWebApi.Data;
using System.Threading.Tasks;
using System;
using _NetWebApi.Models;

namespace _NetWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase {

        private readonly IRepository _repo;
        public ProdutoController(IRepository repo) {
            _repo = repo;
        }

        [HttpGet()]
        public async Task<IActionResult> Get() {

            try {
                var result = await _repo.GetAllProdutosAsync();
                return Ok(result);

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult> GetByProdutoId(int produtoId) {

            try {
                var result = await _repo.GetProdutoAsyncById(produtoId);
                return Ok(result);

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> post(Produto model) {

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

        [HttpPut("{produtoId}")]
        public async Task<IActionResult> put(int produtoId, Produto model) {

            try {
                var produto = await _repo.GetProdutoAsyncById(produtoId);
                if(produto == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()) {
                    return Ok(model);
                }

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Não esperado");
        }

        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> delete(int produtoId) {

            try {
                var produto = await _repo.GetProdutoAsyncById(produtoId);
                if(produto == null) return NotFound();

                _repo.Delete(produto);
                
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