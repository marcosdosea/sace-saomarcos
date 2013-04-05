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
            clienteBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            profissionalBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(1);
            contaBancoBindingSource.DataSource = GerenciadorContaBanco.GetInstance().ObterTodos();
            cartaoCreditoBindingSource.DataSource = GerenciadorCartaoCredito.GetInstance().ObterTodos();
            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).Obter(saida.CodSaida);
            saida = (Saida) saidaBindingSource.Current;
            if (codClienteComboBox.SelectedIndex != 0)
            {
                codFormaPagamentoComboBox.SelectedIndex = 1;
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
            codFormaPagamentoComboBox.SelectedIndex = 0;
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
                saidaPagamento.Data = DateTime.Now;
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

                if (Math.Abs(saida.TotalAVista) <= Math.Abs(saida.TotalPago))
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
            if ((saida.PedidoGerado == null) || saida.PedidoGerado.Equals(""))
            {

                var frmSaidaConfirma = new FrmSaidaConfirma(saida);
                frmSaidaConfirma.ShowDialog();
                Cursor.Current = Cursors.WaitCursor;
                
                if (frmSaidaConfirma.Opcao != 0)  // Opção 0 é quando pressiona o botão Cancelar
                {
                    GerenciadorSaida.GetInstance(null).Encerrar(saida.CodSaida, frmSaidaConfirma.Opcao);
                    if (frmSaidaConfirma.Opcao == Saida.TIPO_PRE_VENDA)
                    {
                        // quando tem pagamento crediário imprime o DAV
                        bool temPagamentoCrediario = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaidaFormaPagamento(saida.CodSaida, FormaPagamento.CREDIARIO).ToList().Count > 0;
                        if (temPagamentoCrediario)
                        {
                            Pessoa cliente = (Pessoa)clienteBindingSource.Current;
                            if (cliente.ImprimirDAV)
                            {
                                GerenciadorSaida.GetInstance(null).ImprimirDAV(new List<Saida>() { saida }, saida.Total, saida.TotalAVista, saida.Desconto, true);
                            }
                        }
                        else
                        {
                            Dictionary<long, decimal> saidaTotalAVista = new Dictionary<long, decimal>();
                            saidaTotalAVista.Add(saida.CodSaida, saida.TotalAVista);
                            GerenciadorSaida.GetInstance(null).GerarDocumentoFiscal(saidaTotalAVista, null);
                        }
                    }
                }
                frmSaidaConfirma.Close();               
                frmSaidaConfirma.Dispose();
            }
            Cursor.Current = Cursors.Default;
            this.Close();
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
            
            // Cálculo de quanto falta receber
            //decimal faltaReceber = saida.TotalAVista - saida.TotalPago;
            //if (faltaReceber > 0)
            //    faltaReceberTextBox.Text = faltaReceber.ToString("N2");
            //else
            //    faltaReceberTextBox.Text = "0";
            
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
            Pessoa cliente = ComponentesLeave.PessoaComboBox_Leave(sender, e, codClienteComboBox, EstadoFormulario.INSERIR, clienteBindingSource, true);
            cpf_CnpjTextBox.Text = cliente.CpfCnpj;
            codSaidaTextBox_Leave(sender, e);
        }

        private void codProfissionalComboBox_Leave(object sender, EventArgs e)
        {
            ComponentesLeave.PessoaComboBox_Leave(sender, e, codProfissionalComboBox, EstadoFormulario.INSERIR, profissionalBindingSource, true); 
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