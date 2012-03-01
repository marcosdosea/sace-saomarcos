using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaPagamento
    {
        private Int64 codSaidaPagamento;

        public Int64 CodSaidaPagamento
        {
            get { return codSaidaPagamento; }
            set { codSaidaPagamento = value; }
        }
        private Int64 codSaida;

        public Int64 CodSaida
        {
            get { return codSaida; }
            set { codSaida = value; }
        }
        private Int32 codFormaPagamento;

        public Int32 CodFormaPagamento
        {
            get { return codFormaPagamento; }
            set { codFormaPagamento = value; }
        }
        private Int32 codContaBanco;

        public Int32 CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        private Int32 codCartaoCredito;

        public Int32 CodCartaoCredito
        {
            get { return codCartaoCredito; }
            set { codCartaoCredito = value; }
        }

        private Int64 codPessoaResponsavel;

        public Int64 CodPessoaResponsavel
        {
            get { return codPessoaResponsavel; }
            set { codPessoaResponsavel = value; }
        }
        
        private decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private Int64 codDocumentoPagamento;

        public Int64 CodDocumentoPagamento
        {
            get { return codDocumentoPagamento; }
            set { codDocumentoPagamento = value; }
        }

        private Int32 parcelas;

        public Int32 Parcelas
        {
            get { return parcelas; }
            set { parcelas = value; }
        }
        private Int32 intervaloDias;

        public Int32 IntervaloDias
        {
            get { return intervaloDias; }
            set { intervaloDias = value; }
        }

        private String mapeamentoFormaPagamento;

        public String MapeamentoFormaPagamento
        {
            get { return mapeamentoFormaPagamento; }
            set { mapeamentoFormaPagamento = value; }
        }

        private String mapeamentoCartao;

        public String MapeamentoCartao
        {
            get { return mapeamentoCartao; }
            set { mapeamentoCartao = value; }
        }

        private String descricaoFormaPagamento;

        public String DescricaoFormaPagamento
        {
            get { return descricaoFormaPagamento; }
            set { descricaoFormaPagamento = value; }
        }

        private String nomeCartaoCredito;

        public String NomeCartaoCredito
        {
            get { return nomeCartaoCredito; }
            set { nomeCartaoCredito = value; }
        }

    }    
}