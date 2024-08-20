namespace Dominio
{
    public class FormaPagamento
    {
        public const int DINHEIRO = 1;
        public const int CREDIARIO = 2;
        public const int CARTAO = 3;
        public const int BOLETO = 4;
        public const int CHEQUE = 5;
        public const int DEPOSITO_PIX = 6;

        public int CodFormaPagamento { get; set; }
        public string Descricao { get; set; }
        public int Parcelas { get; set; }
        public decimal DescontoAcrescimo { get; set; }
        public string Mapeamento { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodFormaPagamento.Equals(((FormaPagamento)obj).CodFormaPagamento);
        }
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodFormaPagamento.GetHashCode();
        }
    }
}
