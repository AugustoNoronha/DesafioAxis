using DesafioAxis.Domain.Data;
using DesafioAxis.WepApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioAxis.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooperativaController : ControllerBase
    {
        private readonly DesafioAxisContext _context;
        private readonly ILogger<CooperativaController> _logger;


        public CooperativaController(DesafioAxisContext context, ILogger<CooperativaController> logger)
        {
                _context = context;
                _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetCooperativas()
        {
           
            try
            {
                List<Cooperativas> res = await _context.Cooperativas.ToListAsync();
                int tam = res.Count();

                return Ok(new
                {
                    data = res,
                    success = true,
                    message = tam + " itens retornados"
                });
            }
            catch(Exception ex)
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
        public async Task<ActionResult> CreateCooperativas(Cooperativas cooperativas)
        {
            try
            {
                await _context.Cooperativas.AddAsync(cooperativas);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    data = cooperativas,
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
    }
}
