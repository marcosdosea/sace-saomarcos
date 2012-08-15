using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Negocio;
using Dominio;
using Util;
using System.Data;

namespace Telas
{
    public partial class FrmEntradaPedido : Form
    {
        private EstadoFormulario estado;
        private Entrada entrada;
        private EntradaProduto entradaProduto;
        private Produto produto;
        string ultimoCodigoBarraLido = "";
        
        public FrmEntradaPedido()
        {
            InitializeComponent();
        }

        private void FrmEntradaPedido_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.ENTRADA_PRODUTOS, Principal.Autenticacao.CodUsuario);
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
            if ((codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 1)) {
                this.tb_entrada_produtoTableAdapter.FillByCodEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
            }
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_entradaTableAdapter.FillPedidos(this.saceDataSet.tb_entrada);
            this.tb_situacao_pagamentosTableAdapter.Fill(this.saceDataSet.tb_situacao_pagamentos);
            this.tb_cstTableAdapter.Fill(this.saceDataSet.tb_cst);
            entrada = new Entrada();
            entradaProduto = new EntradaProduto();
            tb_entradaBindingSource.MoveLast();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmEntradaPesquisa FrmEntradaPedidoPesquisa = new Telas.FrmEntradaPesquisa();
            FrmEntradaPedidoPesquisa.ShowDialog();
            if (FrmEntradaPedidoPesquisa.getCodEntrada() != -1)
            {
                tb_entradaBindingSource.Position = tb_entradaBindingSource.Find("codEntrada", FrmEntradaPedidoPesquisa.getCodEntrada());
            }
            FrmEntradaPedidoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_entradaBindingSource.AddNew();
            codEntradaTextBox.Enabled = false;
            codFornecedorComboBox.Focus();
            codFornecedorComboBox.SelectedIndex = 0;
            codFornecedorComboBox.SelectAll();
            codEmpresaFreteComboBox.SelectedIndex = 0;
            dataEntradaDateTimePicker.Text = DateTime.Now.ToShortDateString();
            //codSituacaoPagamentosComboBox.SelectedIndex = 0;
            fretePagoEmitenteCheckBox.Checked = true;
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codFornecedorComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorEntrada.getInstace().remover(Convert.ToInt64(codEntradaTextBox.Text));
                tb_entradaTableAdapter.FillPedidos(saceDataSet.tb_entrada);
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
            entrada.CodTipoEntrada = Entrada.TIPO_PEDIDO_COMPRA;
            entrada.DataEmissao = Convert.ToDateTime(dataEntradaDateTimePicker.Text);
            entrada.DataEntrada = Convert.ToDateTime(dataEntradaDateTimePicker.Text);
            entrada.Desconto = Convert.ToDecimal(descontoTextBox.Text);
            entrada.NumeroNotaFiscal = DateTime.Now.ToString();
            entrada.OutrasDespesas = 0;
            entrada.TotalBaseCalculo = 0;
            entrada.TotalBaseSubstituicao = 0;
            entrada.TotalICMS = Convert.ToDecimal(totalICMSTextBox.Text);
            entrada.TotalIPI = 0;
            entrada.TotalNota = 0;
            entrada.TotalProdutos = Convert.ToDecimal(totalNotaCalculadoTextBox.Text);
            entrada.TotalProdutosST = 0;
            entrada.TotalSubstituicao = 0;
            entrada.ValorFrete = Convert.ToDecimal(valorFreteTextBox.Text);
            entrada.ValorSeguro = 0;
            entrada.FretePagoEmitente = fretePagoEmitenteCheckBox.Checked;
            entrada.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;
                        
            IGerenciadorEntrada gEntrada = GerenciadorEntrada.getInstace();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                entrada.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;

                entrada.CodEntrada = gEntrada.inserir(entrada);
                tb_entradaTableAdapter.FillPedidos(saceDataSet.tb_entrada);
                tb_entradaBindingSource.Position = tb_entradaBindingSource.Find("codEntrada", entrada.CodEntrada);
                habilitaBotoes(true);
                btnProdutos.Focus();
            }
            else if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                IGerenciadorEntradaProduto gEntradaProduto = GerenciadorEntradaProduto.getInstace();
                EntradaProduto entradaProduto = new EntradaProduto();
                entradaProduto.CodTipoEntrada = entrada.CodTipoEntrada;
                entradaProduto.CodProduto = Convert.ToInt32(codProdutoComboBox.SelectedValue.ToString());
                entradaProduto.BaseCalculoICMS = 0;
                entradaProduto.BaseCalculoICMSST = 0;
                entradaProduto.Cfop = 9999;
                entradaProduto.CodCST = codCSTComboBox.SelectedValue.ToString();
                entradaProduto.CodEntrada = entrada.CodEntrada;
                entradaProduto.DataEntrada = entrada.DataEntrada;
                entradaProduto.DataValidade = entrada.DataEntrada;
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
                entradaProduto.Ncmsh = produto.Ncmsh;
                entradaProduto.UnidadeCompra = unidadeCompraTextBox.Text;
                entradaProduto.ValorICMS = 0;
                entradaProduto.ValorICMSST = 0;
                entradaProduto.ValorIPI = 0;
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
                tb_entradaTableAdapter.FillPedidos(saceDataSet.tb_entrada);
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

        private void FrmEntradaPedido_KeyDown(object sender, KeyEventArgs e)
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
            ProdutosGroupBox.Enabled = true;
            codProdutoComboBox.Focus();
            simplesTextBox.Text = Global.SIMPLES.ToString();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
        }

        private void codFornecedorComboBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                Pessoa pessoa = GerenciadorPessoa.getInstace().obterPessoaNomeIgual(codFornecedorComboBox.Text);
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

                Pessoa pessoa = GerenciadorPessoa.getInstace().obterPessoaNomeIgual(codEmpresaFreteComboBox.Text);
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
                    }
                }
                if (produto != null)
                {
                    quantidadeTextBox.Text = "0";
                    codCSTComboBox_SelectedIndexChanged(sender, e);
                    preencherDadosEstatisticos(produto);
                    atualizaValores();
                }
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void preencherDadosEstatisticos(Produto produto) {

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

        private void codCSTComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((codCSTComboBox.SelectedValue != null) && (ProdutosGroupBox.Enabled) && estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                bool ehTributadoIntegral = GerenciadorProduto.getInstace().ehProdututoTributadoIntegral(codCSTComboBox.SelectedValue.ToString());

                icms_substitutoTextBox.ReadOnly = ehTributadoIntegral;
                icms_substitutoTextBox.TabStop = !icms_substitutoTextBox.ReadOnly;

                icmsTextBox.ReadOnly = !ehTributadoIntegral;
                icmsTextBox.TabStop = !icmsTextBox.ReadOnly;

                inicializaVariaveis();

                icmsTextBox.Text = totalICMSTextBox.Text;
                icms_substitutoTextBox.Text = produto.IcmsSubstituto.ToString("N2");
                ipiTextBox.Text = produto.Ipi.ToString("N2");
                descontoProdutoTextBox.Text = descontoTextBox.Text;
                freteTextBox.Text = valorFreteTextBox.Text;
                simplesTextBox.Text = produto.Simples.ToString("N2");
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

        private void valorUnitarioTextBox_Leave(object sender, EventArgs e)
        {
           if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
           {
                FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
                inicializaVariaveis();
                atualizaValores();
           }
           codEntradaTextBox_Leave(sender, e);
        }

        private void atualizaValores()
        {
            entradaProduto.ValorTotal = Convert.ToDecimal(valorTotalTextBox.Text);

            if ((entradaProduto.ValorTotal > 0) && valorTotalTextBox.Focused)
            {
                entradaProduto.ValorUnitario = entradaProduto.ValorTotal / entradaProduto.Quantidade;
                valorUnitarioTextBox.Text = entradaProduto.ValorUnitario.ToString("N3");
            }
            valorTotalTextBox.Text = (entradaProduto.ValorUnitario * entradaProduto.Quantidade).ToString("N2");

            entradaProduto.Icms = Convert.ToDecimal(icmsTextBox.Text);
            entradaProduto.IcmsSubstituto = Convert.ToDecimal(icms_substitutoTextBox.Text);
            entradaProduto.Ipi = Convert.ToDecimal(ipiTextBox.Text);
            entradaProduto.Frete = Convert.ToDecimal(freteTextBox.Text);
            entradaProduto.Desconto = Convert.ToDecimal(descontoProdutoTextBox.Text);

            entradaProduto.ValorICMSST = entradaProduto.ValorTotal * entradaProduto.IcmsSubstituto / 100;

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

        private void quantidadeTextBox_Leave(object sender, EventArgs e)
        {
            valorUnitarioTextBox_Leave(sender, e);
            decimal quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
            if (quantidade <= 0)
            {
                quantidadeTextBox.Focus();
                throw new TelaException("A quantidade de produtos do pedido deve ser maior que zero.");
            }
            codEntradaTextBox_Leave(sender, e);
            btnSalvar.Focus();
        }

        private void inicializaVariaveis()
        {
            if (entradaProduto != null)
            {
                entradaProduto.ValorUnitario = Convert.ToDecimal(valorUnitarioTextBox.Text);
                entradaProduto.Quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
                entradaProduto.Icms = Convert.ToDecimal(icmsTextBox.Text);
                //entradaProduto.IcmsSubstituto = Convert.ToDecimal(icms_substitutoTextBox.Text);
                entradaProduto.Ipi = Convert.ToDecimal(ipiTextBox.Text);
                entradaProduto.Simples = Global.SIMPLES;
                entradaProduto.Desconto = Convert.ToDecimal(descontoProdutoTextBox.Text);
                entradaProduto.BaseCalculoICMS = 0;
                entradaProduto.BaseCalculoICMSST = 0;
                entradaProduto.ValorICMSST = 0;
                entradaProduto.CodCST = codCSTComboBox.SelectedValue.ToString();
            }

            if (entrada != null)
            {
                // armazena a porcentagem estimada do frete
                entrada.ValorFrete = Convert.ToDecimal(valorFreteTextBox.Text);
                // armazena a porcentagem padrão do icms
                entrada.TotalICMS = Convert.ToDecimal(totalICMSTextBox.Text);
                entrada.TotalNota = 0;
                entrada.TotalProdutos = 0;
                entrada.TotalProdutosST = 0;
                entrada.TotalSubstituicao = 0;
                entrada.Desconto = Convert.ToDecimal(descontoTextBox.Text);
            }
        }

        private void precoVendaVarejoTextBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE) || estado.Equals(EstadoFormulario.INSERIR))
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

        private void descontoTextBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE) || estado.Equals(EstadoFormulario.INSERIR))
            {
                FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            }
            codEntradaTextBox_Leave(sender, e);
            btnSalvar.Focus();
        }

        private void codEntradaTextBox_Enter(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
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