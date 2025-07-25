using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa.Models
{
    public class VendaDTO
    {
        public required string IdCliente { get; set; }
        public required string IdServico { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;
    }
}