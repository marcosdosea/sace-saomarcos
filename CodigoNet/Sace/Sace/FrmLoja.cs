using Dados;
using Dominio;
using Negocio;
using Util;

namespace Sace
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
            pessoaBindingSource.DataSource = GerenciadorPessoa.ObterPorTipoPessoa(Pessoa.PESSOA_JURIDICA);
            lojaBindingSource.DataSource = GerenciadorLoja.ObterTodos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmLojaPesquisa frmLojaPesquisa = new FrmLojaPesquisa();
            frmLojaPesquisa.ShowDialog();
            if (frmLojaPesquisa.LojaSelected != null)
            {
                lojaBindingSource.Position = lojaBindingSource.List.IndexOf(frmLojaPesquisa.LojaSelected);
            }
            frmLojaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            lojaBindingSource.AddNew();
            codPessoaComboBox.SelectedIndex = 1;
            Loja loja = (Loja)lojaBindingSource.Current;
            loja.CodPessoa = ((Pessoa)pessoaBindingSource.Current).CodPessoa;
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
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorLoja.Remover(int.Parse(codLojaTextBox.Text));
                lojaBindingSource.RemoveCurrent();
            }
            btnBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lojaBindingSource.CancelEdit();
            lojaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Loja loja = (Loja)lojaBindingSource.Current;

                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    long codLoja = GerenciadorLoja.Inserir(loja);
                    codLojaTextBox.Text = codLoja.ToString();
                }
                else
                {
                    GerenciadorLoja.Atualizar(loja);
                }
                lojaBindingSource.EndEdit();
            }
            catch (DadosException de)
            {
                lojaBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
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
                    lojaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    lojaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    lojaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    lojaBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{tab}");
                }
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }

                else if ((e.KeyCode == Keys.F2) && (codPessoaComboBox.Focused))
                {
                    FrmPessoaPesquisa frmPessoaPesquisa = new FrmPessoaPesquisa(Pessoa.PESSOA_JURIDICA);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codPessoaComboBox.Focused))
                {
                    FrmPessoa frmPessoa = new FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.PessoaSelected != null)
                    {
                        pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoa.PessoaSelected);
                    }
                    frmPessoa.Dispose();
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

        private void codPessoaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codPessoaComboBox_Leave(object sender, EventArgs e)
        {
            ComponentesLeave.PessoaComboBox_Leave(sender, e, codPessoaComboBox, estado, pessoaBindingSource, true, true);
        }

        private void nomeTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }
    }
}
