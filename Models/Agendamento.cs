namespace SimuladoOficina.Api.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string? Servico { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
    }


}
