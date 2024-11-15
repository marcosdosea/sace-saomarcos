using Dominio;
using Negocio;

namespace Sace
{
    public partial class FrmProdutoEstatistica : Form
    {

        private Produto produto;

        public FrmProdutoEstatistica()
        {
            InitializeComponent();
            produto = null;
        }

        public FrmProdutoEstatistica(Produto produto)
        {
            InitializeComponent();
            this.produto = produto;
        }

        public FrmProdutoEstatistica(long codProduto)
        {
            InitializeComponent();
            this.produto = GerenciadorProduto.Obter(new ProdutoPesquisa() { CodProduto = codProduto });
        }


        private void FrmProdutoEstatistica_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = GerenciadorProduto.ObterTodos();
            if (produto != null)
            {
                produtoBindingSource.Position = produtoBindingSource.List.IndexOf(produto);
            }
            else
            {
                produtoBindingSource.Position = 1;
            }        
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
            EstadoFormulario estado = EstadoFormulario.INSERIR;
            ProdutoPesquisa _produtoPesquisa = ComponentesLeave.ProdutoComboBox_Leave(sender, e, codProdutoComboBox, estado, produtoBindingSource, true);

            if (_produtoPesquisa != null)
            {
                preencherDadosEstatisticos(_produtoPesquisa);
                codProdutoComboBox.Focus();
                codProdutoComboBox.SelectAll();
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
            var listaProdutosVendidos = GerenciadorSaidaProduto.ObterProdutosVendidosUltimosAnos(produto.CodProduto, 3);
            produtoVendidoBindingSource.DataSource = listaProdutosVendidos.OrderBy(pv => pv.Ano).ThenBy(pv => pv.Mes).ToList();

            // Configurações adicionais do gráfico (opcional)
            chart1.ChartAreas[0].AxisX.Title = "Mês/Ano";
            chart1.ChartAreas[0].AxisY.Title = "Quantidade Vendida";
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 30;
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

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }
    }
}