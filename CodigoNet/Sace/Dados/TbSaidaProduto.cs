using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSaidaProduto
    {
        public long CodSaidaProduto { get; set; }
        public long CodProduto { get; set; }
        public long CodSaida { get; set; }
        public string CodCst { get; set; } = null!;
        public int Cfop { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? ValorVenda { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? SubtotalAvista { get; set; }
        public DateTime? DataValidade { get; set; }
        public decimal? BaseCalculoIcms { get; set; }
        public decimal? ValorIcms { get; set; }
        public decimal? BaseCalculoIcmssubst { get; set; }
        public decimal? ValorIcmssubst { get; set; }
        public decimal? ValorIpi { get; set; }

        public virtual TbCfop CfopNavigation { get; set; } = null!;
        public virtual TbCst CodCstNavigation { get; set; } = null!;
        public virtual TbProduto CodProdutoNavigation { get; set; } = null!;
        public virtual TbSaidum CodSaidaNavigation { get; set; } = null!;
    }
}
