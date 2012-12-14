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
using Util;

namespace Telas
{
    public partial class FrmPessoa : Form
    {
        private EstadoFormulario estado;
        public Int32 CodPessoa { get; set; }

        public FrmPessoa()
        {
            InitializeComponent();
        }

        private void FrmPessoa_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.PESSOAS, Principal.Autenticacao.CodUsuario);
            pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            if (!codPessoaTextBox.Text.Trim().Equals(""))
                contatosBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterContatos(long.Parse(codPessoaTextBox.Text));
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
            frmPessoaPesquisa.ShowDialog();
            if (frmPessoaPesquisa.CodPessoa != -1)
            {
                Pessoa pessoa = GerenciadorPessoa.GetInstance().Obter(frmPessoaPesquisa.CodPessoa).ElementAt(0);
                pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(pessoa);
            }
            frmPessoaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            pessoaBindingSource.AddNew();
            codPessoaTextBox.Enabled = false;
            cidadeTextBox.Text = "ARACAJU";
            ufTextBox.Text = "SE";
            limiteCompraTextBox.Text = "0";
            valorComissaoTextBox.Text = "0";
            ehFabricanteCheckBox.Checked = false;
            imprimirCFCheckBox.Checked = false;
            imprimirDAVCheckBox.Checked = true;
            PfRadioButton.Select();
            nomeFantasiaTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nomeFantasiaTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorPessoa.GetInstance().Remover(Int64.Parse(codPessoaTextBox.Text));
                pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pessoaBindingSource.CancelEdit();
            pessoaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa _pessoa = new Pessoa();
            _pessoa.CodPessoa = Int64.Parse(codPessoaTextBox.Text);
            _pessoa.Nome = nomeTextBox.Text;
            _pessoa.NomeFantasia = nomeFantasiaTextBox.Text;
            _pessoa.Complemento = complementoTextBox.Text;
            _pessoa.Bairro = bairroTextBox.Text;
            _pessoa.Cep = cepMaskedTextBox.Text;
            _pessoa.Cidade = cidadeTextBox.Text;
            _pessoa.Email = emailTextBox.Text;
            _pessoa.IeSubstituto = ieSubstitutoTextBox.Text;
            _pessoa.Numero = numeroTextBox.Text;
            _pessoa.CpfCnpj = cpf_CnpjTextBox.Text;
            _pessoa.Endereco = enderecoTextBox.Text;
            _pessoa.Fone1 = fone1MaskedTextBox.Text;
            _pessoa.Fone2 = fone2MaskedTextBox.Text;
            _pessoa.Fone3 = fone3TextBox.Text;
            _pessoa.Ie = ieTextBox.Text;
            _pessoa.LimiteCompra = (limiteCompraTextBox.Text=="")?0:Decimal.Parse(limiteCompraTextBox.Text);
            _pessoa.Observacao = observacaoTextBox.Text;
            _pessoa.Tipo = PfRadioButton.Checked ? "F" : "J";
            _pessoa.Uf = ufTextBox.Text;
            _pessoa.ValorComissao = (valorComissaoTextBox.Text=="")?0:Decimal.Parse(valorComissaoTextBox.Text);
            _pessoa.EhFabricante = ehFabricanteCheckBox.Checked;
            _pessoa.ImprimirCF = imprimirCFCheckBox.Checked;
            _pessoa.ImprimirDAV = imprimirDAVCheckBox.Checked;

            GerenciadorPessoa gPessoa = GerenciadorPessoa.GetInstance();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                gPessoa.Inserir(_pessoa);
                pessoaBindingSource.DataSource = gPessoa.ObterTodos();
                pessoaBindingSource.MoveLast();
            }
            else
            {
                gPessoa.Atualizar(_pessoa);
                pessoaBindingSource.EndEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void excluirContato(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão do contato?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_contato_empresaDataGridView.Rows.Count > 0)
                {
                    ContatoPessoa cp = new ContatoPessoa();
                    cp.CodPessoaContato = long.Parse(tb_contato_empresaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    cp.CodPessoa = long.Parse(codPessoaTextBox.Text);
                    GerenciadorPessoa.GetInstance().RemoverContato(cp);
                }
            }

            contatosBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(long.Parse(codPessoaTextBox.Text));
        }

        private void pessoaBindingSource_PositionChanged(object sender, EventArgs e)
        {
            Pessoa pessoa = (Pessoa) pessoaBindingSource.Current;
            bool tipoCliente = false;
            if (pessoa.CodPessoa > 0)
                tipoCliente = pessoa.Tipo.Equals(Pessoa.PESSOA_FISICA);
            if (tipoCliente)
            {
                PfRadioButton.Checked = true;
                PjRadioButton.Checked = false;
            }
            else
            {
                PfRadioButton.Checked = false;
                PjRadioButton.Checked = true;
            }
        }

        private void codPessoaTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((codPessoaTextBox.Text != null) && (codPessoaTextBox.Text != ""))
                contatosBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterContatos(long.Parse(codPessoaTextBox.Text));
        }

        private void btnAdicionarContato_Click(object sender, EventArgs e)
        {
            Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
            frmPessoaPesquisa.ShowDialog();
            if (frmPessoaPesquisa.CodPessoa != -1)
            {
                ContatoPessoa contatoPessoa = new ContatoPessoa();
                contatoPessoa.CodPessoa = Int64.Parse(codPessoaTextBox.Text);
                contatoPessoa.CodPessoaContato = frmPessoaPesquisa.CodPessoa;

                GerenciadorPessoa.GetInstance().InserirContato(contatoPessoa);
                contatosBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterContatos(long.Parse(codPessoaTextBox.Text));
            }
            frmPessoaPesquisa.Dispose();
        }


        private void FrmPessoa_KeyDown(object sender, KeyEventArgs e)
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
                else if (e.KeyCode == Keys.F7)
                {
                    btnAdicionarContato_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    pessoaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    pessoaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    pessoaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    pessoaBindingSource.MoveNext();
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
                }
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
            }
            // Coloca o foco na grid caso ela não possua
            if (e.KeyCode == Keys.F12)
            {
                tb_contato_empresaDataGridView.Focus();

            }
            // permite excluir um contato quando o foco está na grid
            else if ((e.KeyCode == Keys.Delete) && (tb_contato_empresaDataGridView.Focused == true))
            {
                excluirContato(sender, e);
            }
        }

        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            btnAdicionarContato.Enabled = habilita;
            tb_pessoaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmPessoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            CodPessoa = Int32.Parse(codPessoaTextBox.Text);
        }

        private void limiteCompraTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
        }

        private void nomeFantasiaTextBox_Leave(object sender, EventArgs e)
        {
            if (nomeTextBox.Text.Trim().Equals(""))
            {
                nomeTextBox.Text = nomeFantasiaTextBox.Text;
            }
        }
    }
}
