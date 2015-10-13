using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class CupomFiscal
    {
        public long CodSaida { get; set; }
        public string NumeroCupomFiscal { get; set; }
        public DateTime DataEmissaoCupomFiscal { get; set; }
        public long CodCliente { get; set; }
        public string NomeCliente { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodSaida.Equals(((CupomFiscal)obj).CodSaida);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodSaida.GetHashCode();
        }
    }
}
