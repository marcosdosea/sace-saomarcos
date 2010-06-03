using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SACE.Excecoes;

namespace Telas
{
    internal class TratamentoException
    {
        public void TratarException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            string erro = t.Exception.Message;
            
            if (t.Exception is DivideByZeroException)
            {
                erro = "não é possivel divisão por 0";
            }
            
            try
            {
                result = MessageBox.Show(erro, "Erro da Aplicação", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Erro Fatal", "Erro Fatal", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            if (result == DialogResult.Abort)
                Application.Exit();
        }
    }
}
