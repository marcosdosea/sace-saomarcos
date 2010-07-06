using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Util;

namespace SACE.Telas
{
    public partial class FrmPessoa : Form
    {
        private EstadoFormulario estado;

        public FrmPessoa()
        {
            InitializeComponent();
        }

        private void FrmPessoa_Load(object sender, EventArgs e)
        {
            Seguranca.GetInstancia().verificaPermissao(this, Funcoes.PESSOAS, Principal.Autenticacao.CodUsuario);

            // TODO: This line of code loads data into the 'saceDataSet.tb_pessoa' table. You can move, or remove it, as needed.
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
            frmPessoaPesquisa.ShowDialog();
            if (frmPessoaPesquisa.getCodPessoa() != -1)
            {
                tb_pessoaBindingSource.Position = tb_pessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.getCodPessoa());
            }
            frmPessoaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_pessoaBindingSource.AddNew();
            codPessoaTextBox.Enabled = false;
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
            try
            {
                if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tb_pessoaTableAdapter.Delete(int.Parse(codPessoaTextBox.Text));
                    tb_pessoaTableAdapter.Fill(saceDataSet.tb_pessoa);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
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
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    if ((PfRadioButton.Checked) && (!Validacoes.ValidaCPF(cpf_cnpjMaskedTextBox.Text)))
                    {
                        ErrorProvider errorprovider = new ErrorProvider();
                        cpf_cnpjErrorProvider.SetError(cpf_cnpjMaskedTextBox, "CPF Inválido");
                        return;
                    }
                    else if (!(PfRadioButton.Checked) && (!Validacoes.ValidaCNPJ(cpf_cnpjMaskedTextBox.Text)))
                    {
                        ErrorProvider errorprovider = new ErrorProvider();
                        cpf_cnpjErrorProvider.SetError(cpf_cnpjMaskedTextBox, "CNPJ Inválido");
                        return;
                    }
                    tb_pessoaTableAdapter.Insert(nomeTextBox.Text, cpf_cnpjMaskedTextBox.Text, enderecoTextBox.Text,
                        cepMaskedTextBox.Text, bairroTextBox.Text, cidadeTextBox.Text, ufTextBox.Text, fone1MaskedTextBox.Text,
                        fone2MaskedTextBox.Text, decimal.Parse(limiteCompraMaskedTextBox.Text), decimal.Parse(valorComissaoMaskedTextBox.Text),
                        observacaoTextBox.Text, PfRadioButton.Checked?"F":"J");
                    tb_pessoaTableAdapter.Fill(saceDataSet.tb_pessoa);
                    tb_pessoaBindingSource.MoveLast();
                }
                else
                {
                    if ((PfRadioButton.Checked) && (!Validacoes.ValidaCPF(cpf_cnpjMaskedTextBox.Text)))
                    {
                        ErrorProvider errorprovider = new ErrorProvider();
                        cpf_cnpjErrorProvider.SetError(cpf_cnpjMaskedTextBox, "CPF Inválido");
                        return;
                    }
                    else if (!(PfRadioButton.Checked) && (!Validacoes.ValidaCNPJ(cpf_cnpjMaskedTextBox.Text)))
                    {
                        ErrorProvider errorprovider = new ErrorProvider();
                        cpf_cnpjErrorProvider.SetError(cpf_cnpjMaskedTextBox, "CNPJ Inválido");
                        return;
                    }                    
                    tb_pessoaTableAdapter.Update(nomeTextBox.Text, cpf_cnpjMaskedTextBox.Text, enderecoTextBox.Text,
                        cepMaskedTextBox.Text, bairroTextBox.Text, cidadeTextBox.Text, ufTextBox.Text, fone1MaskedTextBox.Text,
                        fone2MaskedTextBox.Text, decimal.Parse(limiteCompraMaskedTextBox.Text), decimal.Parse(valorComissaoMaskedTextBox.Text),
                        observacaoTextBox.Text, PfRadioButton.Checked ? "F" : "J", long.Parse(codPessoaTextBox.Text));
                    tb_pessoaBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_pessoaBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
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
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_pessoaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void PfRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (PfRadioButton.Checked)
            {
                nomeLabel.Text = "Nome:";
                cpfLabel.Text = "CPF:";
                cpf_cnpjMaskedTextBox.Mask = "999.999.999-99";
            }
            else
            {
                nomeLabel.Text = "Razão Social:";
                cpfLabel.Text = "CNPJ:";
                cpf_cnpjMaskedTextBox.Mask = "99.999.999/9999-99";
            }
        }

        private void tb_pessoaBindingSource_PositionChanged(object sender, EventArgs e)
        {
            DataRowView linha = (DataRowView)tb_pessoaBindingSource.Current;

            bool tipoCliente = linha["Tipo"].ToString().Equals("F");
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

    }
}
