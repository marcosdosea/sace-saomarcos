﻿using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmGrupoPesquisa : Form
    {
        public Grupo SelectedGrupo { get; set; }

        public FrmGrupoPesquisa()
        {
            InitializeComponent();
        }

        private void FrmGrupoPesquisa_Load(object sender, EventArgs e)
        {
            grupoBindingSource.DataSource = GerenciadorGrupo.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                grupoBindingSource.DataSource = GerenciadorGrupo.Obter(Convert.ToInt32(txtTexto.Text));
            else
                grupoBindingSource.DataSource = GerenciadorGrupo.ObterPorDescricao(txtTexto.Text);
        }

        private void tb_grupoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGrupo = (Grupo) grupoBindingSource.Current;
            this.Close();
        }

        private void FrmGrupoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_grupoDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                grupoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                grupoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
