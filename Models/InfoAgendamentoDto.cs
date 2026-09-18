namespace SimuladoOficina.Api.Models
{
    public class InfoAgendamentoDto
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string ModeloVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public string NomeCliente { get; set; }

        public string? Servico { get; set; }


    }

}
