using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        public FrmReceberPagamentoPessoa()
        {
            InitializeComponent();
        }

        private void FrmReceberPagamentoPessoa_Load(object sender, EventArgs e)
        {
            pessoaBindingSource.DataSource = gerenciadorPessoa.ObterTodos();
            habilitaBotoes(true);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            totalContasTextBox.Text = "0,00";
            totalPagamentosTextBox.Text = "0,00";
            faltaReceberTextBox.Text = "0,00";
            descontoTextBox.Text = "0,00";
            totalAVistaTextBox.Text = "0,00";
            valorRecebidoTextBox.Text = "0,00";
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
            Cursor.Current = Cursors.WaitCursor;
            decimal valorRecebido = Convert.ToDecimal(valorRecebidoTextBox.Text);
            decimal faltaReceber = Convert.ToDecimal(faltaReceberTextBox.Text);

          
            // Adicionar todas as saídas e totais para impressão do documento fiscal
            List<ContaSaida> listaContaSaida = new List<ContaSaida>();

            for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                long codConta = Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[0].Value.ToString()); //codConta 
                long codSaidaTemp = Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[1].Value.ToString()); //codSaida
                decimal valorAVistaTemp = Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[9].Value.ToString()); //totalAVista
                if (!listaContaSaida.Exists(sp => sp.CodSaida.Equals(codSaidaTemp)))
                {
                    listaContaSaida.Add(new ContaSaida() { CodConta = codConta, CodSaida = codSaidaTemp, Valor = valorAVistaTemp });
                }
            }

            // cupom fiscal pode ser impresso quando todas as contas associadas a uma saída estiverem selecionadas
            bool podeImprimirCF = (valorRecebido == faltaReceber);

            Saida saida = NovaSaidaTipoPreCredito(pessoa.CodPessoa, valorRecebido);
            saida.CodSaida = GerenciadorSaida.GetInstance(null).Inserir(saida);

            FrmSaidaPagamento frmSaidaPagamento = new FrmSaidaPagamento(saida, null);
            frmSaidaPagamento.ShowDialog();
            frmSaidaPagamento.Dispose();

            var listaSaidaPagamentos = gerenciadorSaidaPagamento.ObterPorSaida(saida.CodSaida);

            if (listaSaidaPagamentos.Sum(sp => sp.Valor) == valorRecebido)
            {
                if (MessageBox.Show("Confirma pagamento?", "Confirmação Pagamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var listaMovimentacaoConta = (List<MovimentacaoConta>)movimentacaoContaBindingSource.DataSource;
                    gerenciadorConta.ReceberPagamentosContas(listaContaSaida, listaSaidaPagamentos, listaMovimentacaoConta, saida);
                }
                else
                {
                    GerenciadorSaida.GetInstance(null).Remover(saida);
                }
            }
            listaSaidaPagamentos = new List<SaidaPagamento>();
            if (saida != null && saida.TipoSaida == Saida.TIPO_CREDITO)
            {
                if (podeImprimirCF && MessageBox.Show("Deseja imprimir NFe/NFCe das contas selecionadas?", "Confirmar Impressão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>();
                    foreach (ContaSaida contaSaida in listaContaSaida)
                    {
                        if (contaSaida.Valor > 0)
                        {
                            listaSaidaPedido.Add(new SaidaPedido() { CodSaida = contaSaida.CodSaida, TotalAVista = contaSaida.Valor });
                            listaSaidaPagamentos.AddRange(gerenciadorSaidaPagamento.ObterPorSaida(contaSaida.CodSaida));
                        }
                    }
                    gerenciadorSolicitacaoDocumento.InserirSolicitacaoDocumento(listaSaidaPedido, listaSaidaPagamentos, DocumentoFiscal.TipoSolicitacao.NFCE, false, false);
                    FrmSaidaAutorizacao frmSaidaAutorizacao = new FrmSaidaAutorizacao(listaContaSaida.FirstOrDefault().CodSaida, pessoa.CodPessoa, DocumentoFiscal.TipoSolicitacao.NFCE);
                    frmSaidaAutorizacao.ShowDialog();
                    frmSaidaAutorizacao.Dispose();
                }
                else if (!podeImprimirCF && MessageBox.Show("Deseja imprimir CRÉDITO para o cliente?", "Confirmar Impressão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GerenciadorSaida.GetInstance(null).ImprimirCreditoPagamento(saida, Properties.Settings.Default.PORTA_IMPRESSORA_REDUZIDA2);
                }
            }
            codClienteComboBox_Leave(sender, e);
        }

        private Saida NovaSaidaTipoPreCredito(long codCliente, decimal valorPagamento)
        {
            Saida saida = new Saida();
            saida.CodSaida = -1;
            saida.CodEntrada = UtilConfig.Default.ENTRADA_PADRAO;
            saida.CodCliente = codCliente;
            saida.CodProfissional = UtilConfig.Default.PROFISSIONAL_PADRAO;
            saida.CodEmpresaFrete = UtilConfig.Default.CLIENTE_PADRAO;
            saida.TipoDocumentoFiscal = Saida.TIPO_DOCUMENTO_NFCE;

            saida.DataSaida = DateTime.Now;
            saida.Desconto = 0;
            saida.NumeroCartaoVenda = 0;
            saida.CupomFiscal = "";
            saida.Total = valorPagamento;
            saida.TotalAVista = valorPagamento;
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
            saida.TipoSaida = Saida.TIPO_PRE_CREDITO;
            saida.EspecieVolumes = "VOLUMES";
            saida.CodLojaOrigem = UtilConfig.Default.LOJA_PADRAO;
            return saida;
        }

        private void AtualizarValoresDescontosContas()
        {
            if (alterouDesconto)
            {
                for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
                {
                    decimal valorDescontoConta = (decimal)contasPessoaDataGridView.SelectedRows[i].Cells[8].Value;
                    long codConta = (long)contasPessoaDataGridView.SelectedRows[i].Cells[0].Value;
                    Conta conta = gerenciadorConta.Obter(codConta).ElementAt(0);
                    if (conta.CodSituacao.Equals(SituacaoConta.SITUACAO_ABERTA))
                    {
                        gerenciadorConta.Atualizar(conta.CodSituacao, valorDescontoConta, conta.CodConta);
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


            
            SaidaPagamento saidaPagamento = new SaidaPagamento();
            FormaPagamento dinheiro = GerenciadorFormaPagamento.GetInstance().Obter(FormaPagamento.DINHEIRO).ElementAt(0);
            saidaPagamento.CodFormaPagamento = FormaPagamento.DINHEIRO;
            saidaPagamento.CodCartaoCredito = UtilConfig.Default.CARTAO_LOJA;
            saidaPagamento.MapeamentoFormaPagamento = dinheiro.Mapeamento;
            saidaPagamento.DescricaoFormaPagamento = dinheiro.Descricao;
            saidaPagamento.Valor = Convert.ToDecimal(valorRecebidoTextBox.Text) + Convert.ToDecimal(totalPagamentosTextBox.Text);
            List<SaidaPagamento> listaSaidaPagamento = new List<SaidaPagamento>() { saidaPagamento };

            if (!pedidoGerado.Trim().Equals("") || (pessoa.ImprimirCF))
            {
                long codSaida = Convert.ToInt64(contasPessoaDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                Saida saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
                AtualizarValoresDescontosContas();
                FrmSaidaNFe frmSaidaNF = new FrmSaidaNFe(saida.CodSaida, listaSaidaPedido, listaSaidaPagamento);
                frmSaidaNF.ShowDialog();
                frmSaidaNF.Dispose();
            }
            else
            {
                if (MessageBox.Show("Confirma emisssão da NFce das Contas Selecionadas?", "Confirmar Impressão NFe/NFCe", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    AtualizarValoresDescontosContas();
                    gerenciadorSolicitacaoDocumento.InserirSolicitacaoDocumento(listaSaidaPedido, listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao.NFCE, false, false);
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
            else if ((e.KeyCode == Keys.Delete) && (tb_movimentacao_contaDataGridView.Focused))
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
                    Negocio.gerenciadorMovimentacaoConta.Remover(codMovimentacaoConta);
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
            if ((pessoa != null) && (!pessoa.CodPessoa.Equals(UtilConfig.Default.CLIENTE_PADRAO)))
            {
                // Obter todas as contas da pessoa em aberto
                ObterTodasContasAbertas(pessoa);
            }
            alterouDesconto = false;
        }

        private void ObterTodasContasAbertas(Pessoa pessoa)
        {
            contasPessoaDataGridView.DataSource = gerenciadorConta.ObterPorSituacaoPessoa(SituacaoConta.SITUACAO_ABERTA.ToString(), pessoa.CodPessoa);
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

        private void dataInicioDateTimePicker_Leave(object sender, EventArgs e)
        {
            if (!dataInicioDateTimePicker.Value.Equals(dataInicio) || !dataFinalDateTimePicker.Value.Equals(dataFim) ||
                (abertaCheckBox.Checked != abertaChecked) || (quitadaCheckBox.Checked != quitadaChecked))
                ListarContasPessoa();
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
                contasPessoaDataGridView.DataSource = gerenciadorConta.ObterPorSituacaoPessoaPeriodo(situacoes[0], situacoes[1], pessoa.CodPessoa, dataInicio, dataFim);
            }
            else if (situacoes.Count == 1)
            {
                contasPessoaDataGridView.DataSource = gerenciadorConta.ObterPorSituacaoPessoaPeriodo(situacoes[0], situacoes[0], pessoa.CodPessoa, dataInicio, dataFim);
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
                    string formatoConta = contasPessoaDataGridView.SelectedRows[i].Cells[2].Value.ToString();
                    if (formatoConta.Equals("FICHA"))
                    {
                        decimal valorConta = (decimal)contasPessoaDataGridView.SelectedRows[i].Cells[7].Value;
                        // valor do desconto
                        contasPessoaDataGridView.SelectedRows[i].Cells[8].Value = (valorConta * (descontoAtual / 100)).ToString("N2");
                        decimal valorDescontoConta = (decimal)contasPessoaDataGridView.SelectedRows[i].Cells[8].Value;
                        // valor da conta a vista
                        contasPessoaDataGridView.SelectedRows[i].Cells[9].Value = valorConta - valorDescontoConta;
                        contasPessoaDataGridView.Refresh();
                    }
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
            movimentacaoContaBindingSource.DataSource = gerenciadorMovimentacaoConta.ObterPorContas(contasExibidas);
        }


        private void CalcularTotalContasSelecionadas()
        {
            decimal totalContas = 0;
            decimal totalDesconto = 0;
            decimal totalPagamentos = 0;
            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                string formatoConta = contasPessoaDataGridView.SelectedRows[i].Cells[2].Value.ToString();
                if (formatoConta.Equals("FICHA"))
                {
                    totalContas += Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[7].Value.ToString()); //total
                    totalDesconto += Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[8].Value.ToString()); //totalPagar
                }
                else
                {
                    totalPagamentos += (-1) * Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[7].Value.ToString());
                }
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
            valorRecebidoTextBox.Text = faltaReceberTextBox.Text;
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
                decimal valor = Decimal.Parse(contasPessoaDataGridView.Rows[i].Cells[7].Value.ToString());
                if (valor < 0)
                {
                    contasPessoaDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }
                else
                {
                    if ((dataConta < DateTime.Now) && (situacaoConta.Trim().Equals("ABERTA")))
                        contasPessoaDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        contasPessoaDataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                DateTime dataConta = Convert.ToDateTime(contasPessoaDataGridView.SelectedRows[i].Cells[3].Value);
                string situacaoConta = contasPessoaDataGridView.SelectedRows[i].Cells[6].Value.ToString();
                decimal valor = Decimal.Parse(contasPessoaDataGridView.SelectedRows[i].Cells[7].Value.ToString());
                if (valor < 0)
                {
                    contasPessoaDataGridView.SelectedRows[i].DefaultCellStyle.SelectionForeColor = Color.Green;
                }
                else
                {
                    if ((dataConta < DateTime.Now) && (situacaoConta.Trim().Equals("ABERTA")))
                        contasPessoaDataGridView.SelectedRows[i].DefaultCellStyle.SelectionForeColor = Color.Red;
                    else
                        contasPessoaDataGridView.SelectedRows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                
            }

        }

        private void faltaReceberTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
        }

        private void btnBoleto_Click(object sender, EventArgs e)
        {
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
