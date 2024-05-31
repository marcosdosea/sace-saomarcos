using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbMunicipiosIbge
    {
        public TbMunicipiosIbge()
        {
            TbPessoas = new HashSet<TbPessoa>();
        }

        public int Codigo { get; set; }
        public string Municipio { get; set; } = null!;
        public string Uf { get; set; } = null!;

        public virtual ICollection<TbPessoa> TbPessoas { get; set; }
    }
}
