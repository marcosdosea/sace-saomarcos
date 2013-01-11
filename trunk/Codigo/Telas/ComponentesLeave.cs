using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Telas
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
        public static void PessoaComboBox_Leave(object sender, EventArgs e, ComboBox pessoaComboBox, EstadoFormulario estado, BindingSource pessoaBindingSource, bool retornaNomeFantasia)
        {
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                List<Pessoa> pessoas;
                if (retornaNomeFantasia)
                    pessoas = (List<Pessoa>)GerenciadorPessoa.GetInstance().ObterPorNomeFantasia(pessoaComboBox.Text);
                else
                    pessoas = (List<Pessoa>)GerenciadorPessoa.GetInstance().ObterPorNome(pessoaComboBox.Text);

                if (pessoas.Count == 0)
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(pessoaComboBox.Text);
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
                    pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(pessoas[0]);
                    if (retornaNomeFantasia)
                        pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).NomeFantasia;
                    else
                        pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).Nome;
                }
            }
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
        public static ProdutoPesquisa ProdutoComboBox_Leave(object sender, EventArgs e, ComboBox produtoComboBox, EstadoFormulario estado, BindingSource produtoBindingSource, string ultimoCodigoBarraLido, bool exibirTodos)
        {
            bool entradaViaCodigoBarra = false;
            ProdutoPesquisa _produtoPesquisa = null;
            List<ProdutoPesquisa> _listaProdutos = new List<ProdutoPesquisa>();

            if ((estado != EstadoFormulario.ESPERA) && (estado != EstadoFormulario.ATUALIZAR_DETALHE))
            {
                long result;
                // Busca produto pelo Código ou Código de Barra
                bool isNumber = long.TryParse(produtoComboBox.Text.ToString(), out result);
                if (isNumber)
                {
                    // Busca pelo código do produto
                    if (produtoComboBox.Text.Length < 7)
                    {
                        _listaProdutos = GerenciadorProduto.GetInstance().Obter(Convert.ToInt32(result)).ToList();
                    }
                    // Busca pelo código de barra
                    else
                    {
                        _listaProdutos = GerenciadorProduto.GetInstance().ObterPorCodBarra(produtoComboBox.Text).ToList();
                        entradaViaCodigoBarra = (_listaProdutos.Count > 0);
                        ultimoCodigoBarraLido = (_listaProdutos.Count > 0) ? "" : produtoComboBox.Text;
                    }
                }
                else
                {
                    // Busca produto pelo nome
                    _listaProdutos = GerenciadorProduto.GetInstance().ObterPorNome(produtoComboBox.Text).ToList();
                    if (_listaProdutos.Count == 0)
                    {
                        Telas.FrmProdutoPesquisaPreco frmProdutoPesquisaPreco = new Telas.FrmProdutoPesquisaPreco(produtoComboBox.Text, exibirTodos);
                        frmProdutoPesquisaPreco.ShowDialog();
                        if (frmProdutoPesquisaPreco.ProdutoPesquisa != null)
                        {
                            produtoComboBox.Text = frmProdutoPesquisaPreco.ProdutoPesquisa.Nome;
                            produtoBindingSource.Position = produtoBindingSource.List.IndexOf(frmProdutoPesquisaPreco.ProdutoPesquisa);
                        }
                        frmProdutoPesquisaPreco.Dispose();
                    }
                }
                // Se retornou algum produto nas pesquisas
                if (_listaProdutos.Count > 0)
                {
                    produtoBindingSource.Position = produtoBindingSource.List.IndexOf(_listaProdutos[0]);
                }
                // Se posição não foi modificada então focus no combobox
                if ((produtoBindingSource.Position == 0))
                {
                    produtoComboBox.Text = "";
                    produtoComboBox.Focus();
                }
                else
                {
                    _produtoPesquisa = (ProdutoPesquisa)produtoBindingSource.Current;
                    // Associa o útlimo código de barra lido ao produto selecionado
                    if (!ultimoCodigoBarraLido.Equals(""))
                    {
                        if (MessageBox.Show("Associar o último código de barra lido ao produto selecionado?", "Confirmar Associação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            GerenciadorProduto.GetInstance().AtualizarCodigoBarra(_produtoPesquisa, ultimoCodigoBarraLido);
                        }
                        ultimoCodigoBarraLido = "";
                    }
                }
            }
            return _produtoPesquisa;
        }
    }
}
