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
using Dados;
using Microsoft.EntityFrameworkCore;

namespace Sace
{
    public partial class FrmPessoa : Form
    {
        private EstadoFormulario estado;
        public Pessoa PessoaSelected { get; set; }
        private Loja loja;
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;


        public FrmPessoa(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            var context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmPessoa_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pessoaBindingSource.DataSource = service.GerenciadorPessoa.ObterTodos();
            municipiosIBGEBindingSource.DataSource = service.GerenciadorMunicipio.ObterTodos();
            loja = service.GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAtOrDefault(0);
            if (!codPessoaTextBox.Text.Trim().Equals(""))
                contatosBindingSource.DataSource = service.GerenciadorPessoa.ObterContatos(long.Parse(codPessoaTextBox.Text));
            habilitaBotoes(true);
            Cursor.Current = Cursors.Default;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmPessoaPesquisa frmPessoaPesquisa = new FrmPessoaPesquisa(saceOptions);
            frmPessoaPesquisa.ShowDialog();
            if (frmPessoaPesquisa.PessoaSelected != null)
            {
                pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
            }
            frmPessoaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = (Pessoa) pessoaBindingSource.AddNew();
            pessoa.EhFabricante = false;
            pessoa.ImprimirCF = false;
            pessoa.ImprimirDAV = true;
            PfRadioButton.Checked = true;
            pessoa.Tipo = Pessoa.PESSOA_FISICA;
            pessoa.BloquearCrediario = true;

            pessoa.CodMunicipioIBGE = loja.CodMunicipioIBGE;
            MunicipiosIBGE defaultMunicipio = new MunicipiosIBGE() { Codigo = pessoa.CodMunicipioIBGE };
            municipiosIBGEBindingSource.Position = municipiosIBGEBindingSource.List.IndexOf(defaultMunicipio);
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
                service.GerenciadorPessoa.Remover(Int32.Parse(codPessoaTextBox.Text));
                pessoaBindingSource.RemoveCurrent();
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
            _pessoa.CodMunicipioIBGE = Convert.ToInt32(codMunicipioIBGEComboBox.SelectedValue);
            _pessoa.Cidade = codMunicipioIBGEComboBox.Text;
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
            _pessoa.BloquearCrediario = bloquearCrediarioCheckBox.Checked;

            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                service.GerenciadorPessoa.Inserir(_pessoa);
                pessoaBindingSource.DataSource = service.GerenciadorPessoa.ObterTodos();
                pessoaBindingSource.MoveLast();
            }
            else
            {
                service.GerenciadorPessoa.Atualizar(_pessoa);
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
                    service.GerenciadorPessoa.RemoverContato(cp);
                }
            }
            contatosBindingSource.DataSource = service.GerenciadorPessoa.ObterContatos(long.Parse(codPessoaTextBox.Text));
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
            {
                contatosBindingSource.DataSource = service.GerenciadorPessoa.ObterContatos(long.Parse(codPessoaTextBox.Text));
                
                municipiosIBGEBindingSource.Position = municipiosIBGEBindingSource.List.IndexOf(new MunicipiosIBGE() { Codigo = ((Pessoa)pessoaBindingSource.Current).CodMunicipioIBGE });
            }
        }

        private void btnAdicionarContato_Click(object sender, EventArgs e)
        {
            FrmPessoaPesquisa frmPessoaPesquisa = new FrmPessoaPesquisa(saceOptions);
            frmPessoaPesquisa.ShowDialog();
            if (frmPessoaPesquisa.PessoaSelected != null)
            {
                ContatoPessoa contatoPessoa = new ContatoPessoa();
                contatoPessoa.CodPessoa = Int64.Parse(codPessoaTextBox.Text);
                contatoPessoa.CodPessoaContato = frmPessoaPesquisa.PessoaSelected.CodPessoa;

                service.GerenciadorPessoa.InserirContato(contatoPessoa);
                contatosBindingSource.DataSource = service.GerenciadorPessoa.ObterContatos(long.Parse(codPessoaTextBox.Text));
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
            PessoaSelected = (Pessoa) pessoaBindingSource.Current;
        }

        private void limiteCompraTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
        }

        private void nomeFantasiaTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox) sender);
            if (nomeTextBox.Text.Trim().Equals(""))
            {
                ((Pessoa)pessoaBindingSource.Current).Nome = nomeFantasiaTextBox.Text; 
            }
        }

        private void nomeTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }

        private void codMunicipioIBGEComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];
        }

        private void pessoaBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            pessoaBindingSource.ResumeBinding();
        }

    }
}
