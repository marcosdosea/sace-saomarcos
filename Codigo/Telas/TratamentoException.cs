using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SACE.Excecoes;
using System.Data.SqlClient;

namespace Telas
{
    internal class TratamentoException
    {
        public void TratarException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            string erro = t.Exception.Message;


            if (t.Exception is ArgumentOutOfRangeException)
                erro = "O valor está fora dos limites do indice " + t.Exception.TargetSite;
            else if (t.Exception is ArgumentNullException)
                erro = "Objeto não pode ser nulo " + t.Exception.TargetSite;
            else if (t.Exception is ArgumentException)
                erro = "Argumento inválido " + t.Exception.TargetSite;

            if (t.Exception is DuplicateWaitObjectException)
                erro = "... " + t.Exception.TargetSite;
            else if (t.Exception is InvalidOperationException)
                erro = "... " + t.Exception.TargetSite;

            if (t.Exception is AccessViolationException)
                erro = "... " + t.Exception.TargetSite;
            else if (t.Exception is NullReferenceException)
                erro = "Referencia ao objeto não encontrada ou nula" + t.Exception.TargetSite;
            else if (t.Exception is IndexOutOfRangeException)
                erro = "Indice invalido " + t.Exception.TargetSite;

            //verificar hierarquia de excecoes
            if (t.Exception is ApplicationException)
                erro = "... " + t.Exception.TargetSite;
            else if (t.Exception is SystemException)
                erro = "... " + t.Exception.TargetSite;


            if (t.Exception is DivideByZeroException)
                erro = "Não é possivel divisão por zero ";
            else if (t.Exception is NullReferenceException)
                erro = "Referência para um objeto não encontrado.";
                


            result = MessageBox.Show(erro, "Erro da Aplicação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (result == DialogResult.Abort)
                Application.Exit();
        }
    }
}
