using System;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Util;
using System.Data;

namespace Telas
{
    public partial class FrmEntrada : Form
    {
        private EstadoFormulario estado;
        private Entrada entrada;
        private EntradaProduto entradaProduto;
        private Int32 tipoEntrada;
        private Produto produto;
        private string ultimoCodigoBarraLido = "";

        public FrmEntrada()
        {
            InitializeComponent();
        }

        private void FrmEntrada_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.ENTRADA_PRODUTOS, Principal.Autenticacao.CodUsuario);
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
            if ((codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 1)) {
                this.tb_entrada_produtoTableAdapter.FillByCodEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
            }
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_cfopTableAdapter.Fill(this.saceDataSet.tb_cfop);
            this.tb_entradaTableAdapter.FillEntradas(this.saceDataSet.tb_entrada);
            this.tb_situacao_pagamentosTableAdapter.Fill(this.saceDataSet.tb_situacao_pagamentos);
            this.tb_cstTableAdapter.Fill(this.saceDataSet.tb_cst);
            tb_entradaBindingSource.MoveLast();
            entrada = new Entrada();
            entradaProduto = new EntradaProduto();
            tipoEntrada = Entrada.TIPO_ENTRADA;
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmEntradaPesquisa frmEntradaPesquisa = new Telas.FrmEntradaPesquisa();
            frmEntradaPesquisa.ShowDialog();
            if (frmEntradaPesquisa.getCodEntrada() != -1)
            {
                tb_entradaBindingSource.Position = tb_entradaBindingSource.Find("codEntrada", frmEntradaPesquisa.getCodEntrada());
            }
            frmEntradaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_entradaBindingSource.AddNew();
            codEntradaTextBox.Enabled = false;
            numeroNotaFiscalTextBox.Focus();
            codEmpresaFreteComboBox.SelectedIndex = 0;
            codFornecedorComboBox.SelectedIndex = 0;
            codSituacaoPagamentosComboBox.SelectedIndex = 0;
            fretePagoEmitenteCheckBox.Checked = true;
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitaBotoes(false);
            numeroNotaFiscalTextBox.Focus();
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorEntrada.getInstace().remover(Convert.ToInt64(codEntradaTextBox.Text));
                tb_entradaTableAdapter.FillEntradas(saceDataSet.tb_entrada);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitaBotoes(true);
            
            tb_entradaBindingSource.CancelEdit();
            tb_entradaBindingSource.EndEdit();
            tb_entrada_produtoBindingSource.CancelEdit();
            tb_entrada_produtoBindingSource.EndEdit();
            ProdutosGroupBox.Enabled = false;
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            entrada = new Entrada();
            entrada.CodEntrada = Convert.ToInt64(codEntradaTextBox.Text);
            entrada.CodEmpresaFrete = Convert.ToInt32(codEmpresaFreteComboBox.SelectedValue.ToString());
            entrada.CodFornecedor = Convert.ToInt32(codFornecedorComboBox.SelectedValue.ToString());
            entrada.CodTipoEntrada = tipoEntrada;
            entrada.DataEmissao = Convert.ToDateTime(dataEmissaoDateTimePicker.Text);
            entrada.DataEntrada = Convert.ToDateTime(dataEntradaDateTimePicker.Text);
            entrada.Desconto = Convert.ToDecimal(descontoTextBox.Text);
            entrada.NumeroNotaFiscal = numeroNotaFiscalTextBox.Text;
            entrada.OutrasDespesas = Convert.ToDecimal(outrasDespesasTextBox.Text);
            entrada.TotalBaseCalculo = Convert.ToDecimal(totalBaseCalculoTextBox.Text);
            entrada.TotalBaseSubstituicao = Convert.ToDecimal(totalBaseSubstituicaoTextBox.Text);
            entrada.TotalICMS = Convert.ToDecimal(totalICMSTextBox.Text);
            entrada.TotalIPI = Convert.ToDecimal(totalIPITextBox.Text);
            entrada.TotalNota = Convert.ToDecimal(totalNotaTextBox.Text);
            entrada.TotalProdutos = Convert.ToDecimal(totalProdutosTextBox.Text);
            entrada.TotalProdutosST = Convert.ToDecimal(totalProdutosSTTextBox.Text);
            entrada.TotalSubstituicao = Convert.ToDecimal(totalSubstituicaoTextBox.Text);
            entrada.ValorFrete = Convert.ToDecimal(valorFreteTextBox.Text);
            entrada.ValorSeguro = Convert.ToDecimal(valorSeguroTextBox.Text);
            entrada.FretePagoEmitente = fretePagoEmitenteCheckBox.Checked;
            if (codSituacaoPagamentosComboBox.SelectedValue != null)
            {
                entrada.CodSituacaoPagamentos = Convert.ToInt32(codSituacaoPagamentosComboBox.SelectedValue.ToString());
            }
            else
            {
                entrada.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;
            }
                        
            GerenciadorEntrada gEntrada = GerenciadorEntrada.getInstace();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                entrada.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;

                entrada.CodEntrada = gEntrada.inserir(entrada);
                tb_entradaTableAdapter.FillEntradas(saceDataSet.tb_entrada);
                tb_entradaBindingSource.Position = tb_entradaBindingSource.Find("codEntrada", entrada.CodEntrada);
                habilitaBotoes(true);
                btnProdutos.Focus();
            }
            else if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                GerenciadorEntradaProduto gEntradaProduto = GerenciadorEntradaProduto.getInstace();
                entradaProduto = new EntradaProduto();
                entradaProduto.CodTipoEntrada = entrada.CodTipoEntrada;
                entradaProduto.CodProduto = Convert.ToInt32(codProdutoComboBox.SelectedValue.ToString());
                entradaProduto.BaseCalculoICMS = Convert.ToDecimal(baseCalculoICMSTextBox.Text);
                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(baseCalculoICMSSTTextBox.Text);
                entradaProduto.Cfop = Convert.ToInt32(cfopComboBox.SelectedValue.ToString());
                entradaProduto.CodCST = codCSTComboBox.SelectedValue.ToString();
                entradaProduto.CodEntrada = entrada.CodEntrada;
                entradaProduto.DataEntrada = entrada.DataEntrada;
                entradaProduto.DataValidade = Convert.ToDateTime(data_validadeDateTimePicker.Text);
                entradaProduto.Frete = Convert.ToDecimal(freteTextBox.Text);
                entradaProduto.LucroPrecoVendaAtacado = Convert.ToDecimal(lucroPrecoVendaAtacadoTextBox.Text);
                entradaProduto.LucroPrecoVendaVarejo = Convert.ToDecimal(lucroPrecoVendaVarejoTextBox.Text);
                entradaProduto.PrecoCusto = Convert.ToDecimal(preco_custoTextBox.Text);
                entradaProduto.PrecoVendaAtacado = Convert.ToDecimal(precoVendaAtacadoTextBox.Text);
                entradaProduto.PrecoVendaVarejo = Convert.ToDecimal(precoVendaVarejoTextBox.Text);
                entradaProduto.Quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
                entradaProduto.QuantidadeEmbalagem = Convert.ToDecimal(quantidadeEmbalagemTextBox.Text);
                entradaProduto.QuantidadeDisponivel = entradaProduto.Quantidade * entradaProduto.QuantidadeEmbalagem;
                entradaProduto.Simples = Convert.ToDecimal(simplesTextBox.Text);
                entradaProduto.Icms = Convert.ToDecimal(icmsTextBox.Text);
                entradaProduto.IcmsSubstituto = Convert.ToDecimal(icms_substitutoTextBox.Text);
                entradaProduto.Ipi = Convert.ToDecimal(ipiTextBox.Text);
                entradaProduto.Ncmsh = ncmshTextBox.Text;
                entradaProduto.UnidadeCompra = unidadeCompraTextBox.Text;
                entradaProduto.ValorICMS = Convert.ToDecimal(valorICMSTextBox.Text);
                entradaProduto.ValorICMSST = Convert.ToDecimal(valorICMSSTTextBox.Text);
                entradaProduto.ValorIPI = Convert.ToDecimal(valorIPITextBox.Text);
                entradaProduto.ValorTotal = Convert.ToDecimal(valorTotalTextBox.Text);
                entradaProduto.ValorUnitario = Convert.ToDecimal(valorUnitarioTextBox.Text);
                entradaProduto.QtdProdutoAtacado = Convert.ToDecimal(qtdProdutoAtacadoTextBox.Text);
                entradaProduto.Desconto = Convert.ToDecimal(descontoProdutoTextBox.Text);

                entradaProduto.FornecedorEhFabricante = ((Dados.saceDataSet.tb_pessoaRow) ((System.Data.DataRowView) tbpessoaBindingSource.Current).Row).ehFabricante;
                entradaProduto.CodFornecedor = ((Dados.saceDataSet.tb_pessoaRow)((System.Data.DataRowView)tbpessoaBindingSource.Current).Row).codPessoa;

                GerenciadorEntradaProduto.getInstace().inserir(entradaProduto);
                codEntradaTextBox_TextChanged(sender, e);
                btnProdutos_Click(sender, e);
            }
            else 
            {
                gEntrada.atualizar(entrada);
                tb_entradaBindingSource.EndEdit();
                tb_entradaTableAdapter.FillEntradas(saceDataSet.tb_entrada);
                tb_entradaBindingSource.Position = tb_entradaBindingSource.Find("codEntrada", entrada.CodEntrada);
                tb_produtoBindingSource.Position = 0;
                habilitaBotoes(true);
                btnProdutos.Focus();
            }
        }

        private void excluirProduto(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirma exclusão do produto?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_entrada_produtoDataGridView.Rows.Count > 0)
                {
                    long codEntradaProduto = long.Parse(tb_entrada_produtoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    Negocio.GerenciadorEntradaProduto.getInstace().remover(codEntradaProduto);
                }
            }
            codEntradaTextBox_TextChanged(sender, e);
        }

        private void FrmEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnExcluir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F7)
                {
                    btnProdutos_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F8)
                {
                    btnPagamentos_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F12)
                {
                    if (tipoEntrada == Entrada.TIPO_ENTRADA)
                    {
                        FrmEntrada.ActiveForm.Text = "Entrada de Produtox";
                        tipoEntrada = Entrada.TIPO_ENTRADA_AUX;
                    }
                    else
                    {
                        FrmEntrada.ActiveForm.Text = "Entrada de Produtos";
                        tipoEntrada = Entrada.TIPO_ENTRADA;
                    }
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_entradaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_entradaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_entradaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_entradaBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else 
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (codFornecedorComboBox.Focused)
                    {
                        codFornecedorComboBox_Leave(sender, e);
                    }
                    else if (codEmpresaFreteComboBox.Focused)
                    {
                        codEmpresaFreteComboBox_Leave(sender, e);
                    }
                    else if (codProdutoComboBox.Focused)
                    {
                        codProdutoComboBox_Leave(sender, e);
                    } 
                    
                    e.Handled = true;
                    SendKeys.Send("{tab}");
                }
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
                else if ((e.KeyCode == Keys.F2) && (codFornecedorComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codFornecedorComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.CodPessoa > 0)
                    {
                        this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoa.CodPessoa);
                    }
                    frmPessoa.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codEmpresaFreteComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource1.Position = tbpessoaBindingSource1.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codEmpresaFreteComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.CodPessoa > 0)
                    {
                        this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
                        tbpessoaBindingSource1.Position = tbpessoaBindingSource1.Find("codPessoa", frmPessoa.CodPessoa);
                    }
                    frmPessoa.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codProdutoComboBox.Focused))
                {
                    Telas.FrmProdutoPesquisaPreco frmProdutoPesquisaPreco = new Telas.FrmProdutoPesquisaPreco(true);
                    frmProdutoPesquisaPreco.ShowDialog();
                    if (frmProdutoPesquisaPreco.getCodProduto() != -1)
                    {
                        tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", frmProdutoPesquisaPreco.getCodProduto());
                    }
                    frmProdutoPesquisaPreco.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codProdutoComboBox.Focused))
                {
                    Telas.FrmProduto frmProduto = new Telas.FrmProduto();
                    frmProduto.ShowDialog();
                    if (frmProduto.CodProduto > 0)
                    {
                        this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
                        tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", frmProduto.CodProduto);
                    }
                    frmProduto.Dispose();
                }
                
            }
            // Coloca o foco na grid caso ela não possua
            if (e.KeyCode == Keys.F12)
            {
                btnCancelar_Click(sender, e);
                tb_entrada_produtoDataGridView.Focus();
                tb_entrada_produtoDataGridView.Select();
                if (tb_entrada_produtoDataGridView.RowCount == 1)
                {
                    tb_entrada_produtoDataGridView.SelectAll();
                }
            }

            // permite excluir um contato quando o foco está na grid
            if ((e.KeyCode == Keys.Delete) && (tb_entrada_produtoDataGridView.Focused == true))
            {
                excluirProduto(sender, e);
            }
        }

        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            btnProdutos.Enabled = habilita && (codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 0);
            btnPagamentos.Enabled = habilita && (codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 0);
            tb_entradaBindingNavigator.Enabled = habilita;
            //ProdutosGroupBox.Enabled = !habilita && (codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 0);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }


        private void codigoFornecedorComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            tb_entrada_produtoBindingSource.AddNew();
            codProdutoComboBox.SelectedIndex = 0;
            tb_produtoBindingSource.Position = 0;
            cfopComboBox.SelectedIndex = 0;
            ProdutosGroupBox.Enabled = true;
            codProdutoComboBox.Focus();
            simplesTextBox.Text = Global.SIMPLES.ToString();
            inicializaVariaveis();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
            
        }

        private void codFornecedorComboBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR)) {
                Pessoa pessoa = GerenciadorPessoa.getInstace().obterPessoaNomeFantasiaIgual(codFornecedorComboBox.Text);
                if (pessoa == null)
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(codFornecedorComboBox.Text);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                        codFornecedorComboBox.Text = ((Dados.saceDataSet.tb_pessoaRow)((DataRowView)tbpessoaBindingSource.Current).Row).nome;
                    }
                    else
                    {
                        codFornecedorComboBox.Focus();
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else
                {
                    tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", pessoa.CodPessoa);
                }
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void codEmpresaFreteComboBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                Pessoa pessoa = GerenciadorPessoa.getInstace().obterPessoaNomeFantasiaIgual(codEmpresaFreteComboBox.Text);
                if (pessoa == null)
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(codEmpresaFreteComboBox.Text);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource1.Position = tbpessoaBindingSource1.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                        codEmpresaFreteComboBox.Text = ((Dados.saceDataSet.tb_pessoaRow)((DataRowView)tbpessoaBindingSource1.Current).Row).nome;
                    }
                    else
                    {
                        codEmpresaFreteComboBox.Focus();
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else
                {
                    tbpessoaBindingSource1.Position = tbpessoaBindingSource1.Find("codPessoa", pessoa.CodPessoa);
                }
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {

                Produto produtoOriginal;

                if ((estado != EstadoFormulario.ESPERA) && (estado != EstadoFormulario.ATUALIZAR_DETALHE))
                {
                    quantidadeTextBox.Text = "1";
                    if (Convert.ToInt32(codProdutoComboBox.SelectedValue) == 1)
                    {
                        produto = null;
                        codProdutoComboBox.Text = "";
                    }

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
                    else
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

                        // Exeibe dados do produto selecionado
                        codProdutoComboBox.Text = produto.Nome;
                        produtoOriginal = (Produto)produto.Clone();
                        tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", produto.CodProduto);
                        data_validadeDateTimePicker.Enabled = produto.TemVencimento;
                        if (Convert.ToDecimal(quantidadeEmbalagemTextBox.Text) <= 0)
                        {
                            quantidadeEmbalagemTextBox.Text = "1";
                        }

                    }
                }

                codCSTComboBox_SelectedIndexChanged(sender, e);
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void codEntradaTextBox_TextChanged(object sender, EventArgs e)
        {
            totalNotaCalculadoTextBox.Text = "0,00";
            if ((!codEntradaTextBox.Text.Trim().Equals("")) /*&& (long.Parse(codEntradaTextBox.Text) > 1)*/) {
                tb_entrada_produtoTableAdapter.FillByCodEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
                decimal? total = tb_entrada_produtoTableAdapter.totalEntrada(long.Parse(codEntradaTextBox.Text));
                if (total != null) {
                    totalNotaCalculadoTextBox.Text = ((decimal) total).ToString("N2");
                }
            }
        }

        private void totalBaseCalculoTextBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void quantidadeTextBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
                inicializaVariaveis();

                entradaProduto.ValorTotal = Convert.ToDecimal(valorTotalTextBox.Text);

                if ((entradaProduto.ValorTotal > 0) && valorTotalTextBox.Focused)
                {
                    entradaProduto.ValorUnitario = entradaProduto.ValorTotal / entradaProduto.Quantidade;
                    valorUnitarioTextBox.Text = entradaProduto.ValorUnitario.ToString("N3");
                }
                valorTotalTextBox.Text = (entradaProduto.ValorUnitario * entradaProduto.Quantidade).ToString("N2");

                entradaProduto.ValorICMSST = entradaProduto.ValorTotal * entradaProduto.IcmsSubstituto / 100;
                valorICMSSTTextBox.Text = entradaProduto.ValorICMSST.ToString("N2");

                if ((entradaProduto.BaseCalculoICMS == 0) && (GerenciadorProduto.getInstace().ehProdututoTributadoIntegral(entradaProduto.CodCST)))
                {
                    baseCalculoICMSTextBox.Text = valorTotalTextBox.Text;
                }

                if ((entradaProduto.BaseCalculoICMSST == 0) && (!GerenciadorProduto.getInstace().ehProdututoTributadoIntegral(entradaProduto.CodCST)))
                {
                    baseCalculoICMSSTTextBox.Text = valorTotalTextBox.Text;
                }

                valorICMSTextBox.Text = (entradaProduto.BaseCalculoICMS * entradaProduto.Icms / 100).ToString("N2");
                valorIPITextBox.Text = (entradaProduto.ValorTotal * entradaProduto.Ipi / 100).ToString("N2");

                entradaProduto.LucroPrecoVendaVarejo = Convert.ToDecimal(lucroPrecoVendaVarejoTextBox.Text);
                entradaProduto.LucroPrecoVendaAtacado = Convert.ToDecimal(lucroPrecoVendaAtacadoTextBox.Text);

                entradaProduto.CodCST = codCSTComboBox.SelectedValue.ToString();
                entradaProduto.QuantidadeEmbalagem = Convert.ToDecimal(quantidadeEmbalagemTextBox.Text);

                if (entradaProduto.QuantidadeEmbalagem <= 0)
                {
                    throw new TelaException("A quantidade de produtos da embalagem deve ser maior ou igual a 1.");
                }

                if (GerenciadorProduto.getInstace().ehProdututoTributadoIntegral(codCSTComboBox.SelectedValue.ToString()))
                {
                    entradaProduto.PrecoCusto = GerenciadorPrecos.getInstance().calculaPrecoCustoNormal(entradaProduto.ValorUnitario, entradaProduto.Icms,
                        entradaProduto.Simples, entradaProduto.Ipi, entradaProduto.Frete, Global.CUSTO_MANUTENCAO_LOJA, entradaProduto.Desconto) / entradaProduto.QuantidadeEmbalagem;
                }
                else
                {
                    entradaProduto.PrecoCusto = GerenciadorPrecos.getInstance().calculaPrecoCustoSubstituicao(entradaProduto.ValorUnitario, entradaProduto.IcmsSubstituto,
                        entradaProduto.Simples, entradaProduto.Ipi, entradaProduto.Frete, Global.CUSTO_MANUTENCAO_LOJA, entradaProduto.Desconto) / entradaProduto.QuantidadeEmbalagem;
                }
                preco_custoTextBox.Text = entradaProduto.PrecoCusto.ToString("N2");

                entradaProduto.LucroPrecoVendaVarejo = Convert.ToDecimal(lucroPrecoVendaVarejoTextBox.Text);
                entradaProduto.LucroPrecoVendaAtacado = Convert.ToDecimal(lucroPrecoVendaAtacadoTextBox.Text);

                entradaProduto.PrecoVendaVarejo = GerenciadorPrecos.getInstance().calculaPrecoVenda(entradaProduto.PrecoCusto,
                    entradaProduto.LucroPrecoVendaVarejo);
                entradaProduto.PrecoVendaAtacado = GerenciadorPrecos.getInstance().calculaPrecoVenda(entradaProduto.PrecoCusto,
                    entradaProduto.LucroPrecoVendaAtacado);

                precoVarejoSugestaoTextBox.Text = entradaProduto.PrecoVendaVarejo.ToString("N3");
                precoAtacadoSugestaoTextBox.Text = entradaProduto.PrecoVendaAtacado.ToString("N3");
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void inicializaVariaveis()
        {
            if (entradaProduto != null)
            {
                entradaProduto.ValorUnitario = Convert.ToDecimal(valorUnitarioTextBox.Text);
                entradaProduto.Quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
                entradaProduto.Icms = Convert.ToDecimal(icmsTextBox.Text);
                entradaProduto.IcmsSubstituto = Convert.ToDecimal(icms_substitutoTextBox.Text);
                entradaProduto.Ipi = Convert.ToDecimal(ipiTextBox.Text);
                entradaProduto.Simples = Global.SIMPLES;
                entradaProduto.Desconto = Convert.ToDecimal(descontoProdutoTextBox.Text);
                entradaProduto.BaseCalculoICMS = Convert.ToDecimal(baseCalculoICMSTextBox.Text);
                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(baseCalculoICMSSTTextBox.Text);
                entradaProduto.ValorICMSST = Convert.ToDecimal(valorICMSSTTextBox.Text);
                entradaProduto.CodCST = codCSTComboBox.SelectedValue.ToString();
            }

            if (entrada != null)
            {
                entrada.ValorFrete = Convert.ToDecimal(valorFreteTextBox.Text);
                entrada.TotalNota = Convert.ToDecimal(totalNotaTextBox.Text);
                entrada.TotalProdutos = Convert.ToDecimal(totalProdutosTextBox.Text);
                entrada.TotalProdutosST = Convert.ToDecimal(totalProdutosSTTextBox.Text);
                entrada.TotalSubstituicao = Convert.ToDecimal(totalSubstituicaoTextBox.Text);
                entrada.Desconto = Convert.ToDecimal(descontoTextBox.Text);
            }
        }

        private void precoVendaVarejoTextBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                FormatTextBox.NumeroCom3CasasDecimais((TextBox)sender);
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void qtdProdutoAtacadoTextBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE) || estado.Equals(EstadoFormulario.INSERIR))
            {
                FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(codEntradaTextBox.Text) > 0 )
            {
                habilitaBotoes(true);
                estado = EstadoFormulario.ESPERA;
                entrada = GerenciadorEntrada.getInstace().obterEntrada(Convert.ToInt64(codEntradaTextBox.Text));
                FrmEntradaPagamento frmEntradaPagamento = new FrmEntradaPagamento(entrada);
                frmEntradaPagamento.ShowDialog();
                frmEntradaPagamento.Dispose();

                this.tb_entradaTableAdapter.FillEntradas(this.saceDataSet.tb_entrada);
                tb_entradaBindingSource.MoveLast();
                btnNovo.Focus();
            }
        }

        private void precoVendaAtacadoTextBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE) || estado.Equals(EstadoFormulario.INSERIR))
            {
                FormatTextBox.NumeroCom3CasasDecimais((TextBox)sender);
            }
            codEntradaTextBox_Leave(sender, e);
            btnSalvar.Focus();
        }

        private void codCSTComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((codCSTComboBox.SelectedValue != null) && (ProdutosGroupBox.Enabled) && estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                bool ehTributadoIntegral = GerenciadorProduto.getInstace().ehProdututoTributadoIntegral(codCSTComboBox.SelectedValue.ToString());
            
                baseCalculoICMSSTTextBox.ReadOnly = ehTributadoIntegral;
                baseCalculoICMSSTTextBox.TabStop = !baseCalculoICMSSTTextBox.ReadOnly;
                icms_substitutoTextBox.ReadOnly = ehTributadoIntegral;
                icms_substitutoTextBox.TabStop = !icms_substitutoTextBox.ReadOnly;

                baseCalculoICMSTextBox.ReadOnly = !ehTributadoIntegral;
                baseCalculoICMSTextBox.TabStop = !baseCalculoICMSTextBox.ReadOnly;
                icmsTextBox.ReadOnly = !ehTributadoIntegral;
                icmsTextBox.TabStop = !icmsTextBox.ReadOnly;

                inicializaVariaveis();

                if (!GerenciadorProduto.getInstace().ehProdututoTributadoIntegral(entradaProduto.CodCST) &&
                    (entrada.TotalProdutosST > 0))
                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100;
                else
                    entradaProduto.IcmsSubstituto = 0;
                icms_substitutoTextBox.Text = entradaProduto.IcmsSubstituto.ToString("N2");

                if (entrada.ValorFrete > 0)
                {
                    if (entrada.FretePagoEmitente)
                        entradaProduto.Frete = ((entrada.ValorFrete / entrada.TotalProdutos) * 100);
                    else
                        entradaProduto.Frete = ((entrada.ValorFrete / entrada.TotalNota) * 100);
                }
                else
                {
                    entradaProduto.Frete = 0;
                }
                freteTextBox.Text = entradaProduto.Frete.ToString("N2");

                if (entrada.Desconto > 0)
                {
                    entradaProduto.Desconto = (entrada.Desconto / entrada.TotalProdutos) * 100;
                    descontoProdutoTextBox.Text = entradaProduto.Desconto.ToString("N2");
                }
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void codEntradaTextBox_Enter(object sender, EventArgs e)
        {
            if ( (sender is Control) && !(sender is Form) )
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS;
            }
        }

        private void codEntradaTextBox_Leave(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS_LEAVE;
            }
        }
    }
}