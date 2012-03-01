using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaProduto
    {
        private Int64 codSaidaProduto;

        public Int64 CodSaidaProduto
        {
            get { return codSaidaProduto; }
            set { codSaidaProduto = value; }
        }
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

        private Int64 codSaida;

        public Int64 CodSaida
        {
            get { return codSaida; }
            set { codSaida = value; }
        }
        private decimal quantidade;

        public decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        private decimal valorVenda;

        public decimal ValorVenda
        {
            get { return valorVenda; }
            set { valorVenda = value; }
        }

        private decimal valorVendaAVista;

        public decimal ValorVendaAVista
        {
            get { return valorVendaAVista; }
            set { valorVendaAVista = value; }
        }

        private decimal desconto;

        public decimal Desconto
        {
            get { return desconto; }
            set { desconto = value; }
        }
        
        public decimal Subtotal
        {
            get { return ValorVenda * Quantidade; }
        }

        public decimal SubtotalAVista
        {
            get { return ValorVendaAVista * Quantidade; }
        }

        private DateTime dataValidade;

        public DateTime DataValidade
        {
            get { return dataValidade; }
            set { dataValidade = value; }
        }


        private String codCST;

        public String CodCST
        {
            get { return codCST; }
            set { codCST = value; }
        }

        private String unidade;

        public String Unidade
        {
            get { return unidade; }
            set { unidade = value; }
        }
    }
}