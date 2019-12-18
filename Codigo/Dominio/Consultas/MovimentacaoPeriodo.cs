using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Consultas
{
    public class MovimentacaoPeriodo
    {
        public long CodSaida { get; set; }
        public String NomeCliente { get; set; }
        public DateTime DataSaida { get; set; }
        public String DescricaoTipoMovimentacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
