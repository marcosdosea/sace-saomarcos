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


        private long codDocumentoPagamento;

        public long CodDocumentoPagamento
        {
            get { return codDocumentoPagamento; }
            set { codDocumentoPagamento = value; }
        }
        private long codPessoaResponsavel;

        public long CodPessoaResponsavel
        {
            get { return codPessoaResponsavel; }
            set { codPessoaResponsavel = value; }
        }
        private int codBanco;

        public int CodBanco
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
        private string numeroDocumento;

        public string NumeroDocumento
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
        private decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private string agencia;

        public string Agencia
        {
            get { return agencia; }
            set { agencia = value; }
        }
        private string conta;

        public string Conta
        {
            get { return conta; }
            set { conta = value; }
        }
        private string emitente;

        public string Emitente
        {
            get { return emitente; }
            set { emitente = value; }
        }
        private string observacao;

        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }


    }
}
