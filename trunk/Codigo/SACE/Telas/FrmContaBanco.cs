using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SACE.Telas
{
    public partial class FrmContaBanco : Form
    {
        private EstadoFormulario estado;

        public FrmContaBanco()
        {
            InitializeComponent();
        }

        private void FrmContaBanco_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_banco' table. You can move, or remove it, as needed.
            this.tb_bancoTableAdapter.Fill(this.saceDataSet.tb_banco);
            // TODO: This line of code loads data into the 'saceDataSet.tb_conta_Banco' table. You can move, or remove it, as needed.
            this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmContaBancoPesquisa frmContaBancoPesquisa = new Telas.FrmContaBancoPesquisa();
            frmContaBancoPesquisa.ShowDialog();
            if (frmContaBancoPesquisa.getCodContaBanco() != -1)
            {
                tb_conta_bancoBindingSource.MoveFirst();
                while (!codContaBancoTextBox.Text.Equals(frmContaBancoPesquisa.getCodContaBanco().ToString()))
                {
                    tb_conta_bancoBindingSource.MoveNext();
                }
            }
            frmContaBancoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_conta_bancoBindingSource.AddNew();
            codContaBancoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codContaBancoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tb_conta_bancoTableAdapter.Delete(codContaBancoTextBox.Text);
                    tb_conta_bancoTableAdapter.Fill(saceDataSet.tb_conta_banco);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_conta_bancoBindingSource.CancelEdit();
            tb_conta_bancoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    if (codBancoComboBox.SelectedValue != null)
                        tb_conta_bancoTableAdapter.Insert(codContaBancoTextBox.Text,
                            agenciaTextBox.Text, descricaoTextBox.Text, decimal.Parse(saldoTextBox.Text), int.Parse(codBancoComboBox.SelectedValue.ToString()));
                    else
                        tb_conta_bancoTableAdapter.Insert(codContaBancoTextBox.Text,
                            agenciaTextBox.Text, descricaoTextBox.Text, decimal.Parse(saldoTextBox.Text), null);
                    tb_conta_bancoTableAdapter.Fill(saceDataSet.tb_conta_banco);
                    tb_conta_bancoBindingSource.MoveLast();
                }
                else
                {
                    tb_conta_bancoTableAdapter.Update(codContaBancoTextBox.Text, 
                        agenciaTextBox.Text, descricaoTextBox.Text, decimal.Parse(saldoTextBox.Text), int.Parse(codBancoComboBox.SelectedValue.ToString()), codContaBancoTextBox.Text);
                    tb_conta_bancoBindingSource.EndEdit();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void FrmContaBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnExcluir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_conta_bancoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_conta_bancoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_conta_bancoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_conta_bancoBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
            }
        }
        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_conta_bancoBindingNavigator.Enabled = habilita;
            codBancoComboBox.Enabled = !(habilita);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
