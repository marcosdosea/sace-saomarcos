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

        public int CodSituacaoPagamentos { get; set;  }
        public string DescricaoSituacaoPagamentos { get; set; }
    }
}
