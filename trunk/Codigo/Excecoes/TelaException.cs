using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SACE.Excecoes
{
    public class TelaException: SystemException
    {
        public TelaException(string message)
            :base(message)
        {}

        public TelaException(string message, Exception exp)
            : base(message, exp)
        { }
    }
}
