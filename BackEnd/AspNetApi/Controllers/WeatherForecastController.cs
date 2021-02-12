using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MiniMercado.Repositorio;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        public readonly MiniMercadoContext _context;

        public WeatherForecastController(MiniMercadoContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {   
            try 
            {
                var resultados = await _context.Pedidos.ToListAsync();
                
                return Ok(resultados);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try 
            {
                var resultados = await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
                
                return Ok(resultados);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Falhou");
            }

        }
    }
}
