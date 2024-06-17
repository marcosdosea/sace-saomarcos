using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorBanco
    {
        private readonly SaceContext context;

        public GerenciadorBanco(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere dados do banco
        /// </summary>
        /// <param name="banco"></param>
        /// <returns></returns>
        public Int64 Inserir(Banco banco)
        {
            TbBanco _banco = new TbBanco();
            try
            {
                _banco.CodBanco = banco.CodBanco;
                _banco.Nome = banco.Nome;

                context.Add(_banco);
                context.SaveChanges();

                return _banco.CodBanco;
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
        public void Atualizar(Banco banco)
        {
            TbBanco _banco = new TbBanco();
            try
            {
                _banco.CodBanco = banco.CodBanco;
                _banco.Nome = banco.Nome;

                context.SaveChanges();
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
        public void Remover(Int32 codBanco)
        {
            if (codBanco == 1)
                throw new NegocioException("O banco não pode ser removido.");


            TbBanco _banco = new TbBanco();
            try
            {
                _banco.CodBanco = codBanco;
                context.Remove(_banco);
                context.SaveChanges();
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
        public List<Banco> ObterTodos()
        {
            var query = from banco in context.TbBancos
                        select new Banco
                        {
                            CodBanco = banco.CodBanco,
                            Nome = banco.Nome
                        };
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Obtém banco com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Banco> Obter(int codBanco)
        {
            try
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
        public IEnumerable<Banco> ObterPorNome(string nome)
        {
            try
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
            catch (Exception e)
            {
                throw new DadosException("Banco", e.Message, e);
            }
        }
    }
}