using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaPagamento
    {
        public long CodSaidaPagamento { get; set; }
        public long CodSaida { get; set; }
        public int CodFormaPagamento { get; set; }
        public int CodContaBanco { get; set; }
        public string DescricaoContaBanco { get; set; }
        public int CodCartaoCredito { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int Parcelas { get; set; }
        public int IntervaloDias { get; set; }
        public string MapeamentoFormaPagamento { get; set; }
        public string MapeamentoCartao { get; set; }
        public string DescricaoFormaPagamento { get; set; }
        public string NomeCartaoCredito { get; set; }
        public string NumeroControle { get; set; }
    }
}