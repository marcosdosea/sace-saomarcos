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
    public class GerenciadorLoja
    {
        private static GerenciadorLoja gLoja;
        private static RepositorioGenerico<LojaE, SaceEntities> repLoja;
        
        public static GerenciadorLoja GetInstance()
        {
            if (gLoja == null)
            {
                gLoja = new GerenciadorLoja();
                repLoja = new RepositorioGenerico<LojaE, SaceEntities>("chave");
            }
            return gLoja;
        }

        /// <summary>
        /// Insere um nova loja
        /// </summary>
        /// <param name="loja"></param>
        /// <returns></returns>
        public Int64 Inserir(Loja loja)
        {
            try
            {
                LojaE _lojaE = new LojaE();
                _lojaE.codPessoa = loja.CodPessoa;
                _lojaE.nome = loja.Nome;

                repLoja.Inserir(_lojaE);
                repLoja.SaveChanges();
                
                return _lojaE.codLoja;
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma loja
        /// </summary>
        /// <param name="loja"></param>
        public void Atualizar(Loja loja)
        {
            try
            {
                LojaE _lojaE = repLoja.ObterEntidade(l => l.codLoja == loja.CodLoja);
                _lojaE.codPessoa = loja.CodPessoa;
                _lojaE.nome = loja.Nome;

                repLoja.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de uma loja
        /// </summary>
        /// <param name="codloja"></param>
        public void Remover(Int32 codloja)
        {
            if (codloja == 1)
                throw new NegocioException("A loja matriz não pode ser excluída.");
                
            try
            {
                repLoja.Remover(loja => loja.codLoja == codloja);
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Loja> GetQuery()
        {
            var saceEntities = (SaceEntities) repLoja.ObterContexto();
            var query = from loja in saceEntities.LojaSet
                        select new Loja
                        {
                            CodLoja = loja.codLoja,
                            CodPessoa = loja.codPessoa,
                            Nome = loja.nome
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os lojas cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Loja> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém loja com a código especificado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public List<Loja> Obter(int codLoja)
        {
            return GetQuery().Where(loja => loja.CodLoja == codLoja).ToList();
        }

        /// <summary>
        /// Obtém lojas que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<Loja> ObterPorNome(string nome)
        {
            return GetQuery().Where(loja => loja.Nome.StartsWith(nome)).ToList();
        }

        /// <summary>
        /// Obtém loja associada a uma pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public List<Loja> ObterPorPessoa(long codPessoa)
        {
            return GetQuery().Where(loja => loja.CodPessoa == codPessoa).ToList();
        }
    }
}