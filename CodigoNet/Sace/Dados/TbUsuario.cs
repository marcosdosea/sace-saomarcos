using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbPermissaos = new HashSet<TbPermissao>();
        }

        public long CodPessoa { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public int CodPerfil { get; set; }

        public virtual TbPerfil CodPerfilNavigation { get; set; } = null!;
        public virtual TbPessoa CodPessoaNavigation { get; set; } = null!;
        public virtual ICollection<TbPermissao> TbPermissaos { get; set; }
    }
}
