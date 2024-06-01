using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorSubgrupo
    {
        private readonly SaceContext context;

        public GerenciadorSubgrupo(SaceContext saceContext)
        {
            context = saceContext;
        }


        /// <summary>
        /// Insere um novo subgrupo
        /// </summary>
        /// <param name="subgrupo"></param>
        /// <returns></returns>
        public long Inserir(Subgrupo subgrupo)
        {
            try
            {
                var _subgrupo = new TbSubgrupo();
                _subgrupo.CodGrupo = subgrupo.CodGrupo;
                _subgrupo.Descricao = subgrupo.Descricao;

                context.Add(_subgrupo);
                context.SaveChanges();

                return _subgrupo.CodSubgrupo;
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
                var _subgrupo = new TbSubgrupo();
                _subgrupo.CodSubgrupo = subgrupo.CodSubgrupo;

                _subgrupo = context.TbSubgrupos.Find(_subgrupo);
                if (_subgrupo != null)
                {
                    _subgrupo.CodGrupo = subgrupo.CodGrupo;
                    _subgrupo.Descricao = subgrupo.Descricao;
                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("Subgrupo não foi encontrado para atualização.");
                }
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
        public void Remover(int codSubgrupo)
        {
            if (codSubgrupo == 1)
                throw new NegocioException("Esse subgrupo não pode ser excluído para manter a consistência da base de dados");
            try
            {
                var _subgrupo = new TbSubgrupo();
                _subgrupo.CodSubgrupo = codSubgrupo;

                context.Remove(_subgrupo);
                context.SaveChanges();
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
            var query = from subgrupo in context.TbSubgrupos
                        select new Subgrupo
                        {
                            CodGrupo = (int)subgrupo.CodGrupo,
                            Descricao = subgrupo.Descricao,
                            CodSubgrupo = subgrupo.CodSubgrupo,
                            DescricaoGrupo = subgrupo.CodGrupoNavigation.Descricao
                        };
            return query.AsNoTracking();
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