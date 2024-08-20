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

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CodSolicitacaoPagamento.Equals(((SolicitacaoPagamento)obj).CodSolicitacaoPagamento);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return CodSolicitacaoPagamento.GetHashCode();
        }
    }
}
