using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class NegocioException : SystemException
    {
        public NegocioException()
            : base("Erro no negócio da aplicação.")
        {

        }

        public NegocioException(String mensagem)
            : base(mensagem)
        {

        }
    }
}
