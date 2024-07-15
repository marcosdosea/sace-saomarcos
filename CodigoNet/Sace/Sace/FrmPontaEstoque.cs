using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;
using Util;

namespace Sace
{
    public partial class FrmPontaEstoque : Form
    {
        private EstadoFormulario estado;
        public ProdutoPesquisa ProdutoSelected { get; set; }
        private IEnumerable<ProdutoPesquisa> bufferListaProdutos;

        public FrmPontaEstoque(ProdutoPesquisa _produto)
        {
            InitializeComponent();
            ProdutoSelected = _produto;
        }

        private void FrmPontaEstoque_Load(object sender, EventArgs e)
        {
            bufferListaProdutos = GerenciadorProduto.ObterTodos();
            produtoBindingSource.DataSource = bufferListaProdutos;
            produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new Produto() { CodProduto = ProdutoSelected.CodProduto });
            produtoBindingSource.ResumeBinding();
            ProdutoSelected  = (ProdutoPesquisa) produtoBindingSource.Current;
            habilitaBotoes(true);
        }

        
        private void btnNovo_Click(object sender, EventArgs e)
        {
            
            PontaEstoque pontaEstoque = new PontaEstoque();
            pontaEstoque.CodProduto = ProdutoSelected.CodProduto;
            pontaEstoque.NomeProduto = ProdutoSelected.Nome;
            pontaEstoque.Quantidade = 1;

            pontaEstoqueBindingSource.Position = pontaEstoqueBindingSource.Add(pontaEstoque);
            quantidadeTextBox.Focus();
            habilitaBotoes(false);
            pontaEstoqueBindingSource.ResumeBinding();
            estado = EstadoFormulario.INSERIR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pontaEstoqueBindingSource.CancelEdit();
            pontaEstoqueBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                PontaEstoque pontaEstoque = (PontaEstoque)pontaEstoqueBindingSource.Current;

                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    GerenciadorPontaEstoque.Inserir(pontaEstoque);
                }
                pontaEstoqueBindingSource.EndEdit();
                pontaEstoqueDataGridView.DataSource = GerenciadorPontaEstoque.ObterPorProduto(ProdutoSelected.CodProduto);
            }
            catch (DadosException de)
            {
                pontaEstoqueBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnNovo.Focus();
            }
        }

        private void FrmPontaEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    produtoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    produtoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    produtoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    produtoBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                // Coloca o foco na grid caso ela não possua
                if (e.KeyCode == Keys.F12)
                {
                    pontaEstoqueDataGridView.Focus();
                }
                // permite excluir um contato quando o foco está na grid
                else if ((e.KeyCode == Keys.Delete) && (pontaEstoqueDataGridView.Focused == true))
                {
                    excluirPontaEstoque(sender, e);
                }

            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{tab}");
                } else if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
            }

        }

        private void excluirPontaEstoque(object sender, KeyEventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão dessa Ponta de Estoque?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (pontaEstoqueDataGridView.Rows.Count > 0)
                {
                    int codPontaEstoque = int.Parse(pontaEstoqueDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    GerenciadorPontaEstoque.Remover(codPontaEstoque);
                }
            }
            pontaEstoqueDataGridView.DataSource = GerenciadorPontaEstoque.ObterPorProduto(ProdutoSelected.CodProduto);
            btnNovo.Focus();
        }

        
        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void nomeTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmProdutoPesquisaPreco frmProdutoPesquisa = new FrmProdutoPesquisaPreco(true);
            frmProdutoPesquisa.ShowDialog();
            if (frmProdutoPesquisa.ProdutoPesquisa != null)
            {
                produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new Produto() { CodProduto = frmProdutoPesquisa.ProdutoPesquisa.CodProduto });
                produtoBindingSource.ResumeBinding();
                ProdutoSelected = (ProdutoPesquisa)produtoBindingSource.Current;
                habilitaBotoes(true);
            }
            frmProdutoPesquisa.Dispose();
            btnNovo.Focus();

        }

        private void codProdutoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(codProdutoTextBox.Text))
                pontaEstoqueDataGridView.DataSource = GerenciadorPontaEstoque.ObterPorProduto(Convert.ToInt64(codProdutoTextBox.Text));
        }

    }
}
