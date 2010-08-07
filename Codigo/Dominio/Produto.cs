using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Produto
    {
        private Int32 codProduto;

        public Int32 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }
        private String nome;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private String nomeFabricante;

        public String NomeFabricante
        {
            get { return nomeFabricante; }
            set { nomeFabricante = value; }
        }
        private String unidade;

        public String Unidade
        {
            get { return unidade; }
            set { unidade = value; }
        }
        private String codigoBarra;

        public String CodigoBarra
        {
            get { return codigoBarra; }
            set { codigoBarra = value; }
        }
        private Int32 codGrupo;

        public Int32 CodGrupo
        {
            get { return codGrupo; }
            set { codGrupo = value; }
        }
        private Int32 codFabricante;

        public Int32 CodFabricante
        {
            get { return codFabricante; }
            set { codFabricante = value; }
        }
        private Boolean temVencimento;

        public Boolean TemVencimento
        {
            get { return temVencimento; }
            set { temVencimento = value; }
        }
        private Int32 cfop;

        public Int32 Cfop
        {
            get { return cfop; }
            set { cfop = value; }
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
        private Decimal simples;

        public Decimal Simples
        {
            get { return simples; }
            set { simples = value; }
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
        private Decimal custoVenda;

        public Decimal CustoVenda
        {
            get { return custoVenda; }
            set { custoVenda = value; }
        }
        private Decimal ultimoPrecoCompra;

        public Decimal UltimoPrecoCompra
        {
            get { return ultimoPrecoCompra; }
            set { ultimoPrecoCompra = value; }
        }
        private DateTime ultimaDataAtualizacao;

        public DateTime UltimaDataAtualizacao
        {
            get { return ultimaDataAtualizacao; }
            set { ultimaDataAtualizacao = value; }
        }
        private Decimal ultimoPrecoCusto;

        public Decimal UltimoPrecoCusto
        {
            get { return ultimoPrecoCusto; }
            set { ultimoPrecoCusto = value; }
        }
        private Decimal ultimoPrecoMedio;

        public Decimal UltimoPrecoMedio
        {
            get { return ultimoPrecoMedio; }
            set { ultimoPrecoMedio = value; }
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
        private Decimal qtdProdutoAtacado;

        public Decimal QtdProdutoAtacado
        {
            get { return qtdProdutoAtacado; }
            set { qtdProdutoAtacado = value; }
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
        private Decimal qtdProdutoSuperAtacado;

        public Decimal QtdProdutoSuperAtacado
        {
            get { return qtdProdutoSuperAtacado; }
            set { qtdProdutoSuperAtacado = value; }
        }
        private Decimal lucroPrecoVendaSuperAtacado;

        public Decimal LucroPrecoVendaSuperAtacado
        {
            get { return lucroPrecoVendaSuperAtacado; }
            set { lucroPrecoVendaSuperAtacado = value; }
        }
        private Decimal precoVendaSuperAtacado;

        public Decimal PrecoVendaSuperAtacado
        {
            get { return precoVendaSuperAtacado; }
            set { precoVendaSuperAtacado = value; }
        }
        private Boolean exibeNaListagem;

        public Boolean ExibeNaListagem
        {
            get { return exibeNaListagem; }
            set { exibeNaListagem = value; }
        }


    }
}
