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
using Util;

namespace Telas
{
    public partial class FrmSubgrupo : Form
    {
        private EstadoFormulario estado;

        public String CodSubgrupo { get; set; }

        public FrmSubgrupo()
        {
            InitializeComponent();
        }

        private void FrmSubgrupo_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.CONTAS_BANCO_CAIXA, Principal.Autenticacao.CodUsuario);
            this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
            this.tb_subgrupoTableAdapter.Fill(this.saceDataSet.tb_subgrupo);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmSubgrupoPesquisa frmSubgrupoPesquisa = new Telas.FrmSubgrupoPesquisa();
            frmSubgrupoPesquisa.ShowDialog();
            if (frmSubgrupoPesquisa.CodSubgrupo != -1)
            {
                tb_subgrupoBindingSource.Position = tb_subgrupoBindingSource.Find("codSubgrupo", frmSubgrupoPesquisa.CodSubgrupo);
            }
            frmSubgrupoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_subgrupoBindingSource.AddNew();
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            codGrupoComboBox.SelectedIndex = 0;
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codSubgrupoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorSubgrupo.getInstace().remover(Int32.Parse(codSubgrupoTextBox.Text));
                tb_subgrupoTableAdapter.Fill(saceDataSet.tb_subgrupo);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_subgrupoBindingSource.CancelEdit();
            tb_subgrupoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Subgrupo subgrupo = new Subgrupo();

                subgrupo.CodGrupo = Convert.ToInt32(codGrupoComboBox.SelectedValue.ToString());
                subgrupo.CodSubgrupo = Convert.ToInt32(codSubgrupoTextBox.Text);
                subgrupo.Descricao = descricaoTextBox.Text;

                IGerenciadorSubgrupo gSubgrupo = GerenciadorSubgrupo.getInstace();

                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gSubgrupo.inserir(subgrupo);
                    tb_subgrupoTableAdapter.Fill(saceDataSet.tb_subgrupo);
                    tb_subgrupoBindingSource.MoveLast();
                }
                else
                {
                    gSubgrupo.atualizar(subgrupo);
                    tb_subgrupoBindingSource.EndEdit();
                }
            }
            catch (Dados.DadosException de)
            {
                tb_subgrupoBindingSource.CancelEdit();
                throw de;
            }
            finally {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmSubgrupo_KeyDown(object sender, KeyEventArgs e)
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
                    tb_subgrupoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_subgrupoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_subgrupoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_subgrupoBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codGrupoComboBox.Focused))
                {
                    Telas.FrmGrupoPesquisa frmGrupoPesquisa = new Telas.FrmGrupoPesquisa();
                    frmGrupoPesquisa.ShowDialog();
                    if (frmGrupoPesquisa.CodGrupo != -1)
                    {
                        tbgrupoBindingSource.Position = tbgrupoBindingSource.Find("codGrupo", frmGrupoPesquisa.CodGrupo);
                    }
                    frmGrupoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codGrupoComboBox.Focused))
                {
                    Telas.FrmGrupo frmGrupo = new Telas.FrmGrupo();
                    frmGrupo.ShowDialog();
                    if (frmGrupo.CodGrupo != -1)
                    {
                        this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
                        tbgrupoBindingSource.Position = tbgrupoBindingSource.Find("codGrupo", frmGrupo.CodGrupo);
                    }
                    frmGrupo.Dispose();
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
            tb_subgrupoBindingNavigator.Enabled = habilita;
            codGrupoComboBox.Enabled = !(habilita);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmSubgrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            CodSubgrupo = codSubgrupoTextBox.Text;
        }

        private void codGrupoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void codGrupoComboBox_Leave(object sender, EventArgs e)
        {
            if (codGrupoComboBox.SelectedValue == null)
            {
                codGrupoComboBox.Focus();
                throw new TelaException("Um banco válido precisa ser selecionado.");
            }
        }
    }
}
