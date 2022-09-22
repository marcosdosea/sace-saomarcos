using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbSaidaProduto
    {
        public long CodSaidaProduto { get; set; }
        public long CodProduto { get; set; }
        public long CodSaida { get; set; }
        public string CodCst { get; set; }
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

        public virtual TbCst CodCstNavigation { get; set; }
    }
}
