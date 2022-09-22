using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbContaBanco
    {
        public int CodContaBanco { get; set; }
        public string Numeroconta { get; set; }
        public string Agencia { get; set; }
        public string Descricao { get; set; }
        public decimal? Saldo { get; set; }
        public int? CodBanco { get; set; }
    }
}
