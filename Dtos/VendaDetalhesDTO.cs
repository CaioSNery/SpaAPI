using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAPI.Dtos
{
    public class VendaDetalhesDTO
    {
        public int IdCliente { get; set; }
        public int IdServico { get; set; }
        public decimal Total { get; set; }
    }
}