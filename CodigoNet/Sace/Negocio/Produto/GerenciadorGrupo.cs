﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorGrupo 
    {
        private readonly SaceContext context;

        public GerenciadorGrupo(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere um grupo e um grupo padrão
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public Int64 Inserir(Grupo grupo)
        {
            try
            {
                var repGrupo = new RepositorioGenerico<GrupoE>();
                var repSubgrupo = new RepositorioGenerico<SubgrupoE>();

                GrupoE _grupoE = new GrupoE();
                _grupoE.descricao = grupo.Descricao;
                repGrupo.Inserir(_grupoE);
                repGrupo.SaveChanges();

                SubgrupoE _subgrupoE = new SubgrupoE();
                _subgrupoE.codGrupo = Convert.ToInt32(_grupoE.codGrupo);
                _subgrupoE.descricao = "---- NAO DEFINIDO ----";
                repSubgrupo.Inserir(_subgrupoE);

                repSubgrupo.SaveChanges();
                return _grupoE.codGrupo;
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo", e.Message, e);
            }
        }

        /// <summary>
        /// Atualizar grupo
        /// </summary>
        /// <param name="grupo"></param>
        public void Atualizar(Grupo grupo)
        {
            try
            {
                var repGrupo = new RepositorioGenerico<GrupoE>();
                
                GrupoE _grupoE = repGrupo.ObterEntidade(g => g.codGrupo == grupo.CodGrupo);
                _grupoE.descricao = grupo.Descricao;

                repGrupo.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo", e.Message, e);
            }
        }

        /// <summary>
        /// Remover um grupo
        /// </summary>
        /// <param name="codGrupo"></param>
        public void Remover(Int32 codGrupo)
        {
            if (codGrupo == 1)
                throw new NegocioException("Esse grupo não pode ser excluído para manter a consistência da base de dados");
            try
            {
                var repGrupo = new RepositorioGenerico<GrupoE>();
                
                repGrupo.Remover(grupo => grupo.codGrupo == codGrupo);
                repGrupo.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Grupo", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Grupo> GetQuery()
        {
            var repGrupo = new RepositorioGenerico<GrupoE>();
            var repSubgrupo = new RepositorioGenerico<SubgrupoE>();
            var saceEntities = (SaceEntities)repGrupo.ObterContexto();
            var query = from grupo in saceEntities.GrupoSet
                        select new Grupo
                        {
                            CodGrupo = (int)grupo.codGrupo,
                            Descricao = grupo.descricao,
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os grupos cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Grupo> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém grupo com a código especificado
        /// </summary>
        /// <param name="codGrupo"></param>
        /// <returns></returns>
        public IEnumerable<Grupo> Obter(int codGrupo)
        {
            return GetQuery().Where(grupo => grupo.CodGrupo == codGrupo).ToList();
        }

        /// <summary>
        /// Obtém grupos que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Grupo> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(grupo => grupo.Descricao.StartsWith(descricao)).ToList();
        }
    }
}