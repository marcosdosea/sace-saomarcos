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
        private Int32 codProduto;

        public Int32 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }


        public FrmProdutoAjusteEstoque(Int32 codProduto)
        {
            InitializeComponent();
            this.codProduto = codProduto;
        }

        private void FrmProdutoAjusteEstoque_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.GRUPOS_DE_PRODUTOS, Principal.Autenticacao.CodUsuario);
            this.tb_lojaTableAdapter.Fill(this.saceDataSet.tb_loja);
            this.tb_produto_lojaTableAdapter.FillByCodProduto(this.saceDataSet.tb_produto_loja, codProduto);
            habilitaBotoes(true);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            String nomeProduto = nomeProdutoTextBox.Text;
            tb_produto_lojaBindingSource.AddNew();
            habilitaBotoes(false);
            codProdutoTextBox.Text = codProduto.ToString();
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
            tb_produto_lojaBindingSource.CancelEdit();
            tb_produto_lojaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnEditar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoLoja produtoLoja = new ProdutoLoja();
                produtoLoja.CodProduto = codProduto;
                produtoLoja.CodLoja = Int32.Parse(codLojaComboBox.SelectedValue.ToString());
                produtoLoja.QtdEstoque = decimal.Parse(qtdEstoqueTextBox.Text);
                produtoLoja.QtdEstoqueAux = decimal.Parse(qtdEstoqueAuxTextBox.Text);
                produtoLoja.Localizacao = localizacaoTextBox.Text;

                
                IGerenciadorProdutoLoja gProdutoLoja = GerenciadorProdutoLoja.getInstace();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gProdutoLoja.inserir(produtoLoja);
                    tb_produto_lojaTableAdapter.FillByCodProduto(saceDataSet.tb_produto_loja, codProduto);
                    tb_produto_lojaBindingSource.MoveLast();
                }
                else
                {
                    gProdutoLoja.atualizar(produtoLoja);
                    tb_produto_lojaBindingSource.EndEdit();
                }
            }
            catch (DadosException de)
            {
                tb_produto_lojaBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnEditar.Focus();
            }
        }

        private void FrmProdutoAjusteEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_produto_lojaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_produto_lojaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_produto_lojaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_produto_lojaBindingSource.MoveNext();
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
    }
}
