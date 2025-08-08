using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ServicoId { get; set; }
        public Serviço Servico { get; set; }

        public int Sessoes { get; set; } = 1;
        public decimal ValorUnitario { get; set; }
        public decimal Total => ValorUnitario * Sessoes;
        public DateTime DataVenda { get; set; } = DateTime.Now;
    }
}