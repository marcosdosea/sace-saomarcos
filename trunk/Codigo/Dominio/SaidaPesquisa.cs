using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaPesquisa
    {
        public long CodSaida { get; set; }
        public long CodCliente { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataSaida { get; set; }
        public string CupomFiscal { get; set; }
        public decimal TotalAVista { get; set; }
        public int TipoSaida { get; set; }
        public int CodSituacaoPagamentos { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodSaida.Equals(((Saida)obj).CodSaida);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodSaida.GetHashCode();
        }

        //TODO: colocar núemro da ecf no banco de dados.
        public string NumeroECF { get { return "01"; } }
    }
}