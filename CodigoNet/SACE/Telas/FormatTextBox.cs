namespace Util
{
    public static class FormatTextBox
    {
        public static void NumeroCom2CasasDecimais(System.Windows.Forms.TextBox textBox)
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

        public static void RemoverAcentos(TextBox textBox)
        {
            try
            {
                string input = textBox.Text;
                if (string.IsNullOrEmpty(input))
                    textBox.Text = "";
                else
                {
                    byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(input);
                    textBox.Text = System.Text.Encoding.UTF8.GetString(bytes);
                }
            }
            catch (Exception)
            {
                textBox.Focus();
                throw new UtilException("Problemas na remoção de acentuação.");
            }
        }

    }
}
