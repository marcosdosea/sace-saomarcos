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

namespace Telas
{
    public partial class Principal : Form
    {
        static Autenticacao autenticacao = new Autenticacao();

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
            TratamentoException eh = new TratamentoException();
            Application.ThreadException += new ThreadExceptionEventHandler(eh.TratarException);
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
                Negocio.GerenciadorSeguranca.getInstance().Backup();
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

        private void movimentaçãoContasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                Negocio.GerenciadorSeguranca.getInstance().Backup();

            }
        }

        private void transferênciaEntreLojasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_SAIDA_DEPOSITO);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }

        
        private void receberPagamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReceberPagamentoPessoa frmReceberPagamento = new FrmReceberPagamentoPessoa();
            frmReceberPagamento.ShowDialog();
            frmReceberPagamento.Dispose();
        }

        private void devoluçãoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_DEVOLUCAO_FRONECEDOR);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSaida frmSaida = new FrmSaida(Saida.TIPO_OUTRAS_SAIDAS);
            frmSaida.ShowDialog();
            frmSaida.Dispose();
        }

        private void códigoFiscalDeOperaçãoCFOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCfop frmCfop = new FrmCfop();
            frmCfop.ShowDialog();
            frmCfop.Dispose();
        }

        private void timerAtualizaCuponsFiscais_Tick(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerAtualizarCupons.RunWorkerAsync();
            }
            catch (Exception)
            {
                // nao precisa lançar nenhuma exceção apenas os cupons ficais emitidos não atualização o SACE
            }
        }

        private void backgroundWorkerAtualizarCupons_DoWork(object sender, DoWorkEventArgs e)
        {
            GerenciadorSaida.GetInstance().AtualizarPedidosComDocumentosFiscais();
        }

        private void estatísticaPorProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutoEstatistica frmProdutoEstatistica = new FrmProdutoEstatistica();
            frmProdutoEstatistica.ShowDialog();
            frmProdutoEstatistica.Dispose();
        }
    }
}