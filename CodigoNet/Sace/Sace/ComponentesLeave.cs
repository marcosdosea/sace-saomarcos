using Dados;
using Dominio;
using Negocio;
using Util;

namespace Sace
{
    public class ComponentesLeave
    {
        /// <summary>
        /// Controla os combobox com entrada de pessoas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="pessoaComboBox"></param>
        /// <param name="estado"></param>
        /// <param name="pessoaBindingSource"></param>
        /// <param name="retornaNomeFantasia"></param>
        public static Pessoa PessoaComboBox_Leave(object sender, EventArgs e, ComboBox pessoaComboBox, EstadoFormulario estado, 
            BindingSource pessoaBindingSource, bool retornaNomeFantasia, bool precisaEscolherPessoa, GerenciadorPessoa gerenciadorPessoa)
        {
            if (estado.Equals(EstadoFormulario.INSERIR) || estado.Equals(EstadoFormulario.ATUALIZAR))
            {
                List<Pessoa> pessoas;
                if (retornaNomeFantasia)
                    pessoas = (List<Pessoa>) gerenciadorPessoa.ObterPorNomeFantasia(pessoaComboBox.Text);
                else
                    pessoas = (List<Pessoa>) gerenciadorPessoa.ObterPorNome(pessoaComboBox.Text);

                Pessoa pessoaNomeIgual = null;
                foreach (Pessoa pessoa in pessoas)
                {
                    if (retornaNomeFantasia)
                    {
                        if (pessoa.NomeFantasia.Equals(pessoaComboBox.Text))
                            pessoaNomeIgual = pessoa;
                    }
                    else
                    {
                        if (pessoa.Nome.Equals(pessoaComboBox.Text))
                            pessoaNomeIgual = pessoa;
                    }
                }

                if ((pessoas.Count == 0) || ((pessoas.Count > 1) && (pessoaNomeIgual == null)) || ((pessoaNomeIgual != null) && pessoaNomeIgual.CodPessoa.Equals(UtilConfig.Default.CLIENTE_PADRAO) && precisaEscolherPessoa))
                {
                    FrmPessoaPesquisa frmPessoaPesquisa;
                    if ((pessoaNomeIgual != null) && pessoaNomeIgual.CodPessoa.Equals(UtilConfig.Default.CLIENTE_PADRAO))
                        frmPessoaPesquisa = new FrmPessoaPesquisa("");
                    else 
                        frmPessoaPesquisa = new FrmPessoaPesquisa(pessoaComboBox.Text);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                        if (retornaNomeFantasia)
                            pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).NomeFantasia;
                        else
                            pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).Nome;
                    }
                    else
                    {
                        pessoaComboBox.Focus();
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else
                {
                    pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(pessoaNomeIgual);
                    if (retornaNomeFantasia)
                        pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).NomeFantasia;
                    else
                        pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).Nome;
                }
            }
            return (Pessoa)pessoaBindingSource.Current;
        }

        /// <summary>
        /// Controla os combobox com entrada de produtos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="produtoComboBox"></param>
        /// <param name="estado"></param>
        /// <param name="produtoBindingSource"></param>
        /// <param name="ultimoCodigoBarraLido"></param>
        /// <param name="exibirTodos"></param>
        /// <returns></returns>
        public static ProdutoPesquisa ProdutoComboBox_Leave(object sender, EventArgs e, ComboBox produtoComboBox, EstadoFormulario estado, BindingSource produtoBindingSource, bool exibirTodos, SaceContext context)
        {
            ProdutoPesquisa _produtoPesquisa = null;
            GerenciadorProduto gerenciadorProduto = new GerenciadorProduto(context);
            if (produtoComboBox.DataSource != null)
            {
                List<ProdutoPesquisa> _listaProdutos = new List<ProdutoPesquisa>();

                if ((estado != EstadoFormulario.ESPERA) && (estado != EstadoFormulario.ATUALIZAR_DETALHE))
                {
                    long result;
                    // Busca produto pelo Código ou Código de Barra
                    bool isNumber = long.TryParse(produtoComboBox.Text.ToString(), out result);
                    ProdutoPesquisa produtoNomeIgual = null;
                    if (isNumber)
                    {
                        // Busca pelo código do produto
                        if (produtoComboBox.Text.Length < 7)
                        {
                            _listaProdutos = gerenciadorProduto.Obter(Convert.ToInt32(result)).ToList();
                        }
                        // Busca pelo código de barra
                        else
                        {
                            _listaProdutos = gerenciadorProduto.ObterPorCodigoBarraExato(produtoComboBox.Text).ToList();
                        }
                        if (_listaProdutos.Count > 0)
                        {
                            produtoNomeIgual = _listaProdutos[0];
                            produtoComboBox.Text = produtoNomeIgual.Nome;
                        }
                    }
                    else
                    {
                        if (!produtoComboBox.Text.Trim().Equals(""))
                        {
                            // Busca produto pelo nome
                            _listaProdutos = gerenciadorProduto.ObterPorNome(produtoComboBox.Text).ToList();
                            if (_listaProdutos.Count > 0)
                            {
                                if ((_listaProdutos.Count == 1) || (_listaProdutos[0].Nome.Equals(produtoComboBox.Text)))
                                    produtoNomeIgual = _listaProdutos[0];
                            }
                        }
                        if ((_listaProdutos.Count == 0) || ((_listaProdutos.Count >= 1) && (produtoNomeIgual == null)))
                        {
                            FrmProdutoPesquisaPreco frmProdutoPesquisaPreco = new FrmProdutoPesquisaPreco(exibirTodos, produtoComboBox.Text, context);
                            frmProdutoPesquisaPreco.ShowDialog();
                            if (frmProdutoPesquisaPreco.ProdutoPesquisa != null)
                            {
                                produtoComboBox.Text = frmProdutoPesquisaPreco.ProdutoPesquisa.Nome;
                                produtoBindingSource.Position = produtoBindingSource.List.IndexOf(frmProdutoPesquisaPreco.ProdutoPesquisa);
                                produtoNomeIgual = frmProdutoPesquisaPreco.ProdutoPesquisa;
                            }
                            frmProdutoPesquisaPreco.Dispose();
                        }
                    }
                    //Se retornou algum produto nas pesquisas
                    if ((_listaProdutos.Count > 0) && (produtoNomeIgual != null))
                    {
                        _produtoPesquisa = produtoNomeIgual;
                        produtoComboBox.Text = produtoNomeIgual.Nome;
                        if (produtoBindingSource.Current is ProdutoNome)
                        {
                            produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new ProdutoNome() { CodProduto = produtoNomeIgual.CodProduto });
                        }
                        else if (produtoBindingSource.Current is Produto)
                            produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new Produto() { CodProduto = produtoNomeIgual.CodProduto });
                        else
                            produtoBindingSource.Position = produtoBindingSource.List.IndexOf(produtoNomeIgual);
                       
                    }
                    else if (produtoComboBox != null)
                    {
                        produtoComboBox.Text = "";
                        produtoComboBox.Focus();
                    }
                }
            }
            return _produtoPesquisa;
        }
    }
}
