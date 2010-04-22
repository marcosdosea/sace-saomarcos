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
    public partial class FrmUsuario : Form
    {
        private EstadoFormulario estado;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
            frmPessoaPesquisa.ShowDialog();
            if (frmPessoaPesquisa.getCodPessoa() != -1)
            {
                tb_pessoaBindingSource.Position = tb_pessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.getCodPessoa());
                codPessoaTextBox.Text = frmPessoaPesquisa.getCodPessoa().ToString();
            }
            frmPessoaPesquisa.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_usuarioBindingSource.CancelEdit();
            tb_usuarioBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    tb_usuarioTableAdapter.Insert(Convert.ToInt32(codPessoaTextBox.Text), loginTextBox.Text, senhaTextBox.Text, Convert.ToInt32(perfilComboBox.SelectedValue));
                    tb_usuarioTableAdapter.Fill(saceDataSet.tb_usuario);
                    tb_usuarioBindingSource.MoveLast();
                }
                else
                {
                    tb_usuarioTableAdapter.Update(loginTextBox.Text, senhaTextBox.Text, Convert.ToInt32(perfilComboBox.SelectedValue), Convert.ToInt32(codPessoaTextBox.Text));
                    tb_usuarioBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_usuarioBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_usuarioBindingSource.AddNew();
            codPessoaTextBox.Enabled = false;
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tb_usuarioTableAdapter.Delete(int.Parse(codPessoaTextBox.Text));
                    tb_usuarioTableAdapter.Fill(saceDataSet.tb_usuario);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_usuarioBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
