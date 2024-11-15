﻿using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmCfopPesquisa : Form
    {
        public Cfop CfopSelected { get; set; }

        public FrmCfopPesquisa()
        {
            InitializeComponent();
            CfopSelected = null;
        }

        private void FrmCfopPesquisa_Load(object sender, EventArgs e)
        {
            
            cfopBindingSource.DataSource = GerenciadorCfop.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                cfopBindingSource.DataSource = GerenciadorCfop.Obter(Convert.ToInt32(txtTexto.Text));
            else
                cfopBindingSource.DataSource = GerenciadorCfop.ObterPorDescricao(txtTexto.Text);
        }

        private void tb_cfopDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CfopSelected = (Cfop) cfopBindingSource.Current;
            this.Close();
        }

        private void FrmCfopPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_cfopDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                cfopBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                cfopBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
