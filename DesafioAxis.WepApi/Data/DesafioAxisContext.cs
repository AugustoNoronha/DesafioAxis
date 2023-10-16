using DesafioAxis.WepApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioAxis.Domain.Data
{
    public class DesafioAxisContext : DbContext
    {
        public DesafioAxisContext(DbContextOptions<DesafioAxisContext> options) : base(options){
        
        }

        public DbSet<Cooperador> Cooperadores { get; set; }
        public DbSet<Cooperativas> Cooperativas { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }


    }
}
