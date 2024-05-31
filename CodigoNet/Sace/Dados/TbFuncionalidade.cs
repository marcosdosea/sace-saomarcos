using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbFuncionalidade
    {
        public TbFuncionalidade()
        {
            TbPermissaos = new HashSet<TbPermissao>();
            CodPerfils = new HashSet<TbPerfil>();
        }

        public int CodFuncionalidade { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual ICollection<TbPermissao> TbPermissaos { get; set; }

        public virtual ICollection<TbPerfil> CodPerfils { get; set; }
    }
}
