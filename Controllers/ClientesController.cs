using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladoOficina.Api.Data;
using SimuladoOficina.Api.Models;

namespace SimuladoOficina.Api.Controllers
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

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            return await _context.Clientes.Select(c => new ClienteDto
            {
                Nome = c.Nome,
                Cpf = c.Cpf
            }).ToListAsync();
        }

        // GET: api/clientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return new ClienteDto
            {
                Nome = cliente.Nome,
                Cpf = cliente.Cpf
            };

        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> CreateCliente(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nome = clienteDto.Nome,
                Cpf = clienteDto.Cpf
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, clienteDto);
        }
    }
}