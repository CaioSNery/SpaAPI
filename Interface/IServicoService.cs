using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spa.Models;
using SpaAPI.Dtos;

namespace SpaAPI.Interface
{
    public interface IServicoService
    {
        Task<ServicoDTO> CadastrarNovoServicoAsync(ServicoDTO dto);

        Task<IEnumerable<Serviço>> ListarServicosCadastradosAsync();

        Task<bool> DeletarCadastroServicoAsync(int id);




    }
}