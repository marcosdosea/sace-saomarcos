using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Dados;
using Util;

namespace Telas
{
    public partial class FrmSaida : Form {

        private const string ENTRADA_MANUAL = "F1-MANUAL";
        private const string ENTRADA_AUTOMATICA = "F1-AUTOMÁTICA";

        private EstadoFormulario estado;
        private Produto produto, produtoOriginal;
        private Saida saida;
        private SaidaProduto saidaProduto;
        private String ultimoCodigoBarraLido = "";


        public FrmSaida(int tipoSaida)
        {
            InitializeComponent();
            saida = new Saida();
            saida.TipoSaida = tipoSaida;
            saidaProduto = new SaidaProduto();
            produto = new Produto();
        }

        /// <summary>
        /// Carrega os dados de todas os Pedidos e faz uma cache da lista
        /// de produtos que podem ser exibidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSaida_Load(object sender, EventArgs e)
        {
            //GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.SAIDA, Principal.Autenticacao.CodUsuario);

            Cursor.Current = Cursors.WaitCursor;
            GerenciadorSaida.getInstace().atualizarPedidosComDocumentosFiscais();

            this.tb_produtoTableAdapter.FillExibiveis(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
            if (saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO)
            {
                lblSaidaProdutos.Text = "Saída para Depósito";
                this.Text = "Saída para Depósito";
                this.tb_saidaTableAdapter.FillSaidasDeposito(this.saceDataSet.tb_saida);
            }
            else
            {
                this.tb_saidaTableAdapter.Fill(this.saceDataSet.tb_saida);
            }
                        
            tb_saidaBindingSource.MoveLast();
            quantidadeTextBox.Text = "1";
            precoVendatextBox.Text = "0,00";
            habilitaBotoes(true);
            estado = EstadoFormulario.ESPERA;
            lblFormaEntrada.Text = ENTRADA_AUTOMATICA;
            lblFormaEntrada.ForeColor = Color.Lime;
            
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Busca de pedidos cadastrados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmSaidaPesquisa frmSaidaPesquisa = new Telas.FrmSaidaPesquisa();
            frmSaidaPesquisa.ShowDialog();
            if (frmSaidaPesquisa.CodSaida != -1)
            {
                tb_saidaBindingSource.Position = tb_saidaBindingSource.Find("codSaida", frmSaidaPesquisa.CodSaida);
            }
            frmSaidaPesquisa.Dispose();
        }

        /// <summary>
        /// Cria e grava uma nova saída para entrada de itens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovo_Click(object sender, EventArgs e)
        {
            saida.CodCliente = Global.CLIENTE_PADRAO;
            saida.CodProfissional = Global.PROFISSIONAL_PADRAO;
            saida.DataSaida = DateTime.Now;
            saida.Desconto = 0;
            saida.NumeroCartaoVenda = 0;
            saida.PedidoGerado = null;
            saida.Total = 0;
            saida.TotalAVista = 0;
            saida.TotalLucro = 0;
            saida.TotalPago = 0;
            saida.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;
            saida.Troco = 0;
            saida.Nfe = null;
            saida.EntregaRealizada = true;
            
            subtotalTextBox.Text = "0,00";
            subtotalAVistatextBox.Text = "0,00";
            precoVendaSemDescontoTextBox.Text = "0,00";
            precoVendatextBox.Text = "0,00";

            GerenciadorSaida.getInstace().inserir(saida);
            tb_saidaTableAdapter.Fill(saceDataSet.tb_saida);
            tb_saidaBindingSource.MoveLast();
                
            codProdutoComboBox.Focus();
            codProdutoComboBox.Text = "";
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
        }


        /// <summary>
        /// Permite editar um pedido. Se o pedido já for uma uma Pré-Venda
        /// é necessário excluir o pedido que foi gravado para impressão fiscal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            saida = GerenciadorSaida.getInstace().obterSaida( Convert.ToInt64(codSaidaTextBox.Text) );
            if (saida.TipoSaida == Saida.TIPO_PRE_VENDA) {
                GerenciadorSaida.getInstace().removerPreVenda(saida);
                GerenciadorSaidaPagamento.getInstace().removerPagamentos(saida);
                List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
                GerenciadorSaida.getInstace().registrarEstornoEstoque(saidaProdutos);
                saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                saida.PedidoGerado = "";
                GerenciadorSaida.getInstace().atualizar(saida);
                this.tb_saidaTableAdapter.Fill(this.saceDataSet.tb_saida);
                tb_saidaBindingSource.Position = tb_saidaBindingSource.Find("codSaida", saida.CodSaida);
            }
            
            codProdutoComboBox.Focus();
            codProdutoComboBox.Text = "";
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
        }

        
        
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Saida saida = GerenciadorSaida.getInstace().obterSaida(Int64.Parse(codSaidaTextBox.Text));
                if  ( (saida.TipoSaida == Saida.TIPO_VENDA) && (MessageBox.Show("Houve Cancelamento do Cupom Fiscal? Confirma transformar VENDA em ORÇAMENTO?", "Confirmar Transformar Venda em Orçamento", MessageBoxButtons.YesNo) == DialogResult.Yes) )
                {
                    GerenciadorSaida.getInstace().remover(saida);
                } else {
                    GerenciadorSaida.getInstace().remover(saida);
                }
                tb_saidaTableAdapter.Fill(saceDataSet.tb_saida);
                tb_saidaBindingSource.MoveLast(); 
            }
            estado = EstadoFormulario.ESPERA;
            btnNovo.Focus();
        }

        /// <summary>
        /// Se cancelar um pedido sem itens então a saída é excluída.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (codProdutoComboBox.Focused)
            {
                if ((tb_saida_produtoDataGridView.RowCount == 0) && (estado.Equals(EstadoFormulario.INSERIR_DETALHE)))
                {
                    Saida saida = GerenciadorSaida.getInstace().obterSaida(Int64.Parse(codSaidaTextBox.Text));
                    GerenciadorSaida.getInstace().remover(saida);
                    tb_saidaTableAdapter.Fill(saceDataSet.tb_saida);
                    tb_saidaBindingSource.MoveLast();
                    habilitaBotoes(true);
                    estado = EstadoFormulario.ESPERA;
                    btnNovo.Focus();
                }
                else if ((tb_saida_produtoDataGridView.RowCount > 0) && (estado.Equals(EstadoFormulario.INSERIR_DETALHE)))
                {
                    btnEncerrar_Click(sender, e);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                codProdutoComboBox.Focus();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            saidaProduto = new SaidaProduto();
            saidaProduto.CodProduto = produto.CodProduto;
            saidaProduto.CodSaida = long.Parse(codSaidaTextBox.Text);
            saidaProduto.Desconto = 10;
            saidaProduto.Quantidade = decimal.Parse(quantidadeTextBox.Text);
            saidaProduto.ValorVenda = decimal.Parse(precoVendaSemDescontoTextBox.Text);
            saidaProduto.ValorVendaAVista = decimal.Parse(precoVendatextBox.Text);
            saidaProduto.DataValidade = Convert.ToDateTime(data_validadeDateTimePicker.Text);

            codProdutoComboBox.Focus();
            codProdutoComboBox.Text = "";

            IGerenciadorSaidaProduto gSaidaProduto = GerenciadorSaidaProduto.getInstace();
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                gSaidaProduto.inserir(saidaProduto, saida);
                codSaidaTextBox_TextChanged(sender, e);
                tbsaidaprodutoBindingSource.MoveLast();

                if (tb_saida_produtoDataGridView.RowCount > 0)
                {
                    saida = GerenciadorSaida.getInstace().obterSaida(Convert.ToInt64(codSaidaTextBox.Text));
                    totalTextBox.Text = saida.Total.ToString();
                    totalAVistaTextBox.Text = saida.TotalAVista.ToString();
                }
            }
        }

        /// <summary>
        /// Permite excluir o pedido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void excluirProduto(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão do produto?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_saida_produtoDataGridView.Rows.Count > 0)
                {
                    saidaProduto.CodSaidaProduto = long.Parse(tb_saida_produtoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    saidaProduto.CodSaida = Convert.ToInt64(codSaidaTextBox.Text);
                    
                    Negocio.GerenciadorSaidaProduto.getInstace().remover(saidaProduto, saida);

                    saida = GerenciadorSaida.getInstace().obterSaida(Convert.ToInt64(codSaidaTextBox.Text));
                    totalTextBox.Text = saida.Total.ToString();
                    totalAVistaTextBox.Text = saida.TotalAVista.ToString();
                }
            }
            estado = EstadoFormulario.INSERIR_DETALHE;
            codSaidaTextBox_TextChanged(sender, e);
            codProdutoComboBox.Focus();
        }

        
        /// <summary>
        /// Permite escolher um produto pela descrição, código ou código de barra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            bool entradaViaCodigoBarra = false;

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
                        entradaViaCodigoBarra = (produto != null);
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

                    // Exibe dados do produto selecionado
                    codProdutoComboBox.Text = produto.Nome;
                    produtoOriginal = (Produto)produto.Clone();
                    tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", produto.CodProduto);
                    if (saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO)
                    {
                        precoVendatextBox.Text = produto.UltimoPrecoCompra.ToString("N3");
                        precoVendaSemDescontoTextBox.Text = "0.00";
                    }
                    else
                    {
                        precoVendatextBox.Text = produto.PrecoVendaVarejo.ToString("N3");
                        precoVendaSemDescontoTextBox.Text = produto.PrecoVendaVarejo.ToString("N3");
                        data_validadeDateTimePicker.Enabled = produto.TemVencimento;
                        data_validadeDateTimePicker.TabStop = produto.TemVencimento;
                    }
                    buscaPrecos();
                    atualizarSubTotal();
                    if (entradaViaCodigoBarra && (lblFormaEntrada.Text.Equals(ENTRADA_AUTOMATICA)))
                    {
                        
                        btnSalvar_Click(sender, e);
                    }
                }
            }
        }

        /// <summary>
        /// De acordo com a quantidade escolhida define o preço
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quantidadeTextBox_Leave(object sender, EventArgs e)
        {

            FormatTextBox.NumeroCom2CasasDecimais((TextBox) sender);
            buscaPrecos();
            atualizarSubTotal();
        }

        private void buscaPrecos()
        {
            decimal quantidade = Convert.ToDecimal(quantidadeTextBox.Text);

            if (produto != null)
            {
                if (saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO)
                {
                    precoVendatextBox.Text = produto.UltimoPrecoCompra.ToString("N3");
                    precoVendaSemDescontoTextBox.Text = produto.UltimoPrecoCompra.ToString("N3");
                }
                else
                {
                    if ((produto.QtdProdutoAtacado != 0) && (quantidade >= produto.QtdProdutoAtacado))
                    {
                        precoVendaSemDescontoTextBox.Text = produtoOriginal.PrecoVendaAtacadoSemDesconto.ToString();
                        precoVendatextBox.Text = produtoOriginal.PrecoVendaAtacado.ToString();
                    }
                    else
                    {
                        precoVendaSemDescontoTextBox.Text = produtoOriginal.PrecoVendaVarejoSemDesconto.ToString();
                        precoVendatextBox.Text = produtoOriginal.PrecoVendaVarejo.ToString();
                    }
                }
            }
        }

        private void atualizarSubTotal()
        {
            decimal quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
            decimal preco = Convert.ToDecimal(precoVendaSemDescontoTextBox.Text);
            decimal precoAVista = Convert.ToDecimal(precoVendatextBox.Text);
            subtotalTextBox.Text = (quantidade * preco).ToString("N2");
            subtotalAVistatextBox.Text = (quantidade * precoAVista).ToString("N2");
        }

        /// <summary>
        /// Exibe os produtos de uma determinada Venda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codSaidaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!codSaidaTextBox.Text.Trim().Equals(""))
            {
                tb_saida_produtoTableAdapter.FillByCodSaida(this.saceDataSet.tb_saida_produto, long.Parse(codSaidaTextBox.Text));
            }
        }

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void precoVendatextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais(precoVendatextBox);
            produto.PrecoVendaVarejo = Convert.ToDecimal(precoVendatextBox.Text);
            if (saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO)
            {
                precoVendaSemDescontoTextBox.Text = produto.PrecoVendaVarejo.ToString("N2");
            }
            else
            {
                precoVendaSemDescontoTextBox.Text = produto.PrecoVendaVarejoSemDesconto.ToString("N2");
            }
            atualizarSubTotal();
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                habilitaBotoes(true);
                estado = EstadoFormulario.ESPERA;
               
                saida = GerenciadorSaida.getInstace().obterSaida(long.Parse(codSaidaTextBox.Text));
                saida.EntregaRealizada = entregaRealizadaCheckBox.Checked;

                if (saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO)
                {
                    FrmSaidaDeposito frmSaidaDeposito = new FrmSaidaDeposito(saida);
                    frmSaidaDeposito.ShowDialog();
                    frmSaidaDeposito.Dispose();
                    this.tb_saidaTableAdapter.FillSaidasDeposito(this.saceDataSet.tb_saida);
                }
                else
                {
                    FrmSaidaPagamento frmSaidaPagamento = new FrmSaidaPagamento(saida);
                    frmSaidaPagamento.ShowDialog();
                    frmSaidaPagamento.Dispose();
                    GerenciadorSaida.getInstace().atualizarPedidosComDocumentosFiscais();
                    this.tb_saidaTableAdapter.Fill(this.saceDataSet.tb_saida);
                }
                descricaoTipoSaidaTextBox.Text = ((saceDataSet.tb_saidaRow) ((DataRowView)tb_saidaBindingSource.Current).Row).descricaoTipoSaida;
                tb_saidaBindingSource.Position = tb_saidaBindingSource.Find("codSaida", saida.CodSaida);
                //tb_saidaBindingSource.MoveLast();
                tb_produtoBindingSource.MoveFirst();
                btnNovo.Focus();
            }
            Cursor.Current = Cursors.Default;
        }

        private void quantidadeTextBox_Enter(object sender, EventArgs e)
        {
            quantidadeTextBox.SelectAll();
        }

        private void data_validadeDateTimePicker_Leave(object sender, EventArgs e)
        {
            DateTime dataVencimento = Convert.ToDateTime(data_validadeDateTimePicker.Text);
            if (!GerenciadorSaida.getInstace().dataVencimentoProdutoAceitavel(produto, dataVencimento))
            {
                if (MessageBox.Show("Existem Produtos no estoque com data de validade mais antiga. Manter o Produto lançado?", "Confirmar Data Validade", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    data_validadeDateTimePicker.Focus();
                }
            }
        }
 
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmSaidaDAV frmSaidaDav = new FrmSaidaDAV( Convert.ToInt64(codSaidaTextBox.Text) );
            frmSaidaDav.ShowDialog();
            frmSaidaDav.Dispose();
        }

        private void btnCfNfe_Click(object sender, EventArgs e)
        {
            Saida saida = GerenciadorSaida.getInstace().obterSaida(long.Parse(codSaidaTextBox.Text));

            if (saida.TipoSaida == Saida.TIPO_PRE_VENDA) {
                if (MessageBox.Show("Confirma impressão do Cupom Fiscal?", "Confirmar Impressão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GerenciadorSaida.getInstace().imprimirNotaFiscal(saida);
                }
            }
            else if (saida.TipoSaida == Saida.TIPO_VENDA)
            {
                FrmSaidaNF frmSaidaNF = new FrmSaidaNF(saida);
                frmSaidaNF.ShowDialog();
                frmSaidaNF.Dispose();
            } else if (saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO) {
                GerenciadorSaida.getInstace().imprimirNotaFiscal(saida);
            } else {
                throw new TelaException("Impossível imprimir um Cupom Fiscal ou NF-e a partir de um ORÇAMENTO. Faça a edição do pedido e transforme-o numa PRÉ-VENDA.");
            }
        }
        
        private void tb_saida_produtoDataGridView_Leave(object sender, EventArgs e)
        {
            estado = EstadoFormulario.INSERIR_DETALHE;
        }

        
        private void FrmSaida_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnExcluir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F8)
                {
                    btnImprimir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F9)
                {
                    btnCfNfe_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_saidaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_saidaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_saidaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_saidaBindingSource.MoveNext();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{tab}");
                } else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F7)
                {
                    btnEncerrar_Click(sender, e);
                } 
                else if (e.KeyCode == Keys.Escape)
                {
                    btnCancelar_Click(sender, e);
                }
                // Coloca o foco na grid caso ela não possua
                else if (e.KeyCode == Keys.F12)
                {
                    if (tb_saida_produtoDataGridView.Focused)
                    {
                        codProdutoComboBox.Focus();
                        codProdutoComboBox.Text = "";
                    }
                    else
                    {
                        estado = EstadoFormulario.ATUALIZAR_DETALHE;
                        tb_saida_produtoDataGridView.Focus();
                    }
                }
                // permite excluir um contato quando o foco está na grid
                else if ((e.KeyCode == Keys.Delete) && (tb_saida_produtoDataGridView.Focused == true))
                {
                    excluirProduto(sender, e);
                } else if (e.KeyCode == Keys.F1) {
                    if (lblFormaEntrada.Text.Equals(ENTRADA_MANUAL)) {
                        lblFormaEntrada.Text = ENTRADA_AUTOMATICA;
                        lblFormaEntrada.ForeColor = Color.Lime;
                    } else {
                        lblFormaEntrada.Text = ENTRADA_MANUAL;
                        lblFormaEntrada.ForeColor = Color.Red;
                    }

                }
            }
        }

        private void habilitaBotoes(Boolean habilita)
        {
            panelBalcao.Visible = habilita;
            lblBalcao.Visible = habilita;
            btnSalvar.Enabled = !(habilita);
            btnEncerrar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnImprimir.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_saidaBindingNavigator.Enabled = habilita;
        }



    }
}