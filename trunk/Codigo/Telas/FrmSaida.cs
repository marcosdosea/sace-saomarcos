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

        private const string PRECO_VAREJO = "CTRL+P - Preço Varejo";
        private const string PRECO_ATACADO = "CTRL+P - Preço Atacado";
        private const string PRECO_VAREJO_DESCONTO = "CTRL+P - Varejo+Desc 10%";

        private EstadoFormulario estado;
        private Produto produto, produtoOriginal;
        private Saida saida;
        private SaidaProduto saidaProduto;
        private String ultimoCodigoBarraLido = "";
        private int tipoSaidaFormulario;
        private int posicaoUltimoProduto;


        public FrmSaida(int tipoSaida)
        {
            InitializeComponent();
            saida = new Saida();
            tipoSaidaFormulario = tipoSaida;
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
           
            this.tb_produtoTableAdapter.FillExibiveis(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
            
            ObterSaidas(true);
                        
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
                ObterSaidas(false);
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
            saida.CodSaida = -1;
            saida.CodCliente = Global.CLIENTE_PADRAO;
            saida.CodProfissional = Global.PROFISSIONAL_PADRAO;
            saida.CodEmpresaFrete = Global.CLIENTE_PADRAO;
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
            saida.BaseCalculoICMS = 0;
            saida.BaseCalculoICMSSubst = 0;
            saida.EspecieVolumes = "";
            saida.Marca = "";
            saida.Numero = 0;
            saida.OutrasDespesas = 0;
            saida.PesoBruto = 0;
            saida.PesoLiquido = 0;
            saida.QuantidadeVolumes = 0;
            saida.TotalNotaFiscal = 0;
            saida.ValorFrete = 0;
            saida.ValorICMS = 0;
            saida.ValorICMSSubst = 0;
            saida.ValorIPI = 0;
            saida.ValorSeguro = 0;
            saida.Marca = "DIVERSAS";
            saida.TipoSaida = tipoSaidaFormulario;
            saida.EspecieVolumes = "VOLUMES";

            DataRowView saidaR = (DataRowView) tb_saidaBindingSource.AddNew();
            //saceDataSet.tb_saidaRow saidaRow = (saceDataSet.tb_saidaRow)saidaR.Row;

            //saidaRow.codCliente = Global.CLIENTE_PADRAO;

            baseCalculoICMSTextBox.Text = "0.00";
            valorICMSTextBox.Text = "0.00";
            baseCalculoICMSSubstTextBox.Text = "0.00";
            valorICMSSubstTextBox.Text = "0.00";
            valorIPITextBox.Text = "0.00";
            dataSaidaDateTimePicker.Text = saida.DataSaida.ToShortDateString();

            lblPreco.Text = PRECO_VAREJO;
            lblPreco.ForeColor = Color.Red;
            
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
            if (saida.TipoSaida.Equals(Saida.TIPO_PRE_VENDA)) {
                GerenciadorSaida.getInstace().ExcluirDocumentoFiscal(saida.CodSaida);
                GerenciadorSaidaPagamento.getInstace().removerPagamentos(saida);
                List<SaidaProduto> saidaProdutos = GerenciadorSaidaProduto.getInstace().obterSaidaProdutos(saida.CodSaida);
                GerenciadorSaida.getInstace().registrarEstornoEstoque(saidaProdutos);
                saida.TipoSaida = Saida.TIPO_ORCAMENTO;
                saida.CodSituacaoPagamentos = SituacaoPagamentos.ABERTA;
                saida.PedidoGerado = "";
                GerenciadorSaida.getInstace().atualizar(saida);
                descricaoTipoSaidaTextBox.Text = saida.DescricaoTipoSaida;
                //this.tb_saidaTableAdapter.Fill(this.saceDataSet.tb_saida);
                //tb_saidaBindingSource.Position = tb_saidaBindingSource.Find("codSaida", saida.CodSaida);
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
                tb_saidaBindingSource.RemoveCurrent();
                //ObterSaidas(true);
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
                long codSaida = Int64.Parse(codSaidaTextBox.Text);

                if ((tb_saida_produtoDataGridView.RowCount == 0) && (codSaida <= 0) ) {
                    tb_saidaBindingSource.CancelEdit();
                    tb_saidaBindingSource.EndEdit();
                    tb_saidaBindingSource.MoveLast();
                    habilitaBotoes(true);
                    estado = EstadoFormulario.ESPERA;
                    btnNovo.Focus();
                } else if ((tb_saida_produtoDataGridView.RowCount == 0) && (estado.Equals(EstadoFormulario.INSERIR_DETALHE)) && (codSaida > 0) )
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

        /// <summary>
        /// Salva os dados de um produto inserido na saída
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (saida.CodSaida < 0)
            {
                saida.CodSaida = GerenciadorSaida.getInstace().inserir(saida);
                codSaidaTextBox.Text = saida.CodSaida.ToString();
            }
                        
            saidaProduto = new SaidaProduto();
            saidaProduto.CodProduto = produto.CodProduto;
            saidaProduto.CodSaida = Convert.ToInt64(codSaidaTextBox.Text);
            saidaProduto.Desconto = Global.DESCONTO_PADRAO;
            saidaProduto.Quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
            saidaProduto.ValorVenda = Convert.ToDecimal(precoVendaSemDescontoTextBox.Text);
            saidaProduto.ValorVendaAVista = Convert.ToDecimal(precoVendatextBox.Text);
            saidaProduto.DataValidade = Convert.ToDateTime(data_validadeDateTimePicker.Text);
            saidaProduto.BaseCalculoICMS = Convert.ToDecimal(baseCalculoICMSTextBox.Text);
            saidaProduto.ValorICMS = Convert.ToDecimal(valorICMSTextBox.Text);
            saidaProduto.BaseCalculoICMSSubst = Convert.ToDecimal(baseCalculoICMSSubstTextBox.Text);
            saidaProduto.ValorICMSSubst = Convert.ToDecimal(valorICMSSubstTextBox.Text);
            saidaProduto.ValorIPI = Convert.ToDecimal(valorIPITextBox.Text);

            codProdutoComboBox.Focus();
            posicaoUltimoProduto = codProdutoComboBox.SelectedIndex;
            codProdutoComboBox.Text = "";
            
            GerenciadorSaidaProduto gSaidaProduto = GerenciadorSaidaProduto.getInstace();
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                gSaidaProduto.inserir(saidaProduto, saida);
                codSaidaTextBox_TextChanged(sender, e);
                tbsaidaprodutoBindingSource.MoveLast();
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
        /// Obter saídas e armazenar e disponibilizar em tela de acordo com o tipo
        /// </summary>
        private void ObterSaidas(bool somenteUltimosPedidos)
        {
            if (tipoSaidaFormulario.Equals(Saida.TIPO_SAIDA_DEPOSITO))
            {
                lblSaidaProdutos.Text = "Saída para Depósito";
                this.Text = "Saída para Depósito";
                lblBalcao.Text = "Saída Depósito";
                
                this.tb_saidaTableAdapter.FillByCodTipoSaida(this.saceDataSet.tb_saida, Saida.TIPO_SAIDA_DEPOSITO);
                tb_saida_produtoDataGridView.Height = 370;
            }
            else if (tipoSaidaFormulario.Equals(Saida.TIPO_DEVOLUCAO_FRONECEDOR))
            {
                lblSaidaProdutos.Text = "Devolução de Produtos para Fornecedor";
                this.Text = "Devolução de Produtos para Fornecedor";
                lblBalcao.Text = "Devolução";
                this.tb_saidaTableAdapter.FillByCodTipoSaida(this.saceDataSet.tb_saida, Saida.TIPO_DEVOLUCAO_FRONECEDOR);
                baseCalculoICMSSubstTextBox.ReadOnly = false;
                baseCalculoICMSTextBox.ReadOnly = false;
                valorICMSSubstTextBox.ReadOnly = false;
                baseCalculoICMSTextBox.TabStop = true;
                baseCalculoICMSSubstTextBox.TabStop = true;
                valorICMSSubstTextBox.TabStop = true;
                tb_saida_produtoDataGridView.Height = 300;
            }
            else
            {
                if (somenteUltimosPedidos)
                {
                    long codSaida = (long)this.tb_saidaTableAdapter.GetUltimoCodSaida();
                    this.tb_saidaTableAdapter.FillLastOrcamentosVendas(this.saceDataSet.tb_saida, codSaida - Global.QUANTIDADE_EXIBIR_PEDIDOS);
                }
                else
                {
                    this.tb_saidaTableAdapter.FillOrcamentosVendas(this.saceDataSet.tb_saida);
                }
                tb_saida_produtoDataGridView.Height = 370;
            }
            tb_saidaBindingSource.MoveLast();
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
                    
                    buscaPrecos();
                    
                    atualizarSubTotal();
                    if (entradaViaCodigoBarra && (lblFormaEntrada.Text.Equals(ENTRADA_AUTOMATICA)))
                    {
                        
                        btnSalvar_Click(sender, e);
                    }
                }
            }
            codSaidaTextBox_Leave(sender, e);
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
            codSaidaTextBox_Leave(sender, e);
        }

        /// <summary>
        /// Atualiza o preço de venda a prazo com o acréscimo padrão
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void precoVendatextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom3CasasDecimais(precoVendatextBox);
            produto.PrecoVendaVarejo = Convert.ToDecimal(precoVendatextBox.Text);

            if (saida.TipoSaida.Equals(Saida.TIPO_SAIDA_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FRONECEDOR))
            {
                precoVendaSemDescontoTextBox.Text = produto.PrecoVendaVarejo.ToString("N2");
            }
            else
            {
                precoVendaSemDescontoTextBox.Text = produto.PrecoVendaVarejoSemDesconto.ToString("N2");
            }
            atualizarSubTotal();
            codSaidaTextBox_Leave(sender, e);
        }

        /// <summary>
        /// Busca os preços que serão exibidos de acordo com o tipo de saída
        /// </summary>
        private void buscaPrecos()
        {
            decimal quantidade = Convert.ToDecimal(quantidadeTextBox.Text);

            if (produto != null)
            {
                if (saida.TipoSaida.Equals(Saida.TIPO_SAIDA_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FRONECEDOR))
                {
                    precoVendatextBox.Text = produto.UltimoPrecoCompra.ToString("N2");
                    precoVendaSemDescontoTextBox.Text = produto.UltimoPrecoCompra.ToString("N2");
                }
                else
                {
                    if (((produto.QtdProdutoAtacado != 0) && (quantidade >= produto.QtdProdutoAtacado)) || (lblPreco.Text.Equals(PRECO_ATACADO)))
                    {
                        precoVendaSemDescontoTextBox.Text = produtoOriginal.PrecoVendaAtacadoSemDesconto.ToString("N2");
                        precoVendatextBox.Text = produtoOriginal.PrecoVendaAtacado.ToString();
                    }
                    else if (lblPreco.Text.Equals(PRECO_VAREJO))
                    {
                        precoVendaSemDescontoTextBox.Text = produtoOriginal.PrecoVendaVarejoSemDesconto.ToString("N2");
                        precoVendatextBox.Text = produtoOriginal.PrecoVendaVarejo.ToString();
                    }
                    else if (lblPreco.Text.Equals(PRECO_VAREJO_DESCONTO))
                    {
                        precoVendaSemDescontoTextBox.Text = (produtoOriginal.PrecoVendaVarejoSemDesconto * Convert.ToDecimal(0.9)).ToString("N2");
                        precoVendatextBox.Text = ( produtoOriginal.PrecoVendaVarejo * Convert.ToDecimal(0.9)).ToString("N2");
                    }
                    data_validadeDateTimePicker.Enabled = produto.TemVencimento;
                    data_validadeDateTimePicker.TabStop = produto.TemVencimento;
                }
            }
        }

        /// <summary>
        /// Atualiza os subtotais do produto
        /// </summary>
        private void atualizarSubTotal()
        {
            decimal quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
            decimal preco = Convert.ToDecimal(precoVendaSemDescontoTextBox.Text);
            decimal precoAVista = Convert.ToDecimal(precoVendatextBox.Text);
            subtotalTextBox.Text = (quantidade * preco).ToString("N2");
            subtotalAVistatextBox.Text = (quantidade * precoAVista).ToString("N2");

            baseCalculoICMSTextBox.Text = (precoAVista * quantidade).ToString("N2");
            baseCalculoICMSSubstTextBox.Text = (precoAVista * quantidade).ToString("N2");

            calculaICMSIPI();
        }
        
        /// <summary>
        /// Faz o cálculo de ICMS e IPI do produto baseando-se sempre no preço a vista
        /// Valores são mais utilzados para devolução de produtos.
        /// </summary>
        private void calculaICMSIPI() {

            decimal baseCalculoICMS = Convert.ToDecimal(baseCalculoICMSTextBox.Text);
            decimal baseCalculoICMSSubst = Convert.ToDecimal(baseCalculoICMSSubstTextBox.Text);
            
            valorICMSTextBox.Text = (baseCalculoICMS * produto.Icms / 100).ToString("N2");
            valorICMSSubstTextBox.Text = (baseCalculoICMSSubst * produto.IcmsSubstituto / 100).ToString("N2");
            valorIPITextBox.Text = (baseCalculoICMS * produto.Ipi / 100).ToString("N2");
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
                saida.CodSaida = Convert.ToInt64(codSaidaTextBox.Text);
                tb_saida_produtoTableAdapter.FillByCodSaida(this.saceDataSet.tb_saida_produto, saida.CodSaida);
                atualizarTelaDadosSaida(saida.CodSaida);
            }
        }

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
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
                    this.tb_saidaTableAdapter.FillByCodTipoSaida(this.saceDataSet.tb_saida, Saida.TIPO_SAIDA_DEPOSITO);
                }
                else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FRONECEDOR))
                {
                    FrmSaidaDevolucao frmSaidaDevolucao = new FrmSaidaDevolucao(saida);
                    frmSaidaDevolucao.ShowDialog();
                    frmSaidaDevolucao.Dispose();
                    this.tb_saidaTableAdapter.FillByCodTipoSaida(this.saceDataSet.tb_saida, Saida.TIPO_DEVOLUCAO_FRONECEDOR);
                }
                else
                {
                    FrmSaidaPagamento frmSaidaPagamento = new FrmSaidaPagamento(saida);
                    frmSaidaPagamento.ShowDialog();
                    frmSaidaPagamento.Dispose();
                    //backgroundWorkerRecuperaCupons.RunWorkerAsync();
                }
                atualizarTelaDadosSaida(saida.CodSaida);
                tb_produtoBindingSource.MoveFirst();
                btnNovo.Focus();
            }
            Cursor.Current = Cursors.Default;
        }

        private void atualizarTelaDadosSaida(long codSaida)
        {
            if (codSaida > 0)
            {
                saida = GerenciadorSaida.getInstace().obterSaida(codSaida);

                descricaoTipoSaidaTextBox.Text = saida.DescricaoTipoSaida;
                pedidoGeradoTextBox.Text = saida.PedidoGerado;
                nfeTextBox.Text = saida.Nfe;
                nomeClienteTextBox.Text = saida.NomeCliente;
                descricaoSituacaoPagamentosTextBox.Text = saida.DescricaoSituacaoPagamentos;
                totalTextBox.Text = saida.Total.ToString();
                totalAVistaTextBox.Text = saida.TotalAVista.ToString();
            }
        }

        /// <summary>
        /// Permite a impressão de DAV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            decimal total = Convert.ToDecimal(totalTextBox.Text);
            decimal totalAVista = Convert.ToDecimal(totalAVistaTextBox.Text);
            decimal desconto = (1 - (totalAVista / total)) * 100;
            long codSaida = Convert.ToInt64(codSaidaTextBox.Text);
            
            FrmSaidaDAV frmSaidaDav = new FrmSaidaDAV(new HashSet<long>(){codSaida} , total, totalAVista, desconto);
            frmSaidaDav.ShowDialog();
            frmSaidaDav.Dispose();
        }

        /// <summary>
        /// Permite realizar a impressão de Cupons Fiscais e NF-e
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCfNfe_Click(object sender, EventArgs e)
        {
            Saida saida = GerenciadorSaida.getInstace().obterSaida(long.Parse(codSaidaTextBox.Text));

            if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
            {
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
            }
            else if ((saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO) || (saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FRONECEDOR))
            {
                if (MessageBox.Show("Confirma impressão da Nota Fiscal?", "Confirmar Impressão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    GerenciadorSaida.getInstace().imprimirNotaFiscal(saida);
                }
            }
            else
            {
                throw new TelaException("Impossível imprimir um Cupom Fiscal ou NF-e a partir de um ORÇAMENTO. Faça a edição do pedido e transforme-o numa PRÉ-VENDA.");
            }
        }

        /// <summary>
        /// Verifica se existem produtos com data de valida menor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            codSaidaTextBox_Leave(sender, e);
        }

        /// <summary>
        /// Refaz os cálculos de ICMS e IPI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baseCalculoICMSTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais(precoVendatextBox);
            calculaICMSIPI();
        }

        private void quantidadeTextBox_Enter(object sender, EventArgs e)
        {
            quantidadeTextBox.SelectAll();
            codSaidaTextBox_Enter(sender, e);
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
                }
                else if ((e.KeyCode == Keys.Down) && (codProdutoComboBox.Focused) && (posicaoUltimoProduto < (codProdutoComboBox.Items.Count-1)))
                {
                    codProdutoComboBox.SelectedIndex = posicaoUltimoProduto;
                    posicaoUltimoProduto++;
                }
                else if ((e.KeyCode == Keys.Up) && (codProdutoComboBox.Focused) && (posicaoUltimoProduto > 0))
                {
                    codProdutoComboBox.SelectedIndex = posicaoUltimoProduto;
                    posicaoUltimoProduto--;
                }
                else if (e.KeyCode == Keys.F1)
                {
                    if (lblFormaEntrada.Text.Equals(ENTRADA_MANUAL))
                    {
                        lblFormaEntrada.Text = ENTRADA_AUTOMATICA;
                        lblFormaEntrada.ForeColor = Color.Lime;
                    }
                    else
                    {
                        lblFormaEntrada.Text = ENTRADA_MANUAL;
                        lblFormaEntrada.ForeColor = Color.Red;
                    }
                }
                else if ((Control.ModifierKeys == Keys.Control) && (e.KeyCode == Keys.P))
                {
                    if (lblPreco.Text.Equals(PRECO_VAREJO))
                    {
                        lblPreco.Text = PRECO_ATACADO;
                        lblPreco.ForeColor = Color.Green;
                    }
                    else if (lblPreco.Text.Equals(PRECO_ATACADO))
                    {
                        lblPreco.Text = PRECO_VAREJO_DESCONTO;
                        lblPreco.ForeColor = Color.DarkMagenta;
                    }
                    else
                    {
                        lblPreco.Text = PRECO_VAREJO;
                        lblPreco.ForeColor = Color.Red;
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

        private void codSaidaTextBox_Enter(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control) sender;
                control.BackColor = Global.BACKCOLOR_FOCUS;
            }
        }

        private void codSaidaTextBox_Leave(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS_LEAVE;
            }
        }

        private void valorICMSSubstTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox) sender);
        }

        private void tb_saida_produtoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}