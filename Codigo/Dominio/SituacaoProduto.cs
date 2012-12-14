using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SituacaoProduto
    {
        public const int DISPONIVEL = 1;
        public const int COMPRA_NECESSARIA = 2;
        public const int COMPRADO = 3;

        private int codSituacaoProduto;

        public int CodSituacaoProduto
        {
            get { return codSituacaoProduto; }
            set { codSituacaoProduto = value; }
        }
        private string descricaoSituacao;

        public string DescricaoSituacao
        {
            get { return descricaoSituacao; }
            set { descricaoSituacao = value; }
        }

    }
}
