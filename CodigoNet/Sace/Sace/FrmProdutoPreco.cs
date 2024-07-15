using Dominio;
using Negocio;
using System.Globalization;

namespace Sace
{
    public partial class FrmProdutoPreco : Form
    {
        private string filtroNome;
        private string textoAtual;

        public bool ExibirTodos { get; set;}
        public ProdutoPesquisa ProdutoPesquisa { get; set; }

        public FrmProdutoPreco(bool exibirTodos)
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            filtroNome = null;
            ExibirTodos = exibirTodos;
        }

        public FrmProdutoPreco(String nome, bool exibirTodos)
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            filtroNome = nome;
            ExibirTodos = exibirTodos;
        }

        private void FrmProdutoPesquisaPreco_Load(object sender, EventArgs e)
        {
            cmbBusca.SelectedIndex = 0;

            if ((filtroNome != null) && (filtroNome.Length > 0))
            {
                textoAtual = filtroNome;
                txtTexto.Text = filtroNome;
                txtTexto.Select(filtroNome.Length + 1, filtroNome.Length + 1);
                if (ExibirTodos)
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.ObterPorNome(txtTexto.Text);
                }
                else
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.ObterPorNomeExibiveis(txtTexto.Text);
                }
            }
            else
            {
                textoAtual = "";
            }
           
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if ((txtTexto.Text.Trim().Length > 0) && (txtTexto.Text.Length > textoAtual.Length))
            {
                if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                    produtoBindingSource.DataSource = GerenciadorProduto.Obter(int.Parse(txtTexto.Text));
                else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.ObterPorReferenciaFabricante(txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 3) && !txtTexto.Text.Equals(""))
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.ObterPorNomeProdutoFabricante(txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 4) && (txtTexto.Text.Length > 9))
                {
                    try
                    {
                        DateTime data = Convert.ToDateTime(txtTexto.Text);
                        // se conseguir converter para uma data válida ele faz a busca
                        produtoBindingSource.DataSource = GerenciadorProduto.ObterPorDataAtualizacaoMaiorIgual(data);
                    }
                    catch (Exception)
                    {
                        // qualquer problema a busca não é realizada
                    }

                }
                else if (cmbBusca.SelectedIndex == 5) // códigos de barra inválidos
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.ObterPorCodigosBarraInvalidos();
                }
                else if (cmbBusca.SelectedIndex == 6) // códigos de barra inválidos
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.ObterPorCodigosBarraEmBranco();
                }
                else if ((cmbBusca.SelectedIndex == 7) && (txtTexto.Text.Length > 9))
                {
                    try
                    {
                        DateTime data = Convert.ToDateTime(txtTexto.Text);
                        // se conseguir converter para uma data válida ele faz a busca
                        produtoBindingSource.DataSource = GerenciadorProduto.ObterPorDataMudancaPrecoMaiorIgual(data);
                    }
                    catch (Exception)
                    {
                        // qualquer problema a busca não é realizada
                    }

                }
                else if ((cmbBusca.SelectedIndex == 8) && (txtTexto.Text.Length > 0))
                {
                    long codFabricante = long.Parse(txtTexto.Text);
                    produtoBindingSource.DataSource = GerenciadorProduto.ObterPorCodigoFabricante(codFabricante);
                }
                else
                {
                    if ((!txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length >= 1)) || ((txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length >= 1))))
                    {
                        if (ExibirTodos)
                            produtoBindingSource.DataSource = GerenciadorProduto.ObterPorNome(txtTexto.Text);
                        else
                            produtoBindingSource.DataSource = GerenciadorProduto.ObterPorNomeExibiveis(txtTexto.Text);
                    }
                }
                            }
            textoAtual = txtTexto.Text;

            if (produtoBindingSource.Count > 0)
            {
                ProdutoPesquisa produto = (ProdutoPesquisa) produtoBindingSource.Current;
                }
            Cursor.Current = Cursors.Default;
        }

        private void tb_produtoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tb_produtoDataGridView.RowCount > 0)
            {
                ProdutoPesquisa = (ProdutoPesquisa) produtoBindingSource.Current;
            }
            this.Close();
        }

        private void FrmProdutoPesquisaPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_produtoDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                produtoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                produtoBindingSource.MovePrevious();
            }
            else if ((e.KeyCode == Keys.PageDown) && (txtTexto.Focused))
            {
                produtoBindingSource.Position += 15;
            }
            else if ((e.KeyCode == Keys.PageUp) && (txtTexto.Focused))
            {
                produtoBindingSource.Position -= 15;
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnEstatistica_Click(sender, e);
            }
        }


        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBusca.SelectedIndex == 0)
            {
                label2.Text = "Descrição do Produto";
            }
            else if (cmbBusca.SelectedIndex == 1)
            {
                label2.Text = "Código do Produto:";
            }
            else if (cmbBusca.SelectedIndex == 2)
            {
                label2.Text = "Referência do Fabricante:";
            
            }
            else if (cmbBusca.SelectedIndex == 3)
            {
                label2.Text = "Nome do Produto conforme Fabricante:";
                }
            else if (cmbBusca.SelectedIndex == 4)
            {
                label2.Text = "Data de Atualizacão Maior que (aaaa-mm-dd):";
            }
            else if ((cmbBusca.SelectedIndex == 5) || (cmbBusca.SelectedIndex == 6))
            {
                label2.Text = "Digite um caractere para iniciar a pesquisa";
            }
            else if (cmbBusca.SelectedIndex == 7)
            {
                label2.Text = "Data Mudança Preço Etiqueta Maior que (aaaa-mm-dd):";
            }
            else if (cmbBusca.SelectedIndex == 8)
            {
                label2.Text = "Código do Fabricante do Produto:";
            }
            txtTexto.Text = "";
        }
        
        private void tb_produtoDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((tb_produtoDataGridView.RowCount > 0) && (tb_produtoDataGridView.SelectedRows.Count > 0))
            {
                Int32 codProduto = int.Parse(tb_produtoDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (tb_produtoDataGridView.RowCount > 0)
            {
                for (int i = 0; i < tb_produtoDataGridView.RowCount; i++)
                {
                    long codProduto = Convert.ToInt64( tb_produtoDataGridView.Rows[i].Cells[0].Value );
                    string nomeProduto = tb_produtoDataGridView.Rows[i].Cells[1].Value.ToString();
                    decimal precoVarejo = Decimal.Parse(tb_produtoDataGridView.Rows[i].Cells[4].Value.ToString());
                    decimal precoAtacado = Decimal.Parse(tb_produtoDataGridView.Rows[i].Cells[5].Value.ToString());
                    decimal precoRevenda = Decimal.Parse(tb_produtoDataGridView.Rows[i].Cells[6].Value.ToString());
                    GerenciadorProduto.AtualizarPrecoVarejoAtacado(codProduto, nomeProduto, precoVarejo, precoAtacado, precoRevenda);
                }

            }
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Produtos atualizados com sucesso");
        }

        
        private string formataValor(decimal? valor)
        {
            try
            {
                if (valor == null)
                    valor = 0;

                return ((decimal)valor).ToString("0.00", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void liberarObjetos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            if (tb_produtoDataGridView.RowCount > 0)
            {
                ProdutoPesquisa _produto = (ProdutoPesquisa)produtoBindingSource.Current;
                FrmProdutoEstatistica frmEstatistica = new FrmProdutoEstatistica(_produto.CodProduto);
                frmEstatistica.ShowDialog();
                frmEstatistica.Dispose();
            }
        }
    }
}
