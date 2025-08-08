using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spa.Models;
using SpaAPI.Dtos;

namespace SpaAPI.Interface
{
    public interface IClienteService
    {
        Task<ClienteDTO> CriarCadastroClienteAsync(ClienteDTO dto);

        Task<bool> DeletarCadastroClienteAsync(int id);

        Task<Cliente> AtualizarCadastroClienteAsync(int id, Cliente upcliente);

        Task<IEnumerable<ClienteDetalhesDto>> ListarCadastrosClientesAsync();

        Task<ClienteDTO> BuscarCadastroClientePorIdAsync(int id);
    }
}