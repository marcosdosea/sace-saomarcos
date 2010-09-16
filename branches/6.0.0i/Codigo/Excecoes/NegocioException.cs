using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SACE.Excecoes
{
    public class NegocioException : SystemException
    {
        public NegocioException(string menssagem):base(menssagem)  {        }
    }
}
