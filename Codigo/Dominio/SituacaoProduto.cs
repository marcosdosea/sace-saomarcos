using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SituacaoProduto
    {
        public const Int32 DISPONIVEL = 1;
        public const Int32 COMPRA_NECESSARIA = 2;
        public const Int32 COMPRADO = 3;

        private Int32 codSituacaoProduto;

        public Int32 CodSituacaoProduto
        {
            get { return codSituacaoProduto; }
            set { codSituacaoProduto = value; }
        }
        private String descricaoSituacao;

        public String DescricaoSituacao
        {
            get { return descricaoSituacao; }
            set { descricaoSituacao = value; }
        }

    }
}
