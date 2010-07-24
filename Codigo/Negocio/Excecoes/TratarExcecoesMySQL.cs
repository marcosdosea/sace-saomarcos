using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class TratarExcecoesMySQL:TratarExcecoes
    {
        
        
        protected override void tratador(String entidade, String atributo, Exception e, BindingSource bs) {
            if (e is MySqlException)
            {
                MySqlException exception = (MySqlException)e;
                // Tratamento de chaves únicas
                if (exception.Number == 1062)
                {
                    bs.CancelEdit();
                    bs.EndEdit();
                    tratarChaveUnica(entidade, atributo, e);
                }
                // Tratamento de chaves estrangeiras
                else if (exception.Number == 1451)
                {
                    tratarChaveEstrangeira(entidade, e);
                }
                else
                {
                    tratarDesconhecida(entidade, e, exception.Number);
                }
            }
        }
    }
}
