using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using Dados.saceDataSetTableAdapters;
using MySql.Data.MySqlClient;
using Dados;
using Dominio;
using Negocio;
using Util;


namespace Telas
{
    public partial class FrmReceberPagamentoPessoa : Form
    {
        private EstadoFormulario estado;

        Pessoa pessoa;

        public FrmReceberPagamentoPessoa()
        {
            InitializeComponent();
        }

        private void FrmReceberPagamentoPessoa_Load(object sender, EventArgs e)
        {
            //GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.BANCOS, Principal.Autenticacao.CodUsuario);

            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_forma_pagamentoTableAdapter.Fill(this.saceDataSet.tb_forma_pagamento);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Telas.FrmReceberPagamentoPessoaPesquisa FrmReceberPagamentoPessoaPesquisa = new Telas.FrmReceberPagamentoPessoaPesquisa();
            //FrmReceberPagamentoPessoaPesquisa.ShowDialog();
            //if (FrmReceberPagamentoPessoaPesquisa.CodBanco != -1)
            //{
            //    tb_bancoBindingSource.Position = tb_bancoBindingSource.Find("codBanco", FrmReceberPagamentoPessoaPesquisa.CodBanco);
            //}
            //FrmReceberPagamentoPessoaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            //tb_bancoBindingSource.AddNew();
            codClienteComboBox.Focus();
            //codBancoTextBox.Enabled = false;
            //nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //tb_bancoBindingSource.CancelEdit();
            //tb_bancoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    BancoE banco = new BancoE();
            //    banco.codBanco = Int32.Parse(codBancoTextBox.Text);
            //    banco.nome = nomeTextBox.Text;

            //    IGerenciadorBanco gBanco = GerenciadorBanco.getInstace();
            //    if (estado.Equals(EstadoFormulario.INSERIR))
            //    {
            //        gBanco.inserir(banco);
            //        tb_bancoBindingSource.DataSource = GerenciadorBanco.getInstace().obterTodos();
            //        tb_bancoBindingSource.MoveLast();
            //    }
            //    else
            //    {
            //        gBanco.atualizar(banco);
            //        tb_bancoBindingSource.EndEdit();
            //    }
            //}
            //catch (DadosException de)
            //{
            //    tb_bancoBindingSource.CancelEdit();
            //    throw de;
            //}
            //finally
            //{
                habilitaBotoes(true);
                btnBuscar.Focus();
            //}
        }

        private void FrmReceberPagamentoPessoa_KeyDown(object sender, KeyEventArgs e)
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
                } else if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
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
            btnImprimir.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnCFNfe.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }


        private void codClienteComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codClienteComboBox_Leave(object sender, EventArgs e)
        {
            pessoa = GerenciadorPessoa.getInstace().obterPessoaNomeIgual(codClienteComboBox.Text);
            if (pessoa == null)
            {
                Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(codClienteComboBox.Text);
                frmPessoaPesquisa.ShowDialog();
                if (frmPessoaPesquisa.CodPessoa != -1)
                {
                    tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    codClienteComboBox.Text = ((Dados.saceDataSet.tb_pessoaRow)((DataRowView)tbpessoaBindingSource.Current).Row).nome;
                }
                else
                {
                    codClienteComboBox.Focus();
                }
                frmPessoaPesquisa.Dispose();
            }
            else
            {
                tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", pessoa.CodPessoa);
                buscarContas();
            }
        }

        private void buscarContas()
        {
            String situacao1  = abertaCheckBox.Checked ? "A": "";
            String situacao2 = abertaCheckBox.Checked ? "P": "";
            String situacao3 = quitadaCheckBox.Checked ? "Q": "";

            //this.saceDataSetConsultas.ContasPessoa contasDT = new this.saceDataSetConsultas.ContasPessoa ();

            //DataRow[] rows = this.saceDataSetConsultas.ContasPessoa.Where(("(codPessoa =" + pessoa.CodPessoa + ")");// AND (codSituacao in ('A'))");


            //int resultado = rows.Count();

            //Console.WriteLine(resultado);
            //this.contasPessoaTableAdapter.Fill(this.saceDataSetConsultas.ContasPessoa);
            
            //DataRow[] rows = contasDT.Select
           //contasPessoaDataGridView.Rows = rows;

            //DataGridViewRow row = new DataGridViewRow(

            //

            
            
            //this.contasPessoaTableAdapter.Fill(this.saceDataSetConsultas.ContasPessoa);

            calcularTotalContas();
        }



        private string obterListaSituacao()
        {
            if (abertaCheckBox.Checked && quitadaCheckBox.Checked)
                return Conta.SITUACAO_ABERTA + "," + Conta.SITUACAO_PARCIALMENTE_QUITADA + "," + Conta.SITUACAO_QUITADA;
            else if (abertaCheckBox.Checked)
                return Conta.SITUACAO_ABERTA + "," + Conta.SITUACAO_PARCIALMENTE_QUITADA;
            else if (quitadaCheckBox.Checked)
                return Conta.SITUACAO_QUITADA.ToString();
            else
                return "";
        }
        private void calcularTotalContas()
        {
            decimal total = 0;
            for (int i = 0; i < contasPessoaDataGridView.RowCount; i++) { 
                total += Convert.ToDecimal(contasPessoaDataGridView.Rows[i].Cells[5].Value.ToString());
            }

            totalContasTextBox.Text = total.ToString("N2");
        }


    }
}
