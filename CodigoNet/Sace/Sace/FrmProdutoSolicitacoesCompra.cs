﻿using Dominio;
using Negocio;
using Util;

namespace Sace
{
    public partial class FrmProdutoSolicitacoesCompra : Form
    {

        public FrmProdutoSolicitacoesCompra()
        {
            InitializeComponent();
        }

        private void FrmProdutoEstatistica_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = GerenciadorProduto.ObterTodos();
            pessoaBindingSource.DataSource = GerenciadorPessoa.ObterTodos();

            if (MessageBox.Show("Deseja ANALISAR ESTOQUE para atualizar SOLICITAÇÕES DE COMPRA?", "Confirmar Análise Estoque", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                GerenciadorSaidaProduto.AtualizarSituacaoEstoqueProdutos();
                Cursor.Current = Cursors.Default;
            }
            comboBoxFornecedor_SelectedIndexChanged(sender, e);
        }



        private void FrmProdutoEstatistica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F8)
            {
                if (MessageBox.Show("Confirma NÃO COMPRAR produto para o Estoque?", "Confirmar Não Comprar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SolicitacoesCompra solicitacaoCompra = new SolicitacoesCompra();
                    solicitacaoCompra = (SolicitacoesCompra)solicitacoesCompraBindingSource.Current;
                    solicitacaoCompra.CodSituacaoProduto = SituacaoProduto.NAO_COMPRAR;
                    GerenciadorProduto.AtualizarSituacaoProduto(solicitacaoCompra, UtilConfig.Default.SERVIDOR_NFE);
                    comboBoxFornecedor_SelectedIndexChanged(sender, e);
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                if (MessageBox.Show("Confirma DISPONIBILIDADE do produto no Estoque?", "Confirmar Seleção Ponta Estoque", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SolicitacoesCompra solicitacaoCompra = new SolicitacoesCompra();
                    solicitacaoCompra = (SolicitacoesCompra)solicitacoesCompraBindingSource.Current;
                    solicitacaoCompra.CodSituacaoProduto = SituacaoProduto.DISPONIVEL;
                    GerenciadorProduto.AtualizarSituacaoProduto(solicitacaoCompra, UtilConfig.Default.SERVIDOR_NFE);
                    comboBoxFornecedor_SelectedIndexChanged(sender, e);
                }
            }
            else if (e.KeyCode == Keys.F10)
            {
                if (MessageBox.Show("Confirma SOLICITAÇÃO DE COMPRA do produto?", "Confirmar Solicitação de Compra", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SolicitacoesCompra solicitacaoCompra = new SolicitacoesCompra();
                    solicitacaoCompra = (SolicitacoesCompra)solicitacoesCompraBindingSource.Current;
                    solicitacaoCompra.CodSituacaoProduto = SituacaoProduto.COMPRA_NECESSARIA;
                    solicitacaoCompra.DataSolicitacaoCompra = DateTime.Now;
                    GerenciadorProduto.AtualizarSituacaoProduto(solicitacaoCompra, UtilConfig.Default.SERVIDOR_NFE);
                    comboBoxFornecedor_SelectedIndexChanged(sender, e);
                }
            }

            else if (e.KeyCode == Keys.F11)
            {
                if (MessageBox.Show("Confirma SOLICITAÇÃO URGENTE DE COMPRA do produto?", "Confirmar Solicitação de Compra", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SolicitacoesCompra solicitacaoCompra = new SolicitacoesCompra();
                    solicitacaoCompra = (SolicitacoesCompra)solicitacoesCompraBindingSource.Current;
                    solicitacaoCompra.CodSituacaoProduto = SituacaoProduto.COMPRA_URGENTE;
                    solicitacaoCompra.DataSolicitacaoCompra = DateTime.Now;
                    GerenciadorProduto.AtualizarSituacaoProduto(solicitacaoCompra, UtilConfig.Default.SERVIDOR_NFE);
                    comboBoxFornecedor_SelectedIndexChanged(sender, e);
                }
            }

            else if (e.KeyCode == Keys.F12)
            {
                if (MessageBox.Show("Confirma que produto foi COMPRADO?", "Confirmar Solicitação de Compra", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SolicitacoesCompra solicitacaoCompra = new SolicitacoesCompra();
                    solicitacaoCompra = (SolicitacoesCompra)solicitacoesCompraBindingSource.Current;
                    solicitacaoCompra.CodSituacaoProduto = SituacaoProduto.COMPRADO;
                    solicitacaoCompra.DataPedidoCompra = DateTime.Now;
                    GerenciadorProduto.AtualizarSituacaoProduto(solicitacaoCompra, UtilConfig.Default.SERVIDOR_NFE);
                    comboBoxFornecedor_SelectedIndexChanged(sender, e);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //if (codProdutoComboBox.Focused)
                //{
                //    codProdutoComboBox_Leave(sender, e);
                //}
                e.Handled = true;
                SendKeys.Send("{tab}");
            }

        }
      
        private void preencherDadosEstatisticos(ProdutoPesquisa produtoPesquisa)
        {
            Produto produto = GerenciadorProduto.Obter(produtoPesquisa);
            
            preco_custoTextBox.Text = produto.PrecoCusto.ToString("N2");
            precoVarejoSugestaoTextBox.Text = produto.PrecoVendaVarejoSugestao.ToString("N2");
            precoAtacadoSugestaoTextBox.Text = produto.PrecoVendaAtacadoSugestao.ToString("N2");

            produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.ObterPorProduto(produto.CodProduto);
            entradaProdutoPesquisaBindingSource.DataSource = GerenciadorEntradaProduto.ObterPorProdutoTipoEntradaFornecedor(produto.CodProduto);
            var listaProdutosVendidos = GerenciadorSaidaProduto.ObterProdutosVendidosUltimosAnos(produto.CodProduto, 2);
            produtoVendidoBindingSource.DataSource = listaProdutosVendidos.OrderBy(pv => pv.Ano).ThenBy(pv => pv.Mes).ToList();

            // Configurações adicionais do gráfico (opcional)
            chart1.ChartAreas[0].AxisX.Title = "Mês/Ano";
            chart1.ChartAreas[0].AxisY.Title = "Quantidade Vendida";
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 20;
            chart1.Series[0].BorderWidth = 1;
            chart1.Series[0].BorderColor = Color.Black;
            chart1.DataBind();
            chart1.Visible = true;

            decimal somaVendidos = 0;
            if (listaProdutosVendidos.Count == 0)
            {
                vendidos3textBox.Text = "0,00";
                vendidos6textBox.Text = "0,00";
                vendidos12textBox.Text = "0,00";
                vendidos18textBox.Text = "0,00";
            }
            
            for (int i = 0; i < listaProdutosVendidos.Count && i < 18; i++)
            {
                ProdutoVendido produtoVendido = listaProdutosVendidos[i];
                somaVendidos += produtoVendido.QuantidadeVendida;
                if (i < 3)
                {
                    vendidos3textBox.Text = somaVendidos.ToString("N2");
                    vendidos6textBox.Text = somaVendidos.ToString("N2");
                    vendidos12textBox.Text = somaVendidos.ToString("N2");
                    vendidos18textBox.Text = somaVendidos.ToString("N2");
                }
                else if (i < 6)
                {
                    vendidos6textBox.Text = somaVendidos.ToString("N2");
                    vendidos12textBox.Text = somaVendidos.ToString("N2");
                    vendidos18textBox.Text = somaVendidos.ToString("N2");
                }
                else if (i < 12)
                {
                    vendidos12textBox.Text = somaVendidos.ToString("N2");
                    vendidos18textBox.Text = somaVendidos.ToString("N2");
                }
                else
                {
                    vendidos18textBox.Text = somaVendidos.ToString("N2");
                }
            }

        }

        private void comboBoxFornecedor_Leave(object sender, EventArgs e)
        {
            ComponentesLeave.PessoaComboBox_Leave(sender, e, comboBoxFornecedor, EstadoFormulario.ATUALIZAR, pessoaBindingSource, true, false); 
        }

        private void comboBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> listaSituacoesProdutoChecked = new List<int>();
            if (checkBoxNaoComprar.Checked)
                listaSituacoesProdutoChecked.Add(SituacaoProduto.NAO_COMPRAR);
            if (checkBoxComprado.Checked)
                listaSituacoesProdutoChecked.Add(SituacaoProduto.COMPRADO);
            if (checkBoxDisponivel.Checked)
                listaSituacoesProdutoChecked.Add(SituacaoProduto.DISPONIVEL);
            if (checkBoxSolicitacaoCompra.Checked)
                listaSituacoesProdutoChecked.Add(SituacaoProduto.COMPRA_NECESSARIA);
            if (checkBoxCompraUrgente.Checked)
                listaSituacoesProdutoChecked.Add(SituacaoProduto.COMPRA_URGENTE);
            long codFornecedor = 1;
            if (comboBoxFornecedor.SelectedValue != null)
                codFornecedor = (long) comboBoxFornecedor.SelectedValue;
            solicitacoesCompraBindingSource.DataSource = GerenciadorProduto.ObterSolicitacoesCompra(listaSituacoesProdutoChecked, codFornecedor);
        }

        private void DestacarProdutos()
        {
            for (int i = 0; i < solicitacoesCompraDataGridView.RowCount; i++)
            {
                int codSituacaoProduto = Convert.ToInt32(solicitacoesCompraDataGridView.Rows[i].Cells[5].Value);

                if (codSituacaoProduto == SituacaoProduto.COMPRA_NECESSARIA)
                {
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                }
                else if (codSituacaoProduto == SituacaoProduto.COMPRA_URGENTE)
                {
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                }
                else if (codSituacaoProduto == SituacaoProduto.COMPRADO)
                {
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Green;
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                }
                else if (codSituacaoProduto == SituacaoProduto.NAO_COMPRAR)
                {
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Black;
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.White;
                }
                else
                {
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.BackColor = Color.White;
                    solicitacoesCompraDataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                }
            }
        }

        private void comboBoxFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void solicitacoesCompraDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (solicitacoesCompraBindingSource.Count > 0)
            {
                SolicitacoesCompra solicitacao = (SolicitacoesCompra)solicitacoesCompraBindingSource.Current;
                ProdutoPesquisa produto = GerenciadorProduto.Obter(new ProdutoPesquisa() { CodProduto = solicitacao.CodProduto });
                produtoBindingSource.DataSource = produto;
                preencherDadosEstatisticos(produto);
            }

        }

        private void solicitacoesCompraDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DestacarProdutos();
        }
    }
}