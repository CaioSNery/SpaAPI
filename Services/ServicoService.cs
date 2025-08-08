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
    public class ServicoService : IServicoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ServicoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServicoDTO> CadastrarNovoServicoAsync(ServicoDTO dto)
        {
            var servico = _mapper.Map<Serviço>(dto);

            _context.Add(servico);
            await _context.SaveChangesAsync();

            return _mapper.Map<ServicoDTO>(servico);
        }

        public async Task<bool> DeletarCadastroServicoAsync(int id)
        {
            var servico = await _context.Serviços.FindAsync(id);
            if (servico == null) return false;

            _context.Remove(servico);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<Serviço>> ListarServicosCadastradosAsync()
        {
            var servicos = await _context.Serviços.ToListAsync();

            return _mapper.Map<IEnumerable<Serviço>>(servicos);
        }
    }
}