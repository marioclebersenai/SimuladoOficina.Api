using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladoOficina.Api.Data;
using SimuladoOficina.Api.Models;

namespace SimuladoOficina.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
            //return await _context.Veiculos.Include(v => v.Cliente).Select(v => new VeiculoDto
            //{
            //    Modelo = v.Modelo,
            //    Placa = v.Placa,
            //    NomeCliente = v.Cliente.Nome
            //}).ToListAsync();
        }

        // GET: api/veiculos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDto>> GetVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.Include(v => v.Cliente).FirstOrDefaultAsync(v => v.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return new VeiculoDto
            {
                Modelo = veiculo.Modelo,
                Placa = veiculo.Placa,
                NomeCliente = veiculo.Cliente.Nome
            };
        }

        // POST: api/veiculos
        [HttpPost]
        public async Task<ActionResult<Veiculo>> CreateVeiculo(CriarVeiculoDto criarVeiculoDto)
        {
            var veiculo = new Veiculo
            {
                Modelo = criarVeiculoDto.Modelo,
                Placa = criarVeiculoDto.Placa,
                ClienteId = criarVeiculoDto.ClienteId
            };

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVeiculo), new { id = veiculo.Id }, veiculo);
        }
    }
}