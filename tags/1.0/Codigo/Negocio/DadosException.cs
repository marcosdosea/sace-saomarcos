using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;

namespace Negocio
{
    public class DadosException: DbException
    {
        
        public DadosException(): base()
        { }

        public DadosException(string msg):base(msg)
        { }

        public DadosException(string msg, Exception ex): base(msg,ex)
        { }

        public string Tratar()
        {
            //TODO tratar os tipos de erros sql
            return this.Message;
        }
    }
}
