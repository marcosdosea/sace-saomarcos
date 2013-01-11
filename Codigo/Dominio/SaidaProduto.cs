using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaProduto
    {
        public long CodSaidaProduto { get; set; }
        public long CodProduto { get; set; }
        public string Nome { get; set; }
        public long CodSaida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorVendaAVista { get; set; }
        public decimal Desconto { get; set; }
        public decimal Subtotal
        {
            get { return ValorVenda * Quantidade; }
            set { ValorVenda = value / Quantidade; } 
        }
        public decimal SubtotalAVista
        {
            get { return ValorVendaAVista * Quantidade; }
            set { ValorVendaAVista = value / Quantidade; }
        }

        public DateTime DataValidade { get; set; }
        public string CodCST { get; set; }
        public string Unidade { get; set; }
        public decimal BaseCalculoICMS { get; set; }
        public decimal ValorICMS { get; set; }
        public decimal BaseCalculoICMSSubst { get; set; }
        public decimal ValorICMSSubst { get; set; }
        public decimal ValorIPI { get; set; }

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