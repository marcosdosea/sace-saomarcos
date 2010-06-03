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
    public partial class FrmLoja : Form
    {
        private EstadoFormulario estado;

        public FrmLoja()
        {
            InitializeComponent();
        }

        private void FrmLoja_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_loja' table. You can move, or remove it, as needed.
            this.tb_lojaTableAdapter.Fill(this.saceDataSet.tb_loja);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmLojaPesquisa frmLojaPesquisa = new Telas.FrmLojaPesquisa();
            frmLojaPesquisa.ShowDialog();
            if (frmLojaPesquisa.getCodLoja() != -1)
            {
                tb_lojaBindingSource.Position = tb_lojaBindingSource.Find("codLoja", frmLojaPesquisa.getCodLoja());
            }
            frmLojaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_lojaBindingSource.AddNew();
            codLojaTextBox.Enabled = false;
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
                    tb_lojaTableAdapter.Delete(int.Parse(codLojaTextBox.Text));
                    tb_lojaTableAdapter.Fill(saceDataSet.tb_loja);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
                tb_lojaBindingSource.CancelEdit();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_lojaBindingSource.CancelEdit();
            tb_lojaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    tb_lojaTableAdapter.Insert(nomeTextBox.Text, cnpjTextBox.Text, ieTextBox.Text, enderecoTextBox.Text,
                        bairroTextBox.Text, cepTextBox.Text, cidadeTextBox.Text, ufTextBox.Text, foneTextBox.Text);
                    
                    tb_lojaTableAdapter.Fill(saceDataSet.tb_loja);
                    tb_lojaBindingSource.MoveLast();
                }
                else
                {
                    tb_lojaTableAdapter.Update(nomeTextBox.Text, cnpjTextBox.Text, ieTextBox.Text, enderecoTextBox.Text,
                        bairroTextBox.Text, cepTextBox.Text, cidadeTextBox.Text, ufTextBox.Text, foneTextBox.Text, int.Parse(codLojaTextBox.Text));
                    tb_lojaBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_lojaBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void FrmLoja_KeyDown(object sender, KeyEventArgs e)
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
                    tb_lojaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_lojaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_lojaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_lojaBindingSource.MoveNext();
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
            tb_lojaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
