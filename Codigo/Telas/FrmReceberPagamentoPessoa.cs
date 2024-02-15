using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dominio;
using Negocio;
using Util;


namespace Telas
{
    public partial class FrmReceberPagamentoPessoa : Form
    {
        private EstadoFormulario estado;

        Pessoa pessoa;
        private DateTime dataInicio;
        private DateTime dataFim;
        private bool abertaChecked;
        private bool quitadaChecked;
        private decimal descontoCalculado;
        private bool alterouDesconto;
        private bool exibirSomenteAdministradorasCartoes;

        public FrmReceberPagamentoPessoa(bool exibirSomenteAdministradorasCartoes)
        {
            this.exibirSomenteAdministradorasCartoes = exibirSomenteAdministradorasCartoes;
            InitializeComponent();
        }

        private void FrmReceberPagamentoPessoa_Load(object sender, EventArgs e)
        {
            formaPagamentoBindingSource.DataSource = GerenciadorFormaPagamento.GetInstance().ObterTodos();
            contaBancoBindingSource.DataSource = GerenciadorContaBanco.GetInstance().ObterTodos();
            IEnumerable<CartaoCredito> listaCartoes = GerenciadorCartaoCredito.GetInstance().ObterTodos();
            cartaoCreditoBindingSource.DataSource = listaCartoes;
            if (exibirSomenteAdministradorasCartoes)
            {
                IEnumerable<long> administradoras = listaCartoes.Select(c => c.CodPessoa);
                pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos().Where(p => administradoras.Contains(p.CodPessoa));
                OrganizarTelaAdministradoraCartoes();
            }
            else
            {
                pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
                
            }
            codCartaoComboBox.SelectedIndex = 1;
            habilitaBotoes(true);
        }

        private void OrganizarTelaAdministradoraCartoes()
        {
            codCartaoComboBox.Visible = !exibirSomenteAdministradorasCartoes;
            codContaBancoComboBox.Visible = exibirSomenteAdministradorasCartoes;
            codFormaPagamentoComboBox.Enabled = !exibirSomenteAdministradorasCartoes;
            codContaBancoComboBox.Enabled = !exibirSomenteAdministradorasCartoes;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            totalContasTextBox.Text = "0,00";
            totalPagamentosTextBox.Text = "0,00";
            faltaReceberTextBox.Text = "0,00";
            descontoTextBox.Text = "0,00";
            totalAVistaTextBox.Text = "0,00";
            valorPagamentoTextBox.Text = "0,00";
            codClienteComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitaBotoes(true);
            btnNovo.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma registro de pagamento?", "Confirmar Pagamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                int formaPagamento = int.Parse(codFormaPagamentoComboBox.SelectedValue.ToString());
                decimal valorPagamento = Convert.ToDecimal(valorPagamentoTextBox.Text);
                decimal totalPago = Convert.ToDecimal(totalPagamentosTextBox.Text);
                decimal faltaReceber = Convert.ToDecimal(faltaReceberTextBox.Text);

                if (valorPagamento > faltaReceber)
                {
                    codFormaPagamentoComboBox.Focus();
                    Cursor.Current = Cursors.Default;
                    throw new TelaException("O valor do pagamento não pode ser maior que o valor a receber.");
                }

                // Adicionar todas as saídas e totais para impressão do documento fiscal
                List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>();
                List<long> listaContas = new List<long>();
                
                for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
                {
                    listaContas.Add(Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[0].Value.ToString())); //codConta 
                    long codSaidaTemp = Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[1].Value.ToString()); //codSaida
                    decimal valorAVistaTemp = Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[9].Value.ToString()); //totalAVista
                    if ( listaSaidaPedido.Where(sp=>sp.CodSaida.Equals(codSaidaTemp)).Count() == 0 )
                    {
                        listaSaidaPedido.Add(new SaidaPedido() { CodSaida = codSaidaTemp, TotalAVista = valorAVistaTemp });
                    }
                }


                // cupom fiscal pode ser impresso quando todas as contas associadas a uma saída estiverem selecionadas
                bool podeImprimirCF = (valorPagamento == faltaReceber);
                if (podeImprimirCF)
                {
                    foreach (SaidaPedido saidaPedido in listaSaidaPedido)
                    {
                        List<Conta> contas = (List<Conta>)GerenciadorConta.GetInstance(null).ObterPorSaida(saidaPedido.CodSaida);
                        foreach (Conta conta in contas)
                        {
                            if ((!listaContas.Contains(conta.CodConta)) || ((conta.CF != null) && !conta.CF.Trim().Equals("")))
                            {
                                podeImprimirCF = false;
                                break;
                            }
                        }
                        if (!podeImprimirCF)
                            break;
                    }
                }

                //if (formaPagamento.Equals(FormaPagamento.CARTAO) && !podeImprimirCF)
                //{
                //    Cursor.Current = Cursors.Default;
                //    throw new TelaException("Não é possível realizar o pagamento com cartão de crédito. Verifique se alguma NFe referente às contas selecionadas já foi impresso OU se todas as contas referente às saídas escolhidas estão selecionadas.");
                //}

                if (formaPagamento.Equals(FormaPagamento.DINHEIRO) || formaPagamento.Equals(FormaPagamento.DEPOSITO_PIX)
                    || formaPagamento.Equals(FormaPagamento.CARTAO) )
                {
                    AtualizarValoresDescontosContas();

                    if (formaPagamento.Equals(FormaPagamento.DINHEIRO) || formaPagamento.Equals(FormaPagamento.DEPOSITO_PIX))
                    {
                        MovimentacaoConta movimentacao = new MovimentacaoConta();
                        movimentacao.CodConta = listaContas.ElementAt(0); // valor é irrelevante
                        if (formaPagamento.Equals(FormaPagamento.DINHEIRO))
                        {
                            movimentacao.CodContaBanco = Global.CAIXA_PADRAO;
                        }
                        else
                        {
                            movimentacao.CodContaBanco = (int) codContaBancoComboBox.SelectedValue;
                        }

                        movimentacao.CodResponsavel = pessoa.CodPessoa;
                        movimentacao.CodTipoMovimentacao = TipoMovimentacaoConta.RECEBIMENTO_CREDIARIO;
                        movimentacao.DataHora = DateTime.Now;
                        movimentacao.Valor = valorPagamento;

                        List<MovimentacaoConta> listaMovimentacaoConta = (List<MovimentacaoConta>) movimentacaoContaBindingSource.DataSource;
                        GerenciadorMovimentacaoConta.GetInstance(null).Inserir(movimentacao, listaContas, listaMovimentacaoConta);
                        Cursor.Current = Cursors.Default;
                        if (podeImprimirCF && MessageBox.Show("Deseja imprimir NFe/NFCe das contas selecionadas?", "Confirmar Impressão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SaidaPagamento saidaPagamento = new SaidaPagamento();
                            FormaPagamento formaPagamentoDinheiro = GerenciadorFormaPagamento.GetInstance().Obter(FormaPagamento.DINHEIRO).ElementAt(0);
                            saidaPagamento.CodFormaPagamento = formaPagamentoDinheiro.CodFormaPagamento;
                            saidaPagamento.MapeamentoFormaPagamento = formaPagamentoDinheiro.Mapeamento;
                            saidaPagamento.DescricaoFormaPagamento = formaPagamentoDinheiro.Descricao;
                            saidaPagamento.Valor = valorPagamento;
                            saidaPagamento.CodCartaoCredito = Global.CARTAO_LOJA;
                            //saidaPagamento.CodContaBanco


                            long codSolicitacao = GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, new List<SaidaPagamento>() { saidaPagamento }, DocumentoFiscal.TipoSolicitacao.NFCE, false, false);
                            FrmSaidaAutorizacao frmSaidaAutorizacao = new FrmSaidaAutorizacao(listaSaidaPedido.FirstOrDefault().CodSaida, pessoa.CodPessoa, DocumentoFiscal.TipoSolicitacao.NFCE);
                            frmSaidaAutorizacao.ShowDialog();
                            frmSaidaAutorizacao.Dispose();

                        }
                        else if (!podeImprimirCF && MessageBox.Show("Deseja imprimir CRÉDITO para o cliente?", "Confirmar Impressão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            movimentacao.Valor = valorPagamento;
                            GerenciadorSaida.GetInstance(null).ImprimirCreditoPagamento(movimentacao, Properties.Settings.Default.PORTA_IMPRESSORA_REDUZIDA2);
                        }
                    }
                    else if (formaPagamento.Equals(FormaPagamento.CARTAO))
                    {
                        List<SaidaPagamento> listaSaidaPagamento = new List<SaidaPagamento>();

                        SaidaPagamento saidaPagamentoCartao = new SaidaPagamento();
 
                        int codCartao = Convert.ToInt32(codCartaoComboBox.SelectedValue.ToString());
                        int parcelas = Convert.ToInt32(parcelasTextBox.Text);
                        CartaoCredito cartaoCredito = GerenciadorCartaoCredito.GetInstance().Obter(codCartao).ElementAt(0);
                        saidaPagamentoCartao.CodFormaPagamento = FormaPagamento.CARTAO;
                        saidaPagamentoCartao.MapeamentoFormaPagamento = cartaoCredito.Mapeamento;
                        saidaPagamentoCartao.MapeamentoCartao = cartaoCredito.Mapeamento;
                        saidaPagamentoCartao.NomeCartaoCredito = cartaoCredito.Nome;
                        saidaPagamentoCartao.DescricaoFormaPagamento = cartaoCredito.Nome;
                        saidaPagamentoCartao.Valor = valorPagamento;
                        saidaPagamentoCartao.Parcelas = parcelas;
                        saidaPagamentoCartao.CodCartaoCredito = codCartao;
                        listaSaidaPagamento.Add(saidaPagamentoCartao);

                        if (podeImprimirCF)
                        {
                            long codSolicitacao = GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao.NFCE, false, false);
                            FrmSaidaAutorizacao frmSaidaAutorizacao = new FrmSaidaAutorizacao(listaSaidaPedido.FirstOrDefault().CodSaida, pessoa.CodPessoa, DocumentoFiscal.TipoSolicitacao.NFCE);
                            frmSaidaAutorizacao.ShowDialog();
                            frmSaidaAutorizacao.Dispose();
                        }

                        
                        if (MessageBox.Show("A compra foi confirmada pela administradora do cartão selecionado?", "Confirma Cartão de Crédito", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            GerenciadorConta.GetInstance(null).QuitarContasCartaoCredito(listaContas, valorPagamento, cartaoCredito, parcelas);
                        }
                    }
                    codClienteComboBox_Leave(sender, e);
                }
            }
            habilitaBotoes(true);
            btnNovo.Focus();
        }

        private void AtualizarValoresDescontosContas()
        {
            if (alterouDesconto)
            {
                for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
                {
                    decimal valorDescontoConta = (decimal)contasPessoaDataGridView.SelectedRows[i].Cells[8].Value;
                    long codConta = (long)contasPessoaDataGridView.SelectedRows[i].Cells[0].Value;
                    Conta conta = GerenciadorConta.GetInstance(null).Obter(codConta).ElementAt(0);
                    if (conta.CodSituacao.Equals(SituacaoConta.SITUACAO_ABERTA))
                    {
                        GerenciadorConta.GetInstance(null).Atualizar(conta.CodSituacao, valorDescontoConta, conta.CodConta);
                    }
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            HashSet<long> codSaidas = new HashSet<long>();

            for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                codSaidas.Add(Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[1].Value.ToString())); //pre-venda
            }

            decimal total = Convert.ToDecimal(totalContasTextBox.Text);
            decimal totalAVista = Convert.ToDecimal(totalAVistaTextBox.Text);
            decimal desconto = Convert.ToDecimal(descontoTextBox.Text);

            FrmSaidaDAV frmSaidaDAV = new FrmSaidaDAV(codSaidas, total, totalAVista, desconto, false);
            frmSaidaDAV.ShowDialog();
            frmSaidaDAV.Dispose();
        }

        private void btnCFNfe_Click(object sender, EventArgs e)
        {
            string pedidoGerado = contasPessoaDataGridView.SelectedRows[0].Cells[4].Value.ToString().Trim();
            List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>();
            for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                long codSaidaTemp = Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[1].Value.ToString()); //pre-venda
                decimal totalAVistaTemp = Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[9].Value.ToString()); //total a vista
                SaidaPedido saidaPedido = new SaidaPedido() { CodSaida = codSaidaTemp, TotalAVista = totalAVistaTemp };
                listaSaidaPedido.Add(saidaPedido);
            }
            

            decimal total = Convert.ToDecimal(totalContasTextBox.Text);
            decimal totalAVista = Convert.ToDecimal(totalAVistaTextBox.Text);

            SaidaPagamento saidaPagamento = new SaidaPagamento();
            FormaPagamento dinheiro = GerenciadorFormaPagamento.GetInstance().Obter(FormaPagamento.DINHEIRO).ElementAt(0);
            saidaPagamento.CodFormaPagamento = FormaPagamento.DINHEIRO;
            saidaPagamento.CodCartaoCredito = Global.CARTAO_LOJA;
            saidaPagamento.MapeamentoFormaPagamento = dinheiro.Mapeamento;
            saidaPagamento.DescricaoFormaPagamento = dinheiro.Descricao;
            saidaPagamento.Valor = Convert.ToDecimal(valorPagamentoTextBox.Text) + Convert.ToDecimal(totalPagamentosTextBox.Text);
            List<SaidaPagamento> listaSaidaPagamento = new List<SaidaPagamento>() { saidaPagamento };

            if (!pedidoGerado.Trim().Equals("") || (pessoa.ImprimirCF))
            {
                long codSaida = Convert.ToInt64(contasPessoaDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                Saida saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
                AtualizarValoresDescontosContas();
                //decimal totalAVista = Convert.ToDecimal(totalAVistaTextBox.Text);
                FrmSaidaNFe frmSaidaNF = new FrmSaidaNFe(saida.CodSaida, listaSaidaPedido, listaSaidaPagamento);
                frmSaidaNF.ShowDialog();
                frmSaidaNF.Dispose();
            }
            else
            {
                if (MessageBox.Show("Confirma emisssão da NFce das Contas Selecionadas?", "Confirmar Impressão NFe/NFCe", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    AtualizarValoresDescontosContas();
                    long codSolicitacao = GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao.NFCE, false, false);
                    FrmSaidaAutorizacao frmSaidaAutorizacao = new FrmSaidaAutorizacao(listaSaidaPedido.FirstOrDefault().CodSaida, pessoa.CodPessoa, DocumentoFiscal.TipoSolicitacao.NFCE);
                    frmSaidaAutorizacao.ShowDialog();
                    frmSaidaAutorizacao.Dispose();
                }
            }
        }

        

        private void FrmReceberPagamentoPessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
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
                    e.Handled = true;
                    SendKeys.Send("{tab}");
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F7)
                {
                    btnImprimir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F8)
                {
                    btnCFNfe_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F9)
                {
                    btnBoleto_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    btnCancelar_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F12)
            {
                tb_movimentacao_contaDataGridView.Focus();
            }
            else if ((e.KeyCode == Keys.Delete) && (tb_movimentacao_contaDataGridView.Focused == true))
            {
                ExcluirMovimentacao(sender, e);
            }
        }

        private void ExcluirMovimentacao(object sender, KeyEventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão do pagamento?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_movimentacao_contaDataGridView.Rows.Count > 0)
                {
                    long codMovimentacaoConta = long.Parse(tb_movimentacao_contaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    Negocio.GerenciadorMovimentacaoConta.GetInstance(null).Remover(codMovimentacaoConta);
                }
                ObterTodasContasAbertas(pessoa);
            }
        }


        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnNovo.Enabled = habilita;

            btnImprimir.Enabled = contasPessoaDataGridView.RowCount > 0;
            btnCFNfe.Enabled = contasPessoaDataGridView.RowCount > 0;
            btnBoleto.Enabled = contasPessoaDataGridView.RowCount > 0;

            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }


        private void codClienteComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codClienteComboBox_Leave(object sender, EventArgs e)
        {
            pessoa = ComponentesLeave.PessoaComboBox_Leave(sender, e, codClienteComboBox, estado, pessoaBindingSource, true, true);

           
            CartaoCredito cartao = GerenciadorCartaoCredito.GetInstance().ObterTodos().Where(c => c.CodPessoa == pessoa.CodPessoa).ElementAtOrDefault(0);
            OrganizarTelaAdministradoraCartoes();
            if (cartao != null)
            {
                formaPagamentoBindingSource.Position = formaPagamentoBindingSource.IndexOf(new FormaPagamento() { CodFormaPagamento = FormaPagamento.DEPOSITO_PIX });
                contaBancoBindingSource.Position = contaBancoBindingSource.IndexOf(new ContaBanco() { CodContaBanco = cartao.CodContaBanco });
                codFormaPagamentoComboBox.Enabled = false;
                codContaBancoComboBox.Enabled = false;
            }
            else
            {
                formaPagamentoBindingSource.Position = 0;
            }
            if ((pessoa != null) && (!pessoa.CodPessoa.Equals(Global.CLIENTE_PADRAO)))
            {
                // Obter todas as contas da pessoa em aberto
                ObterTodasContasAbertas(pessoa);
            }

            alterouDesconto = false;
        }

        private void ObterTodasContasAbertas(Pessoa pessoa)
        {
            contasPessoaDataGridView.DataSource = GerenciadorConta.GetInstance(null).ObterPorSituacaoPessoa(SituacaoConta.SITUACAO_ABERTA.ToString(), pessoa.CodPessoa);
            if (contasPessoaDataGridView.RowCount > 0)
            {
                //Obter maior e menor data de vencimento para preencher corrretamente
                dataInicioDateTimePicker.Text = contasPessoaDataGridView.Rows[0].Cells[3].Value.ToString();
                int ultimaLinha = contasPessoaDataGridView.RowCount - 1;
                dataFinalDateTimePicker.Text = contasPessoaDataGridView.Rows[ultimaLinha].Cells[3].Value.ToString();

                // Guarda os dados das variáveis para verificar se há necessidade de uma nova consulta
                dataInicio = Convert.ToDateTime(dataInicioDateTimePicker.Text);
                dataFim = Convert.ToDateTime(dataFinalDateTimePicker.Text);
                abertaChecked = abertaCheckBox.Checked;
                quitadaChecked = quitadaCheckBox.Checked;
            }
            contasPessoaDataGridView.SelectAll();
            habilitaBotoes(false);
        }

        private string obterListaSituacao()
        {
            if (abertaCheckBox.Checked && quitadaCheckBox.Checked)
                return SituacaoConta.SITUACAO_ABERTA + "," + "," + SituacaoConta.SITUACAO_QUITADA;
            else if (abertaCheckBox.Checked)
                return SituacaoConta.SITUACAO_ABERTA;
            else if (quitadaCheckBox.Checked)
                return SituacaoConta.SITUACAO_QUITADA;
            else
                return "";
        }

        private void dataInicioDateTimePicker_Leave(object sender, EventArgs e)
        {
            // Se houve alteração nos valores da consulta
            if (!dataInicioDateTimePicker.Value.Equals(dataInicio) || !dataFinalDateTimePicker.Value.Equals(dataFim) ||
                (abertaCheckBox.Checked != abertaChecked) || (quitadaCheckBox.Checked != quitadaChecked))
            {
                ListarContasPessoa();

            }

        }

        private void ListarContasPessoa()
        {
            List<string> situacoes = new List<string>();

            if (abertaCheckBox.Checked)
            {
                situacoes.Add(SituacaoConta.SITUACAO_ABERTA.ToString());
            }
            if (quitadaCheckBox.Checked)
            {
                situacoes.Add(SituacaoConta.SITUACAO_QUITADA.ToString());
            }

            dataInicio = Convert.ToDateTime(dataInicioDateTimePicker.Text);
            dataFim = Convert.ToDateTime(dataFinalDateTimePicker.Text);
            abertaChecked = abertaCheckBox.Checked;
            quitadaChecked = quitadaCheckBox.Checked;
            if (situacoes.Count == 2)
            {
                contasPessoaDataGridView.DataSource = GerenciadorConta.GetInstance(null).ObterPorSituacaoPessoaPeriodo(situacoes[0], situacoes[1], pessoa.CodPessoa, dataInicio, dataFim);
            }
            else if (situacoes.Count == 1)
            {
                contasPessoaDataGridView.DataSource = GerenciadorConta.GetInstance(null).ObterPorSituacaoPessoaPeriodo(situacoes[0], situacoes[0], pessoa.CodPessoa, dataInicio, dataFim);
            }
            else
            {
                contasPessoaDataGridView.DataSource = null;
            }
            contasPessoaDataGridView.SelectAll();

        }

        private void DescontoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            CalcularDescontos();
        }

        private void CalcularDescontos()
        {
            decimal descontoAtual = Convert.ToDecimal(descontoTextBox.Text);
            if (descontoAtual != descontoCalculado)
            {
                alterouDesconto = true;
                for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
                {
                    decimal valorConta = (decimal)contasPessoaDataGridView.SelectedRows[i].Cells[7].Value;
                    // valor do desconto
                    contasPessoaDataGridView.SelectedRows[i].Cells[8].Value = (valorConta * (descontoAtual / 100)).ToString("N2");
                    decimal valorDescontoConta = (decimal)contasPessoaDataGridView.SelectedRows[i].Cells[8].Value;
                    // valor da conta a vista
                    contasPessoaDataGridView.SelectedRows[i].Cells[9].Value = valorConta - valorDescontoConta;
                    contasPessoaDataGridView.Refresh();
                }
                CalcularTotalContasSelecionadas();
            }

        }

        private void ListarPagamentosContasSelecionadas()
        {
            var contasExibidas = new List<Int64>();
            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                contasExibidas.Add((long)contasPessoaDataGridView.SelectedRows[i].Cells[0].Value);
            }
            movimentacaoContaBindingSource.DataSource = GerenciadorMovimentacaoConta.GetInstance(null).ObterPorContas(contasExibidas);
        }


        private void CalcularTotalContasSelecionadas()
        {
            decimal totalContas = 0;
            decimal totalDesconto = 0;
            decimal totalPagamentos = 0;
            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                totalContas += Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[7].Value.ToString()); //total
                totalDesconto += Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[8].Value.ToString()); //totalPagar
            }

            foreach (MovimentacaoConta movimentacaoConta in movimentacaoContaBindingSource)
            {
                totalPagamentos += movimentacaoConta.Valor;
            }
            totalContasTextBox.Text = totalContas.ToString("N2");
            totalAVistaTextBox.Text = (totalContas - totalDesconto).ToString("N2");
            totalPagamentosTextBox.Text = totalPagamentos.ToString("N2");
            faltaReceberTextBox.Text = (totalContas - totalDesconto - totalPagamentos).ToString("N2");
            if (totalContas != 0)
            {
                descontoTextBox.Text = ((totalDesconto / totalContas) * 100).ToString("N2");
            }
            //else
            //{
            //    descontoTextBox.Text = "0,00";
            //}
            valorPagamentoTextBox.Text = faltaReceberTextBox.Text;
            descontoCalculado = Convert.ToDecimal(descontoTextBox.Text);
        }

        private void ContasPessoaDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ListarPagamentosContasSelecionadas();
            CalcularTotalContasSelecionadas();
            DestacarContasEmAtraso();
        }

        private void DestacarContasEmAtraso()
        {
            for (int i = 0; i < contasPessoaDataGridView.RowCount; i++)
            {
                DateTime dataConta = Convert.ToDateTime(contasPessoaDataGridView.Rows[i].Cells[3].Value);
                string situacaoConta = contasPessoaDataGridView.Rows[i].Cells[6].Value.ToString();
                if ((dataConta < DateTime.Now) && (situacaoConta.Trim().Equals("ABERTA")))
                {
                    contasPessoaDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    contasPessoaDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                DateTime dataConta = Convert.ToDateTime(contasPessoaDataGridView.SelectedRows[i].Cells[3].Value);
                string situacaoConta = contasPessoaDataGridView.SelectedRows[i].Cells[6].Value.ToString();
                if ((dataConta < DateTime.Now) && (situacaoConta.Trim().Equals("ABERTA")))
                {
                    contasPessoaDataGridView.SelectedRows[i].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                else
                {
                    contasPessoaDataGridView.SelectedRows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }

        }

        private void codFormaPagamentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (codFormaPagamentoComboBox.SelectedValue != null)
            {
                int formaPagamento = int.Parse(codFormaPagamentoComboBox.SelectedValue.ToString());
                codCartaoComboBox.Enabled = (formaPagamento == FormaPagamento.CARTAO);
                codCartaoComboBox.Visible = (formaPagamento != FormaPagamento.DEPOSITO_PIX);
                
                parcelasTextBox.Enabled = (formaPagamento == FormaPagamento.CARTAO);
                codContaBancoComboBox.Visible = (formaPagamento == FormaPagamento.DEPOSITO_PIX);
                codContaBancoComboBox.Enabled = (formaPagamento == FormaPagamento.DEPOSITO_PIX);
                
            }
        }

        private void codFormaPagamentoComboBox_Leave(object sender, EventArgs e)
        {
            int formaPagamento = int.Parse(codFormaPagamentoComboBox.SelectedValue.ToString());
            if ((formaPagamento != FormaPagamento.DINHEIRO) && (formaPagamento != FormaPagamento.CARTAO) && (formaPagamento != FormaPagamento.DEPOSITO_PIX))
            {
                codFormaPagamentoComboBox.Focus();
                throw new TelaException("Essa forma de pagamento não pode ser utilizada no recebimento de contas.");
            }

        }

        private void faltaReceberTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
        }

        private void btnBoleto_Click(object sender, EventArgs e)
        {
            HashSet<long> codSaidas = new HashSet<long>();

            String cupomFiscal = contasPessoaDataGridView.SelectedRows[0].Cells[4].Value.ToString(); //cupom fiscal
            for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                if (!cupomFiscal.Equals(contasPessoaDataGridView.SelectedRows[i].Cells[4].Value.ToString()))//cupom fiscal
                {
                    throw new TelaException("Não é possível associar boletos a NFe distintas ou pedidos que não foram tiradas a NFe.");
                }
            }

            FrmSaidaPagamentoBoleto frmSaidaPagamentoBoleto = new FrmSaidaPagamentoBoleto(cupomFiscal);
            frmSaidaPagamentoBoleto.ShowDialog();
            frmSaidaPagamentoBoleto.Dispose();
        }



    }
}
