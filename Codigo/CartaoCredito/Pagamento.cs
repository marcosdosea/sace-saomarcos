using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartao
{
    public class Pagamento
    {
        public enum Cartao {DEBITO, CREDITO, CREDIARIO};
        public enum Parcelamento { LOJA=2, ADMINISTRADORA=1, INDEFINIDO=0 };

        public Cartao TipoCartao { get; set; }
        public Parcelamento TipoParcelamento { get; set; }
        public double Valor { get; set; }
        public int QuantidadeParcelas { get; set; }
    }
}
