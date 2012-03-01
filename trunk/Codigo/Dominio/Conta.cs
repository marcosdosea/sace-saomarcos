using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Conta
    {
        public const Char CONTA_PAGAR = 'P';
        public const Char CONTA_RECEBER = 'R';
        public const Char SITUACAO_ABERTA = 'A';
        public const Char SITUACAO_QUITADA = 'Q';
        public const Char SITUACAO_PARCIALMENTE_QUITADA = 'P';
        public const Char SITUACAO_CANCELADA = 'C';
        
        private Int64 codConta;

        public Int64 CodConta
        {
            get { return codConta; }
            set { codConta = value; }
        }
        private Int64 codEntrada;

        public Int64 CodEntrada
        {
            get { return codEntrada; }
            set { codEntrada = value; }
        }
        private Int64 codSaida;

        public Int64 CodSaida
        {
            get { return codSaida; }
            set { codSaida = value; }
        }
        private Int64 codDocumento;

        public Int64 CodDocumento
        {
            get { return codDocumento; }
            set { codDocumento = value; }
        }

        private Int64 codPlanoConta;

        public Int64 CodPlanoConta
        {
            get { return codPlanoConta; }
            set { codPlanoConta = value; }
        }
        private Int64 codPessoa;

        public Int64 CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
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
        private Char codSituacao;

        public Char CodSituacao
        {
            get { return codSituacao; }
            set { codSituacao = value; }
        }

        private String observacao;

        public String Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }
        private Char tipoConta;

        public Char TipoConta
        {
            get { return tipoConta; }
            set { tipoConta = value; }
        }
    }
}