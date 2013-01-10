using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Cfop
    {
        public int CodCfop { get; set; }
        public string Descricao { get; set; }
        public decimal Icms { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.CodCfop.Equals(((Cfop)obj).CodCfop);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodCfop.GetHashCode();
        }
    }
}
