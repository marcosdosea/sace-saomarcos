using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorSubgrupo
    {

        /// <summary>
        /// Insere um novo subgrupo
        /// </summary>
        /// <param name="subgrupo"></param>
        /// <returns></returns>
        public static long Inserir(Subgrupo subgrupo)
        {
            try
            {
                var _subgrupo = new TbSubgrupo();
                _subgrupo.CodGrupo = subgrupo.CodGrupo;
                _subgrupo.Descricao = subgrupo.Descricao;
                using (var context = new SaceContext())
                {
                    context.Add(_subgrupo);
                    context.SaveChanges();
                    return _subgrupo.CodSubgrupo;
                }
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
        public static void Atualizar(Subgrupo subgrupo)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _subgrupo = context.TbSubgrupos.FirstOrDefault(s => s.CodSubgrupo == subgrupo.CodSubgrupo);
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
        public static void Remover(int codSubgrupo)
        {
            if (codSubgrupo == 1)
                throw new NegocioException("Esse subgrupo não pode ser excluído para manter a consistência da base de dados");
            try
            {
                using (var context = new SaceContext())
                {
                    var _subgrupo = context.TbSubgrupos.FirstOrDefault(s => s.CodSubgrupo == codSubgrupo);
                    if (_subgrupo != null)
                    {
                        context.Remove(_subgrupo);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Subgrupo não encontrado para exclusão.");
                    }
                }
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
        private static IQueryable<Subgrupo> GetQuery()
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obtém todos os subgrupos cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Subgrupo> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém subgrupo com a código especificado
        /// </summary>
        /// <param name="codSubgrupo"></param>
        /// <returns></returns>
        public static IEnumerable<Subgrupo> Obter(int codSubgrupo)
        {
            return GetQuery().Where(subgrupo => subgrupo.CodSubgrupo == codSubgrupo).ToList();
        }

        /// <summary>
        /// Obtém subgrupos que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static IEnumerable<Subgrupo> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(subgrupo => subgrupo.Descricao.StartsWith(descricao)).ToList();
        }

        /// <summary>
        /// Obtém subgrupos pela descrição de um determinado grupo
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static IEnumerable<Subgrupo> ObterPorDescricaoGrupo(string descricao)
        {
            return GetQuery().Where(subgrupo => subgrupo.DescricaoGrupo.StartsWith(descricao)).ToList();
        }

        /// <summary>
        /// Obter subgrupos de um determinado grupo
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public static IEnumerable<Subgrupo> ObterPorGrupo(Grupo grupo)
        {
            return GetQuery().Where(subgrupo => subgrupo.CodGrupo == grupo.CodGrupo).ToList();
        }
    }
}