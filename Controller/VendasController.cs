using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spa.Interface;
using Spa.Models;

namespace Spa.Controller
{
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _service;

        public VendasController(IVendaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarServico([FromBody] VendaDTO dto)
        {
            var resultado = await _service.RealizarVendasAsync(dto);
            if (resultado is string erro)
            {
                if (erro.Contains("Nao Encontrado")) return NotFound();
                return BadRequest();
            }
            return Ok(resultado);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendas>>> GetVendas()
        {
            var vendas = await _service.ObterVendasRealizadasAsync();

            return Ok(vendas);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendas>> GetIdVendas(int id)
        {
            var venda = await _service.ObterVendaPorIdAsync(id);
            if (venda == null) return NotFound();

            return Ok(venda);
        }

    }
}