using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Dominio;
using Negocio;
using Util;
using System.Windows.Forms;

namespace Telas
{
    public partial class FrmSaidaDeposito : Form
    {
        private Saida saida;

        public FrmSaidaDeposito(Saida saida)
        {
            InitializeComponent();
            this.saida = saida;
        }

        private void FrmSaidaDeposito_Load(object sender, EventArgs e)
        {
            codSaidaTextBox.Text = saida.CodSaida.ToString();

            this.tb_tipo_saidaTableAdapter.Fill(this.saceDataSet.tb_tipo_saida);
            this.tb_saidaTableAdapter.Fill(this.saceDataSet.tb_saida);
            this.tb_lojaTableAdapter.Fill(this.saceDataSet.tb_loja);
            tb_saidaBindingSource.Position = tb_saidaBindingSource.Find("codSaida", saida.CodSaida);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            saida.CodProfissional = Global.CLIENTE_PADRAO;
            saida.CodCliente = long.Parse(codPessoaComboBox1.SelectedValue.ToString());
            saida.Desconto = 0;
            saida.Total = decimal.Parse(totalTextBox.Text);

            GerenciadorSaida.GetInstance().Atualizar(saida);
            if (MessageBox.Show("Confirma transferência para depósito?", "Confirmar Transferência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorSaida.GetInstance().Encerrar(saida, Saida.TIPO_SAIDA_DEPOSITO);

                if (MessageBox.Show("Confirma Impressão da Nota Fiscal de transferência?", "Confirmar Transferência", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GerenciadorSaida.GetInstance().ImprimirNotaFiscal(saida);
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaidaDeposito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}