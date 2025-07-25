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
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Clientes>> AddClientes(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();

            return Ok(clientes);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> ListarClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> ListarIdCLientes(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente Não encontrado");
            }
            return Ok(cliente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Clientes>> ClienteUpdate(int id, [FromBody] Clientes clientesup)
        {
            if (id != clientesup.Id)
            {
                return BadRequest();
            }

            _context.Clientes.Update(clientesup);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> ClienteDel(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}