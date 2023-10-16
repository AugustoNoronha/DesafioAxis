using DesafioAxis.Domain.Data;
using DesafioAxis.WepApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioAxis.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooperadorController : ControllerBase
    {
        private readonly ILogger<CooperadorController> _logger;

        private readonly DesafioAxisContext _context;
        public CooperadorController(DesafioAxisContext context, ILogger<CooperadorController> logger)
        {
                _context = context;
                _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> GetCooperadores()
        {
            try
            {
                List<Cooperador> res = await _context.Cooperadores.ToListAsync();
                int tam = res.Count();

                return Ok(new
                {
                    data = res,
                    success = true,
                    message = tam + " itens retornados"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateCooperadores(Cooperador cooperador)
        {
            try
            {
                await _context.Cooperadores.AddAsync(cooperador);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    data = cooperador,
                    success = true,
                    message = "Item criado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateCooperadores(Cooperador cooperador)
        {
            try
            {
                var dbCooperador = await _context.Cooperadores.FindAsync(cooperador.Id);

                if (dbCooperador == null)
                    return NotFound();

                dbCooperador.AccountNumber = cooperador.AccountNumber;
                dbCooperador.Name = cooperador.Name;
                dbCooperador.Email = cooperador.Email;

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    data = cooperador,
                    success = true,
                    message = "Item atualizado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletCooperador(long id)
        {
            try
            {
                var dbCooperador = await _context.Cooperadores.FindAsync(id);

                if (dbCooperador == null)
                    return NotFound();

                _context.Remove(dbCooperador);

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Item de id : " + id + " Foi removido com sucesso!"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
