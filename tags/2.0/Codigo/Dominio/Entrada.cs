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

        public long CodEntrada { get; set; }
        public string NumeroNotaFiscal { get; set; }
        public long CodEmpresaFrete { get; set; }
        public string NomeEmpresaFrete { get; set; }
        public long CodFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string Cpf_CnpjFornecedor { get; set; }
        public bool FornecedorEhFabricante { get; set; }
        public int CodTipoEntrada { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataEntrada { get; set; }
        //public decimal TotalPago { get; set; }
        public decimal TotalBaseCalculo { get; set; }
        public decimal TotalICMS { get; set; }
        public decimal TotalBaseSubstituicao { get; set; }
        public decimal TotalSubstituicao { get; set; }
        public decimal TotalProdutos { get; set; }
        public decimal TotalProdutosST { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal Desconto { get; set; }
        public decimal OutrasDespesas { get; set; }
        public decimal TotalIPI { get; set; }
        public decimal TotalNota { get; set; }
        public int CodSituacaoPagamentos { get; set; }
        public Boolean FretePagoEmitente { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodEntrada == ((Entrada)obj).CodEntrada;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodEntrada.GetHashCode();
        }
    }
}