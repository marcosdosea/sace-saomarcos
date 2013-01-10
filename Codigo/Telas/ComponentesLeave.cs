using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Telas
{
    public class ComponentesLeave
    {

        public static void PessoaComboBox_Leave(object sender, EventArgs e, ComboBox pessoaComboBox, EstadoFormulario estado, BindingSource pessoaBindingSource, bool retornaNomeFantasia)
        {
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                List<Pessoa> pessoas;
                if (retornaNomeFantasia)
                    pessoas = (List<Pessoa>) GerenciadorPessoa.GetInstance().ObterPorNomeFantasia(pessoaComboBox.Text);
                else
                    pessoas = (List<Pessoa>)GerenciadorPessoa.GetInstance().ObterPorNome(pessoaComboBox.Text);

                if (pessoas.Count == 0)
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(pessoaComboBox.Text);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                        if (retornaNomeFantasia)
                            pessoaComboBox.Text = ((Pessoa) pessoaBindingSource.Current).NomeFantasia;
                        else
                            pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).Nome;
                    }
                    else
                    {
                        pessoaComboBox.Focus();
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else
                {
                    pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(pessoas[0]);
                    if (retornaNomeFantasia)
                        pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).NomeFantasia;
                    else
                        pessoaComboBox.Text = ((Pessoa)pessoaBindingSource.Current).Nome;
                }
            }
        }
    }
}
