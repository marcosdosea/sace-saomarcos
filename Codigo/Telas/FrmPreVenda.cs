using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Telas;

namespace SACE.Telas
{
    public partial class FrmPreVenda : Form
    {
        private EstadoFormulario estado;        

        public FrmPreVenda()
        {
            InitializeComponent();
        }

        private void FrmPreVenda_Load(object sender, EventArgs e)
        {
            Seguranca.GetInstancia().verificaPermissao(this, Funcoes.PREVENDA, Principal.Autenticacao.CodUsuario);

            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmSaidaPesquisa frmSaidaPesquisa = new FrmSaidaPesquisa();            
            frmSaidaPesquisa.ShowDialog();
            //if (frmProdutoPesquisa.getCodProduto() != -1)
            //{
            //    tb_saida_produtoBindingSource.MoveFirst();
            //}
            //Telas.FrmPreVendaPesquisa frmPreVendaPesquisa = new Telas.FrmPreVendaPesquisa();
            //frmPreVendaPesquisa.ShowDialog();
            //if (frmPreVendaPesquisa.getCodPreVenda() != -1)
            //{
            //    tb_bancoBindingSource.MoveFirst();
            //    while (!codPreVendaTextBox.Text.Equals(frmPreVendaPesquisa.getCodPreVenda().ToString()))
            //    {
            //        tb_bancoBindingSource.MoveNext();
            //    }
            //}
            frmSaidaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_saidaBindingSource.AddNew();
            tb_saidaTableAdapter.Insert(DateTime.Now, "P", 1, null, null, "", "0,0", "0,0", "0,0", "0,0");
            tb_saida_produtoBindingSource.AddNew();
            produtoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //tb_bancoTableAdapter.Delete(int.Parse(codPreVendaTextBox.Text));
                    //tb_bancoTableAdapter.Fill(saceDataSet.tb_banco);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
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
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    //tb_bancoTableAdapter.Insert(nomeTextBox.Text);
                    //tb_bancoTableAdapter.Fill(saceDataSet.tb_banco);
                    //tb_bancoBindingSource.MoveLast();
                }
                else
                {
                    //tb_bancoTableAdapter.Update(nomeTextBox.Text, int.Parse(codPreVendaTextBox.Text));
                    //tb_bancoBindingSource.EndEdit();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void FrmPreVenda_KeyDown(object sender, KeyEventArgs e)
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
                    //tb_bancoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    //tb_bancoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    //tb_bancoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    //tb_bancoBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
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
            btnInsereProduto.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            //tb_bancoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void tb_bancoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.tb_bancoBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.saceDataSet);

        }

        private void insereProdutoButton_Click(object sender, EventArgs e)
        {
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                DataTable dt = tb_produtoTableAdapter.GetDataBycodigoBarra(produtoTextBox.Text);
                if (dt.Rows.Count > 0)
                {
                    //TODO codSaida!
                    tb_saida_produtoTableAdapter.Insert(dt.Rows[0].Field<long>("codProduto"),
                        1, quantidadeTextBox.Text, dt.Rows[0].Field<Decimal>("precoVendaVarejo").ToString(),
                        null, null);
                    tb_saida_produtoTableAdapter.Fill(saceDataSet.tb_saida_produto);
                    tb_saida_produtoBindingSource.MoveLast();
                }
                if (rbtPreVenda.Checked)
                {
                    tb_produtoTableAdapter.UpdateQuantidade(dt.Rows[0].Field<Decimal>("qtdProdutoAtacado"), produtoTextBox.Text);
                }
            }
        }

        private void produtoTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = tb_produtoTableAdapter.GetDataBycodigoBarra(produtoTextBox.Text);            
            if (dt.Rows.Count > 0)
            {
                precoTextBox.Text = dt.Rows[0].Field<Decimal>("precoVendaVarejo").ToString();
                nomeProdutoLabel.Text = dt.Rows[0].Field<String>("nome");
            }
        }

        private void quantidadeTextBox_TextChanged(object sender, EventArgs e)
        {
            qtdProdutoLabel.Text = quantidadeTextBox.Text;
        }
    }
}
