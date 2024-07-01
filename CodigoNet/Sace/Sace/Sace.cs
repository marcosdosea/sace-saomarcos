using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;
using Sace.Relatorios;
using Sace.Relatorios.Produtos;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using Util;

namespace Sace
{
    public partial class Principal : Form
    {


        static string NOME_COMPUTADOR = SystemInformation.ComputerName.ToUpper();
        static string SERVIDOR_NFE = UtilConfig.Default.SERVIDOR_NFE.ToUpper();
        static string SERVIDOR_IMPRIMIR_REDUZIDO1 = UtilConfig.Default.SERVIDOR_IMPRIMIR_REDUZIDO1;
        static string SERVIDOR_IMPRIMIR_REDUZIDO2 = UtilConfig.Default.SERVIDOR_IMPRIMIR_REDUZIDO2;

        private readonly Loja lojaMatriz;
        private readonly Loja lojaDeposito;

        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;
        public Principal(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            var context = new SaceContext(saceOptions);
            service = new SaceService(context);
            
            if (NOME_COMPUTADOR.ToUpper().Equals(SERVIDOR_NFE))
            {
                lojaMatriz = service.GerenciadorLoja.Obter(1).FirstOrDefault();
                fileSystemWatcher.Path = lojaMatriz.PastaNfeRetorno;
                lojaDeposito = service.GerenciadorLoja.Obter(2).FirstOrDefault();
                fileSystemWatcherDeposito.Path = lojaDeposito.PastaNfeRetorno;
            }
            //AtualizarDadosAcompanhamentoVendas();
        }

        private void AtualizarDadosAcompanhamentoVendas()
        {
            lblAno.Text = DateTime.Now.AddYears(-1).Year + " x " + DateTime.Now.Year;

            NumerosPeriodo numeros = gerenciadorSaida.ObterVendasMensalComparandoAnoAnterior();

            if (numeros.NumeroVendas > 0)
                lblNumeroVendas.ForeColor = Color.Green;
            else
                lblNumeroVendas.ForeColor = Color.Red;
            lblNumeroVendas.Text = "Número de Vendas: " + numeros.NumeroVendas.ToString("N2") + "%";
            if (numeros.TotalVendas > 0)
                lblTicketMedio.ForeColor = Color.Green;
            else
                lblTicketMedio.ForeColor = Color.Red;

            lblTicketMedio.Text = "Total Vendas (R$): " + numeros.TotalVendas.ToString("N2") + "%";
        }

        private static bool IsAppAlreadyRunning()
        {

            Process currentProcess = Process.GetCurrentProcess();
            return Process.GetProcessesByName(currentProcess.ProcessName).Any(p => p.Id != currentProcess.Id && !p.HasExited);
        }



        //[STAThread]
        //static void Main(string[] args)
        //{
            //if (IsAppAlreadyRunning() && nomeComputador.Equals(SERVIDOR_NFE))
            //{
            //    MessageBox.Show("Esse computador é o AUTORIZADOR de NFE! Apenas uma instância do SACE pode ser aberta.");
            //    Process.GetCurrentProcess().Kill();
            //}
            //else
            //{
            //TratarException eh = new TratarException();
           // Application.ThreadException += new ThreadExceptionEventHandler(eh.TratarMySqlException);
           // Application.Run(new Principal(options));
            //}

        //}

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                vendaAoConsumidorToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4)
            {
                produtosToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5)
            {
                pessoasToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                entradaDeProdutosToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F7)
            {
                contasAPagarToolStripMenuItem1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                receberPagamentosToolStripMenuItem_Click(sender, e);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma saída do Sistema?", "Confirmar Saída", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Negocio.GerenciadorCupom.GetInstance().EmitirCupomFiscalPreVendasPendentes();
                //Negocio.GerenciadorSeguranca.getInstance().Backup();
                this.Close();
            }
        }

        private void gruposDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrupo frmGrupo = new FrmGrupo(saceOptions);
            frmGrupo.ShowDialog();
            frmGrupo.Dispose();
        }

        private void subgrupoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSubgrupo frmSubgrupo = new FrmSubgrupo(saceOptions);
            frmSubgrupo.ShowDialog();
            frmSubgrupo.Dispose();
        }

        private void lojasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoja frmLoja = new FrmLoja(saceOptions);
            frmLoja.ShowDialog();
            frmLoja.Dispose();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto frmProduto = new FrmProduto(saceOptions);
            frmProduto.ShowDialog();
            frmProduto.Dispose();
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPessoa frmPessoa = new FrmPessoa(saceOptions);
            frmPessoa.ShowDialog();
            frmPessoa.Dispose();
        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBanco frmBanco = new FrmBanco();
            frmBanco.ShowDialog();
            frmBanco.Dispose();
        }

        private void contasBancáriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContaBanco frmContaBanco = new FrmContaBanco();
            frmContaBanco.ShowDialog();
            frmContaBanco.Dispose();
        }

        private void cartõesDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCartaoCredito frmCartaoCredito = new FrmCartaoCredito(saceOptions);
            frmCartaoCredito.ShowDialog();
            frmCartaoCredito.Dispose();
        }

        private void planoDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlanoConta frmPlanoConta = new FrmPlanoConta(saceOptions);
            frmPlanoConta.ShowDialog();
            frmPlanoConta.Dispose();
        }

        private void tiposDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrupoConta frmTipoConta = new FrmGrupoConta(saceOptions);
            frmTipoConta.ShowDialog();
            frmTipoConta.Dispose();
        }

        private void vendaAoConsumidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmPreVenda = new FrmSaida(Saida.TIPO_ORCAMENTO, saceOptions);
            frmPreVenda.ShowDialog();
            frmPreVenda.Dispose();
        }

        private void devoluçãoDeConsumidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmPreVenda = new FrmSaida(Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR, saceOptions);
            frmPreVenda.ShowDialog();
            frmPreVenda.Dispose();
        }


        private void entradaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEntrada frmEntrada = new FrmEntrada(saceOptions);
            frmEntrada.ShowDialog();
            frmEntrada.Dispose();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmFrmUsuario = new FrmUsuario(saceOptions);
            frmFrmUsuario.ShowDialog();
            frmFrmUsuario.Dispose();
        }

        private void contasAPagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConta frmConta = new FrmConta();
            frmConta.ShowDialog();
            frmConta.Dispose();
        }


        private void produtosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmRelProdutos relatorio = new FrmRelProdutos(saceOptions);
            relatorio.ShowDialog();
            relatorio.Dispose();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma criação do backup?", "Confirmar Backup", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                //Negocio.GerenciadorSeguranca.getInstance().Backup(SystemInformation.ComputerName);
                Cursor.Current = Cursors.Default;
            }
        }

        private void restaurarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Selecionar Arquivo ZIP do Backup";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                //Negocio.GerenciadorSeguranca.getInstance().Restore(openFileDialog.FileName);
                Cursor.Current = Cursors.Default;
            }


        }

        private void transferênciaEntreLojasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_PRE_REMESSA_DEPOSITO, saceOptions);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }

        private void retornoDepositoMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_PRE_RETORNO_DEPOSITO, saceOptions);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }
        private void receberPagamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReceberPagamentoPessoa frmReceberPagamento = new FrmReceberPagamentoPessoa(saceOptions);
            frmReceberPagamento.ShowDialog();
            frmReceberPagamento.Dispose();
        }

        private void devoluçãoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR, saceOptions);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }

        private void remessaParaConsertoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_PRE_REMESSA_CONSERTO, saceOptions);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }

        private void códigoFiscalDeOperaçãoCFOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCfop frmCfop = new FrmCfop();
            frmCfop.ShowDialog();
            frmCfop.Dispose();
        }

        private void timerDocumentos_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorkerAtualizarCupons.IsBusy)
                backgroundWorkerAtualizarCupons.RunWorkerAsync();
        }

        private void backgroundWorkerAtualizarCupons_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessarDocumentosFiscais();
        }

        private void ProcessarDocumentosFiscais()
        {
            service.GerenciadorNFe.ImprimirDanfe(null);
            if (NOME_COMPUTADOR.ToUpper().Equals(SERVIDOR_IMPRIMIR_REDUZIDO1.ToUpper()))
            {
                gerenciadorSaida.ImprimirDAV(Impressora.Tipo.REDUZIDO1, UtilConfig.Default.PORTA_IMPRESSORA_REDUZIDA1);
            }
            if (NOME_COMPUTADOR.ToUpper().Equals(SERVIDOR_IMPRIMIR_REDUZIDO2.ToUpper()))
            {
                gerenciadorSaida.ImprimirDAV(Impressora.Tipo.REDUZIDO2, UtilConfig.Default.PORTA_IMPRESSORA_REDUZIDA2);
            }
            if (NOME_COMPUTADOR.ToUpper().Equals(SERVIDOR_NFE.ToUpper()))
            {
                service.GerenciadorSolicitacaoDocumento.EnviarProximoNF(SERVIDOR_NFE, DocumentoFiscal.TipoSolicitacao.NFE);
                service.GerenciadorSolicitacaoDocumento.EnviarProximoNF(SERVIDOR_NFE, DocumentoFiscal.TipoSolicitacao.NFCE);
                service.GerenciadorNFe.ProcessarSolicitacoesCancelamento();
                service.GerenciadorNFe.ProcessaSolicitacaoConsultaNfe();
                service.GerenciadorProduto.AtualizarSituacaoProdutoServidor(SERVIDOR_NFE);
            }
        }

        private void estatísticaPorProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoEstatistica frmProdutoEstatistica = new FrmProdutoEstatistica(saceOptions);
            frmProdutoEstatistica.ShowDialog();
            frmProdutoEstatistica.Dispose();
        }

        private void atualizarCSOSNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoPesquisaCSON frmCSOSN = new FrmProdutoPesquisaCSON(false, saceOptions);
            frmCSOSN.ShowDialog();
            frmCSOSN.Dispose();
        }

        private void produtosParaRevendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFiltroRelatorioProduto relatorio = new FrmFiltroRelatorioProduto(saceOptions);
            relatorio.ShowDialog();
            relatorio.Dispose();
        }


        private void pontaDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPontaEstoque frmPontaEstoque = new FrmPontaEstoque(new ProdutoPesquisa() { CodProduto = 1 }, saceOptions);
            frmPontaEstoque.ShowDialog();
            frmPontaEstoque.Dispose();
        }

        private void movimentaçãoDeCaixasContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimentacaoCaixa frmMovimentacaoCaixa = new FrmMovimentacaoCaixa(saceOptions);
            frmMovimentacaoCaixa.ShowDialog();
            frmMovimentacaoCaixa.Dispose();
        }

        private void solicitaçõesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoSolicitacoesCompra frmProdutoSolicitacoesCompra = new FrmProdutoSolicitacoesCompra( saceOptions);
            frmProdutoSolicitacoesCompra.ShowDialog();
            frmProdutoSolicitacoesCompra.Dispose();
        }

        private void estatísticaPorGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrupoEstatistica frmGrupoEstatistica = new FrmGrupoEstatistica(saceOptions);
            frmGrupoEstatistica.ShowDialog();
            frmGrupoEstatistica.Dispose();
        }

        private void exclusãoDeProdutoDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoExcluir frmProdutoExcluir = new FrmProdutoExcluir(saceOptions);
            frmProdutoExcluir.ShowDialog();
            frmProdutoExcluir.Dispose();
        }

        private void exclusãoDePessoasDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPessoaExcluir frmPessoaExcluir = new FrmPessoaExcluir(saceOptions);
            frmPessoaExcluir.ShowInTaskbar = false;
            frmPessoaExcluir.ShowDialog();
            frmPessoaExcluir.Dispose();
        }

        private void atualizarPreçoVarejoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoPreco frmProdutoPreco = new FrmProdutoPreco(false, saceOptions);
            frmProdutoPreco.ShowDialog();
            frmProdutoPreco.Dispose();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void enviarNFesEmitidasOffLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que Ambiente está On-line para Autorizar NFEs emitidas Off-Line?", "Confirma Ambiente On-Line", MessageBoxButtons.YesNo) == DialogResult.Yes)
                service.GerenciadorNFe.EnviarNFEsOffLine();
        }

        private void calcularImpostoNFCECtempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma o Cálculo de Totais das NFCE da pasta C:\temp?", "Confirma Cálculo Totais", MessageBoxButtons.YesNo) == DialogResult.Yes)
                service.GerenciadorNFe.CalcularTotaisNFCe("C:\\temp\\nfe\\");
        }

        private void cálculoParticipaçãoMensalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCalculoParticipacao frmCalculoParticipacao = new FrmCalculoParticipacao(saceOptions);
            frmCalculoParticipacao.ShowDialog();
            frmCalculoParticipacao.Dispose();
        }

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (lojaMatriz != null)
                service.GerenciadorNFe.RecuperarRetornosNfe(lojaMatriz);
        }

        private void fileSystemWatcherDeposito_Changed(object sender, FileSystemEventArgs e)
        {
            if (lojaDeposito != null)
                service.GerenciadorNFe.RecuperarRetornosNfe(lojaDeposito);
        }

        private void retornoDeFornecedorvariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmPreVenda = new FrmSaida(Saida.TIPO_PRE_RETORNO_FORNECEDOR, saceOptions);
            frmPreVenda.ShowDialog();
            frmPreVenda.Dispose();
        }
        private void vendasPorProfissionaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCalcularVendasPorVendedor frmCalcularVendasPorVendedor = new FrmCalcularVendasPorVendedor();
            frmCalcularVendasPorVendedor.ShowDialog();
            frmCalcularVendasPorVendedor.Dispose();
        }
    }
}