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
            // TODO: This line of code loads data into the 'saceDataSet2.tb_tipo_conta' table. You can move, or remove it, as needed.
            this.tb_tipo_contaTableAdapter.Fill(this.saceDataSet2.tb_tipo_conta);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmGrupoContaPesquisa frmTipoContaPesquisa = new Telas.FrmGrupoContaPesquisa();
            frmTipoContaPesquisa.ShowDialog();
            if (frmTipoContaPesquisa.getCodTipoConta() != -1)
            {
                tb_tipo_contaBindingSource.MoveFirst();
                while (!codTipoContaTextBox.Text.Equals(frmTipoContaPesquisa.getCodTipoConta().ToString()))
                {
                    tb_tipo_contaBindingSource.MoveNext();
                }
            }
            frmTipoContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_tipo_contaBindingSource.AddNew();
            codTipoContaTextBox.Enabled = false;
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
                    tb_tipo_contaTableAdapter.Delete(int.Parse(codTipoContaTextBox.Text));
                    tb_tipo_contaTableAdapter.Fill(saceDataSet2.tb_tipo_conta);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_tipo_contaBindingSource.CancelEdit();
            tb_tipo_contaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    tb_tipo_contaTableAdapter.Insert(descricaoTextBox.Text);
                    tb_tipo_contaTableAdapter.Fill(saceDataSet2.tb_tipo_conta);
                    tb_tipo_contaBindingSource.MoveLast();
                }
                else
                {
                    tb_tipo_contaTableAdapter.Update(descricaoTextBox.Text, int.Parse(codTipoContaTextBox.Text));
                    tb_tipo_contaBindingSource.EndEdit();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
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
                    tb_tipo_contaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_tipo_contaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_tipo_contaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_tipo_contaBindingSource.MoveNext();
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
            tb_tipo_contaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
