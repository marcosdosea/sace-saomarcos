using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;

namespace Telas
{
    public partial class FrmProdutoPesquisaPreco : Form
    {
        private Int32 codProduto;
        private String filtroNome;
        private String textoAtual;
        private DateTime horaUltimaDigitacao;

        public bool ExibirTodos { get; set;}

        public Int32 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }

        public FrmProdutoPesquisaPreco(bool exibirTodos)
        {
            InitializeComponent();
            codProduto = -1;
            filtroNome = null;
            ExibirTodos = exibirTodos;
        }

        public FrmProdutoPesquisaPreco(String nome, bool exibirTodos)
        {
            InitializeComponent();
            codProduto = -1;
            filtroNome = nome;
            ExibirTodos = exibirTodos;
        }

        private void FrmProdutoPesquisaPreco_Load(object sender, EventArgs e)
        {
            cmbBusca.SelectedIndex = 0;

            if ((filtroNome != null) && (filtroNome.Length > 0))
            {
                textoAtual = filtroNome;
                txtTexto.Text = filtroNome;
                txtTexto.Select(filtroNome.Length + 1, filtroNome.Length + 1);
                if (ExibirTodos)
                {
                    this.tb_produtoTableAdapter.FillByNomeTodos(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO, txtTexto.Text);
                }
                else
                {
                    this.tb_produtoTableAdapter.FillByNome(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO, txtTexto.Text);
                }
            }
            else
            {
                textoAtual = "";
            }
           
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if ((txtTexto.Text.Trim().Length > 0) && (txtTexto.Text.Length > textoAtual.Length))
            {
                if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                    this.tb_produtoTableAdapter.FillByCodProduto(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO, int.Parse(txtTexto.Text));
                else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                {
                    this.tb_produtoTableAdapter.FillByReferenciaFabricante(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO, txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 3) && !txtTexto.Text.Equals(""))
                {
                    this.tb_produtoTableAdapter.FillByNomeProdutoFabricante(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO, txtTexto.Text);
                }
                else if ((cmbBusca.SelectedIndex == 4) && (txtTexto.Text.Length > 9))
                {
                    try
                    {
                        DateTime data = Convert.ToDateTime(txtTexto.Text);
                        // se conseguir converter para uma data válida ele faz a busca
                        this.tb_produtoTableAdapter.FillByDataAtualizacao(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO, data);
                    }
                    catch (Exception)
                    {
                        // qualquer problema a busca não é realizada
                    }

                }
                else
                {
                    if (ExibirTodos)
                    {
                        if ((!txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length > 2)) || (txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length > 3)))
                        {
                            this.tb_produtoTableAdapter.FillByNomeTodos(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO, txtTexto.Text);
                        }
                    }
                    else
                    {
                        if ( !txtTexto.Text.StartsWith("%") || (txtTexto.Text.StartsWith("%") && (txtTexto.Text.Length > 3)))  {
                            this.tb_produtoTableAdapter.FillByNome(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO, txtTexto.Text);
                        }
                    }
                }
            }
            textoAtual = txtTexto.Text;
            Cursor.Current = Cursors.Default;
        }

        private void tb_produtoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codProduto = -1;
            if (tb_produtoDataGridView.RowCount > 0)
            {
                codProduto = int.Parse(tb_produtoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            this.Close();
        }

        private void FrmProdutoPesquisaPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_produtoDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_produtoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_produtoBindingSource.MovePrevious();
            }
            else if ((e.KeyCode == Keys.PageDown) && (txtTexto.Focused))
            {
                tb_produtoBindingSource.Position += 15;
            }
            else if ((e.KeyCode == Keys.PageUp) && (txtTexto.Focused))
            {
                tb_produtoBindingSource.Position -= 15;
            }
        }

        public Int32 getCodProduto()
        {
            return codProduto;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            // coluna do nome
            tb_produtoDataGridView.Columns[1].Visible = true;
            // coluna do nome conforme fabricante
            tb_produtoDataGridView.Columns[2].Visible = false;
                
            if (cmbBusca.SelectedIndex == 0)
            {
                label2.Text = "Descrição do Produto";
            }
            else if (cmbBusca.SelectedIndex == 1)
            {
                label2.Text = "Código do Produto:";
            }
            else if (cmbBusca.SelectedIndex == 2)
            {
                label2.Text = "Referência do Fabricante:";
            
            }
            else if (cmbBusca.SelectedIndex == 3)
            {
                label2.Text = "Nome do Produto conforme Fabricante:";
                // coluna do nome
                tb_produtoDataGridView.Columns[1].Visible = false;
                // coluna do nome conforme fabricante
                tb_produtoDataGridView.Columns[2].Visible = true;
            }
            else if (cmbBusca.SelectedIndex == 4)
            {
                label2.Text = "Data de Atualizacão Maior que (aaaa-mm-dd):";
            }
            txtTexto.Text = "";
        }

        private void tb_produtoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_produtoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.saceDataSet);

        }

        private void tb_produtoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
