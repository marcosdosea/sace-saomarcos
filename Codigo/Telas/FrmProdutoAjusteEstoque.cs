using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Dados;
using Util;

namespace Telas
{
    public partial class FrmProdutoAjusteEstoque : Form
    {
        private EstadoFormulario estado;
        public ProdutoPesquisa ProdutoSelected { get; set; }

        public FrmProdutoAjusteEstoque(ProdutoPesquisa _produto)
        {
            InitializeComponent();
            ProdutoSelected = _produto;
        }

        private void FrmProdutoAjusteEstoque_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.GRUPOS_DE_PRODUTOS, Principal.Autenticacao.CodUsuario);
            lojaBindingSource.DataSource = GerenciadorLoja.GetInstance().ObterTodos();
            produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.GetInstance(null).ObterPorProduto(ProdutoSelected.CodProduto);
            habilitaBotoes(true);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            String nomeProduto = nomeProdutoTextBox.Text;
            produtoLojaBindingSource.AddNew();
            habilitaBotoes(false);
            codProdutoTextBox.Text = ProdutoSelected.CodProduto.ToString();
            nomeProdutoTextBox.Text = nomeProduto;
            codLojaComboBox.Focus();
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            qtdEstoqueTextBox.Focus();
            habilitaBotoes(false);
            codLojaComboBox.Enabled = false;
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //CodProduto = Convert.ToInt32(codProdutoTextBox.Text);
            produtoLojaBindingSource.CancelEdit();
            produtoLojaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnEditar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoLoja produtoLoja = new ProdutoLoja();
                produtoLoja.CodProduto = ProdutoSelected.CodProduto;
                produtoLoja.CodLoja = Int32.Parse(codLojaComboBox.SelectedValue.ToString());
                produtoLoja.QtdEstoque = decimal.Parse(qtdEstoqueTextBox.Text);
                produtoLoja.QtdEstoqueAux = decimal.Parse(qtdEstoqueAuxTextBox.Text);
                produtoLoja.EstoqueMaximo = decimal.Parse(estoqueMaximoTextBox.Text);
                produtoLoja.Localizacao = localizacaoTextBox.Text;
                produtoLoja.Localizacao2 = localizacao2TextBox.Text;

                
                GerenciadorProdutoLoja gProdutoLoja = GerenciadorProdutoLoja.GetInstance(null);
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gProdutoLoja.Inserir(produtoLoja);
                    produtoLojaBindingSource.DataSource = gProdutoLoja.ObterPorProduto(ProdutoSelected.CodProduto);
                    produtoLojaBindingSource.MoveLast();
                }
                else
                {
                    gProdutoLoja.Atualizar(produtoLoja);
                    produtoLojaBindingSource.EndEdit();
                }
            }
            catch (DadosException de)
            {
                produtoLojaBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmProdutoAjusteEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    produtoLojaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    produtoLojaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    produtoLojaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    produtoLojaBindingSource.MoveNext();
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
            btnBuscar.Enabled = habilita;
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            tb_produto_lojaBindingNavigator.Enabled = habilita;
            codLojaComboBox.Enabled = !(habilita);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void localizacaoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codProdutoTextBox_Enter(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS;
            }
        }

        private void codProdutoTextBox_Leave(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS_LEAVE;
            }
        }

        private void qtdEstoqueTextBox_Leave(object sender, EventArgs e)
        {
            codProdutoTextBox_Leave(sender, e);
            Util.FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmProdutoPesquisaPreco frmProdutoPesquisa = new Telas.FrmProdutoPesquisaPreco(true);
            frmProdutoPesquisa.ShowDialog();
            if (frmProdutoPesquisa.ProdutoPesquisa != null)
            {
                nomeProdutoTextBox.Text = frmProdutoPesquisa.ProdutoPesquisa.Nome;
                codProdutoTextBox.Text = frmProdutoPesquisa.ProdutoPesquisa.CodProduto.ToString();
                produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.GetInstance(null).ObterPorProduto(frmProdutoPesquisa.ProdutoPesquisa.CodProduto);
                ProdutoSelected = frmProdutoPesquisa.ProdutoPesquisa;
                habilitaBotoes(true);
            }
            frmProdutoPesquisa.Dispose();
            btnEditar.Focus();
        }

        private void FrmProdutoAjusteEstoque_Shown(object sender, EventArgs e)
        {
            btnEditar.Focus();
        }
    }
}
