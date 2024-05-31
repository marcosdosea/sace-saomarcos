using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbPerfil
    {
        public TbPerfil()
        {
            TbUsuarios = new HashSet<TbUsuario>();
            CodFuncionalidades = new HashSet<TbFuncionalidade>();
        }

        public int CodPerfil { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<TbUsuario> TbUsuarios { get; set; }

        public virtual ICollection<TbFuncionalidade> CodFuncionalidades { get; set; }
    }
}
