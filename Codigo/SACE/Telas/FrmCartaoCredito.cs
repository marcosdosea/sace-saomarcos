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
    public partial class FrmCartaoCredito : Form
    {
        private EstadoFormulario estado;

        public FrmCartaoCredito()
        {
            InitializeComponent();
        }

        private void FrmCartaoCredito_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_conta_banco' table. You can move, or remove it, as needed.
            this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
            // TODO: This line of code loads data into the 'saceDataSet.tb_cartao_credito' table. You can move, or remove it, as needed.
            this.tb_cartao_creditoTableAdapter.Fill(this.saceDataSet.tb_cartao_credito);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmCartaoCreditoPesquisa frmCartaoCreditoPesquisa = new Telas.FrmCartaoCreditoPesquisa();
            frmCartaoCreditoPesquisa.ShowDialog();
            if (frmCartaoCreditoPesquisa.getCodCartaoCredito() != -1)
            {
                tb_cartao_creditoBindingSource.Position = tb_cartao_creditoBindingSource.Find("codCartaoCredito", frmCartaoCreditoPesquisa.getCodCartaoCredito());
            }
            frmCartaoCreditoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_cartao_creditoBindingSource.AddNew();
            codCartaoTextBox.Enabled = false;
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tb_cartao_creditoTableAdapter.Delete(int.Parse(codCartaoTextBox.Text));
                    tb_cartao_creditoTableAdapter.Fill(saceDataSet.tb_cartao_credito);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
                tb_cartao_creditoBindingSource.CancelEdit();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_cartao_creditoBindingSource.CancelEdit();
            tb_cartao_creditoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    
                    tb_cartao_creditoTableAdapter.Insert(nomeTextBox.Text, int.Parse(diaBaseTextBox.Text),
                        long.Parse(codContaBancoComboBox.SelectedValue.ToString().Trim()));
                    tb_cartao_creditoTableAdapter.Fill(saceDataSet.tb_cartao_credito);
                    tb_conta_bancoTableAdapter.Fill(saceDataSet.tb_conta_banco);
                    tb_cartao_creditoBindingSource.MoveLast();
                }
                else
                {
                    tb_cartao_creditoTableAdapter.Update(nomeTextBox.Text, int.Parse(diaBaseTextBox.Text),
                        long.Parse(codContaBancoComboBox.SelectedValue.ToString().Trim()), int.Parse(codCartaoTextBox.Text));
                    tb_cartao_creditoBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_cartao_creditoBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void FrmCartaoCredito_KeyDown(object sender, KeyEventArgs e)
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
                    tb_cartao_creditoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_cartao_creditoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_cartao_creditoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_cartao_creditoBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codContaBancoComboBox.Focused))
                {
                    Telas.FrmContaBancoPesquisa frmContaBancoPesquisa = new Telas.FrmContaBancoPesquisa();
                    frmContaBancoPesquisa.ShowDialog();
                    if (frmContaBancoPesquisa.getCodContaBanco() != -1)
                    {
                        tbcontabancoBindingSource.Position = tbcontabancoBindingSource.Find("codContaBanco", frmContaBancoPesquisa.getCodContaBanco());
                    }
                    frmContaBancoPesquisa.Dispose();
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
            tb_cartao_creditoBindingNavigator.Enabled = habilita;
            codContaBancoComboBox.Enabled = !(habilita);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

    }
}
