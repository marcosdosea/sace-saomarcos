using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class NegocioException: Exception
    {
        public NegocioException()
            : base("Erro na excecao")
        {

        }

        public NegocioException(String mensagem)
            : base(mensagem)
        {

        }
    }
}
