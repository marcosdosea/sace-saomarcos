using Dados;
using Dominio;
using Negocio;
using Util;

namespace Sace
{
    public partial class FrmBanco : Form
    {
        private EstadoFormulario estado;

        public Banco BancoSelected { get; set; }

        public FrmBanco()
        {
            InitializeComponent();
            BancoSelected = null;
        }

        private void FrmBanco_Load(object sender, EventArgs e)
        {
            bancoBindingSource.DataSource = GerenciadorBanco.ObterTodos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var frmBancoPesquisa = new FrmBancoPesquisa();
            frmBancoPesquisa.ShowDialog();
            if (frmBancoPesquisa.BancoSelected != null)
            {
                bancoBindingSource.Position = bancoBindingSource.List.IndexOf(frmBancoPesquisa.BancoSelected);
            }
            frmBancoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            bancoBindingSource.AddNew();
            codBancoTextBox.Enabled = false;
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
                GerenciadorBanco.Remover(int.Parse(codBancoTextBox.Text));
                bancoBindingSource.RemoveCurrent();
            }
            btnBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bancoBindingSource.CancelEdit();
            bancoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Banco banco = (Banco)bancoBindingSource.Current;

                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    int codBanco = (int)GerenciadorBanco.Inserir(banco);
                    codBancoTextBox.Text = codBanco.ToString();
                }
                else
                {
                    GerenciadorBanco.Atualizar(banco);
                }
                bancoBindingSource.EndEdit();
            }
            catch (DadosException de)
            {
                bancoBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                bancoBindingSource.ResumeBinding();
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmBanco_KeyDown(object sender, KeyEventArgs e)
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
                    bancoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    bancoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    bancoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    bancoBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
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
            tb_bancoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            BancoSelected = (Banco)bancoBindingSource.Current;
        }

        private void nomeTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }
    }
}
