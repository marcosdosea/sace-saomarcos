using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Telas
{
    public partial class FrmPessoaPesquisa : Form
    {
        private Int32 codPessoa;
        private Char? filtroTipoPessoa;
        private String filtroNome;

        public Int32 CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
        }

        public FrmPessoaPesquisa()
        {
            InitializeComponent();
            codPessoa = -1;
            filtroTipoPessoa = null;
            filtroNome = null;
        }

        public FrmPessoaPesquisa(Char tipoPessoa)
        {
            InitializeComponent();
            codPessoa = -1;
            filtroTipoPessoa = tipoPessoa;
            filtroNome = null;
        }

        public FrmPessoaPesquisa(String nomePessoa)
        {
            InitializeComponent();
            codPessoa = -1;
            filtroTipoPessoa = null;
            filtroNome = nomePessoa;
        }

        private void FrmPessoaPesquisa_Load(object sender, EventArgs e)
        {
            cmbBusca.SelectedIndex = 0;
            if (filtroNome != null) {
                txtTexto.Text = filtroNome;
                txtTexto.Select(filtroNome.Length+1, filtroNome.Length+1);
            } else if (filtroTipoPessoa != null) 
            {
                pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterPorTipoPessoa(filtroTipoPessoa.ToString());
            } else {
                pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            } 
         }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                    pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(long.Parse(txtTexto.Text));
                else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                    pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterPorCpfCnpj(txtTexto.Text);
                else if ((cmbBusca.SelectedIndex == 3) && !txtTexto.Text.Equals(""))
                    pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterPorEndereco(txtTexto.Text);
                else if ((cmbBusca.SelectedIndex == 4) && !txtTexto.Text.Equals(""))
                    pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterPorBairro(txtTexto.Text);         
                else
                    pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterPorNomeFantasia(txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_pessoaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codPessoa = int.Parse(tb_pessoaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmPessoaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_pessoaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                pessoaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                pessoaBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

    }
}
