using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;

namespace Util
{
    public class UtilException : SystemException
    {
        
        public UtilException(): base()
        { }

        public UtilException(string msg):base(msg)
        { }

        public UtilException(string msg, Exception ex): base(msg,ex)
        { }

    }
}
