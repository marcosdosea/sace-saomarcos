using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Saida
    {
        public const int TIPO_ORCAMENTO = 1;
        public const int TIPO_PRE_VENDA = 2;
        public const int TIPO_VENDA = 3;
        public const int TIPO_SAIDA_DEPOSITO = 4;
        public const int TIPO_CONSUMO_INTERNO = 5;
        public const int TIPO_PRODUTOS_DANIFICADOS = 6;
        
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

        private decimal totalAVista;

        public decimal TotalAVista
        {
            get { return totalAVista; }
            set { totalAVista = value; }
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

        private Int32 codSituacaoPagamentos;

        public Int32 CodSituacaoPagamentos
        {
            get { return codSituacaoPagamentos; }
            set { codSituacaoPagamentos = value; }
        }

        private Decimal troco;

        public Decimal Troco
        {
            get { return troco; }
            set { troco = value; }
        }
        private Boolean entregaRealizada;

        public Boolean EntregaRealizada
        {
            get { return entregaRealizada; }
            set { entregaRealizada = value; }
        }
        private String nfe;

        public String Nfe
        {
            get { return nfe; }
            set { nfe = value; }
        }
    }
}