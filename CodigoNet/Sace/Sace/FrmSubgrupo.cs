﻿using System;
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

namespace Sace
{
    public partial class FrmSubgrupo : Form
    {
        private EstadoFormulario estado;

        public Subgrupo SubgrupoSelected { get; set; }
        public Grupo GrupoSelected { get; set; }

        public FrmSubgrupo(Int32 codGrupo)
        {
            InitializeComponent();
            GrupoSelected = null;
            SubgrupoSelected = null;
        }

        private void FrmSubgrupo_Load(object sender, EventArgs e)
        {
            //GerenciadorSeguranca.getInstance().verificaPermissao(this, UtilConfig.Default.CONTAS_BANCO_CAIXA, Principal.Autenticacao.CodUsuario);
            grupoBindingSource.DataSource = GerenciadorGrupo.GetInstance().ObterTodos();
            subgrupoBindingSource.DataSource = GerenciadorSubgrupo.GetInstance().ObterTodos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmSubgrupoPesquisa frmSubgrupoPesquisa = new FrmSubgrupoPesquisa();
            frmSubgrupoPesquisa.ShowDialog();
            if (frmSubgrupoPesquisa.SubgrupoSelected != null)
            {
                subgrupoBindingSource.Position = subgrupoBindingSource.List.IndexOf(frmSubgrupoPesquisa.SubgrupoSelected);
            }
            frmSubgrupoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            subgrupoBindingSource.AddNew();
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            codGrupoComboBox.SelectedIndex = 0;
            Subgrupo subgrupo = (Subgrupo) subgrupoBindingSource.Current;
            subgrupo.CodGrupo = ((Grupo) grupoBindingSource.Current).CodGrupo; // grupo padrão
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
                GerenciadorSubgrupo.GetInstance().Remover(Int32.Parse(codSubgrupoTextBox.Text));
                subgrupoBindingSource.RemoveCurrent();
            }
            btnBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            subgrupoBindingSource.CancelEdit();
            subgrupoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Subgrupo subgrupo = (Subgrupo) subgrupoBindingSource.Current;
                
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    long codSubgrupo = GerenciadorSubgrupo.GetInstance().Inserir(subgrupo);
                    codSubgrupoTextBox.Text = codSubgrupo.ToString();
                }
                else
                {
                    GerenciadorSubgrupo.GetInstance().Atualizar(subgrupo);
                }
                subgrupoBindingSource.EndEdit();
            }
            catch (Dados.DadosException de)
            {
                subgrupoBindingSource.CancelEdit();
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
                    subgrupoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    subgrupoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    subgrupoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    subgrupoBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codGrupoComboBox.Focused))
                {
                    FrmGrupoPesquisa frmGrupoPesquisa = new FrmGrupoPesquisa();
                    frmGrupoPesquisa.ShowDialog();
                    if (frmGrupoPesquisa.SelectedGrupo != null)
                    {
                        grupoBindingSource.Position = grupoBindingSource.List.IndexOf(frmGrupoPesquisa.SelectedGrupo);
                    }
                    frmGrupoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codGrupoComboBox.Focused))
                {
                    FrmGrupo frmGrupo = new FrmGrupo();
                    frmGrupo.ShowDialog();
                    if (frmGrupo.GrupoSelected != null)
                    {
                        grupoBindingSource.Position = grupoBindingSource.List.IndexOf(frmGrupo.GrupoSelected);
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
            SubgrupoSelected = (Subgrupo)subgrupoBindingSource.Current;
            GrupoSelected = GerenciadorGrupo.GetInstance().Obter(SubgrupoSelected.CodGrupo).ElementAt(0);
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
                throw new TelaException("Um grupo válido precisa ser selecionado.");
            }
        }

        private void descricaoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }
    }
}
