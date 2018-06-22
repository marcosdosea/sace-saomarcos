using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telas;
using System.Threading;
using Dominio;
using Negocio;
using System.Diagnostics;
using Util;
using System.IO;

namespace Telas
{
    public partial class Principal : Form
    {
        static Autenticacao autenticacao = new Autenticacao();
        static Cartao.ComunicacaoCartao comunicacaoCartao;
        static string SERVIDOR = Properties.Settings.Default.Servidor.ToUpper();
        static string SERVIDOR_NFE = Properties.Settings.Default.ServidorNfe.ToUpper();
        static string SERVIDOR_NFE_DEPOSITO = Properties.Settings.Default.ServidorNfeDeposito.ToUpper();
        static string SERVIDOR_CARTAO = Properties.Settings.Default.ServidorCartao.ToUpper();
        static int NFCE_SERVIDOR = Properties.Settings.Default.NfceServidor;
        static int NFCE_ONLINE = Properties.Settings.Default.NfceOnline;

        static string SERVIDOR_IMPRIMIR_NFCE = Properties.Settings.Default.ServidorImprimirNfce;
        static string SERVIDOR_IMPRIMIR_NFE  = Properties.Settings.Default.ServidorImprimirNfce;
        //static string SERVIDOR_IMPRIMIR_REDUZIDO1 = Properties.Settings.Default.ServidorImprimirReduzido1;



        static string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
            
       
        public static Autenticacao Autenticacao
        {
            get { return Principal.autenticacao; }
            set { Principal.autenticacao = value; }
        }

        public Principal()
        {
            InitializeComponent();
        }

       [STAThread]
        static void Main(string[] args)
        {
            TratarException eh = new TratarException();
            Application.ThreadException += new ThreadExceptionEventHandler(eh.TratarMySqlException);
            Application.Run(new Principal());
        }

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
            Telas.FrmGrupo frmGrupo = new Telas.FrmGrupo();
            frmGrupo.ShowDialog();
            frmGrupo.Dispose();
        }

        private void subgrupoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmSubgrupo frmSubgrupo = new Telas.FrmSubgrupo(1);
            frmSubgrupo.ShowDialog();
            frmSubgrupo.Dispose();
        }

        private void lojasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmLoja frmLoja = new Telas.FrmLoja();
            frmLoja.ShowDialog();
            frmLoja.Dispose();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmProduto frmProduto = new Telas.FrmProduto();
            frmProduto.ShowDialog();
            frmProduto.Dispose();
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
            frmPessoa.ShowDialog();
            frmPessoa.Dispose();
        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmBanco frmBanco = new Telas.FrmBanco();
            frmBanco.ShowDialog();
            frmBanco.Dispose();
        }

        private void contasBancáriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmContaBanco frmContaBanco = new Telas.FrmContaBanco();
            frmContaBanco.ShowDialog();
            frmContaBanco.Dispose();
        }

        private void cartõesDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmCartaoCredito frmCartaoCredito = new Telas.FrmCartaoCredito();
            frmCartaoCredito.ShowDialog();
            frmCartaoCredito.Dispose();
        }

        private void planoDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmPlanoConta frmPlanoConta = new Telas.FrmPlanoConta();
            frmPlanoConta.ShowDialog();
            frmPlanoConta.Dispose();
        }

        private void tiposDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmGrupoConta frmTipoConta = new Telas.FrmGrupoConta();
            frmTipoConta.ShowDialog();
            frmTipoConta.Dispose();
        }

        private void vendaAoConsumidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmSaida frmPreVenda = new Telas.FrmSaida(Saida.TIPO_ORCAMENTO);
            frmPreVenda.ShowDialog();
            frmPreVenda.Dispose();
        }

        private void devoluçãoDeConsumidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmSaida frmPreVenda = new Telas.FrmSaida(Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR);
            frmPreVenda.ShowDialog();
            frmPreVenda.Dispose();
        }


        private void entradaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmEntrada frmEntrada = new Telas.FrmEntrada();
            frmEntrada.ShowDialog();
            frmEntrada.Dispose();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telas.FrmUsuario frmFrmUsuario = new Telas.FrmUsuario();
            frmFrmUsuario.ShowDialog();
            frmFrmUsuario.Dispose();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //this.Visible = false;
            //Telas.FrmLogin frmFrmLogin = new Telas.FrmLogin();
            //frmFrmLogin.ShowDialog();
            //if (frmFrmLogin.Aturizado)
            //{
            //    autenticacao.CodUsuario = frmFrmLogin.CodUsuario;
            //    autenticacao.Login = frmFrmLogin.Login;
            //    this.Visible = true;
            //    frmFrmLogin.Dispose();
            //}
            //else
            //{
            //    Application.Exit();
            //}

            //MapearImpressorasSeriais();

            autenticacao.CodUsuario = 1;
            autenticacao.Login = "1";
            this.Visible = true;
        }

        private void contasAPagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Telas.FrmConta frmConta = new Telas.FrmConta();
            frmConta.ShowDialog();
            frmConta.Dispose();
        }


        private void produtosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Relatorios.Produtos.FrmRelProdutos relatorio = new Relatorios.Produtos.FrmRelProdutos();
            relatorio.ShowDialog();
            relatorio.Dispose();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma criação do backup?", "Confirmar Backup", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                Negocio.GerenciadorSeguranca.getInstance().Backup(System.Windows.Forms.SystemInformation.ComputerName);
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
                Negocio.GerenciadorSeguranca.getInstance().Restore(openFileDialog.FileName);
                Cursor.Current = Cursors.Default;
            }
                

        }

        private void transferênciaEntreLojasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_PRE_REMESSA_DEPOSITO);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }

        private void retornoDepositoMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_PRE_RETORNO_DEPOSITO);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }        
        private void receberPagamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReceberPagamentoPessoa frmReceberPagamento = new FrmReceberPagamentoPessoa(false);
            frmReceberPagamento.ShowDialog();
            frmReceberPagamento.Dispose();
        }

        private void devoluçãoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }

        private void remessaParaConsertoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_PRE_REMESSA_CONSERTO);
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

        private static void ProcessarDocumentosFiscais()
        {
            //if (nomeComputador.ToUpper().Equals(SERVIDOR))
            //{
                //GerenciadorSolicitacaoDocumento.GetInstance().EnviarProximoECF();
                //GerenciadorSolicitacaoDocumento.GetInstance().AtualizarPedidosComDocumentosECF(SERVIDOR);
                // GerenciadorCartaoCredito.GetInstance().AtualizarPedidosComAutorizacaoCartao();
            //}
            if (nomeComputador.ToUpper().Equals(SERVIDOR_CARTAO))
            {
                GerenciadorCartaoCredito.GetInstance().AtualizarRespostaCartoes(SERVIDOR_CARTAO);
                GerenciadorCartaoCredito.GetInstance().AtualizarPedidosComAutorizacaoCartao();
            }
            if (nomeComputador.ToUpper().Equals(SERVIDOR_NFE))
            {
                GerenciadorSolicitacaoDocumento.GetInstance().EnviarProximoNFe(SERVIDOR_NFE_DEPOSITO);
                GerenciadorSolicitacaoDocumento.GetInstance().EnviarProximoNFCe(SERVIDOR_CARTAO);
                GerenciadorNFe.GetInstance().RecuperarRetornosNfe();
            }
            GerenciadorNFe.GetInstance().imprimirDANFE(null, SERVIDOR_IMPRIMIR_NFE, SERVIDOR_IMPRIMIR_NFCE);
            
            
            //GerenciadorSolicitacaoDocumento.GetInstance().EnviarProximoNFCe(SERVIDOR_CARTAO, NFCE_SERVIDOR, NFCE_ONLINE);
            //GerenciadorSolicitacaoDocumento.GetInstance().AtualizarPedidosComDocumentosNFCE();
        }

        private void estatísticaPorProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoEstatistica frmProdutoEstatistica = new FrmProdutoEstatistica();
            frmProdutoEstatistica.ShowDialog();
            frmProdutoEstatistica.Dispose();
        }

        private void atualizarCSOSNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoPesquisaCSON frmCSOSN = new FrmProdutoPesquisaCSON(false);
            frmCSOSN.ShowDialog();
            frmCSOSN.Dispose();
        }

        private void receberPagamentosCartõesDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReceberPagamentoPessoa frmReceberPagamento = new FrmReceberPagamentoPessoa(true);
            frmReceberPagamento.ShowDialog();
            frmReceberPagamento.Dispose();
        }

        private void produtosParaRevendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.FrmFiltroRelatorioProduto relatorio = new Relatorios.FrmFiltroRelatorioProduto();
            relatorio.ShowDialog();
            relatorio.Dispose();
        }


        private void pontaDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPontaEstoque frmPontaEstoque = new FrmPontaEstoque(new ProdutoPesquisa() { CodProduto = 1 });
            frmPontaEstoque.ShowDialog();
            frmPontaEstoque.Dispose();
        }

        private void movimentaçãoDeCaixasContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimentacaoCaixa frmMovimentacaoCaixa = new FrmMovimentacaoCaixa();
            frmMovimentacaoCaixa.ShowDialog();
            frmMovimentacaoCaixa.Dispose();
        }

        private void solicitaçõesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoSolicitacoesCompra frmProdutoSolicitacoesCompra = new FrmProdutoSolicitacoesCompra();
            frmProdutoSolicitacoesCompra.ShowDialog();
            frmProdutoSolicitacoesCompra.Dispose();
        }

        private void estatísticaPorGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrupoEstatistica frmGrupoEstatistica = new FrmGrupoEstatistica();
            frmGrupoEstatistica.ShowDialog();
            frmGrupoEstatistica.Dispose();
        }

        private void exclusãoDeProdutoDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoExcluir frmProdutoExcluir = new FrmProdutoExcluir();
            frmProdutoExcluir.ShowDialog();
            frmProdutoExcluir.Dispose();
        }

        private void exclusãoDePessoasDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPessoaExcluir frmPessoaExcluir = new FrmPessoaExcluir();
            frmPessoaExcluir.ShowInTaskbar = false;
            frmPessoaExcluir.ShowDialog();
            frmPessoaExcluir.Dispose();
        }

        private void atualizarPreçoVarejoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoPreco frmProdutoPreco = new FrmProdutoPreco(false);
            frmProdutoPreco.ShowDialog();
            frmProdutoPreco.Dispose();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}