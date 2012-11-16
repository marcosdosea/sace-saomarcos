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
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            if (!codPessoaTextBox.Text.Trim().Equals(""))
                this.tb_contato_empresaTableAdapter1.FillByCodEmpresa(saceDataSet.tb_contato_empresa, Int64.Parse(codPessoaTextBox.Text));
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
            frmPessoaPesquisa.ShowDialog();
            if (frmPessoaPesquisa.CodPessoa != -1)
            {
                tb_pessoaBindingSource.Position = tb_pessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
            }
            frmPessoaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_pessoaBindingSource.AddNew();
            codPessoaTextBox.Enabled = false;
            cidadeTextBox.Text = "ARACAJU";
            ufTextBox.Text = "SE";
            limiteCompraTextBox.Text = "0";
            valorComissaoTextBox.Text = "0";
            ehFabricanteCheckBox.Checked = false;
            imprimirCFCheckBox.Checked = false;
            imprimirDAVCheckBox.Checked = true;
            PfRadioButton.Select();
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorPessoa.getInstace().remover(Int64.Parse(codPessoaTextBox.Text));
                tb_pessoaTableAdapter.Fill(saceDataSet.tb_pessoa);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_pessoaBindingSource.CancelEdit();
            tb_pessoaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.CodPessoa = Int64.Parse(codPessoaTextBox.Text);
            pessoa.Nome = nomeTextBox.Text;
            pessoa.Complemento = complementoTextBox.Text;
            pessoa.Bairro = bairroTextBox.Text;
            pessoa.Cep = cepMaskedTextBox.Text;
            pessoa.Cidade = cidadeTextBox.Text;
            pessoa.Email = emailTextBox.Text;
            pessoa.IeSubstituto = ieSubstitutoTextBox.Text;
            pessoa.Numero = numeroTextBox.Text;
            pessoa.CpfCnpj = cpf_CnpjTextBox.Text;
            pessoa.Endereco = enderecoTextBox.Text;
            pessoa.Fone1 = fone1MaskedTextBox.Text;
            pessoa.Fone2 = fone2MaskedTextBox.Text;
            pessoa.Fone3 = fone3TextBox.Text;
            pessoa.Ie = ieTextBox.Text;
            pessoa.LimiteCompra = (limiteCompraTextBox.Text=="")?0:Decimal.Parse(limiteCompraTextBox.Text);
            pessoa.Observacao = observacaoTextBox.Text;
            pessoa.Tipo = PfRadioButton.Checked ? 'F' : 'J';
            pessoa.Uf = ufTextBox.Text;
            pessoa.ValorComissao = (valorComissaoTextBox.Text=="")?0:Decimal.Parse(valorComissaoTextBox.Text);
            pessoa.EhFabricante = ehFabricanteCheckBox.Checked;
            pessoa.ImprimirCF = imprimirCFCheckBox.Checked;
            pessoa.ImprimirDAV = imprimirDAVCheckBox.Checked;

            GerenciadorPessoa gPessoa = GerenciadorPessoa.getInstace();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                gPessoa.inserir(pessoa);
                tb_pessoaTableAdapter.Fill(saceDataSet.tb_pessoa);
                tb_pessoaBindingSource.MoveLast();
            }
            else
            {
                gPessoa.atualizar(pessoa);
                tb_pessoaBindingSource.EndEdit();
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
                    cp.CodPessoaContato = long.Parse(tb_contato_empresaDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                    cp.CodPessoa = long.Parse(codPessoaTextBox.Text);
                    GerenciadorContatoPessoa.getInstace().remover(cp);
                }
            }

            tb_contato_empresaTableAdapter1.FillByCodEmpresa(this.saceDataSet.tb_contato_empresa, long.Parse(codPessoaTextBox.Text));
        }

        private void tb_pessoaBindingSource_PositionChanged(object sender, EventArgs e)
        {
            DataRowView linha = (DataRowView)tb_pessoaBindingSource.Current;
            bool tipoCliente = false;
            if (linha != null)
                tipoCliente = linha["Tipo"].ToString().Equals("F");
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
                this.tb_contato_empresaTableAdapter1.FillByCodEmpresa(saceDataSet.tb_contato_empresa, Int64.Parse(codPessoaTextBox.Text));
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

                GerenciadorContatoPessoa.getInstace().inserir(contatoPessoa);

                tb_contato_empresaTableAdapter1.FillByCodEmpresa(saceDataSet.tb_contato_empresa, Int64.Parse(codPessoaTextBox.Text));
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
                    tb_pessoaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_pessoaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_pessoaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_pessoaBindingSource.MoveNext();
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
    }
}
