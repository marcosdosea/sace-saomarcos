using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SituacaoPagamentos
    {

        public const Int32 ABERTA = 1;
        public const Int32 LANCADOS = 2;
        public const Int32 QUITADA = 3;

        private Int32 codSituacaoPagamentos;

        public Int32 CodSituacaoPagamentos
        {
            get { return codSituacaoPagamentos; }
            set { codSituacaoPagamentos = value; }
        }
        private String descricaoSituacaoPagamentos;

        public String DescricaoSituacaoPagamentos
        {
            get { return descricaoSituacaoPagamentos; }
            set { descricaoSituacaoPagamentos = value; }
        }
    }
}
