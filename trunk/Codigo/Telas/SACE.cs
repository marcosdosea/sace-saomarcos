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
using SACE.Excecoes;

namespace SACE
{
    public partial class Principal : Form
    {
        Autenticacao autenticacao = new Autenticacao();

        public Principal()
        {
            InitializeComponent();
        }

        static void Main(string[] args)
        {
            TratamentoException eh = new TratamentoException();
            Application.ThreadException += new ThreadExceptionEventHandler(eh.TratarException);
            Application.Run(new Principal());
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                produtosToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5)
            {
                pessoasToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                empresasToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                entradaDeProdutosToolStripMenuItem_Click(sender, e);
            }
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gruposDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(9))
            {
                Telas.FrmGrupo frmGrupo = new Telas.FrmGrupo();
                frmGrupo.ShowDialog();
                frmGrupo.Dispose();
            }
        }

        private void lojasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(4))
            {
                Telas.FrmLoja frmLoja = new Telas.FrmLoja();
                frmLoja.ShowDialog();
                frmLoja.Dispose();
            }
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(1))
            {
                Telas.FrmProduto frmProduto = new Telas.FrmProduto();
                frmProduto.ShowDialog();
                frmProduto.Dispose();
            }
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(2))
            {
                Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                frmPessoa.ShowDialog();
                frmPessoa.Dispose();
            }
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(3))
            {
                Telas.FrmEmpresa frmEmpresa = new Telas.FrmEmpresa();
                frmEmpresa.ShowDialog();
                frmEmpresa.Dispose();
            }
        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(5))
            {
                Telas.FrmBanco frmBanco = new Telas.FrmBanco();
                frmBanco.ShowDialog();
                frmBanco.Dispose();
            }
        }

        private void contasBancáriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(7))
            {
                Telas.FrmContaBanco frmContaBanco = new Telas.FrmContaBanco();
                frmContaBanco.ShowDialog();
                frmContaBanco.Dispose();
            }
        }

        private void cartõesDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(8))
            {
                Telas.FrmCartaoCredito frmCartaoCredito = new Telas.FrmCartaoCredito();
                frmCartaoCredito.ShowDialog();
                frmCartaoCredito.Dispose();
            }
        }

        private void planoDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(6))
            {
                Telas.FrmPlanoConta frmPlanoConta = new Telas.FrmPlanoConta();
                frmPlanoConta.ShowDialog();
                frmPlanoConta.Dispose();
            }
        }

        private void tiposDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(10))
            {
                Telas.FrmGrupoConta frmTipoConta = new Telas.FrmGrupoConta();
                frmTipoConta.ShowDialog();
                frmTipoConta.Dispose();
            }
        }

        private void vendaAoConsumidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(12))
            {
                Telas.FrmPreVenda frmPreVenda = new Telas.FrmPreVenda();
                frmPreVenda.ShowDialog();
                frmPreVenda.Dispose();
            }
        }

        private void entradaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(14))
            {
                Telas.FrmEntrada frmEntrada = new Telas.FrmEntrada();
                frmEntrada.ShowDialog();
                frmEntrada.Dispose();
            }
        }

        private void transformaçãoDePrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(15))
            {
                Telas.FrmTransformacaoProduto frmTrasnformacaoProduto = new Telas.FrmTransformacaoProduto();
                frmTrasnformacaoProduto.ShowDialog();
                frmTrasnformacaoProduto.Dispose();
            }
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autenticacao.verificaPermissao(11))
            {
                Telas.FrmUsuario frmFrmUsuario = new Telas.FrmUsuario();
                frmFrmUsuario.ShowDialog();
                frmFrmUsuario.Dispose();
            }
        }
    }
}
