using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaProduto
    {
        public Int64 CodSaidaProduto { get; set; }
        public Int32 CodProduto { get; set; }
        public String Nome { get; set; }
        public Int64 CodSaida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorVendaAVista { get; set; }
        public decimal Desconto { get; set; }
        public decimal Subtotal
        {
            get { return ValorVenda * Quantidade; }
        }
        public decimal SubtotalAVista
        {
            get { return ValorVendaAVista * Quantidade; }
        }

        public DateTime DataValidade { get; set; }
        public String CodCST { get; set; }
        public String Unidade { get; set; }
    }
}