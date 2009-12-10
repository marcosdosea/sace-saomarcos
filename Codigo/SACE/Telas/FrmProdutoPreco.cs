using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SACE.Telas
{
    public partial class FrmProdutoPreco : Form
    {
        private EstadoFormulario estado;
        private long? codProduto = null;

        public FrmProdutoPreco()
        {
            InitializeComponent();
        }

        public FrmProdutoPreco(long codProduto)
        {
            InitializeComponent();
            this.codProduto = codProduto;
        }

        private void FrmCalcularPreco_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_produto' table. You can move, or remove it, as needed.
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            if (codProduto != null)
                tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", codProduto);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmProdutoPesquisa frmProdutoPesquisa = new Telas.FrmProdutoPesquisa();
            frmProdutoPesquisa.ShowDialog();
            if (frmProdutoPesquisa.getCodProduto() != -1)
            {
                tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", frmProdutoPesquisa.getCodProduto());
            }
            frmProdutoPesquisa.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            novoPrecoVarejoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            ipiTextBox.Focus();
            habilitaBotoes(false);
            habilitaTextBox(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                       
                tb_produtoTableAdapter.UpdatePrecos(decimal.Parse(icmsTextBox.Text), decimal.Parse(simplesTextBox.Text),
                     decimal.Parse(ipiTextBox.Text), decimal.Parse(freteTextBox.Text), decimal.Parse(custoVendaTextBox.Text), decimal.Parse("0"),
                     DateTime.Now, decimal.Parse(lucroPrecoVendaVarejoTextBox.Text),
                     decimal.Parse(novoPrecoVarejoTextBox.Text), decimal.Parse(lucroPrecoVendaAtacadoTextBox.Text),
                     decimal.Parse(novoPrecoAtacadoTextBox.Text), decimal.Parse(lucroPrecoVendaSuperAtacadoTextBox.Text),
                     decimal.Parse(novoPrecoSuperTextBox.Text), long.Parse(codProdutoTextBox.Text));
                 tb_produtoBindingSource.EndEdit();
                
            }
            catch (Exception exc)
            {   
                MessageBox.Show(exc.Message);
                tb_produtoBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            habilitaTextBox(true);
            btnBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_produtoBindingSource.CancelEdit();
            tb_produtoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void habilitaBotoes(Boolean habilita)
        {
            btnBuscar.Enabled = habilita;
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnAjustar.Enabled = habilita;
            tb_produtoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void habilitaTextBox(Boolean habilita)
        {
            ipiTextBox.ReadOnly = habilita;
            ipiTextBox.TabStop = habilita;
            custoVendaTextBox.ReadOnly = habilita;
            custoVendaTextBox.TabStop = habilita;
            icmsTextBox.ReadOnly = habilita;
            icmsTextBox.TabStop = habilita;
            simplesTextBox.ReadOnly = habilita;
            simplesTextBox.TabStop = habilita;
            freteTextBox.ReadOnly = habilita;
            freteTextBox.TabStop = habilita;
            lucroPrecoVendaAtacadoTextBox.ReadOnly = habilita;
            lucroPrecoVendaAtacadoTextBox.TabStop = habilita;
            lucroPrecoVendaSuperAtacadoTextBox.ReadOnly = habilita;
            lucroPrecoVendaSuperAtacadoTextBox.TabStop = habilita;
            lucroPrecoVendaVarejoTextBox.ReadOnly = habilita;
            lucroPrecoVendaVarejoTextBox.TabStop = habilita;
        }

        private void FrmProdutoPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnAjustar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_produtoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_produtoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_produtoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_produtoBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
            }
        }
    }
}
