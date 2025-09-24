using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorCst
    {
        /// <summary>
        /// Insere um novo cst na base de dados
        /// </summary>
        /// <param name="cst"></param>
        /// <returns></returns>
        public static void Inserir(Cst cst)
        {
            try
            {
                var _cst = new TbCst();
                _cst.CodCst = cst.CodCST;
                _cst.DescricaoCst = cst.Descricao;
                using (var context = new SaceContext())
                {
                    context.Add(_cst);
                    context.SaveChanges();
                }
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
        public static void Atualizar(Cst cst)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _cst = context.TbCsts.Find(cst.CodCST);
                    if (_cst != null)
                    {
                        _cst.DescricaoCst = cst.Descricao;
                        _cst.CodCst = cst.CodCST;
                        context.Update(_cst);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("CST não encontrado para atualização.");
                    }
                }
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
        public static void Remover(string codCST)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _cst = context.TbCsts.Find(codCST);
                    if (_cst != null)
                    {
                        context.Remove(_cst);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("CST não encontrado para exclusão");
                    }
                }
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
        private static IQueryable<Cst> GetQuery(SaceContext context)
        {
            var query = from cst in context.TbCsts
                        select new Cst
                        {
                            CodCST = cst.CodCst,
                            Descricao = cst.DescricaoCst,
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos os csts cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Cst> ObterTodos()
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).ToList();
            }
        }

        /// <summary>
        /// Obtém cst com a código especificado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<Cst> Obter(string codCst)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(cst => cst.CodCST.Equals(codCst)).ToList();
            }
        }

        /// <summary>
        /// Obtém csts que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static IEnumerable<Cst> ObterPorDescricao(string descricao)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(cst => cst.Descricao.StartsWith(descricao)).ToList();
            }
        }
    }
}