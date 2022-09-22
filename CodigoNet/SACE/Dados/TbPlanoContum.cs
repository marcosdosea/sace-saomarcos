using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbPlanoContum
    {
        public long CodPlanoConta { get; set; }
        public int CodGrupoConta { get; set; }
        public string CodTipoConta { get; set; }
        public string Descricao { get; set; }
        public short? DiaBase { get; set; }
    }
}
