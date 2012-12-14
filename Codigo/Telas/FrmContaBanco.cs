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
        
        private String codContaBanco;

        public String CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        public FrmContaBanco()
        {
            InitializeComponent();
        }

        private void FrmContaBanco_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.CONTAS_BANCO_CAIXA, Principal.Autenticacao.CodUsuario);
            codBancoComboBox.DataSource = GerenciadorBanco.GetInstace().ObterTodos();
            contaBancoBindingSource.DataSource = GerenciadorContaBanco.GetInstance().ObterTodos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmContaBancoPesquisa frmContaBancoPesquisa = new Telas.FrmContaBancoPesquisa();
            frmContaBancoPesquisa.ShowDialog();
            if (frmContaBancoPesquisa.CodContaBanco != "")
            {
                ContaBanco contaBanco = GerenciadorContaBanco.GetInstance().Obter(int.Parse(frmContaBancoPesquisa.CodContaBanco)).ElementAt(0);
                contaBancoBindingSource.Position = contaBancoBindingSource.List.IndexOf( contaBanco );
            }
            frmContaBancoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            contaBancoBindingSource.AddNew();
            numerocontaTextBox.Focus();
            habilitaBotoes(false);
            codBancoComboBox.SelectedIndex = 0;
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

                contaBancoBindingSource.DataSource = GerenciadorContaBanco.GetInstance().ObterTodos();
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
                ContaBanco _contaBanco = new ContaBanco();
                _contaBanco.CodContaBanco = Int32.Parse(codContaBancoTextBox.Text);
                _contaBanco.NumeroConta = numerocontaTextBox.Text;
                _contaBanco.Agencia = agenciaTextBox.Text;
                _contaBanco.Descricao = descricaoTextBox.Text;
                _contaBanco.Saldo = decimal.Parse(saldoTextBox.Text);
                _contaBanco.CodBanco = Int32.Parse(codBancoComboBox.SelectedValue.ToString());

                GerenciadorContaBanco gContaBanco = GerenciadorContaBanco.GetInstance();

                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gContaBanco.Inserir(_contaBanco);
                    contaBancoBindingSource.DataSource = GerenciadorContaBanco.GetInstance().ObterTodos();
                    contaBancoBindingSource.MoveLast();
                }
                else
                {
                    gContaBanco.Atualizar(_contaBanco);
                    contaBancoBindingSource.EndEdit();
                }
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
                    if (frmBancoPesquisa.CodBanco != -1)
                    {
                        bancoBindingSource.Position = bancoBindingSource.Find("codBanco", frmBancoPesquisa.CodBanco);
                    }
                    frmBancoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codBancoComboBox.Focused))
                {
                    Telas.FrmBanco frmBanco = new Telas.FrmBanco();
                    frmBanco.ShowDialog();
                    if (frmBanco.CodBanco != -1)
                    {
                        codBancoComboBox.DataSource = GerenciadorBanco.GetInstace().ObterTodos();
                        bancoBindingSource.Position = bancoBindingSource.Find("CodBanco", frmBanco.CodBanco);
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
            CodContaBanco = codContaBancoTextBox.Text;
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
    }
}
