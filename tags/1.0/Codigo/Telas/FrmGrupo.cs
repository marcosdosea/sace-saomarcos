using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Dados;
using Util;

namespace Telas
{
    public partial class FrmGrupo : Form
    {
        private EstadoFormulario estado;
        private Int32 codGrupo;

        public Int32 CodGrupo
        {
            get { return codGrupo; }
            set { codGrupo = value; }
        }

        public FrmGrupo()
        {
            InitializeComponent();
        }

        private void FrmGrupo_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.GRUPOS_DE_PRODUTOS, Principal.Autenticacao.CodUsuario);
            this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmGrupoPesquisa frmGrupoPesquisa = new Telas.FrmGrupoPesquisa();
            frmGrupoPesquisa.ShowDialog();
            if (frmGrupoPesquisa.CodGrupo != -1)
            {
                tb_grupoBindingSource.Position = tb_grupoBindingSource.Find("codGrupo", frmGrupoPesquisa.CodGrupo);
            }
            frmGrupoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_grupoBindingSource.AddNew();
            codGrupoTextBox.Enabled = false;
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
                GerenciadorGrupo.getInstace().remover(Int32.Parse(codGrupoTextBox.Text));
                tb_grupoTableAdapter.Fill(saceDataSet.tb_grupo);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_grupoBindingSource.CancelEdit();
            tb_grupoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Grupo grupo = new Grupo();
                grupo.Descricao = descricaoTextBox.Text;
                grupo.CodGrupo = Int32.Parse(codGrupoTextBox.Text);

                IGerenciadorGrupo gGrupo = GerenciadorGrupo.getInstace();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gGrupo.inserir(grupo);
                    tb_grupoTableAdapter.Fill(saceDataSet.tb_grupo);
                    tb_grupoBindingSource.MoveLast();
                }
                else
                {
                    gGrupo.atualizar(grupo);
                    tb_grupoBindingSource.EndEdit();
                }
            }
            catch (DadosException de)
            {
                tb_grupoBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmGrupo_KeyDown(object sender, KeyEventArgs e)
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
                    tb_grupoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_grupoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_grupoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_grupoBindingSource.MoveNext();
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
            tb_grupoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            CodGrupo = Int32.Parse(codGrupoTextBox.Text);
        }
    }
}