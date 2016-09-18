using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class DocumentoFiscal
    {
        public enum TipoSolicitacao { ECF, NFCE, NFE, CARTAO };
        
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

            return this.CodSaida.Equals(((DocumentoFiscal)obj).CodSaida);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodSaida.GetHashCode();
        }
    }
}
