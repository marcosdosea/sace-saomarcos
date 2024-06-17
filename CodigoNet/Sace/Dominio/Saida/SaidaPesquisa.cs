namespace Dominio
{
    public class SaidaPesquisa
    {
        public long CodSaida { get; set; }
        public long CodCliente { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataSaida { get; set; }
        public string CupomFiscal { get; set; }
        public decimal TotalAVista { get; set; }
        public int TipoSaida { get; set; }
        public int CodSituacaoPagamentos { get; set; }

        //TODO: colocar número da ecf no banco de dados.
        public string NumeroECF { get { return "01"; } }
    }
}