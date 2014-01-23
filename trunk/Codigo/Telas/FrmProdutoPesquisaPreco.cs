using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using Dominio;
using Negocio;

namespace Telas
{
    public partial class FrmProdutoPesquisaPreco : Form
    {
        private String filtroNome;
        private String textoAtual;
        private DateTime horarioUltimaBusca;

        public bool ExibirTodos { get; set;}
        public ProdutoPesquisa ProdutoPesquisa { get; set; }
        
        
        public FrmProdutoPesquisaPreco(bool exibirTodos)
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            filtroNome = null;
            horarioUltimaBusca = DateTime.Now;
            ExibirTodos = exibirTodos;

        }

        public FrmProdutoPesquisaPreco(String nome, bool exibirTodos)
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
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorNomeExibiveis(txtTexto.Text);
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
                else if ((cmbBusca.SelectedIndex == 5) && (txtTexto.Text.Length > 3))
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorNcmsh(txtTexto.Text);
                }
                else
                {
                    if ((!txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length > 3)) || ((txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length > 2))))
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
                produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.GetInstance(null).ObterPorProduto(produto.CodProduto);
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
                    produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.GetInstance(null).ObterPorProduto(_produto.CodProduto);
                }
            }
        }


        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            // coluna do nome
            tb_produtoDataGridView.Columns[1].Visible = true;
            // coluna do nome conforme fabricante
            tb_produtoDataGridView.Columns[2].Visible = false;
                
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
                // coluna do nome
                tb_produtoDataGridView.Columns[1].Visible = false;
                // coluna do nome conforme fabricante
                tb_produtoDataGridView.Columns[2].Visible = true;
            }
            else if (cmbBusca.SelectedIndex == 4)
            {
                label2.Text = "Data de Atualizacão Maior que (aaaa-mm-dd):";
            }
            txtTexto.Text = "";
        }
        
        private void tb_produtoDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((tb_produtoDataGridView.RowCount > 0) && (tb_produtoDataGridView.SelectedRows.Count > 0))
            {
                Int32 codProduto = int.Parse(tb_produtoDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.GetInstance(null).ObterPorProduto(codProduto);
            }
        }

        
        private void DestacarProdutosEmPromocaoENaoExibiveis()
        {
            for (int i = 0; i < tb_produtoDataGridView.RowCount; i++)
            {
                bool emPromocao = Convert.ToBoolean(tb_produtoDataGridView.Rows[i].Cells[10].Value);
                bool exibirListagem = Convert.ToBoolean(tb_produtoDataGridView.Rows[i].Cells[11].Value);
                if (!exibirListagem)
                {
                    tb_produtoDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if (emPromocao)
                {
                    tb_produtoDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Wheat;

                }
                else
                {
                    tb_produtoDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void tb_produtoDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DestacarProdutosEmPromocaoENaoExibiveis();
        }

        private void tb_produtoDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DestacarProdutosEmPromocaoENaoExibiveis();
        }
    }
}
