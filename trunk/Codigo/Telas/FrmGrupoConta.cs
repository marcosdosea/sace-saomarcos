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
    public partial class FrmGrupoConta : Form
    {
        private EstadoFormulario estado;
        public GrupoConta GrupoContaSelected { get; set; }

        public FrmGrupoConta()
        {
            InitializeComponent();
        }

        private void FrmGrupoConta_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.GRUPOS_DE_CONTAS, Principal.Autenticacao.CodUsuario);
            grupoContaBindingSource.DataSource = GerenciadorGrupoConta.GetInstance().ObterTodos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmGrupoContaPesquisa frmTipoContaPesquisa = new Telas.FrmGrupoContaPesquisa();
            frmTipoContaPesquisa.ShowDialog();
            if (frmTipoContaPesquisa.GrupoConta != null)
            {
                grupoContaBindingSource.Position = grupoContaBindingSource.List.IndexOf(frmTipoContaPesquisa.GrupoConta);
            }
            frmTipoContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            grupoContaBindingSource.AddNew();
            codGrupoContaTextBox.Enabled = false;
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorGrupoConta.GetInstance().Remover(Int32.Parse(codGrupoContaTextBox.Text));
                grupoContaBindingSource.RemoveCurrent();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            grupoContaBindingSource.CancelEdit();
            grupoContaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                GrupoConta grupoConta = new GrupoConta();
                grupoConta.CodGrupoConta = Int32.Parse(codGrupoContaTextBox.Text);
                grupoConta.Descricao = descricaoTextBox.Text;

                GerenciadorGrupoConta gGrupoConta = GerenciadorGrupoConta.GetInstance();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    grupoConta.CodGrupoConta = (int) gGrupoConta.Inserir(grupoConta);
                    codGrupoContaTextBox.Text = grupoConta.CodGrupoConta.ToString();
                }
                else
                {
                    gGrupoConta.Atualizar(grupoConta);
                }
                grupoContaBindingSource.EndEdit();
            }
            catch (DadosException de)
            {
                grupoContaBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
            

        }

        private void FrmGrupoConta_KeyDown(object sender, KeyEventArgs e)
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
                    grupoContaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    grupoContaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    grupoContaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    grupoContaBindingSource.MoveNext();
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
            tb_grupo_contaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmGrupoConta_FormClosing(object sender, FormClosingEventArgs e)
        {
            GrupoContaSelected = (GrupoConta) grupoContaBindingSource.Current;
        }

        private void descricaoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }
    }
}
