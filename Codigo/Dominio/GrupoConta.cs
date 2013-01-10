using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class GrupoConta
    {
        private int codGrupoConta;

        public int CodGrupoConta
        {
            get { return codGrupoConta; }
            set { codGrupoConta = value; }
        }

        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodGrupoConta == ((GrupoConta)obj).CodGrupoConta;    
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodGrupoConta.GetHashCode();
        }
    }
}
