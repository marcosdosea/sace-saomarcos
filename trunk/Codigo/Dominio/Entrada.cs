using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Entrada
    {
        public const int TIPO_ENTRADA = 1;
        public const int TIPO_ENTRADA_AUX = 2;
        public const int TIPO_PEDIDO_COMPRA = 3;
        public const int TIPO_TRANSFERENCIA = 4;

        private Int64 codEntrada;

        public Int64 CodEntrada
        {
            get { return codEntrada; }
            set { codEntrada = value; }
        }
        private String numeroNotaFiscal;

        public String NumeroNotaFiscal
        {
            get { return numeroNotaFiscal; }
            set { numeroNotaFiscal = value; }
        }

        private Int64 codEmpresaFrete;

        public Int64 CodEmpresaFrete
        {
            get { return codEmpresaFrete; }
            set { codEmpresaFrete = value; }
        }

        private String nomeEmpresaFrete;

        public String NomeEmpresaFrete
        {
            get { return nomeEmpresaFrete; }
            set { nomeEmpresaFrete = value; }
        }

        private Int64 codFornecedor;

        public Int64 CodFornecedor
        {
            get { return codFornecedor; }
            set { codFornecedor = value; }
        }

        private String nomeFornecedor;

        public String NomeFornecedor
        {
            get { return nomeFornecedor; }
            set { nomeFornecedor = value; }
        }
        
        private Int32 codTipoEntrada;

        public Int32 CodTipoEntrada
        {
            get { return codTipoEntrada; }
            set { codTipoEntrada = value; }
        }

        private DateTime dataEmissao;

        public DateTime DataEmissao
        {
            get { return dataEmissao; }
            set { dataEmissao = value; }
        }

        private DateTime dataEntrada;

        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set { dataEntrada = value; }
        }

        private Decimal totalPago;

        public Decimal TotalPago
        {
            get { return totalPago; }
            set { totalPago = value; }
        }

        private Decimal totalBaseCalculo;

        public Decimal TotalBaseCalculo
        {
            get { return totalBaseCalculo; }
            set { totalBaseCalculo = value; }
        }
        private Decimal totalICMS;

        public Decimal TotalICMS
        {
            get { return totalICMS; }
            set { totalICMS = value; }
        }
        private Decimal totalBaseSubstituicao;

        public Decimal TotalBaseSubstituicao
        {
            get { return totalBaseSubstituicao; }
            set { totalBaseSubstituicao = value; }
        }
        private Decimal totalSubstituicao;

        public Decimal TotalSubstituicao
        {
            get { return totalSubstituicao; }
            set { totalSubstituicao = value; }
        }
        private Decimal totalProdutos;

        public Decimal TotalProdutos
        {
            get { return totalProdutos; }
            set { totalProdutos = value; }
        }
        private Decimal valorFrete;

        public Decimal ValorFrete
        {
            get { return valorFrete; }
            set { valorFrete = value; }
        }
        private Decimal valorSeguro;

        public Decimal ValorSeguro
        {
            get { return valorSeguro; }
            set { valorSeguro = value; }
        }
        private Decimal desconto;

        public Decimal Desconto
        {
            get { return desconto; }
            set { desconto = value; }
        }
        private Decimal outrasDespesas;

        public Decimal OutrasDespesas
        {
            get { return outrasDespesas; }
            set { outrasDespesas = value; }
        }
        private Decimal totalIPI;

        public Decimal TotalIPI
        {
            get { return totalIPI; }
            set { totalIPI = value; }
        }
        private Decimal totalNota;

        public Decimal TotalNota
        {
            get { return totalNota; }
            set { totalNota = value; }
        }

        private Int32 codSituacaoPagamentos;

        public Int32 CodSituacaoPagamentos
        {
            get { return codSituacaoPagamentos; }
            set { codSituacaoPagamentos = value; }
        }

        private Boolean fretePagoEmitente;

        public Boolean FretePagoEmitente
        {
            get { return fretePagoEmitente; }
            set { fretePagoEmitente = value; }
        }

    }
}