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
        private int codProduto;
        private int codSaida;

        public FrmPreVenda()
        {
            InitializeComponent();
        }

        private void FrmPreVenda_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.GetInstancia().verificaPermissao(this, Funcoes.PREVENDA, Principal.Autenticacao.CodUsuario);
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
            //alterar tipo de entrada...
            tb_saidaTableAdapter.Insert(DateTime.Now, "P", 1, null, null, "", "0,0", "0,0", "0,0", "0,0");

            //TODO alterar como saida é obtida!
            DataTable dt = tb_saidaTableAdapter.GetData();
            
            codSaida = (int)dt.Rows[(dt.Rows.Count - 1)].Field<Int64>("codSaida");
            codSaidaLabel.Text = codSaida.ToString();
            volumesLabel.Text = "0";
            totalLabel.Text = "0,0";
            aVistaLabel.Text = "0,0";

            tb_saidaTableAdapter.Fill(saceDataSet.tb_saida);
            //tb_saida_produtoBindingSource.AddNew();
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
            tb_saidaTableAdapter.UpdateQuerySaida(rbtPreVenda.Checked ? "P" : "O", decimal.Parse(totalLabel.Text), 0, decimal.Parse(aVistaLabel.Text), 0, codSaida);
            tb_saidaTableAdapter.Fill(saceDataSet.tb_saida);                    
            
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
                codProduto = int.Parse(produtoTextBox.Text);
                DataTable dtPRodutoInserido = tb_produtoTableAdapter.GetDataBycodProduto(codProduto);
                double qtdProdutos = double.Parse(quantidadeTextBox.Text);
                if (dtPRodutoInserido.Rows.Count > 0)
                {
                    DataTable dtProdutosInseridos = tb_saida_produtoTableAdapter.GetDataBycodProdutocodSaida(
                        dtPRodutoInserido.Rows[0].Field<long>("codProduto"), codSaida);
                    if (dtProdutosInseridos.Rows.Count > 0)
                    {
                        qtdProdutos += (double)dtProdutosInseridos.Rows[0].Field<decimal>("quantidade");
                        
                        tb_saida_produtoTableAdapter.UpdateProduto((decimal)qtdProdutos, null, null, null,
                            dtProdutosInseridos.Rows[0].Field<long>("codProduto"), codSaida);
                        tb_saida_produtoTableAdapter.FillByCodSaida(saceDataSet.tb_saida_produto, codSaida);
                        tb_saida_produtoBindingSource.MoveLast();
                    }
                    else
                    {
                        tb_saida_produtoTableAdapter.Insert(dtPRodutoInserido.Rows[0].Field<long>("codProduto"),
                            codSaida, qtdProdutos.ToString(),
                            ((double)dtPRodutoInserido.Rows[0].Field<Decimal>("precoVendaVarejo") * qtdProdutos).ToString(),
                            "0", ((double)dtPRodutoInserido.Rows[0].Field<Decimal>("precoVendaVarejo") * qtdProdutos).ToString());

                        tb_saida_produtoTableAdapter.FillByCodSaida(saceDataSet.tb_saida_produto, codSaida);
                        tb_saida_produtoBindingSource.MoveLast();
                        volumesLabel.Text = tb_saida_produtoTableAdapter.GetDataByCodSaida(codSaida).Rows.Count.ToString();
                    }
                }
                //if (rbtPreVenda.Checked)
                //{
                //    decimal qtdProduto = decimal.Parse(tb_produtoTableAdapter.ScalarQueryQtdProduto(codBarras).ToString());
                //    tb_produtoTableAdapter.UpdateQuantidade(dtPRodutoInserido.Rows[0].Field<Decimal>("qtdProdutoAtacado") + qtdProduto, produtoTextBox.Text);
                //}
                DataTable dtProdutosVenda = tb_saida_produtoTableAdapter.GetDataByCodSaida(codSaida);
                double valorTotal = 0;
                double subTotal = 0;
                
                foreach (DataRow linha in dtProdutosVenda.Rows)
                {
                    valorTotal += (double)linha.Field<Decimal>("valorVenda");
                    subTotal += (double)linha.Field<Decimal>("subtotal");
                }
                totalLabel.Text = "";
                aVistaLabel.Text = "";
                totalLabel.Text = valorTotal.ToString();
                aVistaLabel.Text = subTotal.ToString();

                produtoTextBox.Clear();
                quantidadeTextBox.Clear();
                produtoTextBox.Focus();
            }
        }        

        private void quantidadeTextBox_TextChanged(object sender, EventArgs e)
        {
            qtdProdutoLabel.Text = quantidadeTextBox.Text;
        }

        private void rbtPreVenda_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                DataTable dt = tb_saida_produtoTableAdapter.GetDataByCodSaida(codSaida);

                foreach (DataRow linha in dt.Rows)
                {
                    decimal qtdProduto = decimal.Parse(tb_produtoTableAdapter.ScalarQueryQtdProduto(codProduto).ToString());
                    tb_produtoTableAdapter.UpdateQuantidade(decimal.Parse(linha["qtdProdutoAtacado"].ToString()), codProduto);
                }
            }
        }

        private void produtoTextBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(produtoTextBox.Text))
            {
                DataTable dt = tb_produtoTableAdapter.GetDataBycodProduto(int.Parse(produtoTextBox.Text));
                if (dt.Rows.Count > 0)
                {
                    precoTextBox.Text = dt.Rows[0].Field<Decimal>("precoVendaVarejo").ToString();
                    nomeProdutoLabel.Text = dt.Rows[0].Field<String>("nome");
                }
                else
                {
                    produtoTextBox.Focus();
                    MessageBox.Show("Produto não encontrado!");
                }
            }            
        }       
    }
}
