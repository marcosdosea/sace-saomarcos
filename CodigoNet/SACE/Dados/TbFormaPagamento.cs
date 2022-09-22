using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbFormaPagamento
    {
        public int CodFormaPagamento { get; set; }
        public string Descricao { get; set; }
        public int Parcelas { get; set; }
        public decimal DescontoAcrescimo { get; set; }
        public string Mapeamento { get; set; }
    }
}
