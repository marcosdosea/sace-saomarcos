using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbEntradaProduto
    {
        public long CodEntradaProduto { get; set; }
        public long CodEntrada { get; set; }
        public long CodProduto { get; set; }
        public int Cfop { get; set; }
        public string UnidadeCompra { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? QuantidadeEmbalagem { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? BaseCalculoIcms { get; set; }
        public decimal? BaseCalculoIcmsst { get; set; }
        public decimal? ValorIcms { get; set; }
        public decimal? ValorIcmsst { get; set; }
        public decimal? ValorIpi { get; set; }
        public DateTime? DataValidade { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal? QuantidadeDisponivel { get; set; }
        public decimal? Desconto { get; set; }
        public string CodCst { get; set; }
    }
}
