using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace SACE.Telas
{
    public partial class FrmTransformacaoProduto : Form
    {
        public FrmTransformacaoProduto()
        {
            InitializeComponent();
        }

        private void FrmTransformacaoProduto_Load(object sender, EventArgs e)
        {
            Seguranca.GetInstancia().verificaPermissao(this, Funcoes.TRANFORMACOES, Principal.Autenticacao.CodUsuario);
        }
    }
}
