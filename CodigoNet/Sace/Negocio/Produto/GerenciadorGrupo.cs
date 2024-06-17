using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

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
        public long Inserir(Grupo grupo)
        {
            try
            {
                var transaction = context.Database.BeginTransaction();
                var _grupo = new TbGrupo();
                _grupo.Descricao = grupo.Descricao;

                context.Add(_grupo);
                context.SaveChanges();

                var _subgrupo = new TbSubgrupo();
                _subgrupo.CodGrupo = Convert.ToInt32(_grupo.CodGrupo);
                _subgrupo.Descricao = "---- NAO DEFINIDO ----";
                context.Add(_subgrupo);
                context.SaveChanges();

                transaction.Commit();
                
                return _grupo.CodGrupo;
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
                var _grupo = context.TbGrupos.Find(grupo.CodGrupo);
                if (_grupo != null)
                {
                    _grupo.Descricao = grupo.Descricao;

                    context.SaveChanges();
                } 
                else
                {
                    throw new NegocioException("Grupo não encontrado para atualização.");
                }
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
        public void Remover(int codGrupo)
        {
            if (codGrupo == 1)
                throw new NegocioException("Esse grupo não pode ser excluído para manter a consistência da base de dados");
            try
            {
                var grupo = new TbGrupo();
                grupo.CodGrupo = codGrupo;

                context.Remove(grupo);
                context.SaveChanges();
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
            var query = from grupo in context.TbGrupos
                        select new Grupo
                        {
                            CodGrupo = grupo.CodGrupo,
                            Descricao = grupo.Descricao,
                        };
            return query.AsNoTracking();
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