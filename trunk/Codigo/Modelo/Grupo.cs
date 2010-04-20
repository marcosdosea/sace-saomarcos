using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SACE.Modelo
{
    public class Grupo
    {
        private int codGrupo;

        public int CodGrupo
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
