using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class EntradaProduto
    {
        private Int64 codEntradaProduto;

        public Int64 CodEntradaProduto
        {
            get { return codEntradaProduto; }
            set { codEntradaProduto = value; }
        }

        private Int64 codEntrada;

        public Int64 CodEntrada
        {
            get { return codEntrada; }
            set { codEntrada = value; }
        }
        private Int32 codProduto;

        public Int32 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }
        
        private Int32 cfop;

        public Int32 Cfop
        {
            get { return cfop; }
            set { cfop = value; }
        }
        private String unidadeCompra;

        public String UnidadeCompra
        {
            get { return unidadeCompra; }
            set { unidadeCompra = value; }
        }

        private Decimal quantidade;

        public Decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        private Decimal quantidadeEmbalagem;

        public Decimal QuantidadeEmbalagem
        {
            get { return quantidadeEmbalagem; }
            set { quantidadeEmbalagem = value; }
        }        

        private Decimal valorUnitario;

        public Decimal ValorUnitario
        {
            get { return valorUnitario; }
            set { valorUnitario = value; }
        }

        private Decimal valorTotal;

        public Decimal ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }
        private Decimal baseCalculoICMS;

        public Decimal BaseCalculoICMS
        {
            get { return baseCalculoICMS; }
            set { baseCalculoICMS = value; }
        }
        private Decimal baseCalculoICMSST;

        public Decimal BaseCalculoICMSST
        {
            get { return baseCalculoICMSST; }
            set { baseCalculoICMSST = value; }
        }
        private Decimal valorICMS;

        public Decimal ValorICMS
        {
            get { return valorICMS; }
            set { valorICMS = value; }
        }
        private Decimal valorICMSST;

        public Decimal ValorICMSST
        {
            get { return valorICMSST; }
            set { valorICMSST = value; }
        }
        private Decimal valorIPI;

        public Decimal ValorIPI
        {
            get { return valorIPI; }
            set { valorIPI = value; }
        }

        private Decimal precoCusto;

        public Decimal PrecoCusto
        {
            get { return precoCusto; }
            set { precoCusto = value; }
        }

        private String ncmsh;

        public String Ncmsh
        {
            get { return ncmsh; }
            set { ncmsh = value; }
        }

        private Decimal icms;

        public Decimal Icms
        {
            get { return icms; }
            set { icms = value; }
        }
        private Decimal icmsSubstituto;

        public Decimal IcmsSubstituto
        {
            get { return icmsSubstituto; }
            set { icmsSubstituto = value; }
        }
        
        private Decimal ipi;

        public Decimal Ipi
        {
            get { return ipi; }
            set { ipi = value; }
        }
        
        private Decimal frete;

        public Decimal Frete
        {
            get { return frete; }
            set { frete = value; }
        }

        private String codCST;

        public String CodCST
        {
            get { return codCST; }
            set { codCST = value; }
        }

        private Decimal qtdProdutoAtacado;

        public Decimal QtdProdutoAtacado
        {
            get { return qtdProdutoAtacado; }
            set { qtdProdutoAtacado = value; }
        }

        private DateTime dataValidade;

        public DateTime DataValidade
        {
            get { return dataValidade; }
            set { dataValidade = value; }
        }

        private Decimal quantidadeDisponivel;

        public Decimal QuantidadeDisponivel
        {
            get { return quantidadeDisponivel; }
            set { quantidadeDisponivel = value; }
        }

        
        private Decimal simples;

        public Decimal Simples
        {
            get { return simples; }
            set { simples = value; }
        }

        private Decimal lucroPrecoVendaVarejo;

        public Decimal LucroPrecoVendaVarejo
        {
            get { return lucroPrecoVendaVarejo; }
            set { lucroPrecoVendaVarejo = value; }
        }
        private Decimal precoVendaVarejo;

        public Decimal PrecoVendaVarejo
        {
            get { return precoVendaVarejo; }
            set { precoVendaVarejo = value; }
        }
        
        private Decimal lucroPrecoVendaAtacado;

        public Decimal LucroPrecoVendaAtacado
        {
            get { return lucroPrecoVendaAtacado; }
            set { lucroPrecoVendaAtacado = value; }
        }
        private Decimal precoVendaAtacado;

        public Decimal PrecoVendaAtacado
        {
            get { return precoVendaAtacado; }
            set { precoVendaAtacado = value; }
        }
    }
}