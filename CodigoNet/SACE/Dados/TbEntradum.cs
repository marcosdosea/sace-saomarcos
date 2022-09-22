using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbEntradum
    {
        public TbEntradum()
        {
            TbSaida = new HashSet<TbSaidum>();
        }

        public long CodEntrada { get; set; }
        public string NumeroNotaFiscal { get; set; }
        public long CodEmpresaFrete { get; set; }
        public long CodFornecedor { get; set; }
        public int CodTipoEntrada { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime? DataEntrada { get; set; }
        public decimal? TotalBaseCalculo { get; set; }
        public decimal? TotalIcms { get; set; }
        public decimal? TotalBaseSubstituicao { get; set; }
        public decimal? TotalSubstituicao { get; set; }
        public decimal? TotalProdutos { get; set; }
        public decimal? TotalProdutosSt { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? ValorSeguro { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? OutrasDespesas { get; set; }
        public decimal? TotalIpi { get; set; }
        public decimal? TotalNota { get; set; }
        public int CodSituacaoPagamentos { get; set; }
        public bool FretePagoEmitente { get; set; }
        public string Serie { get; set; }
        public string Chave { get; set; }

        public virtual ICollection<TbSaidum> TbSaida { get; set; }
    }
}
