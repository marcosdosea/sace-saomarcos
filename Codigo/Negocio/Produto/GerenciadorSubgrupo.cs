using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorSubgrupo 
    {
        private static GerenciadorSubgrupo gSubgrupo;
       
        public static GerenciadorSubgrupo GetInstance()
        {
            if (gSubgrupo == null)
            {
                gSubgrupo = new GerenciadorSubgrupo();
            }
            return gSubgrupo;
        }


        /// <summary>
        /// Insere um novo subgrupo
        /// </summary>
        /// <param name="subgrupo"></param>
        /// <returns></returns>
        public Int64 Inserir(Subgrupo subgrupo)
        {
            try
            {
                var repSubgrupo = new RepositorioGenerico<SubgrupoE>();
            
                SubgrupoE _subgrupoE = new SubgrupoE();
                _subgrupoE.codGrupo = subgrupo.CodGrupo;
                _subgrupoE.descricao = subgrupo.Descricao;

                repSubgrupo.Inserir(_subgrupoE);
                repSubgrupo.SaveChanges();
                
                return _subgrupoE.codSubgrupo;
            }
            catch (Exception e)
            {
                throw new DadosException("Subgrupo", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza o subgrupo
        /// </summary>
        /// <param name="subgrupo"></param>
        public void Atualizar(Subgrupo subgrupo)
        {
            try
            {
                var repSubgrupo = new RepositorioGenerico<SubgrupoE>();
            
                SubgrupoE _subgrupoE = repSubgrupo.ObterEntidade(s => s.codSubgrupo == subgrupo.CodSubgrupo);
                _subgrupoE.codGrupo = subgrupo.CodGrupo;
                _subgrupoE.descricao = subgrupo.Descricao;

                repSubgrupo.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Subgrupo", e.Message, e);
            }
        }

        /// <summary>
        /// Remove um subgrupo
        /// </summary>
        /// <param name="codSubgrupo"></param>
        public void Remover(Int32 codSubgrupo)
        {
            if (codSubgrupo == 1)
                throw new NegocioException("Esse subgrupo não pode ser excluído para manter a consistência da base de dados");
            try
            {
                var repSubgrupo = new RepositorioGenerico<SubgrupoE>();
            
                repSubgrupo.Remover(s => s.codSubgrupo == codSubgrupo);
                repSubgrupo.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Subgrupo", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Subgrupo> GetQuery()
        {
            var repSubgrupo = new RepositorioGenerico<SubgrupoE>();
            
            var saceEntities = (SaceEntities) repSubgrupo.ObterContexto();
            var query = from subgrupo in saceEntities.SubgrupoSet
                        join grupo in saceEntities.GrupoSet on subgrupo.codGrupo equals grupo.codGrupo
                        select new Subgrupo
                        {
                            CodGrupo = (int) subgrupo.codGrupo,
                            Descricao = subgrupo.descricao,
                            CodSubgrupo = subgrupo.codSubgrupo,
                            DescricaoGrupo = grupo.descricao
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os subgrupos cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subgrupo> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém subgrupo com a código especificado
        /// </summary>
        /// <param name="codSubgrupo"></param>
        /// <returns></returns>
        public IEnumerable<Subgrupo> Obter(int codSubgrupo)
        {
            return GetQuery().Where(subgrupo => subgrupo.CodSubgrupo == codSubgrupo).ToList();
        }

        /// <summary>
        /// Obtém subgrupos que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Subgrupo> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(subgrupo => subgrupo.Descricao.StartsWith(descricao)).ToList();
        }

        /// <summary>
        /// Obtém subgrupos pela descrição de um determinado grupo
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Subgrupo> ObterPorDescricaoGrupo(string descricao)
        {
            return GetQuery().Where(subgrupo => subgrupo.DescricaoGrupo.StartsWith(descricao)).ToList();
        }

        /// <summary>
        /// Obter subgrupos de um determinado grupo
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public IEnumerable<Subgrupo> ObterPorGrupo(Grupo grupo)
        {
            return GetQuery().Where(subgrupo => subgrupo.CodGrupo == grupo.CodGrupo).ToList();
        }
    }
}