﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telas
{
    public partial class FrmCartaoCreditoPesquisa : Form
    {
        private Int32 codCartaoCredito;

        public FrmCartaoCreditoPesquisa()
        {
            InitializeComponent();
            codCartaoCredito = -1;
        }

        private void FrmCartaoCreditoPesquisa_Load(object sender, EventArgs e)
        {
            this.tb_cartao_creditoTableAdapter.Fill(this.saceDataSet.tb_cartao_credito);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                this.tb_cartao_creditoTableAdapter.FillByCodCartao(this.saceDataSet.tb_cartao_credito, int.Parse(txtTexto.Text));
            else
                this.tb_cartao_creditoTableAdapter.FillByNome(this.saceDataSet.tb_cartao_credito, txtTexto.Text);                
        }

        private void tb_cartao_creditoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codCartaoCredito = int.Parse(tb_cartao_creditoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmCartaoCreditoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_cartao_creditoDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_cartao_creditoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_cartao_creditoBindingSource.MovePrevious();
            }
        }

        public Int32 getCodCartaoCredito()
        {
            return codCartaoCredito;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}