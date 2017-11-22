using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Telas
{
    public partial class FrmSaidaPagamentoBoleto : Form
    {
        public FrmSaidaPagamentoBoleto(String cupomFiscal)
        {
            List<SaidaPesquisa> saidas = GerenciadorSaida.GetInstance(null).ObterPorCupomFiscal(cupomFiscal);
            if (saidas.Count > 0)
            {
                SaidaPesquisa saida = saidas.FirstOrDefault();
                if (saida.CodCliente == Util.Global.CLIENTE_PADRAO)
                {
                    throw new TelaException("Não é possível cadastrar boleto. Boletos devem ser associados a clientes.");
                }
                InitializeComponent();
                nomeClienteTextBox.Text = saida.NomeCliente;
                cupomFiscalTextBox.Text = saida.CupomFiscal;
                dataEmissaoCupomFiscalDateTimePicker.Value = saida.DataSaida;
                totalTextBox.Text = saidas.Sum(s => s.TotalAVista).ToString("N2");
                dataVencimentoDateTimePicker.Value = DateTime.Now.AddDays(7);
                valorPagarTextBox.Text = totalTextBox.Text;
                numeroDocumentoTextBox.Text = saida.CupomFiscal + "/1";
            }
            
        }

        private void FrmSaidaPagamentoBoleto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            // Coloca o foco na grid caso ela não possua
            else if ((e.KeyCode == Keys.F12) && (contaDataGridView.Focused))
            {
                contaDataGridView.Focus();
            }
            else if (e.KeyCode == Keys.F12)
            {
                dataVencimentoDateTimePicker.Focus();
            }

            // permite excluir um contato quando o foco está na grid
            else if ((e.KeyCode == Keys.Delete) && (contaDataGridView.Focused == true))
            {
                ExcluirBoleto(sender, e);
            }


            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void ExcluirBoleto(object sender, EventArgs e)
        {

        }
    }
}
