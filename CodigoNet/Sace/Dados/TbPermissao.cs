using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbPermissao
    {
        public long CodPessoa { get; set; }
        public int CodFuncionalidade { get; set; }
        public int Permissao { get; set; }

        public virtual TbFuncionalidade CodFuncionalidadeNavigation { get; set; } = null!;
        public virtual TbUsuario CodPessoaNavigation { get; set; } = null!;
    }
}
