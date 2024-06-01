namespace Dominio
{
    public class MovimentacaoPeriodo
    {
        public long CodSaida { get; set; }
        public String NomeCliente { get; set; }
        public DateTime DataSaida { get; set; }
        public String DescricaoTipoMovimentacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
