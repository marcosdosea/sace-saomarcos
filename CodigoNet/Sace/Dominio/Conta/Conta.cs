namespace Dominio
{
    public class Conta
    {
        public const Char CONTA_PAGAR = 'P';
        public const Char CONTA_RECEBER = 'R';

        public const string FORMATO_CONTA_FICHA = "FICHA";
        public const string FORMATO_CONTA_BOLETO = "BOLETO";
        public const string FORMATO_CONTA_CARTAO = "CARTAO";
        public const string FORMATO_CONTA_CHEQUE = "CHEQUE";
        public const string FORMATO_CONTA_CREDITO = "CREDITO";
        
        
        public long CodConta { get; set; }
        public long CodEntrada { get; set; }
        public long CodSaida { get; set; }
        public string Nfe { get; set; }
        public long CodPlanoConta { get; set; }
        public long CodPessoa { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string CodSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
        public string Observacao { get; set; }
        public string TipoConta { get; set; }
        public string CF { get; set; }
        public decimal ValorPagar
        {
            get { return Valor - Desconto; }
        }
      
        public long? CodPagamento { get; set; }
        public decimal Desconto { get; set; }

        public string FormatoConta { get; set; }
        public string NumeroDocumento { get; set; }
    }
}