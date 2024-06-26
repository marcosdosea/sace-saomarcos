using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;
using Util;

namespace Sace
{
    public partial class FrmPlanoConta : Form
    {
        private EstadoFormulario estado;

        public PlanoConta PlanoContaSelected;
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmPlanoConta(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmPlanoConta_Load(object sender, EventArgs e)
        {
            grupoContaBindingSource.DataSource = service.GerenciadorGrupoConta.ObterTodos();
            planoContaBindingSource.DataSource = service.GerenciadorPlanoConta.ObterTodos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmPlanoContaPesquisa frmPlanoContaPesquisa = new FrmPlanoContaPesquisa(saceOptions);
            frmPlanoContaPesquisa.ShowDialog();
            if (frmPlanoContaPesquisa.PlanoContaSelected != null)
            {
                planoContaBindingSource.Position = planoContaBindingSource.List.IndexOf(frmPlanoContaPesquisa.PlanoContaSelected);
            }
            frmPlanoContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            planoContaBindingSource.AddNew();
            codPlanoContaTextBox.Enabled = false;
            rbPagar.Checked = true;
            codGrupoContaComboBox.SelectedIndex = 0;
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                service.GerenciadorPlanoConta.Remover(int.Parse(codPlanoContaTextBox.Text));
                planoContaBindingSource.RemoveCurrent();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            planoContaBindingSource.CancelEdit();
            planoContaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                PlanoConta planoConta = new PlanoConta();
                planoConta.CodGrupoConta = int.Parse(codGrupoContaComboBox.SelectedValue.ToString());
                planoConta.Descricao = descricaoTextBox.Text;
                planoConta.TipoConta = (rbPagar.Checked) ? Conta.CONTA_PAGAR.ToString() : Conta.CONTA_RECEBER.ToString();
                planoConta.DiaBase = (diaBaseTextBox.Text == "") ? short.Parse("0") : short.Parse(diaBaseTextBox.Text);
                planoConta.CodPlanoConta = Int32.Parse(codPlanoContaTextBox.Text);

                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    long codPlanoConta = service.GerenciadorPlanoConta.Inserir(planoConta);
                    codPlanoContaTextBox.Text = codPlanoConta.ToString();
                }
                else
                {
                    service.GerenciadorPlanoConta.Atualizar(planoConta);
                }
                planoContaBindingSource.EndEdit();
            }
           catch (Exception exc)
            {
               planoContaBindingSource.CancelEdit(); 
               throw exc;
            }
            finally {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmPlanoConta_KeyDown(object sender, KeyEventArgs e)
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
                    planoContaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    planoContaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    planoContaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    planoContaBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codGrupoContaComboBox.Focused))
                {
                    FrmGrupoContaPesquisa frmGrupoContaPesquisa = new FrmGrupoContaPesquisa(saceOptions);
                    frmGrupoContaPesquisa.ShowDialog();
                    if (frmGrupoContaPesquisa.GrupoConta != null)
                    {
                        grupoContaBindingSource.Position = grupoContaBindingSource.List.IndexOf(frmGrupoContaPesquisa.GrupoConta);
                    }
                    frmGrupoContaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codGrupoContaComboBox.Focused))
                {
                    FrmGrupoConta frmGrupoConta = new FrmGrupoConta(saceOptions);
                    frmGrupoConta.ShowDialog();
                    if (frmGrupoConta.GrupoContaSelected != null)
                    {
                        grupoContaBindingSource.Position = grupoContaBindingSource.List.IndexOf(frmGrupoConta.GrupoContaSelected);
                    }
                    frmGrupoConta.Dispose();
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
            tb_plano_contaBindingNavigator.Enabled = habilita;
            codGrupoContaComboBox.Enabled = !habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void codGrupoContaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void tb_plano_contaBindingSource_PositionChanged(object sender, EventArgs e)
        {
            PlanoContaSelected = (PlanoConta) planoContaBindingSource.Current;
            if (PlanoContaSelected != null)
            {
                if (PlanoContaSelected.TipoConta.Equals(Conta.CONTA_PAGAR))
                {
                    rbPagar.Checked = true;
                    rbReceber.Checked = false;
                }
                else
                {
                    rbPagar.Checked = false;
                    rbReceber.Checked = true;
                }
            }
        }

        private void codGrupoContaComboBox_Leave(object sender, EventArgs e)
        {
            if (codGrupoContaComboBox.SelectedValue == null)
            {
                codGrupoContaComboBox.Focus();
                throw new TelaException("Um grupo válido precisa ser selecionado");
            }
        }

        private void FrmPlanoConta_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlanoContaSelected = (PlanoConta)planoContaBindingSource.Current;
        }

        private void descricaoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
        }
    }
}