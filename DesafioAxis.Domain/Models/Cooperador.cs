using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxis.Domain.Models
{
    public class Cooperador
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;

        public Cooperativas Cooperativas { get; set; }
    }

    public enum Cooperativas { 
        CooperativaA = 1,
        CooperativaB = 2,
        CooperativaC = 3,
        CooperativaD = 4,
        CooperativaE = 5,
    }

}
