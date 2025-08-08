using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spa.Data;
using Spa.Models;
using SpaAPI.Dtos;
using SpaAPI.Interface;

namespace SpaAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cliente> AtualizarCadastroClienteAsync(int id, Cliente upcliente)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return null;

            cliente.Nome = upcliente.Nome;
            cliente.Cpf = upcliente.Cpf;
            cliente.Telefone = upcliente.Telefone;

            _context.Update(upcliente);
            await _context.SaveChangesAsync();

            return upcliente;
        }

        public async Task<ClienteDTO> BuscarCadastroClientePorIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return null;

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ClienteDTO> CriarCadastroClienteAsync(ClienteDTO dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);

            _context.Add(cliente);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<bool> DeletarCadastroClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ClienteDetalhesDto>> ListarCadastrosClientesAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<IEnumerable<ClienteDetalhesDto>>(clientes);

        }
    }
}