using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Data;
using Util;

namespace Sace
{
    public partial class FrmProdutoPesquisaPreco : Form
    {
        private string filtroNome;
        private string textoAtual;
        private bool ExibirTodos { get; set;}
        public ProdutoPesquisa ProdutoPesquisa { get; set; }
        IEnumerable<ProdutoPesquisa> listaProdutoBuffer;
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmProdutoPesquisaPreco(bool exibirTodos, DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            filtroNome = null;
            ExibirTodos = exibirTodos;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        public FrmProdutoPesquisaPreco(bool exibirTodos, String nome, DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            filtroNome = nome;
            ExibirTodos = exibirTodos;
        }

        private void FrmProdutoPesquisaPreco_Load(object sender, EventArgs e)
        {
            cmbBusca.SelectedIndex = 0;
            produtoBindingSource.SuspendBinding();

            if ((filtroNome != null) && (filtroNome.Length > 0))
            {
                textoAtual = filtroNome;
                txtTexto.Text = filtroNome;
                txtTexto.Select(filtroNome.Length + 1, filtroNome.Length + 1);
                if (ExibirTodos)
                {
                    produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorNome(txtTexto.Text);
                }
                else
                {
                    produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorNomeExibiveis(txtTexto.Text);

                }
                if (produtoBindingSource.Count > 0)
                {
                    ProdutoPesquisa produto = (ProdutoPesquisa)produtoBindingSource.Current;
                    produtoLojaBindingSource.DataSource = service.GerenciadorProdutoLoja.ObterPorProduto(produto.CodProduto);
                    listaProdutoBuffer = (IEnumerable<ProdutoPesquisa>)produtoBindingSource.DataSource;
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
                    produtoBindingSource.DataSource = service.GerenciadorProduto.Obter(int.Parse(txtTexto.Text));
                else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                {
                    produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorReferenciaFabricante(txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 3) && !txtTexto.Text.Equals(""))
                {
                    produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorNomeProdutoFabricante(txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 4) && (txtTexto.Text.Length > 9))
                {
                    try
                    {
                        DateTime data = Convert.ToDateTime(txtTexto.Text);
                        // se conseguir converter para uma data válida ele faz a busca
                        produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorDataAtualizacaoMaiorIgual(data);
                    }
                    catch (Exception)
                    {
                        // qualquer problema a busca não é realizada
                    }

                }
                else if ((cmbBusca.SelectedIndex == 6) && (txtTexto.Text.Length > 9))
                {
                    try
                    {
                        DateTime data = Convert.ToDateTime(txtTexto.Text);
                        // se conseguir converter para uma data válida ele faz a busca
                        produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorDataMudancaPrecoMaiorIgual(data);
                    }
                    catch (Exception)
                    {
                        // qualquer problema a busca não é realizada
                    }

                }
                else if ((cmbBusca.SelectedIndex == 7) && (txtTexto.Text.Length > 4))
                {
                    produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorCodigoBarra(txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 5) && (txtTexto.Text.Length > 3))
                {
                    produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorNcmsh(txtTexto.Text);
                }
                else
                {
                    if ((!txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length > 3)) || ((txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length > 2))))
                    {
                        if ((txtTexto.Text.Length == 4) || (listaProdutoBuffer == null) || listaProdutoBuffer.Count() == 0)
                        {
                            if (ExibirTodos)
                                produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorNome(txtTexto.Text);
                            else
                                produtoBindingSource.DataSource = service.GerenciadorProduto.ObterPorNomeExibiveis(txtTexto.Text);
                           
                        }
                        else if (txtTexto.Text.Length > 4)
                        {
                            if (txtTexto.Text[0] == '%')
                            {
                                produtoBindingSource.DataSource = listaProdutoBuffer.Where(p => p.Nome.Contains(txtTexto.Text.Remove(0, 1))).ToList();
                            }
                            else
                            {
                                produtoBindingSource.DataSource = listaProdutoBuffer.Where(p => p.Nome.StartsWith(txtTexto.Text)).ToList();
                            }
                        }
                        listaProdutoBuffer = (IEnumerable<ProdutoPesquisa>)produtoBindingSource.DataSource;
                    }
                }
            }
            else if (txtTexto.Text.Length < textoAtual.Length)
            {
               listaProdutoBuffer = null;
            }
            textoAtual = txtTexto.Text;
            

            if (produtoBindingSource.Count > 0)
            {
                ProdutoPesquisa produto = (ProdutoPesquisa) produtoBindingSource.Current;
                produtoLojaBindingSource.DataSource = service.GerenciadorProdutoLoja.ObterPorProduto(produto.CodProduto);
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
                    FrmProdutoAjusteEstoque frmAjuste = new FrmProdutoAjusteEstoque(_produto, saceOptions);
                    frmAjuste.ShowDialog();
                    frmAjuste.Dispose();
                    produtoLojaBindingSource.DataSource = service.GerenciadorProdutoLoja.ObterPorProduto(_produto.CodProduto);
                }
            }
            //else if (e.KeyCode == Keys.F9)
            //{
            //    ProdutoPesquisa _produto = (ProdutoPesquisa)produtoBindingSource.Current;
            //    _produto.CodSituacaoProduto = SituacaoProduto.DISPONIVEL;
            //    MudarSituacaoProduto(sender, e, _produto);
            //}
            //else if (e.KeyCode == Keys.F10)
            //{
            //    ProdutoPesquisa _produto = (ProdutoPesquisa)produtoBindingSource.Current;
            //    _produto.CodSituacaoProduto = SituacaoProduto.COMPRA_NECESSARIA;
            //    MudarSituacaoProduto(sender, e, _produto);
            //}
            //else if (e.KeyCode == Keys.F11)
            //{
            //    ProdutoPesquisa _produto = (ProdutoPesquisa)produtoBindingSource.Current;
            //    _produto.CodSituacaoProduto = SituacaoProduto.COMPRA_URGENTE;
            //    MudarSituacaoProduto(sender, e, _produto);
            //}
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
            else if (cmbBusca.SelectedIndex == 6)
            {
                label2.Text = "Data de Mudança de Preço Etiqueta Maior que (aaaa-mm-dd):";
            }
            txtTexto.Text = "";
        }
        
        private void tb_produtoDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((tb_produtoDataGridView.RowCount > 0) && (tb_produtoDataGridView.SelectedRows.Count > 0))
            {
                Int32 codProduto = int.Parse(tb_produtoDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                produtoLojaBindingSource.DataSource = service.GerenciadorProdutoLoja.ObterPorProduto(codProduto);
            }
        }

        
        private void DestacarProdutosEmPromocaoENaoExibiveis()
        {
            for (int i = 0; i < tb_produtoDataGridView.RowCount; i++)
            {
                bool emPromocao = Convert.ToBoolean(tb_produtoDataGridView.Rows[i].Cells[10].Value);
                bool exibirListagem = Convert.ToBoolean(tb_produtoDataGridView.Rows[i].Cells[11].Value);
                int codSituacaoProduto = Convert.ToInt32(tb_produtoDataGridView.Rows[i].Cells[12].Value);
                if (!exibirListagem)
                {
                    tb_produtoDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if (emPromocao)
                {
                    tb_produtoDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;

                }
                else
                {
                    tb_produtoDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

                if (codSituacaoProduto == SituacaoProduto.COMPRA_NECESSARIA)
                {
                    tb_produtoDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                }
                else if (codSituacaoProduto == SituacaoProduto.COMPRA_URGENTE)
                {
                    tb_produtoDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Red;
                }
                else if (codSituacaoProduto == SituacaoProduto.COMPRADO)
                {
                    tb_produtoDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Green;
                }
                else if (codSituacaoProduto == SituacaoProduto.NAO_COMPRAR)
                {
                    tb_produtoDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Black;
                    tb_produtoDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.White;
                }
                else
                {
                    tb_produtoDataGridView.Rows[i].Cells[0].Style.BackColor = Color.White;
                    tb_produtoDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                }


            }
        }

        private void MudarSituacaoProduto(object sender, EventArgs e, ProdutoPesquisa produto)
        {
            SolicitacoesCompra solicitacao = new SolicitacoesCompra();
            solicitacao.CodProduto = produto.CodProduto;
            solicitacao.CodSituacaoProduto = produto.CodSituacaoProduto;
                
            string mensagem = "";
            if (produto.CodSituacaoProduto == SituacaoProduto.COMPRA_NECESSARIA)
            {
                mensagem = "Confirma SOLICITAÇÃO DE COMPRA do produto?";
                solicitacao.DataSolicitacaoCompra = DateTime.Now;
            }
            else if (produto.CodSituacaoProduto == SituacaoProduto.COMPRA_URGENTE)
            {
                mensagem = "Confirma SOLICITAÇÃO DE COMPRA URGENTE do produto?";
                solicitacao.DataSolicitacaoCompra = DateTime.Now;
            }
            else 
            {
                mensagem = "Confirma que o produto possui DISPONIBILIDADE no estoque?";
            }
            if (MessageBox.Show(mensagem, "Confirmar Mudança Situação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                service.GerenciadorProduto.AtualizarSituacaoProduto(solicitacao, UtilConfig.Default.SERVIDOR_NFE);
                txtTexto_TextChanged(sender, e);
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
