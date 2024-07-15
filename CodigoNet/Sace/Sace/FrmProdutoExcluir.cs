using Dominio;
using Negocio;

namespace Sace
{
    public partial class FrmProdutoExcluir : Form
    {

        public FrmProdutoExcluir()
        {
            InitializeComponent();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            long codProdutoExcluir = ((Produto)produtoBindingSource.Current).CodProduto;
            long codProdutoManter =  ((Produto)produtoBindingSource1.Current).CodProduto;

            if (MessageBox.Show("Confirma exclusão do PRODUTO DO SISTEMA?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorProduto.SubstituirProduto(codProdutoExcluir, codProdutoManter);
                //produtoBindingSource.RemoveCurrent();
            }
            codProdutoComboBox.Focus();
        }

        private void FrmProdutoExcluir_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = GerenciadorProduto.ObterTodos();
            produtoBindingSource1.DataSource = produtoBindingSource.DataSource;
        }

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            EstadoFormulario estado = EstadoFormulario.INSERIR;
            ProdutoPesquisa _produtoPesquisa = ComponentesLeave.ProdutoComboBox_Leave(sender, e, codProdutoComboBox, estado, produtoBindingSource, true);
        }

        private void codProdutoComboBox1_Leave(object sender, EventArgs e)
        {
            EstadoFormulario estado = EstadoFormulario.INSERIR;
            ProdutoPesquisa _produtoPesquisa = ComponentesLeave.ProdutoComboBox_Leave(sender, e, codProdutoComboBox1, estado, produtoBindingSource1, true);
        }

        private void FrmProdutoExcluir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (codProdutoComboBox.Focused)
                {
                    codProdutoComboBox_Leave(sender, e);
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
