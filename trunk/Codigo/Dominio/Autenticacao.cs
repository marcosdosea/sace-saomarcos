using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Autenticacao
    {

        private int _CodUsuario;
        public int CodUsuario
        {
            get
            {
                return _CodUsuario;
            }
            set
            {
                _CodUsuario = value;
            }
        }

        private string _Login;
        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
            }
        }
    }
}
