using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados;
using Util;
using System.Data.Common;

namespace Negocio
{
    public class GerenciadorUsuario : IGerenciadorUsuario
    {
        private static IGerenciadorUsuario gUsuario;
        private static tb_usuarioTableAdapter tb_usuarioTA;
        
        public static IGerenciadorUsuario getInstace()
        {
            if (gUsuario == null)
            {
                gUsuario = new GerenciadorUsuario();
                tb_usuarioTA = new tb_usuarioTableAdapter();
            }
            return gUsuario;
        }

        public Int64 inserir(Usuario usuario)
        {
            try
            {
                tb_usuarioTA.Insert(usuario.CodPessoa, usuario.Login,
                    usuario.Senha, usuario.CodPerfil);
                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Usuario", e.Message, e);
            }
        }

        public void atualizar(Usuario usuario)
        {
            try
            {
                tb_usuarioTA.Update(usuario.Login, usuario.Senha, usuario.CodPerfil,
                    usuario.CodPessoa);
            }
            catch (Exception e)
            {
                throw new DadosException("Usuario", e.Message, e);
            }
        }

        public void remover(Int32 codUsuario)
        {
            if (codUsuario == 1)
                throw new NegocioException("O usuario não pode ser removido.");
            try
            {
                tb_usuarioTA.Delete(codUsuario);
            }
            catch (Exception e)
            {
                throw new DadosException("Usuario", e.Message, e);
            }
        }
    }
}
