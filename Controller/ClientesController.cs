using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spa.Data;
using Spa.Models;
using SpaAPI.Dtos;
using SpaAPI.Interface;

namespace Spa.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCLiente([FromBody] ClienteDTO dto)
        {
            var resultado = await _service.CriarCadastroClienteAsync(dto);

            return Ok(new
            {
                mensagem = "Cliente cadastrado com sucesso!",
                dados = resultado
            });


        }

        [HttpGet]
        public async Task<IActionResult> ListarCadastros()
        {
            var resultado = await _service.ListarCadastrosClientesAsync();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var resultado = await _service.BuscarCadastroClientePorIdAsync(id);
            if (resultado == null) return NotFound("Não houve cadastro encontrado");

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCadastro(int id)
        {
            var resultado = await _service.DeletarCadastroClienteAsync(id);
            if (!resultado) return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCadastro(int id, Cliente upcliente)
        {
            var resultado = await _service.AtualizarCadastroClienteAsync(id, upcliente);
            if (resultado == null) return NotFound();

            return Ok(new
            {
                mensagem = "Cadastro atualizado com sucesso!",
                dados = resultado
            });
        }




    }
}