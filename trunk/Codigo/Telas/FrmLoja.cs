using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dados;
using Dominio;
using Util;

namespace Telas
{
    public partial class FrmLoja : Form
    {
        private EstadoFormulario estado;

        public FrmLoja()
        {
            InitializeComponent();
        }

        private void FrmLoja_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.LOJAS, Principal.Autenticacao.CodUsuario);
            this.tb_lojaTableAdapter.Fill(this.saceDataSet.tb_loja);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmLojaPesquisa frmLojaPesquisa = new Telas.FrmLojaPesquisa();
            frmLojaPesquisa.ShowDialog();
            if (frmLojaPesquisa.CodLoja != -1)
            {
            tb_lojaBindingSource.Position = tb_lojaBindingSource.Find("codLoja", frmLojaPesquisa.CodLoja);
            }
            frmLojaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_lojaBindingSource.AddNew();
            codLojaTextBox.Enabled = false;
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
                GerenciadorLoja.getInstace().remover(int.Parse(codLojaTextBox.Text));
                tb_lojaTableAdapter.Fill(saceDataSet.tb_loja);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_lojaBindingSource.CancelEdit();
            tb_lojaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Loja loja = new Loja();
                loja.CodLoja = int.Parse(codLojaTextBox.Text);
                loja.Nome = nomeTextBox.Text;
                loja.Cnpj = cnpjTextBox.Text;
                loja.Ie = ieTextBox.Text;
                loja.Endereco = enderecoTextBox.Text;
                loja.Bairro = bairroTextBox.Text;
                loja.Cep = cepTextBox.Text;
                loja.Cidade = cidadeTextBox.Text;
                loja.Uf = ufTextBox.Text;
                loja.Fone = foneTextBox.Text;

                IGerenciadorLoja gLoja = GerenciadorLoja.getInstace();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gLoja.inserir(loja);
                    tb_lojaTableAdapter.Fill(saceDataSet.tb_loja);
                    tb_lojaBindingSource.MoveLast();
                }
                else
                {
                    gLoja.atualizar(loja);
                    tb_lojaBindingSource.EndEdit();
                }
            }
            catch (DadosException de)
            {
                tb_lojaBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmLoja_KeyDown(object sender, KeyEventArgs e)
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
                    tb_lojaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_lojaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_lojaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_lojaBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
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
            tb_lojaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
