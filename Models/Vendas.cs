using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public required string NomeCliente { get; set; }
        
        public required string NomeServico { get; set; }
        
        public int Quantidade { get; set; } = 1;
        public decimal ValorUnitario { get; set; }
        public decimal Total => ValorUnitario * Quantidade;
        public DateTime DataVenda { get; set; } = DateTime.Now;
    }
}