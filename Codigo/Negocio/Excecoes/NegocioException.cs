using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    class NegocioException: Exception
    {
        public NegocioException()
            : base("Erro na excecao")
        {

        }
    }
}
