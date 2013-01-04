using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Negocio;
using Dominio;
using Util;
using System.Data;
using Dados;

namespace Telas
{
    public partial class FrmProdutoEstatistica : Form
    {
        private Produto produto;
        string ultimoCodigoBarraLido = "";

        public FrmProdutoEstatistica()
        {
            InitializeComponent();
        }

        private void FrmProdutoEstatistica_Load(object sender, EventArgs e)
        {
            //GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.ENTRADA_PRODUTOS, Principal.Autenticacao.CodUsuario);
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
            codProdutoComboBox.SelectAll();
            codProdutoComboBox.Focus();
        }



        private void FrmProdutoEstatistica_KeyDown(object sender, KeyEventArgs e)
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

        }

      

        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            Produto produtoOriginal;

            //if ((codProdutoComboBox.SelectedValue == null) || Convert.ToInt32(codProdutoComboBox.SelectedValue) == 1)
            //{
            //    produto = null;
            //    codProdutoComboBox.Text = "";
            //}
            //else
            //{

                long result;
                bool isNumber = long.TryParse(codProdutoComboBox.Text.ToString(), out result);

                if (isNumber)
                {
                    // Busca produto pelo Código ou Código de Barra
                    if (codProdutoComboBox.Text.Length < 7)
                    {
                        produto = GerenciadorProduto.getInstace().obterProduto(Convert.ToInt32(result));
                    }
                    else
                    {
                        produto = GerenciadorProduto.getInstace().obterProdutoPorCodBarra(codProdutoComboBox.Text);

                        ultimoCodigoBarraLido = (produto == null) ? codProdutoComboBox.Text : "";
                    }
                    codProdutoComboBox.Text = "";
                }
                else if (!codProdutoComboBox.Text.Trim().Equals(""))
                {
                    // Busca produto pelo nome
                    produto = GerenciadorProduto.getInstace().obterProdutoNomeIgual(codProdutoComboBox.Text);
                    if (produto == null)
                    {
                        Telas.FrmProdutoPesquisaPreco frmProdutoPesquisaPreco = new Telas.FrmProdutoPesquisaPreco(codProdutoComboBox.Text, false);
                        frmProdutoPesquisaPreco.ShowDialog();
                        if (frmProdutoPesquisaPreco.getCodProduto() != -1)
                        {
                            produto = GerenciadorProduto.getInstace().obterProduto(frmProdutoPesquisaPreco.getCodProduto());
                            produtoOriginal = (Produto)produto.Clone();
                            codProdutoComboBox.Text = produto.Nome;
                            tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", frmProdutoPesquisaPreco.getCodProduto());
                        }
                        else
                        {
                            codProdutoComboBox.Focus();
                        }
                        frmProdutoPesquisaPreco.Dispose();
                    }
                }
            //}
            if (produto == null)
            {
                codProdutoComboBox.Focus();
            }
            else
            {
                // Associa o útlimo código de barra lido ao produto selecionado
                if (!ultimoCodigoBarraLido.Equals(""))
                {
                    if (MessageBox.Show("Associar o último código de barra lido ao produto selecionado?", "Confirmar Associação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        produto.CodigoBarra = ultimoCodigoBarraLido;
                        GerenciadorProduto.getInstace().atualizar(produto);
                    }
                    ultimoCodigoBarraLido = "";
                }

                // Exibe dados do produto selecionado
                codProdutoComboBox.Text = produto.Nome;
                produtoOriginal = (Produto)produto.Clone();
                //tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", produto.CodProduto);

                if (produto != null)
                {
                    preencherDadosEstatisticos(produto);
                    codProdutoComboBox.Focus();
                    codProdutoComboBox.SelectAll();
                }
            }
        }

        private void preencherDadosEstatisticos(Produto produto)
        {
            decimal precoCusto = 0;
            if (GerenciadorProduto.getInstace().ehProdututoTributadoIntegral(produto.CodCST))
            {
                precoCusto = GerenciadorPrecos.getInstance().calculaPrecoCustoNormal(produto.UltimoPrecoCompra, produto.Icms,
                    produto.Simples, produto.Ipi, produto.Frete, 0, produto.Desconto);
            }
            else
            {
                precoCusto = GerenciadorPrecos.getInstance().calculaPrecoCustoSubstituicao(produto.UltimoPrecoCompra, produto.IcmsSubstituto,
                    produto.Simples, produto.Ipi, produto.Frete, 0, produto.Desconto);
            }
            preco_custoTextBox.Text = precoCusto.ToString("N2");
            precoVarejoSugestaoTextBox.Text = GerenciadorPrecos.getInstance().calculaPrecoVenda(precoCusto, produto.LucroPrecoVendaVarejo).ToString("N2");
            precoAtacadoSugestaoTextBox.Text = GerenciadorPrecos.getInstance().calculaPrecoVenda(precoCusto, produto.LucroPrecoVendaAtacado).ToString("N2");

            this.tb_produto_lojaTableAdapter.FillByCodProduto(this.saceDataSet.tb_produto_loja, produto.CodProduto);
            this.entradasPorProdutoTableAdapter.FillEntradasByProduto(this.saceDataSetConsultas.EntradasPorProduto, produto.CodProduto);
            this.produtosVendidosTableAdapter.FillQuantidadeProdutosVendidosMesAnoAsc(saceDataSetConsultas.ProdutosVendidos, produto.CodProduto);

            Dados.saceDataSetConsultas.ProdutosVendidosDataTable pVendidosTable = new Dados.saceDataSetConsultas.ProdutosVendidosDataTable();
            pVendidosTable = this.saceDataSetConsultas.ProdutosVendidos;

            chart1.DataSource = produtosVendidosTableAdapterBindingSource;

            chart1.Series[0].Name = "Qtd Vendidos";
            chart1.Series[0].XValueMember = pVendidosTable.mesanoColumn.ToString();
            chart1.EndInit();
            //chart1.Series[0].
            chart1.Series[0].YValueMembers = pVendidosTable.quantidadeVendidaColumn.ToString();

            chart1.DataBind();
            chart1.Visible = true;

            List<ProdutoVendido> produtosVendidos = GerenciadorProdutosVendidos.getInstace().obterProdutosVendidos(produto.CodProduto);

            decimal somaVendidos = 0;

            for (int i = 0; i < produtosVendidos.Count && i < 18; i++)
            {
                ProdutoVendido produtoVendido = produtosVendidos[i];
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

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }
    }
}