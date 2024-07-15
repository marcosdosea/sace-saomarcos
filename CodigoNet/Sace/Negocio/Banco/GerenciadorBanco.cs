using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorBanco
    {
        /// <summary>
        /// Insere dados do banco
        /// </summary>
        /// <param name="banco"></param>
        /// <returns></returns>
        public static long Inserir(Banco banco)
        {

            TbBanco _banco = new TbBanco();
            try
            {
                using (var context = new SaceContext())
                {
                    _banco.CodBanco = banco.CodBanco;
                    _banco.Nome = banco.Nome;
                    context.Add(_banco);
                    context.SaveChanges();
                    return _banco.CodBanco;
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza dados do banco
        /// </summary>
        /// <param name="banco"></param>
        public static void Atualizar(Banco banco)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _banco = context.TbBancos.FirstOrDefault(b => b.CodBanco == banco.CodBanco);
                    if (_banco != null)
                    {
                        _banco.CodBanco = banco.CodBanco;
                        _banco.Nome = banco.Nome;
                        context.Update(_banco);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }

        /// <summary>
        /// Remove dados do banco
        /// </summary>
        /// <param name="codBanco"></param>
        public static void Remover(int codBanco)
        {
            if (codBanco == 1)
                throw new NegocioException("O banco não pode ser removido.");
            try
            {
                using (var context = new SaceContext())
                {
                    var _banco = context.TbBancos.FirstOrDefault(b => b.CodBanco == codBanco);
                    if (_banco != null)
                    {
                        context.Remove(_banco);
                        context.SaveChanges();

                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }

        /// <summary>
        /// Obtém todos os banco cadastrados
        /// </summary>
        /// <returns></returns>
        public static List<Banco> ObterTodos()
        {
            using (var context = new SaceContext())
            {
                var query = from banco in context.TbBancos
                            select new Banco
                            {
                                CodBanco = banco.CodBanco,
                                Nome = banco.Nome
                            };
                return query.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// Obtém banco com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<Banco> Obter(int codBanco)
        {
            try
            {
                using (var context = new SaceContext())
                {

                    var query = from banco in context.TbBancos
                                where banco.CodBanco == codBanco
                                select new Banco
                                {
                                    CodBanco = banco.CodBanco,
                                    Nome = banco.Nome
                                };
                    return query.AsNoTracking().ToList();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }

        /// <summary>
        /// Obtém bancos que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static IEnumerable<Banco> ObterPorNome(string nome)
        {
            try
            {
                using (var context = new SaceContext())
                {

                    var query = from banco in context.TbBancos
                                where banco.Nome.StartsWith(nome)
                                select new Banco
                                {
                                    CodBanco = banco.CodBanco,
                                    Nome = banco.Nome
                                };
                    return query.AsNoTracking().ToList();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }
    }
}