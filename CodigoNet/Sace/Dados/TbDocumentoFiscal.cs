using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbDocumentoFiscal
    {
        public uint NumeroDocumentoFiscal { get; set; }
        public DateTime DataSoliciticao { get; set; }
        public string Situacao { get; set; } = null!;
    }
}
