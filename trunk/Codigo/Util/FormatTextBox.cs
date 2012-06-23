using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Util
{
    public static class FormatTextBox
    {
        public static void NumeroCom2CasasDecimais(TextBox textBox)
        {
            try
            {
                decimal numero = decimal.Parse(textBox.Text);
                textBox.Text = numero.ToString("N2");
            }
            catch (Exception)
            {
                textBox.Focus();
                textBox.Text = "1,00";
               throw new UtilException("O valor digitado não é um número válido.");
            }
        }

        public static void NumeroCom3CasasDecimais(TextBox textBox)
        {
            try
            {
                decimal numero = decimal.Parse(textBox.Text);
                textBox.Text = numero.ToString("N3");
            }
            catch (Exception)
            {
                textBox.Focus();
                throw new UtilException("O valor digitado não é um número válido.");
            }
        }

    }
}
