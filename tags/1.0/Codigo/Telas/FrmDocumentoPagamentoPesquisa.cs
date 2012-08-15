using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telas
{
    public partial class FrmDocumentoPagamentoPesquisa : Form
    {
        private Int32 codDocumentoPagamento;

        public Int32 CodDocumentoPagamento
        {
            get { return codDocumentoPagamento; }
            set { codDocumentoPagamento = value; }
        }

        public FrmDocumentoPagamentoPesquisa()
        {
            InitializeComponent();
            codDocumentoPagamento = -1;
        }

        private void FrmDocumentoPagamentoPesquisa_Load(object sender, EventArgs e)
        {
            this.tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                this.tb_documento_pagamentoTableAdapter.FillByCodDocumentoPagamento(this.saceDataSet.tb_documento_pagamento, Convert.ToInt64(txtTexto.Text));
            else
                this.tb_documento_pagamentoTableAdapter.FillByNumero(this.saceDataSet.tb_documento_pagamento, txtTexto.Text);                
        }

        private void tb_documento_pagamentoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codDocumentoPagamento = int.Parse(tb_documento_pagamentoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmDocumentoPagamentoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_documento_pagamentoDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_documento_pagamentoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_documento_pagamentoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
