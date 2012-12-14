using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SituacaoPagamentos
    {

        public const int ABERTA = 1;
        public const int LANCADOS = 2;
        public const int QUITADA = 3;

        private int codSituacaoPagamentos;

        public int CodSituacaoPagamentos
        {
            get { return codSituacaoPagamentos; }
            set { codSituacaoPagamentos = value; }
        }
        private string descricaoSituacaoPagamentos;

        public string DescricaoSituacaoPagamentos
        {
            get { return descricaoSituacaoPagamentos; }
            set { descricaoSituacaoPagamentos = value; }
        }
    }
}
