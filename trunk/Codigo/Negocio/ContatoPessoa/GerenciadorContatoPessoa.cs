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
    public class GerenciadorContatoPessoa : IGerenciadorContatoPessoa
    {
        private static IGerenciadorContatoPessoa gContatoPessoa;
        private static tb_contato_empresaTableAdapter tb_contato_empresaTA;
        
        
        public static IGerenciadorContatoPessoa getInstace()
        {
            if (gContatoPessoa == null)
            {
                gContatoPessoa = new GerenciadorContatoPessoa();
                tb_contato_empresaTA = new tb_contato_empresaTableAdapter();
            }
            return gContatoPessoa;
        }

        public void inserir(ContatoPessoa contatoPessoa)
        {
            try
            {
                tb_contato_empresaTA.Insert(contatoPessoa.CodPessoa, contatoPessoa.CodPessoaContato);
            }
            catch (Exception e)
            {
                throw new DadosException("Contato Pessoa", e.Message, e);
            }
        }

        public void atualizar(ContatoPessoa contatoPessoa)
        {
            try
            {
                tb_contato_empresaTA.Update(contatoPessoa.CodPessoa, contatoPessoa.CodPessoaContato);
            }
            catch (Exception e)
            {
                throw new DadosException("Contato Pessoa", e.Message, e);
            }
        }

        public void remover(ContatoPessoa contatoPessoa)
        {
            try
            {
                tb_contato_empresaTA.Delete(contatoPessoa.CodPessoa, contatoPessoa.CodPessoaContato);
            }
            catch (Exception e)
            {
                throw new DadosException("Contato Pessoa", e.Message, e);
            }
        }
    }
}
