namespace Dominio
{
    public class SolicitacaoPagamento
    {
        public ulong CodSolicitacaoPagamento { get; set; }
        public long CodSolicitacao { get; set; }
        public int CodCartao { get; set; }
        public int CodFormaPagamento { get; set; }
        public decimal Valor { get; set; }
        public uint Parcelas { get; set; }
        public string CupomCliente { get; set; } = null!;
        public string CupomEstabelecimento { get; set; } = null!;
        public string CupomReduzido { get; set; } = null!;
    }
}
