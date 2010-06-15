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
    public partial class FrmGrupoConta : Form
    {
        private EstadoFormulario estado;

        public FrmGrupoConta()
        {
            InitializeComponent();
        }

        private void FrmGrupoConta_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_grupo_conta' table. You can move, or remove it, as needed.
            this.tb_grupo_contaTableAdapter.Fill(this.saceDataSet.tb_grupo_conta);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmGrupoContaPesquisa frmTipoContaPesquisa = new Telas.FrmGrupoContaPesquisa();
            frmTipoContaPesquisa.ShowDialog();
            if (frmTipoContaPesquisa.getCodTipoConta() != -1)
            {
                tb_grupo_contaBindingSource.Position = tb_grupo_contaBindingSource.Find("codGrupoConta", frmTipoContaPesquisa.getCodTipoConta());
            }
            frmTipoContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_grupo_contaBindingSource.AddNew();
            codGrupoContaTextBox.Enabled = false;
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
                    tb_grupo_contaTableAdapter.Delete(int.Parse(codGrupoContaTextBox.Text));
                    tb_grupo_contaTableAdapter.Fill(saceDataSet.tb_grupo_conta);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
                tb_grupo_contaBindingSource.CancelEdit();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_grupo_contaBindingSource.CancelEdit();
            tb_grupo_contaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    tb_grupo_contaTableAdapter.Insert(descricaoTextBox.Text);
                    tb_grupo_contaTableAdapter.Fill(saceDataSet.tb_grupo_conta);
                    tb_grupo_contaBindingSource.MoveLast();
                }
                else
                {
                    tb_grupo_contaTableAdapter.Update(descricaoTextBox.Text, int.Parse(codGrupoContaTextBox.Text));
                    tb_grupo_contaBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_grupo_contaBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void FrmGrupoConta_KeyDown(object sender, KeyEventArgs e)
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
                    tb_grupo_contaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_grupo_contaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_grupo_contaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_grupo_contaBindingSource.MoveNext();
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
            tb_grupo_contaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
