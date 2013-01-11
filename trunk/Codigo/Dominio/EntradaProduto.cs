using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class EntradaProduto
    {


        public long CodEntradaProduto { get; set; }
        public long CodEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
        public long CodProduto { get; set; }
        public int Cfop { get; set; }
        public string UnidadeCompra { get; set; }
        public decimal Quantidade { get; set; }
        public decimal QuantidadeEmbalagem { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal BaseCalculoICMS { get; set; }
        public decimal BaseCalculoICMSST { get; set; }
        public decimal ValorICMS { get; set; }
        public decimal ValorICMSST { get; set; }
        public decimal ValorIPI { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal PrecoCusto { get; set; }
        public string Ncmsh { get; set; }
        public decimal Icms { get; set; }
        public decimal IcmsSubstituto { get; set; }
        public decimal Ipi { get; set; }
        public decimal Frete { get; set; }
        public decimal Desconto { get; set; }
        public string CodCST { get; set; }
        public decimal QtdProdutoAtacado { get; set; }
        public DateTime DataValidade { get; set; }
        public decimal QuantidadeDisponivel { get; set; }
        public decimal Simples { get; set; }
        public decimal LucroPrecoVendaVarejo { get; set; }
        public decimal PrecoVendaVarejo { get; set; }
        public decimal LucroPrecoVendaAtacado { get; set; }
        public decimal PrecoVendaAtacado { get; set; }
        public bool EhTributacaoIntegral
        {
            get
            {
                Cst cst = new Cst() { CodCST = this.CodCST };
                return cst.EhTributacaoIntegral;
            }
        }

        public bool FornecedorEhFabricante { get; set; }
        public long CodFornecedor { get; set; }
        public int CodTipoEntrada { get; set; }

    }
}