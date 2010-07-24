using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Grupo
    {
        private Int32 codGrupo;

        public Int32 CodGrupo
        {
            get { return codGrupo; }
            set { codGrupo = value; }
        }
        private String descricao;

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
