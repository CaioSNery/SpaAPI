using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa.Models
{
    public class VendaDTO
    {
        public int IdCliente { get; set; }
        public int IdServico { get; set; }
        public decimal Total { get; set; }

        public int Sessoes { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;
    }
}