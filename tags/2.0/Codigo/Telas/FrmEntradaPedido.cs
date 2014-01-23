using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Negocio;
using Dominio;
using Util;
using Dados;

namespace Telas
{
    public partial class FrmEntradaPedido : Form
    {
        private EstadoFormulario estado;
        string ultimoCodigoBarraLido = "";
        
        public FrmEntradaPedido()
        {
            InitializeComponent();
        }

        private void FrmEntradaPedido_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.ENTRADA_PRODUTOS, Principal.Autenticacao.CodUsuario);
            produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterTodos();
            pessoaFornecedorBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            cstBindingSource.DataSource = GerenciadorCst.GetInstance().ObterTodos();
            entradaBindingSource.DataSource = GerenciadorEntrada.GetInstance().ObterPorTipoEntrada(Entrada.TIPO_PEDIDO_COMPRA);
            situacaoPagamentosBindingSource.DataSource = GerenciadorEntrada.GetInstance().ObterTodosSituacoesPagamentos();
            entradaBindingSource.MoveLast();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmEntradaPesquisa frmEntradaPedidoPesquisa = new Telas.FrmEntradaPesquisa();
            frmEntradaPedidoPesquisa.ShowDialog();
            if (frmEntradaPedidoPesquisa.EntradaSelected != null)
            {
                entradaBindingSource.Position = entradaBindingSource.List.IndexOf(frmEntradaPedidoPesquisa.EntradaSelected);
            }
            frmEntradaPedidoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            entradaBindingSource.AddNew();
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
                GerenciadorEntrada.GetInstance().Remover(Convert.ToInt64(codEntradaTextBox.Text));
                entradaBindingSource.RemoveCurrent();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitaBotoes(true);
            
            entradaBindingSource.CancelEdit();
            entradaBindingSource.EndEdit();
            entradaProdutoBindingSource.CancelEdit();
            entradaProdutoBindingSource.EndEdit();
            ProdutosGroupBox.Enabled = false;
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Entrada entrada = new Entrada();
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
                        
            GerenciadorEntrada gEntrada = GerenciadorEntrada.GetInstance();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                entrada.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;

                entrada.CodEntrada = gEntrada.Inserir(entrada);
                habilitaBotoes(true);
                btnProdutos.Focus();
            }
            else if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                GerenciadorEntradaProduto gEntradaProduto = GerenciadorEntradaProduto.GetInstance();
                EntradaProduto entradaProduto = new EntradaProduto();
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
                entradaProduto.Ncmsh = ((Produto) produtoBindingSource.Current).Ncmsh;
                entradaProduto.UnidadeCompra = unidadeCompraTextBox.Text;
                entradaProduto.ValorICMS = 0;
                entradaProduto.ValorICMSST = 0;
                entradaProduto.ValorIPI = 0;
                entradaProduto.ValorTotal = Convert.ToDecimal(valorTotalTextBox.Text);
                entradaProduto.ValorUnitario = Convert.ToDecimal(valorUnitarioTextBox.Text);
                entradaProduto.QtdProdutoAtacado = Convert.ToDecimal(qtdProdutoAtacadoTextBox.Text);
                entradaProduto.Desconto = Convert.ToDecimal(descontoProdutoTextBox.Text);

                entradaProduto.FornecedorEhFabricante = ((Dados.saceDataSet.tb_pessoaRow) ((System.Data.DataRowView) pessoaFornecedorBindingSource.Current).Row).ehFabricante;
                entradaProduto.CodFornecedor = ((Dados.saceDataSet.tb_pessoaRow)((System.Data.DataRowView)pessoaFornecedorBindingSource.Current).Row).codPessoa;

                GerenciadorEntradaProduto.GetInstance().Inserir(entradaProduto, entrada.CodTipoEntrada);
                codEntradaTextBox_TextChanged(sender, e);
                btnProdutos_Click(sender, e);
            }
            else 
            {
                gEntrada.Atualizar(entrada);
                entradaBindingSource.Position = entradaBindingSource.List.IndexOf(entrada);
                produtoBindingSource.Position = 0;
                habilitaBotoes(true);
                btnProdutos.Focus();
            }
            entradaBindingSource.EndEdit();
        }

        private void excluirProduto(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirma exclusão do produto?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_entrada_produtoDataGridView.Rows.Count > 0)
                {
                    EntradaProduto _entradaProduto = (EntradaProduto)entradaProdutoBindingSource.Current;
                    Entrada _entrada = (Entrada)entradaBindingSource.Current;
                    GerenciadorEntradaProduto.GetInstance().Remover(_entradaProduto, _entrada.CodTipoEntrada);
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
                    entradaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    entradaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    entradaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    entradaBindingSource.MoveNext();
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
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaFornecedorBindingSource.Position = pessoaFornecedorBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codFornecedorComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.PessoaSelected != null)
                    {
                        pessoaFornecedorBindingSource.Position = pessoaFornecedorBindingSource.List.IndexOf(frmPessoa.PessoaSelected);
                    }
                    frmPessoa.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codEmpresaFreteComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaTransportadoraBindingSource.Position = pessoaTransportadoraBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codEmpresaFreteComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.PessoaSelected != null)
                    {
                        pessoaTransportadoraBindingSource.Position = pessoaTransportadoraBindingSource.List.IndexOf(frmPessoa.PessoaSelected);
                    }
                    frmPessoa.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codProdutoComboBox.Focused))
                {
                    Telas.FrmProdutoPesquisaPreco frmProdutoPesquisaPreco = new Telas.FrmProdutoPesquisaPreco(true);
                    frmProdutoPesquisaPreco.ShowDialog();
                    if (frmProdutoPesquisaPreco.ProdutoPesquisa != null)
                    {
                        produtoBindingSource.Position = produtoBindingSource.List.IndexOf(frmProdutoPesquisaPreco.ProdutoPesquisa);
                    }
                    frmProdutoPesquisaPreco.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codProdutoComboBox.Focused))
                {
                    Telas.FrmProduto frmProduto = new Telas.FrmProduto();
                    frmProduto.ShowDialog();
                    if (frmProduto.ProdutoPesquisa != null)
                    {
                        produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterTodos();
                        produtoBindingSource.Position = produtoBindingSource.List.IndexOf(frmProduto.ProdutoPesquisa);
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
            entradaProdutoBindingSource.AddNew();
            codProdutoComboBox.SelectedIndex = 0;
            produtoBindingSource.Position = 0;
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
                List<Pessoa> pessoas = (List<Pessoa>)GerenciadorPessoa.GetInstance().ObterPorNomeFantasia(codFornecedorComboBox.Text);
                if (pessoas.Count == 0)
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(codFornecedorComboBox.Text);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaFornecedorBindingSource.Position = pessoaFornecedorBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                        codFornecedorComboBox.Text = frmPessoaPesquisa.PessoaSelected.Nome;
                    }
                    else
                    {
                        codFornecedorComboBox.Focus();
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else
                {
                    pessoaFornecedorBindingSource.Position = pessoaFornecedorBindingSource.List.IndexOf(pessoas[0]);
                }

            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void codEmpresaFreteComboBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR))
            {

                List<Pessoa> pessoas = (List<Pessoa>)GerenciadorPessoa.GetInstance().ObterPorNomeFantasia(codEmpresaFreteComboBox.Text);
                if (pessoas.Count == 0)
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(codEmpresaFreteComboBox.Text);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaTransportadoraBindingSource.Position = pessoaTransportadoraBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                        codEmpresaFreteComboBox.Text = frmPessoaPesquisa.PessoaSelected.Nome;
                    }
                    else
                    {
                        codEmpresaFreteComboBox.Focus();
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else
                {
                    pessoaTransportadoraBindingSource.Position = pessoaTransportadoraBindingSource.List.IndexOf(pessoas[0]);
                }
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                ProdutoPesquisa _produtoPesquisa = ComponentesLeave.ProdutoComboBox_Leave(sender, e, codProdutoComboBox, estado, produtoBindingSource, ref ultimoCodigoBarraLido, true);
                if (_produtoPesquisa != null)
                {
                    quantidadeTextBox.Text = "0";
                    codCSTComboBox_SelectedIndexChanged(sender, e);
                    preencherDadosEstatisticos((Produto) produtoBindingSource.Current);
                    atualizaValores();
                }
            }
            codEntradaTextBox_Leave(sender, e);
        }

        private void preencherDadosEstatisticos(Produto produto) {

            produtosVendidosBindingSource.DataSource = GerenciadorProdutosVendidos.getInstace().obterProdutosVendidos(produto.CodProduto);
            //this.tb_produto_lojaTableAdapter.FillByCodProduto(this.saceDataSet.tb_produto_loja, produto.CodProduto);
            //this.entradasPorProdutoTableAdapter.FillEntradasByProduto(this.saceDataSetConsultas.EntradasPorProduto, produto.CodProduto);
            //this.produtosVendidosTableAdapter.FillQuantidadeProdutosVendidosMesAnoAsc(saceDataSetConsultas.ProdutosVendidos, produto.CodProduto);

            Dados.saceDataSetConsultas.ProdutosVendidosDataTable pVendidosTable = new Dados.saceDataSetConsultas.ProdutosVendidosDataTable();
            //pVendidosTable = this.saceDataSetConsultas.ProdutosVendidos;

            chart1.DataSource = produtosVendidosBindingSource;

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
                Cst cst = new Cst() { CodCST = codCSTComboBox.SelectedValue.ToString()};
                Produto produto = (Produto)produtoBindingSource.Current;

                icms_substitutoTextBox.ReadOnly = cst.EhTributacaoIntegral;
                icms_substitutoTextBox.TabStop = !icms_substitutoTextBox.ReadOnly;

                icmsTextBox.ReadOnly = !cst.EhTributacaoIntegral;
                icmsTextBox.TabStop = !icmsTextBox.ReadOnly;

                //inicializaVariaveis();

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
                entradaProdutoBindingSource.DataSource = GerenciadorEntradaProduto.GetInstance().ObterPorEntrada(long.Parse(codEntradaTextBox.Text));
                //decimal? total = tb_entrada_produtoTableAdapter.totalEntrada(long.Parse(codEntradaTextBox.Text));
                //if (total != null) {
                //    totalNotaCalculadoTextBox.Text = ((decimal) total).ToString("N2");
                //}
            }
        }

        private void valorUnitarioTextBox_Leave(object sender, EventArgs e)
        {
           if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
           {
                FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
                //inicializaVariaveis();
                atualizaValores();
           }
           codEntradaTextBox_Leave(sender, e);
        }

        private void atualizaValores()
        {
            EntradaProduto entradaProduto = (EntradaProduto)entradaProdutoBindingSource.Current;
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

            Produto _produto = (Produto) produtoBindingSource.Current;
            _produto.UltimoPrecoCompra = entradaProduto.ValorUnitario / entradaProduto.QuantidadeEmbalagem;
            _produto.Icms = entradaProduto.Icms;
            _produto.Simples = entradaProduto.Simples;
            _produto.Ipi = entradaProduto.Ipi;
            _produto.CodCST = codCSTComboBox.SelectedValue.ToString();
            _produto.Frete = entradaProduto.Frete;
            _produto.Desconto = entradaProduto.Desconto;
            entradaProduto.PrecoCusto = _produto.PrecoCusto;
            _produto.LucroPrecoVendaVarejo = Convert.ToDecimal(lucroPrecoVendaVarejoTextBox.Text);
            _produto.LucroPrecoVendaAtacado = Convert.ToDecimal(lucroPrecoVendaAtacadoTextBox.Text);
            precoVarejoSugestaoTextBox.Text = _produto.PrecoVendaVarejoSugestao.ToString("N3");
            precoAtacadoSugestaoTextBox.Text = _produto.PrecoVendaAtacadoSugestao.ToString("N3");
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