using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dados.saceDataSetTableAdapters;

namespace Telas
{
    public partial class FrmLogin : Form
    {
        bool aturizado = false;
        //int codUsuario;
        //string login;

        //public string Login
        //{
        //    get { return login; }
        //}

        //public int CodUsuario
        //{
        //    get { return codUsuario; }
        //}

        public bool Aturizado
        {
            get { return aturizado; }
        }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            tb_usuarioTableAdapter ta = new tb_usuarioTableAdapter();
            //TODO
            //DataTable dt = ta.GetDataByLoginSenha(textBoxUsuario.Text, textBoxSenha.Text);
            //if (dt.Rows.Count > 0)
            //{
            //    aturizado = true;
            //    codUsuario = Convert.ToInt32(dt.Rows[0]["codPessoa"].ToString());
            //    login = dt.Rows[0]["login"].ToString(); ;
            //    Close();
            //}
            //else
            //{
            //    throw new SystemException("Usuário Inválido");
            //}
        }
    }
}
