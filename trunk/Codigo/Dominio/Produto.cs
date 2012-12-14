using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;

namespace Dominio
{
    public class Produto: ICloneable
    {
        public const string ST_TRIBUTADO_INTEGRAL = "00";
        public const string ST_SUBSTITUICAO = "10";
        public const string ST_SUBSTITUICAO_ISENTA_NAO_TRIBUTADA = "30";
        public const string ST_SUBSTITUICAO_ICMS_COBRADO = "60";
        public const string ST_SUBSTITUICAO_ICMS_REDUCAO_BC = "70";
        public const string ST_OUTRAS = "90";
        public const string ST_NAO_TRIBUTADA = "41";
        
        public const string ST_SIMPLES_TRIBUTADA_PERM_CREDITO = "101";
        public const string ST_SIMPLES_TRIBUTADA_SEM_PERM_CREDITO = "102";
        public const string ST_SIMPLES_SUBSTITUICAO_SEM_PERM_CREDITO = "202";
        public const string ST_SIMPLES_NAO_TRIBUTADA = "400";
        public const string ST_SIMPLES_SUBSTITUICAO_ICMS_COBRADO = "500";
        public const string ST_SIMPLES_OUTRAS = "900";


        
        public int CodProduto { get; set; }
        public string Nome { get; set; }
        public string NomeProdutoFabricante { get; set; }
        public string Unidade { get; set; }
        public string UnidadeCompra { get; set; }
        public decimal QuantidadeEmbalagem { get; set; }
        public string CodigoBarra { get; set; }
        public string CodCST { get; set; }
        public int CodGrupo { get; set; }
        public int CodSubgrupo { get; set; }
        public long CodFabricante { get; set; }
        public string ReferenciaFabricante { get; set; }
        public Boolean TemVencimento { get; set; }
        public int Cfop { get; set; }
        public string Ncmsh { get; set; }
        public decimal Icms { get; set; }
        public decimal IcmsSubstituto { get; set; }
        public decimal Simples { get; set; }
        public decimal Ipi { get; set; }
        public decimal Frete { get; set; }
        public decimal Desconto { get; set; }
        public decimal UltimoPrecoCompra { get; set; }
        public DateTime UltimaDataAtualizacao { get; set; }
        public decimal LucroPrecoVendaVarejo { get; set; }
        public decimal PrecoVendaVarejo { get; set; }
        public decimal PrecoVendaVarejoSemDesconto
        {
            get { return Math.Round((PrecoVendaVarejo * Global.ACRESCIMO_PADRAO), 2); }
        }

        public decimal QtdProdutoAtacado { get; set; }
        public decimal LucroPrecoVendaAtacado { get; set; }
        public decimal PrecoVendaAtacado { get; set; }
        public decimal PrecoVendaAtacadoSemDesconto
        {
            get { return Math.Round((PrecoVendaAtacado * Global.ACRESCIMO_PADRAO), 2); }
        }
        
        public Boolean ExibeNaListagem { get; set; }
        public DateTime DataUltimoPedido { get; set; }
        public Byte CodSituacaoProduto { get; set; }
        
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
            produto.UnidadeCompra = UnidadeCompra;
            produto.QuantidadeEmbalagem = QuantidadeEmbalagem;
            return produto;
        }
    }
}