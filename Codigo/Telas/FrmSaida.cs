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
        private const string PRECO_REVENDA = "CTRL+P - Preço Revenda";
        
        private EstadoFormulario estado;
        private int tipoSaidaFormulario;
        private int cfopPadrao;

        private Saida saida;
        private ProdutoPesquisa produto;

        public FrmSaida(int tipoSaida)
        {
            InitializeComponent();
            tipoSaidaFormulario = tipoSaida;
        }

        /// <summary>
        /// Carrega os dados de todas os Pedidos e faz uma cache da lista
        /// de produtos que podem ser exibidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSaida_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            produtoBindingSource.SuspendBinding();
            produtoBindingSource.RaiseListChangedEvents = false;
            produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterTodosNomesExibiveis();
            produtoBindingSource.ResumeBinding();
            ObterSaidas(0);

            cfopPadrao = GerenciadorSaida.GetInstance(null).ObterCfopTipoSaida(tipoSaidaFormulario);
            saidaBindingSource.MoveLast();
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
            if (frmSaidaPesquisa.SaidaSelected != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                ObterSaidas(frmSaidaPesquisa.SaidaSelected.CodSaida);
                saidaBindingSource.Position = saidaBindingSource.List.IndexOf(frmSaidaPesquisa.SaidaSelected);
                Cursor.Current = Cursors.Default;
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
            saidaBindingSource.AddNew();
           
            saida = (Saida)saidaBindingSource.Current;
            saida.CodSaida = -1;
            saida.CodEntrada = Global.ENTRADA_PADRAO;
            saida.CodCliente = Global.CLIENTE_PADRAO;
            saida.CodProfissional = Global.PROFISSIONAL_PADRAO;
            saida.CodEmpresaFrete = Global.CLIENTE_PADRAO;
            saida.DataSaida = DateTime.Now;
            saida.Desconto = 0;
            saida.NumeroCartaoVenda = 0;
            saida.CupomFiscal = "";
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
            saida.Observacao = "";
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
            if (tipoSaidaFormulario.Equals(Saida.TIPO_PRE_RETORNO_DEPOSITO))
                saida.CodLojaOrigem = Global.DEPOSITO_PADRAO;
            else
                saida.CodLojaOrigem = Global.LOJA_PADRAO;
            InicializarValoresProdutos(); 
            dataSaidaDateTimePicker.Text = saida.DataSaida.ToShortDateString();
            // necessário para nao perguntar no inicio do pedido 
            // caso a ultima item lido tenha sido um codigo de barra
            
            lblPreco.Text = PRECO_VAREJO;
            lblPreco.ForeColor = Color.Red;
            
            codProdutoComboBox.Focus();
            codProdutoComboBox.Text = "";
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
        }

        private void InicializarValoresProdutos()
        {
            baseCalculoICMSTextBox.Text = "0.00";
            valorICMSTextBox.Text = "0.00";
            baseCalculoICMSSubstTextBox.Text = "0.00";
            valorICMSSubstTextBox.Text = "0.00";
            valorIPITextBox.Text = "0.00";
            precoVendaSemDescontoTextBox.Text = "0.00";
            precoVendatextBox.Text = "0.00";
            subtotalAVistatextBox.Text = "0.00";
            subtotalTextBox.Text = "0.00";
        }


        /// <summary>
        /// Permite editar um pedido. Se o pedido já for uma uma Pré-Venda
        /// é necessário excluir o pedido que foi gravado para impressão fiscal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            long codSaida = Convert.ToInt64(codSaidaTextBox.Text);
            saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
            
            GerenciadorSaida.GetInstance(null).PrepararEdicaoSaida(saida);
            
            codSaidaTextBox_TextChanged(sender, e);
            codProdutoComboBox.Focus();
            codProdutoComboBox.Text = "";
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saida = GerenciadorSaida.GetInstance(null).Obter(Convert.ToInt64(codSaidaTextBox.Text));
                if ((saida.TipoSaida == Saida.TIPO_VENDA) && (MessageBox.Show("Houve Cancelamento do Cupom Fiscal? Confirma transformar VENDA em ORÇAMENTO?", "Confirmar Transformar Venda em Orçamento", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    GerenciadorSaida.GetInstance(null).Remover(saida);
                    codSaidaTextBox_TextChanged(sender, e);
                }
                else
                {
                    GerenciadorSaida.GetInstance(null).Remover(saida);
                    saidaBindingSource.RemoveCurrent();
                }
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
                    saidaBindingSource.CancelEdit();
                    saidaBindingSource.EndEdit();
                    saidaBindingSource.MoveLast();
                    habilitaBotoes(true);
                    estado = EstadoFormulario.ESPERA;
                    btnNovo.Focus();
                } else if ((tb_saida_produtoDataGridView.RowCount == 0) && (codSaida > 0))
                {
                    //saida = (Saida) saidaBindingSource.Current;
                    GerenciadorSaida.GetInstance(null).Remover(saida);
                    saidaBindingSource.RemoveCurrent();
                    saidaBindingSource.MoveLast();
                    habilitaBotoes(true);
                    estado = EstadoFormulario.ESPERA;
                    btnNovo.Focus();
                }
                else if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
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
            //saida = (Saida)saidaBindingSource.Current;
            
            if (saida.CodSaida <= 0)
            {
                saida.CodSaida = GerenciadorSaida.GetInstance(null).Inserir(saida);
                codSaidaTextBox.Text = saida.CodSaida.ToString();
            }

            SaidaProduto saidaProduto = new SaidaProduto();
            if (produto != null)
            {
                saidaProduto.CodProduto = produto.CodProduto;
                saidaProduto.CodSaida = Convert.ToInt64(codSaidaTextBox.Text);
                saidaProduto.Desconto = Global.DESCONTO_PADRAO;
                saidaProduto.Quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
                //saidaProduto.ValorVenda = Convert.ToDecimal(precoVendaSemDescontoTextBox.Text);
                saidaProduto.ValorVendaAVista = Convert.ToDecimal(precoVendatextBox.Text);
                saidaProduto.DataValidade = Convert.ToDateTime(data_validadeDateTimePicker.Text);
                saidaProduto.BaseCalculoICMS = Convert.ToDecimal(baseCalculoICMSTextBox.Text);
                saidaProduto.ValorICMS = Convert.ToDecimal(valorICMSTextBox.Text);
                saidaProduto.BaseCalculoICMSSubst = Convert.ToDecimal(baseCalculoICMSSubstTextBox.Text);
                saidaProduto.ValorICMSSubst = Convert.ToDecimal(valorICMSSubstTextBox.Text);
                saidaProduto.ValorIPI = Convert.ToDecimal(valorIPITextBox.Text);
                saidaProduto.CodCST = produto.CodCST;
                saidaProduto.CodCfop = cfopPadrao;

                codProdutoComboBox.Focus();
                codProdutoComboBox.Text = "";
                InicializarValoresProdutos();

                bool saidaProdutoInvalida = (saidaProduto.CodProduto == 1) || (saidaProduto.Quantidade == 0) || (saidaProduto.ValorVendaAVista == 0);
                if (estado.Equals(EstadoFormulario.INSERIR_DETALHE) && !saidaProdutoInvalida)
                {
                    GerenciadorSaidaProduto.GetInstance(null).Inserir(saidaProduto, saida);
                    codSaidaTextBox_TextChanged(sender, e);
                    saidaProdutoBindingSource.MoveLast();
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
                    SaidaProduto saidaProduto = (SaidaProduto)saidaProdutoBindingSource.Current;
                    //saida = GerenciadorSaida.GetInstance().Obter(saida.CodSaida);
                    
                    Negocio.GerenciadorSaidaProduto.GetInstance(null).Remover(saidaProduto, saida);
                    saidaProdutoBindingSource.RemoveCurrent();

                }
            }
            estado = EstadoFormulario.INSERIR_DETALHE;
            codSaidaTextBox_TextChanged(sender, e);
            codProdutoComboBox.Focus();
        }

        /// <summary>
        /// Obter saídas e armazenar e disponibilizar em tela de acordo com o tipo
        /// </summary>
        private void ObterSaidas(long codSaidaInicial)
        {
            saidaBindingSource.SuspendBinding();
            saidaBindingSource.RaiseListChangedEvents = false;
            if (Saida.LISTA_TIPOS_REMESSA_DEPOSITO.Contains(tipoSaidaFormulario))
            {
                lblSaidaProdutos.Text = "Remessa para Depósito";
                this.Text = "Remessa para Depósito";
                lblBalcao.Text = "Remessa para Depósito";
                
                saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).ObterPorTipoSaida(Saida.LISTA_TIPOS_REMESSA_DEPOSITO);
                tb_saida_produtoDataGridView.Height = 370;
            }
            else if (Saida.LISTA_TIPOS_RETORNO_DEPOSITO.Contains(tipoSaidaFormulario))
            {
                lblSaidaProdutos.Text = "Retorno de Depósito Fechado";
                this.Text = "Retorno de Depósito Fechado";
                lblBalcao.Text = "Retorno de Depósito";

                saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).ObterPorTipoSaida(Saida.LISTA_TIPOS_RETORNO_DEPOSITO);
                tb_saida_produtoDataGridView.Height = 370;
            }
            else if (Saida.LISTA_TIPOS_DEVOLUCAO_FORNECEDOR.Contains(tipoSaidaFormulario))
            {
                lblSaidaProdutos.Text = "Devolução de Produtos para Fornecedor";
                this.Text = "Devolução de Produtos para Fornecedor";
                lblBalcao.Text = "Devolução";
                baseCalculoICMSSubstTextBox.ReadOnly = false;
                baseCalculoICMSTextBox.ReadOnly = false;
                valorICMSSubstTextBox.ReadOnly = false;
                valorICMSTextBox.ReadOnly = false;
                valorIPITextBox.ReadOnly = false;

                baseCalculoICMSTextBox.TabStop = true;
                baseCalculoICMSSubstTextBox.TabStop = true;
                valorICMSTextBox.TabStop = true;
                valorICMSSubstTextBox.TabStop = true;
                valorIPITextBox.TabStop = true;
                tb_saida_produtoDataGridView.Height = 300;
                
                saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).ObterPorTipoSaida(Saida.LISTA_TIPOS_DEVOLUCAO_FORNECEDOR);
            }
            else
            {
                saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).ObterSaidaConsumidor(codSaidaInicial);
                tb_saida_produtoDataGridView.Height = 370;
            }
            //saidaBindingSource.RaiseListChangedEvents = true;
            saidaBindingSource.ResumeBinding();
            saidaBindingSource.MoveLast();
        }

        /// <summary>
        /// Permite escolher um produto pela descrição, código ou código de barra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            long result;
            bool ehCodigoBarra = long.TryParse(codProdutoComboBox.Text, out result) && (codProdutoComboBox.Text.Length > 7);
            
            produto = ComponentesLeave.ProdutoComboBox_Leave(sender, e, codProdutoComboBox, estado, produtoBindingSource, false);
            if (produto != null)
            {
                quantidadeTextBox.Text = "1";
                IEnumerable<PontaEstoque> listaPontaEstoque = GerenciadorPontaEstoque.GetInstace().ObterPorProduto(produto.CodProduto);
                if (listaPontaEstoque.Count() > 0)
                {
                    FrmPontaEstoquePesquisa frmPontaEstoquePesquisa = new FrmPontaEstoquePesquisa(listaPontaEstoque);
                    frmPontaEstoquePesquisa.ShowDialog();
                    if (frmPontaEstoquePesquisa.PontaEstoqueSelected != null)
                    {
                        quantidadeTextBox.Text = frmPontaEstoquePesquisa.PontaEstoqueSelected.Quantidade.ToString();
                    }
                    frmPontaEstoquePesquisa.Dispose();
                }
                
                
                buscaPrecos();
                AtualizarSubTotal();
                if (lblFormaEntrada.Text.Equals(ENTRADA_AUTOMATICA) && ehCodigoBarra)
                {
                    btnSalvar_Click(sender, e);
                }
                codSaidaTextBox_Leave(sender, e);
            }
        }

        /// <summary>
        /// De acordo com a quantidade escolhida define o preço
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quantidadeTextBox_Leave(object sender, EventArgs e)
        {
            if (!panelBalcao.Visible)
            {
                FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
                buscaPrecos();
                AtualizarSubTotal();
                codSaidaTextBox_Leave(sender, e);
            }
        }

        /// <summary>
        /// Atualiza o preço de venda a prazo com o acréscimo padrão
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void precoVendatextBox_Leave(object sender, EventArgs e)
        {
            if (!panelBalcao.Visible)
            {
                FormatTextBox.NumeroCom3CasasDecimais(precoVendatextBox);
                SaidaProduto saidaProduto = new SaidaProduto();
                saidaProduto.ValorVendaAVista = Convert.ToDecimal(precoVendatextBox.Text);

                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_REMESSA) || saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO) 
                    || saida.TipoSaida.Equals(Saida.TIPO_PRE_RETORNO_DEPOSITO))
                {
                    precoVendaSemDescontoTextBox.Text = saidaProduto.ValorVendaAVista.ToString("N2");
                }
                else
                {
                    precoVendaSemDescontoTextBox.Text = saidaProduto.ValorVenda.ToString("N2");
                }
                AtualizarSubTotal();
                codSaidaTextBox_Leave(sender, e);
            }
        }

        /// <summary>
        /// Busca os preços que serão exibidos de acordo com o tipo de saída
        /// </summary>
        private void buscaPrecos()
        {
            decimal quantidade = Convert.ToDecimal(quantidadeTextBox.Text);

            if (produto != null)
            {
                if (saida.TipoSaida.Equals(Saida.TIPO_PRE_REMESSA) || saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO)
                    || saida.TipoSaida.Equals(Saida.TIPO_PRE_RETORNO_DEPOSITO))
                {
                    precoVendatextBox.Text = produto.UltimoPrecoCompra.ToString("N2");
                    precoVendaSemDescontoTextBox.Text = produto.UltimoPrecoCompra.ToString("N2");
                }
                else
                {
                    if (lblPreco.Text.Equals(PRECO_REVENDA))
                    {
                        precoVendaSemDescontoTextBox.Text = produto.PrecoRevendaSemDesconto.ToString("N2");
                        precoVendatextBox.Text = produto.PrecoRevenda.ToString("N2");
                    }
                    else if (((produto.QtdProdutoAtacado != 0) && (Math.Abs(quantidade) >= produto.QtdProdutoAtacado)))
                    {
                        precoVendaSemDescontoTextBox.Text = produto.PrecoVendaAtacadoSemDesconto.ToString("N2");
                        precoVendatextBox.Text = produto.PrecoVendaAtacado.ToString();
                    }
                    else if (lblPreco.Text.Equals(PRECO_VAREJO))
                    {
                        precoVendaSemDescontoTextBox.Text = produto.PrecoVendaVarejoSemDesconto.ToString("N2");
                        precoVendatextBox.Text = produto.PrecoVendaVarejo.ToString();
                    }
                   
                    data_validadeDateTimePicker.Enabled = produto.TemVencimento;
                    data_validadeDateTimePicker.TabStop = produto.TemVencimento;
                }
            }
        }

        /// <summary>
        /// Atualiza os subtotais do produto
        /// </summary>
        private void AtualizarSubTotal()
        {
            decimal quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
            decimal preco = Convert.ToDecimal(precoVendaSemDescontoTextBox.Text);
            decimal precoAVista = Convert.ToDecimal(precoVendatextBox.Text);
            subtotalTextBox.Text = (quantidade * preco).ToString("N2");
            subtotalAVistatextBox.Text = (quantidade * precoAVista).ToString("N2");

            baseCalculoICMSTextBox.Text = (precoAVista * quantidade).ToString("N2");
            baseCalculoICMSSubstTextBox.Text = (precoAVista * quantidade).ToString("N2");

            // Faz o cálculo de ICMS e IPI do produto baseando-se sempre no preço a vista 
            decimal baseCalculoICMS = Convert.ToDecimal(baseCalculoICMSTextBox.Text);
            decimal baseCalculoICMSSubst = Convert.ToDecimal(baseCalculoICMSSubstTextBox.Text);

            //ProdutoPesquisa produto = (ProdutoPesquisa) produtoBindingSource.Current;

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
                saida = (Saida) saidaBindingSource.Current;
                if ((saida != null) && (saida.CodSaida > 0))
                {
                    saida = GerenciadorSaida.GetInstance(null).Obter(saida.CodSaida);
                    saidaProdutoBindingSource.DataSource = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    descricaoTipoSaidaTextBox.Text = saida.DescricaoTipoSaida;
                    pedidoGeradoTextBox.Text = saida.CupomFiscal;
                    nfeTextBox.Text = saida.Nfe;
                    nomeClienteTextBox.Text = saida.NomeCliente;
                    descricaoSituacaoPagamentosTextBox.Text = saida.DescricaoSituacaoPagamentos;
                    totalTextBox.Text = saida.Total.ToString();
                    totalAVistaTextBox.Text = saida.TotalAVista.ToString();
                }
                else
                {
                    saidaProdutoBindingSource.DataSource = null;
                }
                saidaBindingSource.ResumeBinding();
             }
        }

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        
        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            saida = (Saida)saidaBindingSource.Current;
            if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                habilitaBotoes(true);
                estado = EstadoFormulario.ESPERA;
               
                saida.EntregaRealizada = entregaRealizadaCheckBox.Checked;

                if (Saida.LISTA_TIPOS_REMESSA_DEPOSITO.Contains(saida.TipoSaida))
                {
                    FrmSaidaDeposito frmSaidaDeposito = new FrmSaidaDeposito(saida);
                    frmSaidaDeposito.ShowDialog();
                    frmSaidaDeposito.Dispose();
                }
                if (Saida.LISTA_TIPOS_RETORNO_DEPOSITO.Contains(saida.TipoSaida))
                {
                    FrmSaidaDeposito frmSaidaDeposito = new FrmSaidaDeposito(saida);
                    frmSaidaDeposito.ShowDialog();
                    frmSaidaDeposito.Dispose();
                }
                else if (Saida.LISTA_TIPOS_DEVOLUCAO_FORNECEDOR.Contains(saida.TipoSaida))
                {
                    FrmSaidaDevolucao frmSaidaDevolucao = new FrmSaidaDevolucao(saida);
                    frmSaidaDevolucao.ShowDialog();
                    frmSaidaDevolucao.Dispose();
                }
                else if (Saida.LISTA_TIPOS_VENDA.Contains(saida.TipoSaida))
                {
                    FrmSaidaPagamento frmSaidaPagamento = new FrmSaidaPagamento(saida);
                    frmSaidaPagamento.ShowDialog();
                    frmSaidaPagamento.Dispose();
                }
                produtoBindingSource.MoveFirst();
                codSaidaTextBox_TextChanged(sender, e);
                btnNovo.Focus();
            }
            Cursor.Current = Cursors.Default;
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
            bool ehOrcamento = ((Saida) saidaBindingSource.Current).TipoSaida == Saida.TIPO_ORCAMENTO;
           
            FrmSaidaDAV frmSaidaDav = new FrmSaidaDAV(new HashSet<long>(){codSaida} , total, totalAVista, desconto, ehOrcamento);
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
            saida = GerenciadorSaida.GetInstance(null).Obter(long.Parse(codSaidaTextBox.Text));

            if (saida.TipoSaida == Saida.TIPO_PRE_VENDA)
            {
                if (MessageBox.Show("Confirma impressão do Cupom Fiscal?", "Confirmar Impressão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GerenciadorSaida.GetInstance(null).ImprimirNotaFiscal(saida);
                }
            }
            else if (saida.TipoSaida.Equals(Saida.TIPO_VENDA) || saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) || 
                saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) || saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR))
            {
                FrmSaidaNFe frmSaidaNF = new FrmSaidaNFe(saida.CodSaida);
                frmSaidaNF.ShowDialog();
                frmSaidaNF.Dispose();
            }
            else
            {
                throw new TelaException("Impossível imprimir um Cupom Fiscal ou NF-e de a partir de um ORÇAMENTO OU PRÉ REMESSA. Faça a edição do pedido e transforme-o numa PRÉ-VENDA.");
            }
        }

        /// <summary>
        /// Verifica se existem produtos com data de valida menor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void data_validadeDateTimePicker_Leave(object sender, EventArgs e)
        {
            //ProdutoPesquisa produto = (ProdutoPesquisa) produtoBindingSource.Current;
            DateTime dataVencimento = Convert.ToDateTime(data_validadeDateTimePicker.Text);
            if (!GerenciadorSaida.GetInstance(null).DataVencimentoProdutoAceitavel(produto, dataVencimento))
            {
                if (MessageBox.Show("Existem Produtos no estoque com data de validade mais antiga. Manter o Produto lançado?", "Confirmar Data Validade", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    data_validadeDateTimePicker.Focus();
                }
            }
            codSaidaTextBox_Leave(sender, e);
        }

        /// <summary>
        /// Atualiza os preços do orçamento com os valores do dia
        /// </summary>
        private void AtualizarPrecosComValoresDia(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se for possível PODE BAIXAR o PREÇO de VENDA?", "Atualizar Preços com Valores do Dia", MessageBoxButtons.YesNoCancel);
            if ( result == DialogResult.Yes)
            {
                GerenciadorSaidaProduto.GetInstance(null).AtualizarPrecosComValoresDia(saida, true);
                codSaidaTextBox_TextChanged(sender, e);
            }
            else if (result.Equals(DialogResult.No))
            {
                GerenciadorSaidaProduto.GetInstance(null).AtualizarPrecosComValoresDia(saida, false);
                codSaidaTextBox_TextChanged(sender, e);
            }
        }

        /// <summary>
        /// Refaz os cálculos de ICMS e IPI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baseCalculoICMSTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais(precoVendatextBox);
            AtualizarSubTotal();
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
                    saidaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    saidaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    saidaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    saidaBindingSource.MoveNext();
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
                        lblPreco.Text = PRECO_REVENDA;
                        lblPreco.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblPreco.Text = PRECO_VAREJO;
                        lblPreco.ForeColor = Color.Red;
                    }
                }
                else if ((Control.ModifierKeys == Keys.Control) && (e.KeyCode == Keys.A))
                {
                    AtualizarPrecosComValoresDia(sender, e);
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

        private void saidaBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            saidaBindingSource.ResumeBinding();
        }

    }
}