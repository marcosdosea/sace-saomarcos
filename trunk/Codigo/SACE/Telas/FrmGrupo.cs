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
    public partial class FrmGrupo : Form
    {
        private EstadoFormulario estado;

        public FrmGrupo()
        {
            InitializeComponent();
        }

        private void FrmGrupo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_grupo' table. You can move, or remove it, as needed.
            this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmGrupoPesquisa frmGrupoPesquisa = new Telas.FrmGrupoPesquisa();
            frmGrupoPesquisa.ShowDialog();
            if (frmGrupoPesquisa.getCodGrupo() != -1)
            {
                tb_grupoBindingSource.Position = tb_grupoBindingSource.Find("codGrupo", frmGrupoPesquisa.getCodGrupo());
            }
            frmGrupoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_grupoBindingSource.AddNew();
            codGrupoTextBox.Enabled = false;
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
                    tb_grupoTableAdapter.Delete(long.Parse(codGrupoTextBox.Text));
                    tb_grupoTableAdapter.Fill(saceDataSet.tb_grupo);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
                tb_grupoBindingSource.CancelEdit();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_grupoBindingSource.CancelEdit();
            tb_grupoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    tb_grupoTableAdapter.Insert(descricaoTextBox.Text);
                    tb_grupoTableAdapter.Fill(saceDataSet.tb_grupo);
                    tb_grupoBindingSource.MoveLast();
                }
                else
                {
                    tb_grupoTableAdapter.Update(descricaoTextBox.Text, long.Parse(codGrupoTextBox.Text));
                    tb_grupoBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_grupoBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            
            btnBuscar.Focus();
        }

        private void FrmGrupo_KeyDown(object sender, KeyEventArgs e)
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
                    tb_grupoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_grupoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_grupoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_grupoBindingSource.MoveNext();
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
            tb_grupoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
