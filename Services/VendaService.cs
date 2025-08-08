using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spa.Data;
using Spa.Interface;
using Spa.Models;
using SpaAPI.Dtos;

namespace Spa.Services
{
    public class VendaService : IVendaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public VendaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VendaDTO> ObterVendaPorIdAsync(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null) return null;

            return _mapper.Map<VendaDTO>(venda);
        }

        public async Task<IEnumerable<VendaDetalhesDTO>> ObterVendasRealizadasAsync()
        {
            var vendas = await _context.Vendas.ToListAsync();
            if (vendas == null) return null;

            return _mapper.Map<IEnumerable<VendaDetalhesDTO>>(vendas);
        }

        public async Task<object> RealizarVendasAsync(VendaDTO dto)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == dto.IdCliente);

            var servico = await _context.Serviços.FirstOrDefaultAsync(s => s.Id == dto.IdServico);

            if (cliente == null) return "Não Encontrado";
            if (servico == null) return "Servico Indisponivel";

            var vendas = new Venda
            {

                ClienteId = dto.IdCliente,
                ServicoId = dto.IdServico,
                Sessoes = dto.Sessoes,
                ValorUnitario = servico.Preco,
                DataVenda = dto.DataVenda
            };

            _context.Vendas.Add(vendas);
            await _context.SaveChangesAsync();

            return new
            {

                Mensagem = "Venda registrada com sucesso",
                Venda = new
                {
                    vendas.Id,
                    Cliente = cliente.Nome,
                    Servico = servico.Tipo,
                    vendas.Sessoes,
                    vendas.ValorUnitario,
                    vendas.Total,
                    vendas.DataVenda
                }
            };




        }


    }
}