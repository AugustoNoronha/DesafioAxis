using DesafioAxis.Domain.Data;
using DesafioAxis.WepApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioAxis.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase
    {
        private readonly DesafioAxisContext _context;
        public FavoritoController(DesafioAxisContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCooperativas()
        {
            List<Favorito> res = await _context.Favoritos.ToListAsync();
            int tam = res.Count();

            return Ok(new
            {
                data = res,
                success = true,
                message = tam + " itens retornados"
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateFavorito(Favorito favoritos)
        {
            await _context.Favoritos.AddAsync(favoritos);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                data = favoritos,
                success = true,
                message = "Item criado com sucesso!"
            });

        }

        [HttpPut]
        public async Task<ActionResult> UpdateFavoritos(Favorito favorito)
        {
            var dbFavorito = await _context.Favoritos.FindAsync(favorito.Id);

            if (dbFavorito == null)
                return NotFound();

            dbFavorito.Name = favorito.Name;
            dbFavorito.PixType = favorito.PixType;
            dbFavorito.PixKey = favorito.PixKey;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                data = favorito,
                success = true,
                message = "Item atualizado com sucesso!"
            });
        }

        [HttpDelete]
        public async Task<ActionResult> DeletFavorito(long id)
        {
            var dbFavorito = await _context.Favoritos.FindAsync(id);

            if (dbFavorito == null)
                return NotFound();

            _context.Remove(dbFavorito);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Item de id : " + id + " Foi removido com sucesso!"
            });
        }
    }
}
