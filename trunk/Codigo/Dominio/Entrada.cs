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

        public Int64 CodEntrada { get; set; }
        public String NumeroNotaFiscal { get; set; }
        public Int64 CodEmpresaFrete { get; set; }
        public String NomeEmpresaFrete { get; set; }
        public Int64 CodFornecedor { get; set; }
        public String NomeFornecedor { get; set; }
        public Int32 CodTipoEntrada { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataEntrada { get; set; }
        public Decimal TotalPago { get; set; }
        public Decimal TotalBaseCalculo { get; set; }
        public Decimal TotalICMS { get; set; }
        public Decimal TotalBaseSubstituicao { get; set; }
        public Decimal TotalSubstituicao { get; set; }
        public Decimal TotalProdutos { get; set; }
        public Decimal TotalProdutosST { get; set; }
        public Decimal ValorFrete { get; set; }
        public Decimal ValorSeguro { get; set; }
        public Decimal Desconto { get; set; }
        public Decimal OutrasDespesas { get; set; }
        public Decimal TotalIPI { get; set; }
        public Decimal TotalNota { get; set; }
        public Int32 CodSituacaoPagamentos { get; set; }
        public Boolean FretePagoEmitente { get; set; }
    }
}