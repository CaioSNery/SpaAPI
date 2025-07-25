using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa.Models
{
    public class Serviços
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal Preco{ get; set; }
        
    }
}