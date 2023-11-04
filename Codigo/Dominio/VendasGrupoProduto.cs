using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VendasGrupoProduto
    {
        public long CodGrupo { get; set; }
        public string MesAno { get; set; }
        public decimal? TotalVendas {  get; set; }
    }
}
