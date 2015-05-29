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

namespace Telas
{
    public partial class FrmPessoaExcluir : Form
    {
        EstadoFormulario estado = EstadoFormulario.ESPERA;

        public FrmPessoaExcluir()
        {
            InitializeComponent();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            long codPessoaExcluir = ((Pessoa)pessoaBindingSource.Current).CodPessoa;
            long codPessoaManter =  ((Pessoa)pessoaBindingSource1.Current).CodPessoa;

            if (MessageBox.Show("Confirma exclusão da PESSOA DO SISTEMA?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorPessoa.GetInstance().SubstituirPessoa(codPessoaExcluir, codPessoaManter);
                pessoaBindingSource.RemoveCurrent();
            }
            codPessoaComboBox.Focus();
        }

        private void FrmPessoaExcluir_Load(object sender, EventArgs e)
        {
            pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            pessoaBindingSource1.DataSource = pessoaBindingSource.DataSource;
        }

        private void codPessoaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void codPessoaComboBox_Leave(object sender, EventArgs e)
        {
            Pessoa _pessoaPesquisa = ComponentesLeave.PessoaComboBox_Leave(sender, e, codPessoaComboBox, estado, pessoaBindingSource, true);
        }

        private void codPessoaComboBox1_Leave(object sender, EventArgs e)
        {
            Pessoa _pessoaPesquisa = ComponentesLeave.PessoaComboBox_Leave(sender, e, codPessoaComboBox1, estado, pessoaBindingSource1, true);
        }

        private void FrmPessoaExcluir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (codPessoaComboBox.Focused)
                {
                    codPessoaComboBox_Leave(sender, e);
                }
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnExcluir_Click(sender, e);
            }

        }
    }
}
