using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbProduto
    {
        public TbProduto()
        {
            TbEntradaProdutos = new HashSet<TbEntradaProduto>();
            TbPontaEstoques = new HashSet<TbPontaEstoque>();
            TbProdutoLojas = new HashSet<TbProdutoLoja>();
            TbSaidaProdutos = new HashSet<TbSaidaProduto>();
        }

        public long CodProduto { get; set; }
        public string Nome { get; set; } = null!;
        public string? NomeProdutoFabricante { get; set; }
        public string Unidade { get; set; } = null!;
        public string? CodigoBarra { get; set; }
        public string CodCst { get; set; } = null!;
        public string Ncmsh { get; set; } = null!;
        public long CodFabricante { get; set; }
        public string? ReferenciaFabricante { get; set; }
        public sbyte CodSituacaoProduto { get; set; }
        public long CodGrupo { get; set; }
        public int CodSubgrupo { get; set; }
        public bool? TemVencimento { get; set; }
        public decimal? Icms { get; set; }
        public decimal? IcmsSubstituto { get; set; }
        public decimal? Simples { get; set; }
        public decimal? Ipi { get; set; }
        public decimal? Frete { get; set; }
        public DateTime? UltimaDataAtualizacao { get; set; }
        public decimal? UltimoPrecoCompra { get; set; }
        public decimal? LucroPrecoVendaVarejo { get; set; }
        public decimal? PrecoVendaVarejo { get; set; }
        public decimal? QtdProdutoAtacado { get; set; }
        public decimal? LucroPrecoVendaAtacado { get; set; }
        public decimal? PrecoVendaAtacado { get; set; }
        public bool? ExibeNaListagem { get; set; }
        public DateTime? DataUltimoPedido { get; set; }
        public decimal? Desconto { get; set; }
        public string? UnidadeCompra { get; set; }
        public decimal? QuantidadeEmbalagem { get; set; }
        public decimal? LucroPrecoRevenda { get; set; }
        public decimal? PrecoRevenda { get; set; }
        public bool? EmPromocao { get; set; }
        public DateTime DataSolicitacaoCompra { get; set; }
        public DateTime DataPedidoCompra { get; set; }
        public DateTime DataUltimaMudancaPreco { get; set; }

        public virtual TbCst CodCstNavigation { get; set; } = null!;
        public virtual TbPessoa CodFabricanteNavigation { get; set; } = null!;
        public virtual TbGrupo CodGrupoNavigation { get; set; } = null!;
        public virtual TbSituacaoProduto CodSituacaoProdutoNavigation { get; set; } = null!;
        public virtual TbSubgrupo CodSubgrupoNavigation { get; set; } = null!;
        public virtual ICollection<TbEntradaProduto> TbEntradaProdutos { get; set; }
        public virtual ICollection<TbPontaEstoque> TbPontaEstoques { get; set; }
        public virtual ICollection<TbProdutoLoja> TbProdutoLojas { get; set; }
        public virtual ICollection<TbSaidaProduto> TbSaidaProdutos { get; set; }
    }
}
