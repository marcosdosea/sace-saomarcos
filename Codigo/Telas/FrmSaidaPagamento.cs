using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Dominio;
using Negocio;
using Util;
using System.Windows.Forms;
using Dados;

namespace Telas
{
    public partial class FrmSaidaPagamento : Form
    {
        private Saida saida;

        public FrmSaidaPagamento(Saida saida)
        {
            InitializeComponent();
            this.saida = saida;
        }

        /// <summary>
        /// Carrega dados para informar as formas de pagamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSaidaPagamento_Load(object sender, EventArgs e)
        {
            saidaPagamentoBindingSource.DataSource = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaida(saida.CodSaida);
            formaPagamentoBindingSource.DataSource = GerenciadorFormaPagamento.GetInstance().ObterTodos();
            clienteBindingSource.SuspendBinding();
            profissionalBindingSource.SuspendBinding();
            clienteBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            profissionalBindingSource.DataSource = clienteBindingSource.DataSource;
            contaBancoBindingSource.DataSource = GerenciadorContaBanco.GetInstance().ObterTodos();
            cartaoCreditoBindingSource.DataSource = GerenciadorCartaoCredito.GetInstance().ObterTodos();
            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).Obter(saida.CodSaida);
            saida = (Saida) saidaBindingSource.Current;
            if (saida.CodCliente != Global.CLIENTE_PADRAO)
            {
                formaPagamentoBindingSource.Position = formaPagamentoBindingSource.IndexOf(new FormaPagamento() { CodFormaPagamento = FormaPagamento.CREDIARIO });
            }
            else
            {
                formaPagamentoBindingSource.Position = 0;
            }
            if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO))
            {
                totalTextBox.TabStop = true;
                totalPagarLabel.Text = "Total a Creditar";
            }

            InicializaVariaveis();
            AtualizaValores();
        }

        /// <summary>
        /// Inicializar variáveis com valores padrões
        /// </summary>
        private void InicializaVariaveis()
        {
            codCartaoComboBox.SelectedIndex = 0;
            codContaBancoComboBox.SelectedIndex = 0;
            intervaloDiasTextBox.Text = Global.QUANTIDADE_DIAS_CREDIARIO.ToString();
            parcelasTextBox.Text = "1";
        }

        /// <summary>
        /// Salva uma forma de pagamento 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Math.Abs(saida.TotalAVista) <= Math.Abs(saida.TotalPago))
            {
                EncerrarLancamentosPagamentos(sender, e);
            }
            else
            {
                SaidaPagamento saidaPagamento = new SaidaPagamento();
                saidaPagamento.CodContaBanco = int.Parse(codContaBancoComboBox.SelectedValue.ToString());
                saidaPagamento.CodFormaPagamento = int.Parse(codFormaPagamentoComboBox.SelectedValue.ToString());
                saidaPagamento.CodCartaoCredito = int.Parse(codCartaoComboBox.SelectedValue.ToString());
                saidaPagamento.Data = saida.DataSaida;
                saidaPagamento.Valor = decimal.Parse(valorRecebidoTextBox.Text);
                saidaPagamento.CodSaida = saida.CodSaida;
                saidaPagamento.IntervaloDias = Convert.ToInt32(intervaloDiasTextBox.Text);
                saidaPagamento.Parcelas = Convert.ToInt32(parcelasTextBox.Text);

                saida.CodCliente = long.Parse(codClienteComboBox.SelectedValue.ToString());
                saida.CodProfissional = long.Parse(codProfissionalComboBox.SelectedValue.ToString());
                saida.CodEmpresaFrete = saida.CodCliente;
                saida.Desconto = decimal.Parse(descontoTextBox.Text);
                saida.CpfCnpj = cpf_CnpjTextBox.Text;
                saida.Total = decimal.Parse(totalTextBox.Text);
                
                codFormaPagamentoComboBox.Focus();
                GerenciadorSaidaPagamento.GetInstance(null).Inserir(saidaPagamento, saida);

                AtualizaValores();

                saidaPagamentoBindingSource.DataSource = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaida(long.Parse(codSaidaTextBox.Text));

                if (Math.Round(saida.TotalAVista, 2) <= Math.Round(saida.TotalPago, 2))
                {
                    EncerrarLancamentosPagamentos(sender, e);
                }
                else
                {
                    codFormaPagamentoComboBox.Focus();
                }
            }
            valorRecebidoTextBox.Enabled = true;
        }

        /// <summary>
        /// Cancelar os pagamento chama o encerramento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EncerrarLancamentosPagamentos(sender, e);
        }

        
        /// <summary>
        /// Encerra o lançamento de pagamentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncerrarLancamentosPagamentos(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(saida.CupomFiscal))
                {
                    var frmSaidaConfirma = new FrmSaidaConfirma(saida);
                    frmSaidaConfirma.ShowDialog();
                    Cursor.Current = Cursors.WaitCursor;

                    if (frmSaidaConfirma.Opcao != 0)  // Opção 0 é quando pressiona o botão Cancelar
                    {
                        List<SaidaPagamento> listaPagamentosSaida = (List<SaidaPagamento>)saidaPagamentoBindingSource.DataSource;
                        bool limiteCompraLiberado = true;
                        Pessoa cliente = (Pessoa)clienteBindingSource.Current;

                        if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO))
                        {
                            GerenciadorSaida.GetInstance(null).Encerrar(saida, frmSaidaConfirma.Opcao, listaPagamentosSaida, cliente);
                            if (listaPagamentosSaida.Where(ps=> ps.CodFormaPagamento.Equals(FormaPagamento.CARTAO)).Count() > 0) {
                                List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>() { new SaidaPedido() { CodSaida = saida.CodSaida, TotalAVista = saida.TotalAVista } };
                                GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, listaPagamentosSaida, DocumentoFiscal.TipoSolicitacao.ECF, false, false);
                                if (MessageBox.Show("Pagamentos confirmados pelas Administradoras dos CARTÕES?", "Confirmação Pagamento", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    GerenciadorSaida.GetInstance(null).Remover(saida);
                                }
                            
                            }
                        }
                        else
                        {
                            // limite de compra é verificado quando cadastrado um valor maior do que zero no cliente
                            if ((cliente.LimiteCompra > 0) && (frmSaidaConfirma.Opcao == Saida.TIPO_PRE_VENDA))
                            {
                                decimal limiteCompraDisponivel = GerenciadorPessoa.GetInstance().ObterLimiteCompraDisponivel(cliente);
                                if (limiteCompraDisponivel <= saida.TotalAVista)
                                {
                                    if (MessageBox.Show("Cliente NÃO POSSUI LIMITE DISPONÍVEL para essa compra! O limite disponível é R$ " + limiteCompraDisponivel.ToString("N2") + ". Você possui permissão para liberar essa SAÍDA?", "Limite de Compra Ultrapassado", MessageBoxButtons.YesNo) == DialogResult.No)
                                    {
                                        limiteCompraLiberado = false;
                                    }
                                }
                            }
                            if (limiteCompraLiberado)
                            {
                                GerenciadorSaida.GetInstance(null).Encerrar(saida, frmSaidaConfirma.Opcao, listaPagamentosSaida, cliente);
                                if (frmSaidaConfirma.Opcao.Equals(Saida.TIPO_PRE_VENDA))
                                {
                                    // quando tem pagamento crediário imprime o DAV
                                    bool temPagamentoCrediario = listaPagamentosSaida.Where(sp => sp.CodFormaPagamento.Equals(FormaPagamento.CREDIARIO)).ToList().Count > 0;
                                    if (temPagamentoCrediario && cliente.ImprimirDAV)
                                    {
                                        if (!GerenciadorSaida.GetInstance(null).ImprimirDAV(new List<Saida>() { saida }, saida.Total, saida.TotalAVista, saida.Desconto, Global.Impressora.BEMATECH))
                                        {
                                            MessageBox.Show("Não foi possível realizar a impressão. Por Favor Verifique se a impressora REDUZIDA está LIGADA.", "Problema na Impressão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    // imprimir cupom fiscal
                                    if ((!temPagamentoCrediario) && (saida.TotalAVista > 0))
                                    {
                                        bool haPagamentoCartao = listaPagamentosSaida.Where(sp => sp.CodFormaPagamento == FormaPagamento.CARTAO).Count() > 0;
                                        List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>() { new SaidaPedido() { CodSaida = saida.CodSaida, TotalAVista = saida.TotalAVista } };

                                        if (frmSaidaConfirma.GerarNFCe)
                                        {
                                            long codSolicitacao = GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, listaPagamentosSaida, DocumentoFiscal.TipoSolicitacao.NFCE, false, false);
                                            FrmSaidaAutorizacao frmSaidaAutorizacao = new FrmSaidaAutorizacao(codSolicitacao);
                                            frmSaidaAutorizacao.ShowDialog();
                                            frmSaidaAutorizacao.Dispose();
                                        }
                                        else
                                        {
                                            GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, listaPagamentosSaida, DocumentoFiscal.TipoSolicitacao.ECF, false, false);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    frmSaidaConfirma.Close();
                    frmSaidaConfirma.Dispose();
                }
                Cursor.Current = Cursors.Default;
                this.Close();
            }
            catch (NegocioException ne)
            {
                throw ne;
            }
            catch (Exception)
            {
                MessageBox.Show("Problemas no Encerramento da Venda. Favor tentar novamente.", "Erro da Aplicação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSalvar_Click(sender, e);
            }
        }

        /// <summary>
        /// Exclui os dados de um pagamento selecionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcluirPagamento(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão do pagamento?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_saida_forma_pagamentoDataGridView.Rows.Count > 0)
                {
                    // Exclui os dados do pagamento
                    long codSaidaPagamento = long.Parse(tb_saida_forma_pagamentoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    Negocio.GerenciadorSaidaPagamento.GetInstance(null).Remover(codSaidaPagamento, saida);
                    saidaPagamentoBindingSource.DataSource = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaida(saida.CodSaida);

                    InicializaVariaveis();
                    AtualizaValores();
                    codFormaPagamentoComboBox.Focus();
                }
            }
        }

        /// <summary>
        /// Atualiza os valores dos campos a medida que valores são digitados
        /// </summary>
        private void AtualizaValores()
        {
            totalRecebidoLabel.Text = saida.TotalPago.ToString("N2");
            
            // Cálculo do troco em relação aos pagamento efetuados
            if (saida.Troco > 0)
            {
                trocoTextBox.Text = saida.Troco.ToString("N2");
            }
            else
            {
                trocoTextBox.Text = "0,00";
            }


            //Preenche de forma automática o valor recebido com o valor que falta receber
            Int32 codFormaPagamento = Convert.ToInt32(codFormaPagamentoComboBox.SelectedValue);
            if (saida.TipoSaida.Equals(Saida.TIPO_PRE_CREDITO))
            {
                //if ((saida.TotalAVista - saida.TotalPago) > 0)
                if (Math.Abs(saida.Total) > Math.Abs(saida.TotalPago))
                {
                    valorRecebidoTextBox.Text = (saida.Total - saida.TotalPago).ToString("N2");
                }

            }
            else
            {
                if ((codFormaPagamento != FormaPagamento.CHEQUE) && (codFormaPagamento != FormaPagamento.BOLETO))
                {
                    //if ((saida.TotalAVista - saida.TotalPago) > 0)
                    if (Math.Abs(saida.TotalAVista) > Math.Abs(saida.TotalPago))
                    {
                        valorRecebidoTextBox.Text = (saida.TotalAVista - saida.TotalPago).ToString("N2");
                    }
                }

                // Ajusta o valor do desconto que está sendo exibido de acordo com o total a vista
                if (saida.TotalAVista != 0)
                {
                    saida.Desconto = (saida.Total - saida.TotalAVista) / saida.Total * 100;
                }
                else
                {
                    saida.Desconto = 0;
                }
                descontoTextBox.Text = saida.Desconto.ToString("N2");
            }
        }

        private void FrmSaidaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            // Coloca o foco na grid caso ela não possua
            else if ((e.KeyCode == Keys.F12) && (tb_saida_forma_pagamentoDataGridView.Focused))
            {
                codFormaPagamentoComboBox.Focus();
            }
            else if (e.KeyCode == Keys.F12)
            {
                tb_saida_forma_pagamentoDataGridView.Focus();
            }

            // permite excluir um contato quando o foco está na grid
            else if ((e.KeyCode == Keys.Delete) && (tb_saida_forma_pagamentoDataGridView.Focused == true))
            {
                ExcluirPagamento(sender, e);
            }
            
            
            else if (e.KeyCode == Keys.Enter)
            {
                if (codClienteComboBox.Focused)
                {
                    codClienteComboBox_Leave(sender, e);
                }
                else if (codProfissionalComboBox.Focused)
                {
                    codProfissionalComboBox_Leave(sender, e);
                }
                
                e.Handled = true;
                SendKeys.Send("{tab}");
            }

            else if ((e.KeyCode == Keys.F3) && (codClienteComboBox.Focused))
            {
                FrmPessoa frmPessoa = new FrmPessoa();
                frmPessoa.ShowDialog();
                if (frmPessoa.PessoaSelected != null)
                {
                    clienteBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
                    clienteBindingSource.Position = clienteBindingSource.List.IndexOf(frmPessoa.PessoaSelected);
                }
                frmPessoa.Dispose();
            }

            else if ((e.KeyCode == Keys.F3) && (codProfissionalComboBox.Focused))
            {
                FrmPessoa frmPessoa = new FrmPessoa();
                frmPessoa.ShowDialog();
                if (frmPessoa.PessoaSelected != null)
                {
                    profissionalBindingSource.Position = profissionalBindingSource.List.IndexOf(frmPessoa.PessoaSelected);
                }
                frmPessoa.Dispose();
            }
        }

        
        private void codTipoSaidaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

              
        private void totalPagarTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            saida.TotalAVista = Convert.ToDecimal(totalPagarTextBox.Text);
            AtualizaValores();
        }

        private void codClienteComboBox_Leave(object sender, EventArgs e)
        {
            Pessoa cliente = ComponentesLeave.PessoaComboBox_Leave(sender, e, codClienteComboBox, EstadoFormulario.INSERIR, clienteBindingSource, true, false);
            cpf_CnpjTextBox.Text = cliente.CpfCnpj;
            codSaidaTextBox_Leave(sender, e);
        }

        private void codProfissionalComboBox_Leave(object sender, EventArgs e)
        {
            ComponentesLeave.PessoaComboBox_Leave(sender, e, codProfissionalComboBox, EstadoFormulario.INSERIR, profissionalBindingSource, true, false); 
            codSaidaTextBox_Leave(sender, e);
        }

        private void valorRecebidoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            codSaidaTextBox_Leave(sender, e);
        }

        
        private void descontoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            calcularDesconto();
            codSaidaTextBox_Leave(sender, e);
        }

        private void calcularDesconto()
        {
            saida = (Saida) saidaBindingSource.Current;
            const decimal ERRO = 0.02M;
            saida.Desconto = Convert.ToDecimal(descontoTextBox.Text);
            decimal totalCalculado = saida.Total * (1 - (saida.Desconto / 100));

            if (((totalCalculado - saida.TotalAVista) > ERRO) || ((totalCalculado - saida.TotalAVista) < ERRO))
            {
                saida.TotalAVista = totalCalculado;
            }
            totalPagarTextBox.Text = saida.TotalAVista.ToString("N2");
        }

        private void codFormaPagamentoComboBox_Leave(object sender, EventArgs e)
        {
            if (codFormaPagamentoComboBox.SelectedValue == null)
            {
                codFormaPagamentoComboBox.Focus();
                throw new TelaException("Uma forma de pagamento válida precisa ser selecionada.");
            }
            else {
                Int32 codFormaPagamento = Convert.ToInt32(codFormaPagamentoComboBox.SelectedValue);
                Int32 codCliente = Convert.ToInt32(codClienteComboBox.SelectedValue);

                if (((codFormaPagamento == FormaPagamento.BOLETO) || (codFormaPagamento == FormaPagamento.CHEQUE) ||
                (codFormaPagamento== FormaPagamento.CREDIARIO)) && (codCliente == Global.CLIENTE_PADRAO) )
                {
                    codFormaPagamentoComboBox.Focus();
                    codFormaPagamentoComboBox.SelectedIndex = 0;
                    throw new TelaException("Para utilizar essa forma de pagamento é necessário selecionar um cliente.");
                }
            }
        }

        private void codCartaoComboBox_Leave(object sender, EventArgs e)
        {
            if (codCartaoComboBox.SelectedValue == null)
            {
                codCartaoComboBox.Focus();
                throw new TelaException("Um cartão de crédito válido precisa ser selecionado.");
            }            
        }

        
        private void codContaBancoComboBox_Leave(object sender, EventArgs e)
        {
            if (codContaBancoComboBox.SelectedValue == null)
            {
                codContaBancoComboBox.Focus();
                throw new TelaException("Uma conta de banco / caixa válida precisa ser selecionada.");
            }
        }

        private void parcelasTextBox_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(parcelasTextBox.Text) > 1)
            {
                intervaloDiasTextBox.TabStop = true;
            }
            codSaidaTextBox_Leave(sender, e);
        }

        //private void faltaReceberTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    faltaReceber = Convert.ToDecimal(faltaReceberTextBox.Text);
        //}

        private void codClienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( codClienteComboBox.SelectedValue != null) 
            {
                cpf_CnpjTextBox.Enabled = Convert.ToInt64(codClienteComboBox.SelectedValue.ToString()) == 1;
            }
            if (codClienteComboBox.SelectedIndex != 0)
            {
                codFormaPagamentoComboBox.SelectedIndex = 1;
            }
        }

        private void codFormaPagamentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (codFormaPagamentoComboBox.SelectedValue != null)
            {
                int formaPagamento = int.Parse(codFormaPagamentoComboBox.SelectedValue.ToString());
                parcelasTextBox.Enabled = (formaPagamento == FormaPagamento.CARTAO) || (formaPagamento == FormaPagamento.PROMISSORIA);
                codCartaoComboBox.Enabled = (formaPagamento == FormaPagamento.CARTAO);
                codContaBancoComboBox.Enabled = (formaPagamento == FormaPagamento.DEPOSITO);
                valorRecebidoTextBox.Enabled = !((formaPagamento == FormaPagamento.CHEQUE) || (formaPagamento == FormaPagamento.BOLETO));
                intervaloDiasTextBox.Enabled = (formaPagamento == FormaPagamento.DEPOSITO) || (formaPagamento == FormaPagamento.PROMISSORIA);
            }
        }

        private void codSaidaTextBox_Enter(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
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

    }
}