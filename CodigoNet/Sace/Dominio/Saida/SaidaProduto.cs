﻿using Util;

namespace Dominio
{
    public class SaidaProduto
    {
        public long CodSaidaProduto { get; set; }
        public long CodProduto { get; set; }
        public string Nome { get; set; }
        public long CodSaida { get; set; }
        public decimal Quantidade { get; set; }
        public string Ncmsh;
        public decimal ValorVenda
        {
            get { return Math.Round((ValorVendaAVista * UtilConfig.Default.ACRESCIMO_PADRAO), 3, MidpointRounding.AwayFromZero); }
        }
        public decimal ValorVendaAVista { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorProdutoNota { get; set; }
        public decimal Subtotal
        {
            get { return ValorVenda * Quantidade; }
        }
        public decimal SubtotalAVista
        {
            get { return ValorVendaAVista * Quantidade; }
            set { ValorVendaAVista = (Quantidade != 0) ? value / Quantidade : 0; }
        }

        public DateTime DataValidade { get; set; }
        public string CodCST { get; set; }
        public int CodCfop { get; set; }
        public string Unidade { get; set; }
        public decimal BaseCalculoICMS { get; set; }
        public decimal ValorICMS { get; set; }
        public decimal BaseCalculoICMSSubst { get; set; }
        public decimal ValorICMSSubst { get; set; }
        public decimal ValorIPI { get; set; }
        public decimal ValorImposto { get; set; }
        public decimal PrecoVendaVarejo { get; set; }
        public bool TemVencimento { get; set; }

        public bool EhTributacaoIntegral
        {
            get
            {
                Cst cst = new Cst() { CodCST = this.CodCST };
                return cst.EhTributacaoIntegral;
            }
        }

        public String Cest
        {
            get
            {
                return "CEST";
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CodSaidaProduto.Equals(((SaidaProduto)obj).CodSaidaProduto);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return CodSaidaProduto.GetHashCode();
        }
    }
}