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
            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).Obter(saida.CodSaida);
            List<Loja> listaLojas = GerenciadorLoja.GetInstance().ObterTodos();
            lojaBindingSourceDestino.DataSource = listaLojas;
            lojaBindingSourceOrigem.DataSource = listaLojas;
            codPessoaComboBoxOrigem.SelectedIndex = 0;
            codPessoaComboBoxDestino.SelectedIndex = 1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            saida.CodProfissional = Global.CLIENTE_PADRAO;
            saida.CodCliente = long.Parse(codPessoaComboBoxDestino.SelectedValue.ToString());
            saida.Desconto = 0;
            saida.Total = decimal.Parse(totalTextBox.Text);

            GerenciadorSaida.GetInstance(null).Atualizar(saida);
            if (MessageBox.Show("Confirma transferência para depósito?", "Confirmar Transferência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorSaida.GetInstance(null).Encerrar(saida.CodSaida, Saida.TIPO_SAIDA_DEPOSITO);

                FrmSaidaNFe frmSaidaNF = new FrmSaidaNFe(saida.CodSaida);
                frmSaidaNF.ShowDialog();
                frmSaidaNF.Dispose();

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