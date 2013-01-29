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
    public class GerenciadorCst 
    {
        private static GerenciadorCst gCst;
        
        public static GerenciadorCst GetInstance()
        {
            if (gCst == null)
            {
                gCst = new GerenciadorCst();
            }
            return gCst;
        }

        /// <summary>
        /// Insere um novo cst na base de dados
        /// </summary>
        /// <param name="cst"></param>
        /// <returns></returns>
        public Int64 Inserir(Cst cst)
        {
            try
            {
                var repCst = new RepositorioGenerico<CstE>();

                CstE _cst = new CstE();
                _cst.codCST = cst.CodCST;
                _cst.descricaoCST = cst.Descricao;
                
                repCst.Inserir(_cst);
                repCst.SaveChanges();
                
                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Cst", e.Message, e);
            }
        }


        /// <summary>
        /// Atualiza dados do cst na base de dados
        /// </summary>
        /// <param name="cst"></param>
        public void Atualizar(Cst cst)
        {
            try
            {
                var repCst = new RepositorioGenerico<CstE>();

                CstE _cst = repCst.ObterEntidade(c => c.codCST.Equals(cst.CodCST));
                _cst.descricaoCST = cst.Descricao;
                _cst.codCST = cst.CodCST;

                repCst.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Cst", e.Message, e);
            }
        }

        /// <summary>
        /// Remover um cst da base de dados
        /// </summary>
        /// <param name="codCst"></param>
        public void Remover(Int32 codCst)
        {
            try
            {
                var repCst = new RepositorioGenerico<CstE>();

                repCst.Remover(c => c.codCST.Equals(codCst));
                repCst.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Cst", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Cst> GetQuery()
        {
            var repCst = new RepositorioGenerico<CstE>();

            var saceEntities = (SaceEntities)repCst.ObterContexto();
            var query = from cst in saceEntities.CstSet
                        select new Cst
                        {
                            CodCST = cst.codCST,
                            Descricao = cst.descricaoCST,
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os csts cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cst> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém cst com a código especificado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Cst> Obter(string codCst)
        {
            return GetQuery().Where(cst => cst.CodCST.Equals(codCst)).ToList();
        }

        /// <summary>
        /// Obtém csts que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Cst> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(cst => cst.Descricao.StartsWith(descricao)).ToList();
        }
    }
}