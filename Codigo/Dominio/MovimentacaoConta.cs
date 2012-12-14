using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class MovimentacaoConta
    {
        public const int RECEBIMENTO_CLIENTE = 1;
        public const int PAGAMENTO_FORNECEDOR = 2;
        public const int TROCO_CLIENTE = 3;
        public const int DEVOLUCAO_CLIENTE = 4;

        private long codMovimentacao;

        public long CodMovimentacao
        {
            get { return codMovimentacao; }
            set { codMovimentacao = value; }
        }
        private int codTipoMovimentacao;

        public int CodTipoMovimentacao
        {
            get { return codTipoMovimentacao; }
            set { codTipoMovimentacao = value; }
        }
        private decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private DateTime dataHora;

        public DateTime DataHora
        {
            get { return dataHora; }
            set { dataHora = value; }
        }
        private long codResponsavel;

        public long CodResponsavel
        {
            get { return codResponsavel; }
            set { codResponsavel = value; }
        }
        private int codContaBanco;

        public int CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        private long codConta;

        public long CodConta
        {
            get { return codConta; }
            set { codConta = value; }
        }

        private Boolean somaSaldo;

        public Boolean SomaSaldo
        {
            get { return somaSaldo; }
            set { somaSaldo = value; }
        }

    }
}