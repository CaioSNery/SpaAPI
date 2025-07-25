using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spa.Data;
using Spa.Interface;
using Spa.Models;

namespace Spa.Services
{
    public class VendaService : IVendaService
    {
        private readonly AppDbContext _context;
        public VendaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Vendas> ObterVendaPorIdAsync(int id)
        {
            return await _context.Vendas.Include(v => v.NomeCliente).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Vendas>> ObterVendasRealizadasAsync()
        {
            return await _context.Vendas.Include(v => v.NomeCliente).ToListAsync();
        }

        public async Task<object> RealizarVendasAsync(VendaDTO dto)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Nome == dto.IdCliente);

            var servico = await _context.Serviços.FirstOrDefaultAsync(s => s.Nome.ToLower() == dto.IdServico.ToLower());

            if (cliente == null) return "Não Encontrado";
            if (servico == null) return "Servico Indisponivel";

            var venda = new Vendas
            {

                NomeCliente = dto.IdCliente,
                NomeServico = dto.IdServico,
                Quantidade = dto.Quantidade,
                ValorUnitario = servico.Preco,
                DataVenda = dto.DataVenda
            };

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            return new
             {
        
        Mensagem = "Venda registrada com sucesso",
        Venda = new
        {
            venda.Id,
            Cliente = cliente.Nome,
            Servico = servico.Nome,
            venda.Quantidade,
            venda.ValorUnitario,
            venda.Total,
            venda.DataVenda
        }
    };
           



        }

       
    }
}