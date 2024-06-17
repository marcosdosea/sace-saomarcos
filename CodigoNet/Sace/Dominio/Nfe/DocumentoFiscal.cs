namespace Dominio
{
    public class DocumentoFiscal
    {
        public const string SITUACAO_SOLICITADO = "SOLICITADO";
        public const string SITUACAO_CANCELADO = "CANCELADO";
        public const string SITUACAO_AUTORIZADO = "AUTORIZADO";

        public enum TipoSolicitacao { ECF, NFCE, NFE, CARTAO };
        
        public long CodSaida { get; set; }
        public string NumeroCupomFiscal { get; set; }
        public DateTime DataEmissaoCupomFiscal { get; set; }
        public long CodCliente { get; set; }
        public string NomeCliente { get; set; }
    }
}
