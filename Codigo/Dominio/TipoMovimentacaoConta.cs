using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class TipoMovimentacaoConta
    {
        private Int32 codTipoMovimentacao;

        public Int32 CodTipoMovimentacao
        {
            get { return codTipoMovimentacao; }
            set { codTipoMovimentacao = value; }
        }
        private String descricao;

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
