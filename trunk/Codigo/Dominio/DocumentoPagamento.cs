using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class DocumentoPagamento
    {

        public const Byte TIPO_CHEQUE = 1;
        public const Byte TIPO_BOLETO = 2;
        public const Byte TIPO_PROMISSORIA = 3;


        private Int64 codDocumentoPagamento;

        public Int64 CodDocumentoPagamento
        {
            get { return codDocumentoPagamento; }
            set { codDocumentoPagamento = value; }
        }
        private Int64 codPessoaResponsavel;

        public Int64 CodPessoaResponsavel
        {
            get { return codPessoaResponsavel; }
            set { codPessoaResponsavel = value; }
        }
        private Int32 codBanco;

        public Int32 CodBanco
        {
            get { return codBanco; }
            set { codBanco = value; }
        }
        private Byte codTipoDocumento;

        public Byte CodTipoDocumento
        {
            get { return codTipoDocumento; }
            set { codTipoDocumento = value; }
        }
        private String numeroDocumento;

        public String NumeroDocumento
        {
            get { return numeroDocumento; }
            set { numeroDocumento = value; }
        }
        private DateTime dataDocumento;

        public DateTime DataDocumento
        {
            get { return dataDocumento; }
            set { dataDocumento = value; }
        }
        private DateTime dataVencimento;

        public DateTime DataVencimento
        {
            get { return dataVencimento; }
            set { dataVencimento = value; }
        }
        private Decimal valor;

        public Decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private String agencia;

        public String Agencia
        {
            get { return agencia; }
            set { agencia = value; }
        }
        private String conta;

        public String Conta
        {
            get { return conta; }
            set { conta = value; }
        }
        private String emitente;

        public String Emitente
        {
            get { return emitente; }
            set { emitente = value; }
        }
        private String observacao;

        public String Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }


    }
}
