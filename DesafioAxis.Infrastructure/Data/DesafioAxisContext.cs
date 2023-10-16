using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxis.Infrastructure.Data
{
    public class DesafioAxisContext : DbContext
    {
        public DesafioAxisContext(DbContextOptions<DesafioAxisContext> options)
            : base(options)
        {

        }
    }
}
