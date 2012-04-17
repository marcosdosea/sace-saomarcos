using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;

namespace Dominio
{
    public class Produto: ICloneable
    {
        public const String ST_TRIBUTADO_INTEGRAL = "000";
        public const String ST_TRIBUTADO_SUBSTITUICAO = "010";
        public const String ST_OUTRAS = "090";
        
        
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
        private String nomeProdutoFabricante;

        public String NomeProdutoFabricante
        {
            get { return nomeProdutoFabricante; }
            set { nomeProdutoFabricante = value; }
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

        private String codCST;

        public String CodCST
        {
            get { return codCST; }
            set { codCST = value; }
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

        private String referenciaFabricante;

        public String ReferenciaFabricante
        {
            get { return referenciaFabricante; }
            set { referenciaFabricante = value; }
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

        public Decimal PrecoVendaVarejoSemDesconto
        {
            get { return Math.Round((precoVendaVarejo * Global.ACRESCIMO_PADRAO), 2); }
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
        public Decimal PrecoVendaAtacadoSemDesconto
        {
            get { return Math.Round((precoVendaAtacado * Global.ACRESCIMO_PADRAO), 2); }
        }
        
        private Boolean exibeNaListagem;

        public Boolean ExibeNaListagem
        {
            get { return exibeNaListagem; }
            set { exibeNaListagem = value; }
        }

        private DateTime dataUltimoPedido;

        public DateTime DataUltimoPedido
        {
            get { return dataUltimoPedido; }
            set { dataUltimoPedido = value; }
        }
        private Byte codSituacaoProduto;

        public Byte CodSituacaoProduto
        {
            get { return codSituacaoProduto; }
            set { codSituacaoProduto = value; }
        }

        public Object Clone()
        {
            Produto produto = new Produto();
            produto.Cfop = Cfop;
            produto.CodCST = CodCST;
            produto.CodFabricante = CodFabricante;
            produto.CodGrupo = CodGrupo;
            produto.CodigoBarra = CodigoBarra;
            produto.CodProduto = CodProduto;
            produto.CodSituacaoProduto = CodSituacaoProduto;
            produto.DataUltimoPedido = DataUltimoPedido;
            produto.ExibeNaListagem = ExibeNaListagem;
            produto.Frete = Frete;
            produto.Icms = Icms;
            produto.IcmsSubstituto = IcmsSubstituto;
            produto.Ipi = Ipi;
            produto.LucroPrecoVendaAtacado = LucroPrecoVendaAtacado;
            produto.LucroPrecoVendaVarejo = LucroPrecoVendaVarejo;
            produto.Ncmsh = Ncmsh;
            produto.Nome = Nome;
            produto.NomeProdutoFabricante = NomeProdutoFabricante;
            produto.PrecoVendaAtacado = PrecoVendaAtacado;
            produto.PrecoVendaVarejo = PrecoVendaVarejo;
            produto.QtdProdutoAtacado = QtdProdutoAtacado;
            produto.ReferenciaFabricante = ReferenciaFabricante;
            produto.Simples = Simples;
            produto.TemVencimento = TemVencimento;
            produto.UltimaDataAtualizacao = UltimaDataAtualizacao;
            produto.UltimoPrecoCompra = UltimoPrecoCompra;
            produto.Unidade = Unidade;
            return produto;
        }
    }
}