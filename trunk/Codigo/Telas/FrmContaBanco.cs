using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Util;
using Dominio;

namespace Telas
{
    public partial class FrmContaBanco : Form
    {
        private EstadoFormulario estado;

        public ContaBanco ContaBancoSelected { get; set; }

        public FrmContaBanco()
        {
            InitializeComponent();
        }

        private void FrmContaBanco_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.CONTAS_BANCO_CAIXA, Principal.Autenticacao.CodUsuario);
            bancoBindingSource.DataSource = GerenciadorBanco.GetInstace().ObterTodos();
            contaBancoBindingSource.DataSource = GerenciadorContaBanco.GetInstance().ObterTodos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmContaBancoPesquisa frmContaBancoPesquisa = new Telas.FrmContaBancoPesquisa();
            frmContaBancoPesquisa.ShowDialog();
            if (frmContaBancoPesquisa.ContaBancoSelected != null)
            {
                contaBancoBindingSource.Position = contaBancoBindingSource.List.IndexOf(frmContaBancoPesquisa.ContaBancoSelected);
            }
            frmContaBancoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            contaBancoBindingSource.AddNew();
            numerocontaTextBox.Focus();
            habilitaBotoes(false);
            codBancoComboBox.SelectedIndex = 0;
            ContaBanco contaBanco = (ContaBanco)contaBancoBindingSource.Current;
            contaBanco.CodBanco = ((Banco)bancoBindingSource.Current).CodBanco;
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codContaBancoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorContaBanco.GetInstance().Remover(Int32.Parse(codContaBancoTextBox.Text));
                contaBancoBindingSource.RemoveCurrent();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            contaBancoBindingSource.CancelEdit();
            contaBancoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaBanco _contaBanco = (ContaBanco)contaBancoBindingSource.Current;
                
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    long codContaBanco = GerenciadorContaBanco.GetInstance().Inserir(_contaBanco);
                    codContaBancoTextBox.Text = codContaBanco.ToString();
                }
                else
                {
                    GerenciadorContaBanco.GetInstance().Atualizar(_contaBanco);
                }
                contaBancoBindingSource.EndEdit();
            }
            catch (Dados.DadosException de)
            {
                contaBancoBindingSource.CancelEdit();
                throw de;
            }
            finally {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmContaBanco_KeyDown(object sender, KeyEventArgs e)
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
                    contaBancoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    contaBancoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    contaBancoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    contaBancoBindingSource.MoveNext();
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
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
                else if ((e.KeyCode == Keys.F2) && (codBancoComboBox.Focused))
                {
                    Telas.FrmBancoPesquisa frmBancoPesquisa = new Telas.FrmBancoPesquisa();
                    frmBancoPesquisa.ShowDialog();
                    if (frmBancoPesquisa.BancoSelected != null)
                    {
                        bancoBindingSource.Position = bancoBindingSource.List.IndexOf(frmBancoPesquisa.BancoSelected);
                    }
                    frmBancoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codBancoComboBox.Focused))
                {
                    Telas.FrmBanco frmBanco = new Telas.FrmBanco();
                    frmBanco.ShowDialog();
                    if (frmBanco.BancoSelected != null)
                    {
                        bancoBindingSource.Position = bancoBindingSource.List.IndexOf(frmBanco.BancoSelected);
                    }
                    frmBanco.Dispose();
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
            tb_conta_bancoBindingNavigator.Enabled = habilita;
            codBancoComboBox.Enabled = !(habilita);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmContaBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            ContaBancoSelected = (ContaBanco) contaBancoBindingSource.Current;
        }

        private void codBancoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void codBancoComboBox_Leave(object sender, EventArgs e)
        {
            if (codBancoComboBox.SelectedValue == null)
            {
                codBancoComboBox.Focus();
                throw new TelaException("Um banco válido precisa ser selecionado.");
            }
        }

        private void descricaoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }
    }
}
