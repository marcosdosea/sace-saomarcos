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
    public class GerenciadorGrupoConta 
    {
        private static GerenciadorGrupoConta gGrupoConta;
        
        public static GerenciadorGrupoConta GetInstance()
        {
            if (gGrupoConta == null)
            {
                gGrupoConta = new GerenciadorGrupoConta();
            }
            return gGrupoConta;
        }

        /// <summary>
        /// Insere um novo grupo de contas
        /// </summary>
        /// <param name="grupoConta"></param>
        /// <returns></returns>
        public Int64 Inserir(GrupoConta grupoConta)
        {
            try
            {
                var repGrupoConta = new RepositorioGenerico<GrupoContaE>();

                GrupoContaE _grupoContaE = new GrupoContaE();
                _grupoContaE.descricao = grupoConta.Descricao;

                repGrupoConta.Inserir(_grupoContaE);
                repGrupoConta.SaveChanges();

                return _grupoContaE.codGrupoConta;
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo de Contas", e.Message, e);
            }
        }
        /// <summary>
        /// Atualiza os dados do grupo de contas
        /// </summary>
        /// <param name="grupoConta"></param>
        public void Atualizar(GrupoConta grupoConta)
        {
            try
            {
                var repGrupoConta = new RepositorioGenerico<GrupoContaE>();

                GrupoContaE _grupoContaE = repGrupoConta.ObterEntidade(gc => gc.codGrupoConta == grupoConta.CodGrupoConta);
                _grupoContaE.descricao = grupoConta.Descricao;

                repGrupoConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo de Contas", e.Message, e);
            }
        }

        /// <summary>
        /// Remove um grupo de contas
        /// </summary>
        /// <param name="codGrupoConta"></param>
        public void Remover(Int32 codGrupoConta)
        {
            if ( (codGrupoConta == 1) || (codGrupoConta == 2))
                throw new NegocioException("Esse grupo não pode ser excluído para manter a consistência da base de dados");

            try
            {
                var repGrupoConta = new RepositorioGenerico<GrupoContaE>();

                repGrupoConta.Remover(gc => gc.codGrupoConta == codGrupoConta);
                repGrupoConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo de Contas", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<GrupoConta> GetQuery()
        {
            var repGrupoConta = new RepositorioGenerico<GrupoContaE>();

            var saceEntities = (SaceEntities) repGrupoConta.ObterContexto();
            var query = from grupoConta in saceEntities.GrupoContaSet
                        select new GrupoConta
                        {
                            CodGrupoConta = grupoConta.codGrupoConta,
                            Descricao = grupoConta.descricao
                        };
                        
            return query;
        }

        /// <summary>
        /// Obtém todos os grupos de contas cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GrupoConta> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém grupo de contas com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<GrupoConta> Obter(int codGrupoConta)
        {
            return GetQuery().Where(grupoConta => grupoConta.CodGrupoConta == codGrupoConta).ToList();
        }

        /// <summary>
        /// Obtém grupos de contas que iniciam com a descrição
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<GrupoConta> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(grupoConta => grupoConta.Descricao.StartsWith(descricao)).ToList();
        }
    }
}