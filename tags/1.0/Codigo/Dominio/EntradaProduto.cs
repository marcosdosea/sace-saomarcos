using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class EntradaProduto
    {


        public Int64 CodEntradaProduto { get; set; }
        public Int64 CodEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
        public Int32 CodProduto { get; set; }
        public Int32 Cfop { get; set; }
        public String UnidadeCompra { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal QuantidadeEmbalagem { get; set; }
        public Decimal ValorUnitario { get; set; }
        public Decimal ValorTotal { get; set; }
        public Decimal BaseCalculoICMS { get; set; }
        public Decimal BaseCalculoICMSST { get; set; }
        public Decimal ValorICMS { get; set; }
        public Decimal ValorICMSST { get; set; }
        public Decimal ValorIPI { get; set; }
        public Decimal ValorDesconto { get; set; }
        public Decimal PrecoCusto { get; set; }
        public String Ncmsh { get; set; }
        public Decimal Icms { get; set; }
        public Decimal IcmsSubstituto { get; set; }
        public Decimal Ipi { get; set; }
        public Decimal Frete { get; set; }
        public Decimal Desconto { get; set; }
        public String CodCST { get; set; }
        public Decimal QtdProdutoAtacado { get; set; }
        public DateTime DataValidade { get; set; }
        public Decimal QuantidadeDisponivel { get; set; }
        public Decimal Simples { get; set; }
        public Decimal LucroPrecoVendaVarejo { get; set; }
        public Decimal PrecoVendaVarejo { get; set; }
        public Decimal LucroPrecoVendaAtacado { get; set; }
        public Decimal PrecoVendaAtacado { get; set; }

        public bool FornecedorEhFabricante { get; set; }
        public long CodFornecedor { get; set; }
        public int CodTipoEntrada { get; set; }

    }
}