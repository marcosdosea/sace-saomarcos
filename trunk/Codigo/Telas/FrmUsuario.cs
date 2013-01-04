using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Util;

namespace Telas
{
    public partial class FrmUsuario : Form
    {
        private EstadoFormulario estado;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.USUARIOS, Principal.Autenticacao.CodUsuario);

            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_perfilTableAdapter.Fill(this.saceDataSet.tb_perfil);
            this.tb_usuarioTableAdapter.Fill(this.saceDataSet.tb_usuario);
            tb_pessoaBindingSource.Find("codPessoa", -1);

            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
            //frmPessoaPesquisa.ShowDialog();
            //if (frmPessoaPesquisa.CodPessoa != -1)
            //{
            //    tb_pessoaBindingSource.Position = tb_pessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
            //    tb_usuarioBindingSource.Position = tb_usuarioBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
            //    codPessoaTextBox.Text = frmPessoaPesquisa.CodPessoa.ToString();
            //}
            //frmPessoaPesquisa.Dispose();
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
            if (senhaTextBox.Text != confirmarSenhaTextBox.Text)
            {
                MessageBox.Show("Senha/Usuário inválidos");
                tb_usuarioBindingSource.CancelEdit();
                return;
            }
            habilitaBotoes(true);
            btnBuscar.Focus();

            Usuario usuario = new Usuario();
            usuario.CodPessoa = Convert.ToInt32(codPessoaComboBox.SelectedValue);
            usuario.Login = loginTextBox.Text;
            usuario.Senha = senhaTextBox.Text;
            usuario.CodPerfil = Convert.ToInt32(perfilComboBox.SelectedValue);

            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                GerenciadorUsuario.getInstace().inserir(usuario);
                tb_usuarioTableAdapter.Fill(saceDataSet.tb_usuario);
                tb_usuarioBindingSource.MoveLast();
            }
            else
            {
                GerenciadorUsuario.getInstace().atualizar(usuario);
                tb_usuarioBindingSource.EndEdit();
            }


        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            codPessoaComboBox.Focus();
            tb_usuarioBindingSource.AddNew();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
            codPessoaComboBox.SelectedIndex = 0;
            perfilComboBox.SelectedIndex = 0;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                GerenciadorUsuario.getInstace().remover(Convert.ToInt32(codPessoaComboBox.SelectedValue));
                tb_usuarioTableAdapter.Fill(saceDataSet.tb_usuario);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            loginTextBox.Focus();
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

        private void perfilComboBox_Leave(object sender, EventArgs e)
        {
            if (perfilComboBox.SelectedValue == null)
            {
                perfilComboBox.Focus();
                throw new TelaException("Uma perfil válido precisa ser selecionado.");
            }
        }

        private void codPessoaComboBox_Leave(object sender, EventArgs e)
        {
            if (codPessoaComboBox.SelectedValue == null)
            {
                codPessoaComboBox.Focus();
                throw new TelaException("Uma pessoa válida precisa ser selecionada.");
            }
        }

        private void FrmUsuario_KeyDown(object sender, KeyEventArgs e)
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
                    tb_usuarioBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_usuarioBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_usuarioBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_usuarioBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
                else if ((e.KeyCode == Keys.F2) && (codPessoaComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(Pessoa.PESSOA_JURIDICA);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tb_pessoaBindingSource.Position = tb_pessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codPessoaComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.CodPessoa > 0)
                    {
                        this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
                        tb_pessoaBindingSource.Position = tb_pessoaBindingSource.Find("codPessoa", frmPessoa.CodPessoa);
                    }
                    frmPessoa.Dispose();
                }
            }
        }

        private void loginTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }
    }
}