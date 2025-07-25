using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spa.Data;
using Spa.Models;

namespace Spa.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly AppDbContext _appcontext;
        public ServicoController(AppDbContext appcontext)
        {
            _appcontext = appcontext;
        }

        [HttpPost]
        public async Task<ActionResult<Serviços>> AddServico(Serviços servicos)
        {
            _appcontext.Serviços.Add(servicos);
            await _appcontext.SaveChangesAsync();
            return Ok(servicos);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Serviços>>> GetServicos()
        {
            var servicos = await _appcontext.Serviços.ToListAsync();
            return Ok(servicos);
        }
        [HttpPut]
        public async Task<ActionResult<Serviços>> UpServico(int id, [FromBody] Serviços servicosup)
        {
            if (id != servicosup.Id)
            {
                return BadRequest();
            }
            _appcontext.Serviços.Update(servicosup);
            await _appcontext.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Serviços>> DelServicos(int id)
        {
            var servico = _appcontext.Serviços.Find(id);
            if (servico == null) return NotFound();

            _appcontext.Serviços.Remove(servico);
            await _appcontext.SaveChangesAsync();

            return NoContent();
        }
    }
}