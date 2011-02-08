using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class MovimentacaoConta
    {
        private Int64 codMovimentacao;

        public Int64 CodMovimentacao
        {
            get { return codMovimentacao; }
            set { codMovimentacao = value; }
        }
        private Int32 codTipoMovimentacao;

        public Int32 CodTipoMovimentacao
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
        private Int64 codResponsavel;

        public Int64 CodResponsavel
        {
            get { return codResponsavel; }
            set { codResponsavel = value; }
        }
        private Int32 codContaBanco;

        public Int32 CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        private Int64 codPagamento;

        public Int64 CodPagamento
        {
            get { return codPagamento; }
            set { codPagamento = value; }
        }

    }
}
