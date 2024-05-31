using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbEntradaProduto
    {
        public long CodEntradaProduto { get; set; }
        public long CodEntrada { get; set; }
        public long CodProduto { get; set; }
        public int Cfop { get; set; }
        public string? UnidadeCompra { get; set; }
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
        /// <summary>
        /// Os produtos vendidos na loja incrementam esse valor atÃƒÂ© que o nÃƒÂºmero de vendidos seja igual ao de comprados.
        /// 
        /// </summary>
        public decimal? QuantidadeDisponivel { get; set; }
        public decimal? Desconto { get; set; }
        public string CodCst { get; set; } = null!;

        public virtual TbCfop CfopNavigation { get; set; } = null!;
        public virtual TbCst CodCstNavigation { get; set; } = null!;
        public virtual TbEntradum CodEntradaNavigation { get; set; } = null!;
        public virtual TbProduto CodProdutoNavigation { get; set; } = null!;
    }
}
