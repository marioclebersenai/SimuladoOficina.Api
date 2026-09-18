namespace SimuladoOficina.Api.Models
{
    public class CriarAgendamentoDto
    {
        public DateTime DataHora { get; set; }
        public int VeiculoId { get; set; }
        public string? Servico { get; set; }
    }


}
