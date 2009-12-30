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
    public partial class FrmPlanoConta : Form
    {
        private EstadoFormulario estado;

        public FrmPlanoConta()
        {
            InitializeComponent();
        }

        private void FrmPlanoConta_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_plano_conta' table. You can move, or remove it, as needed.
            this.tb_plano_contaTableAdapter.Fill(this.saceDataSet.tb_plano_conta);
            this.tb_grupo_contaTableAdapter.Fill(this.saceDataSet.tb_grupo_conta);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmPlanoContaPesquisa frmPlanoContaPesquisa = new Telas.FrmPlanoContaPesquisa();
            frmPlanoContaPesquisa.ShowDialog();
            if (frmPlanoContaPesquisa.getCodPlanoConta() != -1)
            {
                tb_plano_contaBindingSource.Position = tb_plano_contaBindingSource.Find("codPlanoConta", frmPlanoContaPesquisa.getCodPlanoConta());
            }
            frmPlanoContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_plano_contaBindingSource.AddNew();
            codPlanoContaTextBox.Enabled = false;
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tb_plano_contaTableAdapter.Delete(int.Parse(codPlanoContaTextBox.Text));
                    tb_plano_contaTableAdapter.Fill(saceDataSet.tb_plano_conta);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
                tb_plano_contaBindingSource.CancelEdit();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_plano_contaBindingSource.CancelEdit();
            tb_plano_contaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    tb_plano_contaTableAdapter.Insert(int.Parse(codGrupoContaComboBox.SelectedValue.ToString()), descricaoTextBox.Text, null, short.Parse(diaBaseTextBox.Text));
                    tb_plano_contaTableAdapter.Fill(saceDataSet.tb_plano_conta);
                    tb_plano_contaBindingSource.MoveLast();
                }
                else
                {
                    //tb_plano_contaTableAdapter.Update(descricaoTextBox.Text, tipoContaComboBox.SelectedValue.ToString(), short.Parse(diaBaseTextBox.Text), int.Parse(codPlanoContaTextBox.Text));
                    tb_plano_contaBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_plano_contaBindingSource.CancelEdit(); tb_plano_contaBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void FrmPlanoConta_KeyDown(object sender, KeyEventArgs e)
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
                    tb_plano_contaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_plano_contaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_plano_contaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_plano_contaBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codGrupoContaComboBox.Focused))
                {
                    Telas.FrmGrupoContaPesquisa frmGrupoContaPesquisa = new Telas.FrmGrupoContaPesquisa();
                    frmGrupoContaPesquisa.ShowDialog();
                    if (frmGrupoContaPesquisa.getCodTipoConta() != -1)
                    {
                        tbgrupocontaBindingSource.Position = tbgrupocontaBindingSource.Find("codTipoConta", frmGrupoContaPesquisa.getCodTipoConta());
                    }
                    frmGrupoContaPesquisa.Dispose();
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
            tb_plano_contaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
