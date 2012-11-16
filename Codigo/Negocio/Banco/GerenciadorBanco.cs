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
using MySql.Data;

namespace Negocio
{
    public class GerenciadorBanco {

        private static GerenciadorBanco gBanco;
        private static RepositorioGenerico<BancoE, SaceEntities> repBanco;
        
        public static GerenciadorBanco getInstace()
        {
            if (gBanco == null)
            {
                gBanco = new GerenciadorBanco();
                repBanco = new RepositorioGenerico<BancoE,SaceEntities>("chave");
            }
            return gBanco;
        }

        public IQueryable<Dados.BancoE> GetDataSource()
        {
            return repBanco.GetQueryable();
        }

        public IEnumerable<Dados.BancoE> obterTodos()
        {
            return repBanco.ObterTodos();
        }

        public Int64 inserir(BancoE banco)
        {
            try
            {
                BancoE _banco = repBanco.Inserir(banco);
                repBanco.SaveChanges();
                return _banco.codBanco;
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }

        public void atualizar(BancoE banco)
        {
            try
            {
                BancoE _banco = repBanco.ObterEntidade(b => b.codBanco == banco.codBanco);
                _banco.nome = banco.nome;

                repBanco.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }

        public void remover(Int32 codBanco)
        {
            if (codBanco == 1)
                throw new NegocioException("O banco não pode ser removido.");
            try
            {
                repBanco.Remover(b => b.codBanco == codBanco);
                repBanco.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }
    }
}