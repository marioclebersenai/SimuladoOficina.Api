using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladoOficina.Api.Data;
using SimuladoOficina.Api.Models;

//Controller AgendamentosController
namespace SimuladoOficina.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/agendamentos
        [HttpPost]
        public async Task<ActionResult<Agendamento>> CreateAgendamento(CriarAgendamentoDto agendamentoDto)
        {
            var agendamento = new Agendamento
            {
                DataHora = agendamentoDto.DataHora,
                VeiculoId = agendamentoDto.VeiculoId,
                Servico = agendamentoDto.Servico
            };

            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateAgendamento), new { id = agendamento.Id }, agendamento);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoAgendamentoDto>>> GetAgendamentos()
        {
            var agendamentos = await _context.Agendamentos
                .Include(a => a.Veiculo)
                .ThenInclude(v => v.Cliente)
                .Select(a => new InfoAgendamentoDto
                {
                    DataHora = a.DataHora,
                    ModeloVeiculo = a.Veiculo.Modelo,
                    PlacaVeiculo = a.Veiculo.Placa,
                    NomeCliente = a.Veiculo.Cliente.Nome,
                    Servico = a.Servico
                })
                .ToListAsync();

            return Ok(agendamentos);
        }
    }
}