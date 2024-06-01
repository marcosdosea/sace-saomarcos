namespace Dominio
{
    public class Pagamento
    {
     
        public long CodPagamento { get; set; }
        public int CodFormaPagamento { get; set; }
        public long CodConta { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorDiferenca { get; set; }
        public int CodContaBanco { get; set; }
        public DateTime DataBaixa { get; set; }
    }
}
