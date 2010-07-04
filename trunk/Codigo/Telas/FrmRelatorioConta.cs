using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using SACE.Telas;
using SACE;

namespace SACE.Telas
{
    public partial class FrmRelatorioConta : Form
    {
        public FrmRelatorioConta()
        {
            InitializeComponent();
        }

        private void FrmRelatorioConta_Load(object sender, EventArgs e)
        {
            Seguranca.GetInstancia().verificaPermissao(this, Funcoes.RELATORIO_CONTAS, Principal.Autenticacao.CodUsuario);
        }
    }
}
