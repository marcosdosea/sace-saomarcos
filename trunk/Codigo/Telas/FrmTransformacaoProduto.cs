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

namespace Telas
{
    public partial class FrmTransformacaoProduto : Form
    {
        public FrmTransformacaoProduto()
        {
            InitializeComponent();
        }

        private void FrmTransformacaoProduto_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.TRANFORMACOES, Principal.Autenticacao.CodUsuario);
        }
    }
}
