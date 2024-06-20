using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmGrupoContaPesquisa : Form
    {
        public GrupoConta GrupoConta { get; set; }
        private readonly GerenciadorGrupoConta gerenciadorGrupoConta;

        public FrmGrupoContaPesquisa(DbContextOptions<SaceContext> options)
        {
            InitializeComponent();
            GrupoConta = null;
            SaceContext context = new SaceContext(options);
            gerenciadorGrupoConta = new GerenciadorGrupoConta(context); 
        }

        private void FrmGrupoContaPesquisa_Load(object sender, EventArgs e)
        {
            grupoContaBindingSource.DataSource = gerenciadorGrupoConta.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
               grupoContaBindingSource.DataSource = gerenciadorGrupoConta.Obter(Convert.ToInt32(txtTexto.Text));
            else
              grupoContaBindingSource.DataSource = gerenciadorGrupoConta.ObterPorDescricao(txtTexto.Text);
         }

        private void tb_grupo_contaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GrupoConta = (GrupoConta) grupoContaBindingSource.Current;
            this.Close();
        }

        private void FrmGrupoContaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_grupo_contaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                grupoContaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                grupoContaBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
