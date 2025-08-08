using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAPI.Dtos
{
    public class ServicoDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Preco { get; set; }
    }
}