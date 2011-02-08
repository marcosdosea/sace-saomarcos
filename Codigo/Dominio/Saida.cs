using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Saida
    {
        private Int64 codSaida;

        public Int64 CodSaida
        {
            get { return codSaida; }
            set { codSaida = value; }
        }
        private DateTime dataSaida;

        public DateTime DataSaida
        {
            get { return dataSaida; }
            set { dataSaida = value; }
        }
        private Int32 tipoSaida;

        public Int32 TipoSaida
        {
            get { return tipoSaida; }
            set { tipoSaida = value; }
        }
        private Int64 codCliente;

        public Int64 CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; }
        }
        private Int64 codProfissional;

        public Int64 CodProfissional
        {
            get { return codProfissional; }
            set { codProfissional = value; }
        }
        private Int32 numeroCartaoVenda;

        public Int32 NumeroCartaoVenda
        {
            get { return numeroCartaoVenda; }
            set { numeroCartaoVenda = value; }
        }
        private String pedidoGerado;

        public String PedidoGerado
        {
            get { return pedidoGerado; }
            set { pedidoGerado = value; }
        }
        private decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }
        private decimal desconto;

        public decimal Desconto
        {
            get { return desconto; }
            set { desconto = value; }
        }
        private decimal totalPago;

        public decimal TotalPago
        {
            get { return totalPago; }
            set { totalPago = value; }
        }
        private decimal totalLucro;

        public decimal TotalLucro
        {
            get { return totalLucro; }
            set { totalLucro = value; }
        }
    }
}
