using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;

namespace Dominio
{
    public class Produto: ICloneable
    {
        public const String ST_TRIBUTADO_INTEGRAL = "00";
        public const String ST_SUBSTITUICAO = "10";
        public const String ST_SUBSTITUICAO_ISENTA_NAO_TRIBUTADA = "30";
        public const String ST_SUBSTITUICAO_ICMS_COBRADO = "60";
        public const String ST_SUBSTITUICAO_ICMS_REDUCAO_BC = "70";
        public const String ST_OUTRAS = "90";
        
        
        public Int32 CodProduto { get; set; }
        public String Nome { get; set; }
        public String NomeProdutoFabricante { get; set; }
        public String Unidade { get; set; }
        public String CodigoBarra { get; set; }
        public String CodCST { get; set; }
        public Int32 CodGrupo { get; set; }
        public Int32 CodSubgrupo { get; set; }
        public long CodFabricante { get; set; }
        public String ReferenciaFabricante { get; set; }
        public Boolean TemVencimento { get; set; }
        public Int32 Cfop { get; set; }
        public String Ncmsh { get; set; }
        public Decimal Icms { get; set; }
        public Decimal IcmsSubstituto { get; set; }
        public Decimal Simples { get; set; }
        public Decimal Ipi { get; set; }
        public Decimal Frete { get; set; }
        public Decimal Desconto { get; set; }
        public Decimal UltimoPrecoCompra { get; set; }
        public DateTime UltimaDataAtualizacao { get; set; }
        public Decimal LucroPrecoVendaVarejo { get; set; }
        public Decimal PrecoVendaVarejo { get; set; }
        public Decimal PrecoVendaVarejoSemDesconto
        {
            get { return Math.Round((PrecoVendaVarejo * Global.ACRESCIMO_PADRAO), 2); }
        }

        public Decimal QtdProdutoAtacado { get; set; }
        public Decimal LucroPrecoVendaAtacado { get; set; }
        public Decimal PrecoVendaAtacado { get; set; }
        public Decimal PrecoVendaAtacadoSemDesconto
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
            return produto;
        }
    }
}