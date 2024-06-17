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
    public partial class FrmContaBancoPesquisa : Form
    {
        public ContaBanco ContaBancoSelected { get; set; }

        public FrmContaBancoPesquisa()
        {
            InitializeComponent();
            ContaBancoSelected = null;
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            contaBancoBindingSource.DataSource = gerenciadorContaBanco.ObterTodos();
            cmbBusca.SelectedIndex = 1;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                contaBancoBindingSource.DataSource = gerenciadorContaBanco.ObterPorNumero(txtTexto.Text);
            else
                contaBancoBindingSource.DataSource = gerenciadorContaBanco.ObterPorDescricao(txtTexto.Text);              
            
        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ContaBancoSelected = (ContaBanco) contaBancoBindingSource.Current;
            this.Close();
        }

        private void FrmBancoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_bancoDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                contaBancoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                contaBancoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}