using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorGrupoConta
    {

        /// <summary>
        /// Insere um novo grupo de contas
        /// </summary>
        /// <param name="grupoConta"></param>
        /// <returns></returns>
        public static int Inserir(GrupoConta grupoConta)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _grupoConta = new TbGrupoContum();
                    _grupoConta.Descricao = grupoConta.Descricao;

                    context.Add(_grupoConta);
                    context.SaveChanges();

                    return _grupoConta.CodGrupoConta;
                }
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
        public static void Atualizar(GrupoConta grupoConta)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _grupoConta = new TbGrupoContum();
                    _grupoConta.CodGrupoConta = grupoConta.CodGrupoConta;
                    _grupoConta = context.TbGrupoConta.Find(_grupoConta);

                    if (_grupoConta != null)
                    {
                        _grupoConta.Descricao = grupoConta.Descricao;
                        context.SaveChanges();
                    }
                }
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
        public static void Remover(int codGrupoConta)
        {
            if ((codGrupoConta == 1) || (codGrupoConta == 2))
                throw new NegocioException("Esse grupo não pode ser excluído para manter a consistência da base de dados");
            using (var context = new SaceContext())
            {
                try
                {
                    var _grupoConta = context.TbGrupoConta.FirstOrDefault(g => g.CodGrupoConta == codGrupoConta);

                    context.Remove(_grupoConta);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DadosException("Grupo de Contas", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<GrupoConta> GetQuery()
        {
            using (var context = new SaceContext())
            {
                var query = from grupoConta in context.TbGrupoConta
                            select new GrupoConta
                            {
                                CodGrupoConta = grupoConta.CodGrupoConta,
                                Descricao = grupoConta.Descricao
                            };

                return query.AsNoTracking();
            }
        }

        /// <summary>
        /// Obtém todos os grupos de contas cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<GrupoConta> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém grupo de contas com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<GrupoConta> Obter(int codGrupoConta)
        {
            return GetQuery().Where(grupoConta => grupoConta.CodGrupoConta == codGrupoConta).ToList();
        }

        /// <summary>
        /// Obtém grupos de contas que iniciam com a descrição
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static IEnumerable<GrupoConta> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(grupoConta => grupoConta.Descricao.StartsWith(descricao)).ToList();
        }
    }
}