using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbEntradum
    {
        public TbEntradum()
        {
            TbConta = new HashSet<TbContum>();
            TbEntradaFormaPagamentos = new HashSet<TbEntradaFormaPagamento>();
            TbEntradaProdutos = new HashSet<TbEntradaProduto>();
            TbSaida = new HashSet<TbSaidum>();
        }

        public long CodEntrada { get; set; }
        public string? NumeroNotaFiscal { get; set; }
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
        public string? Serie { get; set; }
        public string? Chave { get; set; }

        public virtual TbPessoa CodEmpresaFreteNavigation { get; set; } = null!;
        public virtual TbPessoa CodFornecedorNavigation { get; set; } = null!;
        public virtual TbSituacaoPagamento CodSituacaoPagamentosNavigation { get; set; } = null!;
        public virtual TpTipoEntradum CodTipoEntradaNavigation { get; set; } = null!;
        public virtual ICollection<TbContum> TbConta { get; set; }
        public virtual ICollection<TbEntradaFormaPagamento> TbEntradaFormaPagamentos { get; set; }
        public virtual ICollection<TbEntradaProduto> TbEntradaProdutos { get; set; }
        public virtual ICollection<TbSaidum> TbSaida { get; set; }
    }
}
