using Util;

namespace Dominio
{
    public class ProdutoPesquisa
    {
        public long CodProduto { get; set; }
        public string? CodigoBarra { get; set; }
        public long CodFabricante { get; set; }
        public string Nome { get; set; }
        public string? NomeProdutoFabricante { get; set; }
        public string Unidade { get; set; }
        public DateTime? UltimaDataAtualizacao { get; set; }
        public DateTime DataUltimaMudancaPreco { get; set; }
        public bool? TemVencimento { get; set; }
        public bool? EmPromocao { get; set; }
        public string CodCST { get; set; }
        public string? ReferenciaFabricante { get; set; }
        public decimal PrecoVendaVarejo { get; set; }
        public decimal PrecoVendaVarejoSemDesconto
        {
            get { return Math.Round((PrecoVendaVarejo * UtilConfig.Default.ACRESCIMO_PADRAO), 2, MidpointRounding.AwayFromZero); }
        }
        public decimal QtdProdutoAtacado { get; set; }
        public decimal PrecoVendaAtacado { get; set; }
        public decimal PrecoVendaAtacadoSemDesconto
        {
            get { return Math.Round((PrecoVendaAtacado * UtilConfig.Default.ACRESCIMO_PADRAO), 2, MidpointRounding.AwayFromZero); }
        }
        public decimal TotalPrecoVendaAtacadoSemDesconto
        {
            get { return Math.Round(PrecoVendaAtacado * UtilConfig.Default.ACRESCIMO_PADRAO, 2, MidpointRounding.AwayFromZero) * QtdProdutoAtacado; }
        }
        public decimal TotalPrecoVendaAtacado
        {
            get { return Math.Round(QtdProdutoAtacado * PrecoVendaAtacado, 2, MidpointRounding.AwayFromZero); }
        }

        public decimal PrecoRevenda { get; set; }
        public decimal PrecoRevendaSemDesconto
        {
            get { return Math.Round((PrecoRevenda * UtilConfig.Default.ACRESCIMO_PADRAO), 3, MidpointRounding.AwayFromZero); }
        }
        
        public bool ExibeNaListagem { get; set; }
        public bool EhTributacaoIntegral
        {
            get
            {
                Cst cst = new Cst() { CodCST = this.CodCST };
                return cst.EhTributacaoIntegral;
            }
        }
        public string? Ncmsh { get; set; }
        public decimal Icms { get; set; }
        public decimal IcmsSubstituto { get; set; }
        public decimal Simples { get; set; }
        public decimal Ipi { get; set; }
        public decimal Frete { get; set; }
        public decimal Desconto { get; set; }
        public decimal UltimoPrecoCompra { get; set; }
        public decimal LucroPrecoVendaVarejo { get; set; }
        public decimal LucroPrecoVendaAtacado { get; set; }
        public decimal LucroPrecoRevenda { get; set; }
        public string? UnidadeCompra { get; set; }
        public decimal QuantidadeEmbalagem { get; set; }
        public sbyte CodSituacaoProduto { get; set; }
       
    }
}