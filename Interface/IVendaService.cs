using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spa.Models;
using SpaAPI.Dtos;

namespace Spa.Interface
{
    public interface IVendaService
    {
        Task<object> RealizarVendasAsync(VendaDTO dto);
        Task<IEnumerable<VendaDetalhesDTO>> ObterVendasRealizadasAsync();
        Task<VendaDTO> ObterVendaPorIdAsync(int id);
    }
}