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
        public CooperativaController(DesafioAxisContext context)
        {
                _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCooperativas()
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

        [HttpPost]
        public async Task<ActionResult> CreateCooperativas(Cooperativas cooperativas)
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
    }
}
