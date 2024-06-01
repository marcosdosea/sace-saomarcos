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
    public partial class FrmCfop : Form
    {
        private EstadoFormulario estado;
        private Cfop CfopSelected { get; set;}

        public FrmCfop()
        {
            InitializeComponent();
        }

        private void FrmCfop_Load(object sender, EventArgs e)
        {
            cfopBindingSource.DataSource = GerenciadorCfop.GetInstance().ObterTodos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmCfopPesquisa frmCfopPesquisa = new Telas.FrmCfopPesquisa();
            frmCfopPesquisa.ShowDialog();
            if (frmCfopPesquisa.CfopSelected != null)
            {
                cfopBindingSource.Position = cfopBindingSource.List.IndexOf(frmCfopPesquisa.CfopSelected);
            }
            frmCfopPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cfopBindingSource.AddNew();
            cfopTextBox.Focus();
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
                GerenciadorCfop.GetInstance().Remover(Int32.Parse(cfopTextBox.Text));
                cfopBindingSource.RemoveCurrent();
            }
            btnBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cfopBindingSource.CancelEdit();
            cfopBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cfop cfop = new Cfop();
                cfop.Descricao = descricaoTextBox.Text;
                cfop.CodCfop = Int32.Parse(cfopTextBox.Text);
                cfop.Icms = 0;

                GerenciadorCfop gCfop = GerenciadorCfop.GetInstance();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gCfop.Inserir(cfop);
                }
                else
                {
                    gCfop.Atualizar(cfop);
                }
                cfopBindingSource.EndEdit();
            }
            catch (DadosException de)
            {
                cfopBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmCfop_KeyDown(object sender, KeyEventArgs e)
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
                    cfopBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    cfopBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    cfopBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    cfopBindingSource.MoveNext();
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
            tb_cfopBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmCfop_FormClosing(object sender, FormClosingEventArgs e)
        {
            CfopSelected = (Cfop) cfopBindingSource.Current;
        }

        private void cfopTextBox_Enter(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            textbox.BackColor = Global.BACKCOLOR_FOCUS;
        }

        private void cfopTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
            TextBox textbox = (TextBox)sender;
            textbox.BackColor = Global.BACKCOLOR_FOCUS_LEAVE;
        }
    }
}