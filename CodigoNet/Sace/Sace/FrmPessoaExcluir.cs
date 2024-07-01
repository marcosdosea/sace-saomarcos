using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmPessoaExcluir : Form
    {
        EstadoFormulario estado = EstadoFormulario.ESPERA;
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmPessoaExcluir(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            var context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            long codPessoaExcluir = ((Pessoa)pessoaBindingSource.Current).CodPessoa;
            long codPessoaManter =  ((Pessoa)pessoaBindingSource1.Current).CodPessoa;

            if (MessageBox.Show("Confirma exclusão da PESSOA DO SISTEMA?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gerenciadorPessoa.SubstituirPessoa(codPessoaExcluir, codPessoaManter);
                pessoaBindingSource.RemoveCurrent();
            }
            codPessoaComboBox.Focus();
        }

        private void FrmPessoaExcluir_Load(object sender, EventArgs e)
        {
            pessoaBindingSource.DataSource = gerenciadorPessoa.ObterTodos();
            pessoaBindingSource1.DataSource = pessoaBindingSource.DataSource;
        }

        private void codPessoaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void codPessoaComboBox_Leave(object sender, EventArgs e)
        {
            Pessoa _pessoaPesquisa = ComponentesLeave.PessoaComboBox_Leave(sender, e, codPessoaComboBox, estado, pessoaBindingSource, true, false, service);
        }

        private void codPessoaComboBox1_Leave(object sender, EventArgs e)
        {
            Pessoa _pessoaPesquisa = ComponentesLeave.PessoaComboBox_Leave(sender, e, codPessoaComboBox1, estado, pessoaBindingSource1, true, false, service);
        }

        private void FrmPessoaExcluir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (codPessoaComboBox.Focused)
                {
                    codPessoaComboBox_Leave(sender, e);
                }
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnExcluir_Click(sender, e);
            }

        }
    }
}
