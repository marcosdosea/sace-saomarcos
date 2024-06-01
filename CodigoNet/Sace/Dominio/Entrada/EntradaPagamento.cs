namespace Dominio
{
    public class EntradaPagamento
    {
        public long CodEntradaFormaPagamento { get; set; }
        public long CodEntrada { get; set; }
        public int CodFormaPagamento { get; set; }
        public int CodContaBanco { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Boolean PagamentoDoFrete { get; set; }
    }
}
