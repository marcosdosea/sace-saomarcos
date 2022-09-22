using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbCartaoCredito
    {
        public int CodCartao { get; set; }
        public string Nome { get; set; }
        public int? DiaBase { get; set; }
        public int CodContaBanco { get; set; }
        public string Mapeamento { get; set; }
        public long CodPessoa { get; set; }
        public decimal Desconto { get; set; }
        public string MapeamentoCappta { get; set; }
        public string TipoCartao { get; set; }
    }
}
