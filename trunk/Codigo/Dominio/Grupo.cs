using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Grupo
    {
        private int codGrupo;

        public int CodGrupo
        {
            get { return codGrupo; }
            set { codGrupo = value; }
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

            return this.CodGrupo == ((Grupo)obj).CodGrupo;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodGrupo.GetHashCode();
        }
    }
}
