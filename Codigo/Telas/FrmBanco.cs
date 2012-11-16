using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dados.saceDataSetTableAdapters;
using Dados;
using Dominio;
using Negocio;
using Util;


namespace Telas
{
    public partial class FrmBanco : Form
    {
        private EstadoFormulario estado;
        
        public Int32 CodBanco;

        public FrmBanco()
        {
            InitializeComponent();
        }

        private void FrmBanco_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.BANCOS, Principal.Autenticacao.CodUsuario);

            tb_bancoBindingSource.DataSource = GerenciadorBanco.getInstace().obterTodos(); 
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmBancoPesquisa frmBancoPesquisa = new Telas.FrmBancoPesquisa();
            frmBancoPesquisa.ShowDialog();
            if (frmBancoPesquisa.CodBanco != -1)
            {
                tb_bancoBindingSource.Position = tb_bancoBindingSource.Find("codBanco", frmBancoPesquisa.CodBanco);
            }
            frmBancoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_bancoBindingSource.AddNew();
            codBancoTextBox.Enabled = false;
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorBanco.getInstace().remover(int.Parse(codBancoTextBox.Text));
                tb_bancoBindingSource.DataSource = GerenciadorBanco.getInstace().obterTodos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_bancoBindingSource.CancelEdit();
            tb_bancoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                BancoE banco = new BancoE();
                banco.codBanco = Int32.Parse(codBancoTextBox.Text);
                banco.nome = nomeTextBox.Text;

                GerenciadorBanco gBanco = GerenciadorBanco.getInstace();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gBanco.inserir(banco);
                    tb_bancoBindingSource.DataSource = GerenciadorBanco.getInstace().obterTodos();
                    tb_bancoBindingSource.MoveLast();
                }
                else
                {
                    gBanco.atualizar(banco);
                    tb_bancoBindingSource.EndEdit();
                }
            }
            catch (DadosException de)
            {
                tb_bancoBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnExcluir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_bancoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_bancoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_bancoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_bancoBindingSource.MoveNext();
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
                } else if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
            }
        }
        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_bancoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            CodBanco = int.Parse(codBancoTextBox.Text);
        }
    }
}
