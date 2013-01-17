using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaPagamento
    {
        private long codSaidaPagamento;

        public long CodSaidaPagamento
        {
            get { return codSaidaPagamento; }
            set { codSaidaPagamento = value; }
        }
        private long codSaida;

        public long CodSaida
        {
            get { return codSaida; }
            set { codSaida = value; }
        }
        private int codFormaPagamento;

        public int CodFormaPagamento
        {
            get { return codFormaPagamento; }
            set { codFormaPagamento = value; }
        }
        private int codContaBanco;

        public int CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        private int codCartaoCredito;

        public int CodCartaoCredito
        {
            get { return codCartaoCredito; }
            set { codCartaoCredito = value; }
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

        private long codDocumentoPagamento;

        public long CodDocumentoPagamento
        {
            get { return codDocumentoPagamento; }
            set { codDocumentoPagamento = value; }
        }

        private int parcelas;

        public int Parcelas
        {
            get { return parcelas; }
            set { parcelas = value; }
        }
        private int intervaloDias;

        public int IntervaloDias
        {
            get { return intervaloDias; }
            set { intervaloDias = value; }
        }

        private string mapeamentoFormaPagamento;

        public string MapeamentoFormaPagamento
        {
            get { return mapeamentoFormaPagamento; }
            set { mapeamentoFormaPagamento = value; }
        }

        private string mapeamentoCartao;

        public string MapeamentoCartao
        {
            get { return mapeamentoCartao; }
            set { mapeamentoCartao = value; }
        }

        private string descricaoFormaPagamento;

        public string DescricaoFormaPagamento
        {
            get { return descricaoFormaPagamento; }
            set { descricaoFormaPagamento = value; }
        }

        private string nomeCartaoCredito;

        public string NomeCartaoCredito
        {
            get { return nomeCartaoCredito; }
            set { nomeCartaoCredito = value; }
        }

    }    
}