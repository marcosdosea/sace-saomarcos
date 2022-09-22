using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbUsuario
    {
        public long CodPessoa { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int CodPerfil { get; set; }
    }
}
