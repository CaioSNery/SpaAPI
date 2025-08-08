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
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _service;
        public ServicoController(IServicoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarServico(ServicoDTO dto)
        {
            var resultado = await _service.CadastrarNovoServicoAsync(dto);
            return Ok(new
            {
                mensagem = "Serviço registrado com sucesso!",
                dados = resultado
            });


        }

        [HttpGet]
        public async Task<IActionResult> ListaDeServiços()
        {
            var resultado = await _service.ListarServicosCadastradosAsync();
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarServico(int id)
        {
            var resultado = await _service.DeletarCadastroServicoAsync(id);
            if (!resultado) return NotFound();

            return NoContent();
        }




    }
}