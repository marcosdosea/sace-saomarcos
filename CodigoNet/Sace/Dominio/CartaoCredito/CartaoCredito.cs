namespace Dominio
{
    public class CartaoCredito
    {
        public const string TIPO_CARTAO_CREDITO = "CREDITO";
        public const string TIPO_CARTAO_DEBITO = "DEBITO";
        public const string TIPO_CARTAO_CREDIARIO = "CREDIARIO";

        public int CodCartao { get; set; }
        public string? Nome { get; set; }
        public int DiaBase { get; set; }
        public int CodContaBanco { get; set; }
        public string? DescricaoContaBanco { get; set; }
        public long CodPessoa { get; set; }
        public string? NomePessoa { get; set; }
        public string? Mapeamento { get; set; }
        public string? MapeamentoCappta { get; set; }
        public decimal Desconto { get; set; }
        public string? TipoCartao { get; set; }
    }
}
