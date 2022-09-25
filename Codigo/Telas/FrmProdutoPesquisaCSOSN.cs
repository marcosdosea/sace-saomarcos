using Dominio;
using Negocio;
using System;
using System.Globalization;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Telas
{
    public partial class FrmProdutoPesquisaCSON : Form
    {
        private String filtroNome;
        private String textoAtual;

        public bool ExibirTodos { get; set;}
        public ProdutoPesquisa ProdutoPesquisa { get; set; }
        
        
        public FrmProdutoPesquisaCSON(bool exibirTodos)
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            filtroNome = null;
            ExibirTodos = exibirTodos;
        }

        public FrmProdutoPesquisaCSON(String nome, bool exibirTodos)
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
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorNome(txtTexto.Text);
                }
                else
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorNome(txtTexto.Text);
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
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().Obter(int.Parse(txtTexto.Text));
                else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorReferenciaFabricante(txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 3) && !txtTexto.Text.Equals(""))
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorNomeProdutoFabricante(txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 4) && (txtTexto.Text.Length > 9))
                {
                    try
                    {
                        DateTime data = Convert.ToDateTime(txtTexto.Text);
                        // se conseguir converter para uma data válida ele faz a busca
                        produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorDataAtualizacaoMaiorIgual(data);
                    }
                    catch (Exception)
                    {
                        // qualquer problema a busca não é realizada
                    }

                }
                else if (cmbBusca.SelectedIndex == 5) // códigos de barra inválidos
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorCodigosBarraInvalidos();
                }
                else if (cmbBusca.SelectedIndex == 6) // códigos de barra inválidos
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorCodigosBarraEmBranco();
                }
                else if ((cmbBusca.SelectedIndex == 7) && (txtTexto.Text.Length > 9))
                {
                    try
                    {
                        DateTime data = Convert.ToDateTime(txtTexto.Text);
                        // se conseguir converter para uma data válida ele faz a busca
                        produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorDataMudancaPrecoMaiorIgual(data);
                    }
                    catch (Exception)
                    {
                        // qualquer problema a busca não é realizada
                    }

                }
                else
                {
                    if ((!txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length >= 1)) || ((txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length >= 1))))
                    {
                        if (ExibirTodos)
                            produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorNome(txtTexto.Text);
                        else
                            produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorNomeExibiveis(txtTexto.Text);
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
            else if (e.KeyCode == Keys.F7)
            {
                if (tb_produtoDataGridView.RowCount > 0)
                {
                    ProdutoPesquisa _produto = (ProdutoPesquisa) produtoBindingSource.Current;
                    FrmProdutoAjusteEstoque frmAjuste = new FrmProdutoAjusteEstoque(_produto);
                    frmAjuste.ShowDialog();
                    frmAjuste.Dispose();
                }
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
                    string ncmsh = tb_produtoDataGridView.Rows[i].Cells[2].Value.ToString();
                    string codigoEAN = "";
                    if (tb_produtoDataGridView.Rows[i].Cells[3].Value != null)
                        codigoEAN = tb_produtoDataGridView.Rows[i].Cells[3].Value.ToString();
                    GerenciadorProduto.GetInstance().AtualizarNcmshQtdAtacado(codProduto, nomeProduto, ncmsh, codigoEAN);
                }

            }
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Produtos atualizados com sucesso");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            string nomeArquivo = saveFileDialog.FileName;

            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "nomeProduto";
                xlWorkSheet.Cells[1, 2] = "codigoBarra";
                xlWorkSheet.Cells[1, 3] = "precoVendaAVista";
                xlWorkSheet.Cells[1, 4] = "precoVendaParcelado";

                for (int i = tb_produtoDataGridView.SelectedRows.Count - 1; i >= 0; i--)
                {
                    xlWorkSheet.Cells[i + 2, 1] = tb_produtoDataGridView.SelectedRows[i].Cells[1].Value; //nome produto
                    xlWorkSheet.Cells[i + 2, 2] = tb_produtoDataGridView.SelectedRows[i].Cells[3].Value; //código de barra

                    decimal quantidadeAtacado = (decimal)tb_produtoDataGridView.SelectedRows[i].Cells[6].Value;
                    if (quantidadeAtacado == 0)
                    {
                        xlWorkSheet.Cells[i + 2, 3] = "R$ " + formataValor((decimal)tb_produtoDataGridView.SelectedRows[i].Cells[4].Value); //preco venda varejo
                        xlWorkSheet.Cells[i + 2, 4] = "R$ " + formataValor((decimal)tb_produtoDataGridView.SelectedRows[i].Cells[5].Value); //preço venda varejo sem desconto
                    }
                    else
                    {
                        decimal precoVendaAtacado = (decimal)tb_produtoDataGridView.SelectedRows[i].Cells[7].Value;
                        xlWorkSheet.Cells[i + 2, 3] = "R$ " + formataValor(precoVendaAtacado * quantidadeAtacado);
                        decimal precoVendaAtacadoSemDesconto = (decimal)tb_produtoDataGridView.SelectedRows[i].Cells[8].Value;
                        xlWorkSheet.Cells[i + 2, 4] = "R$ " + formataValor(precoVendaAtacadoSemDesconto * quantidadeAtacado); //preço venda atacado sem desconto
                    }
                }


                xlWorkBook.SaveAs(nomeArquivo, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                        Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                liberarObjetos(xlWorkSheet);
                liberarObjetos(xlWorkBook);
                liberarObjetos(xlApp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}
