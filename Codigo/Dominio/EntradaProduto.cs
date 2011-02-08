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
        private Decimal quantidade;

        public Decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        private Decimal valorCompra;

        public Decimal ValorCompra
        {
            get { return valorCompra; }
            set { valorCompra = value; }
        }
        private Decimal ipi;

        public Decimal Ipi
        {
            get { return ipi; }
            set { ipi = value; }
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
        private Decimal precoCusto;

        public Decimal PrecoCusto
        {
            get { return precoCusto; }
            set { precoCusto = value; }
        }

        private Decimal frete;

        public Decimal Frete
        {
            get { return frete; }
            set { frete = value; }
        }


        private DateTime dataValidade;

        public DateTime DataValidade
        {
            get { return dataValidade; }
            set { dataValidade = value; }
        }

        private Decimal quantidadeVendidos;

        public Decimal QuantidadeVendidos
        {
            get { return quantidadeVendidos; }
            set { quantidadeVendidos = value; }
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
