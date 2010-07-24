using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;

namespace Dados
{
    public class DadosException: DbException
    {
        private String entidade;
        public String Entidade
        {
            get { return entidade; }
        }
        private String atributo;

        public String Atributo
        {
            get { return atributo; }
            set { atributo = value; }
        }
        
        public DadosException(): base()
        { }

        public DadosException(string msg):base(msg)
        { }

        public DadosException(string msg, Exception ex): base(msg,ex)
        { }

        public DadosException(String entidade, string msg, Exception ex)
            : base(msg, ex)
        {
            this.entidade = entidade;
        }
    }
}
