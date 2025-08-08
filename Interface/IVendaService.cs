using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spa.Models;

namespace Spa.Interface
{
    public interface IVendaService
    {
        Task<object> RealizarVendasAsync(VendaDTO dto);
        Task<IEnumerable<Venda>> ObterVendasRealizadasAsync();
        Task<Venda> ObterVendaPorIdAsync(int id);
    }
}