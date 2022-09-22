using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbDocumentoFiscal
    {
        public int NumeroDocumentoFiscal { get; set; }
        public DateTime DataSoliciticao { get; set; }
        public string Situacao { get; set; }
    }
}
