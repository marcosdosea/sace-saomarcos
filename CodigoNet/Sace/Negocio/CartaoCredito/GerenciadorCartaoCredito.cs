using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorCartaoCredito
    {
        /// <summary>
        /// Insere os dados de um cartão de crédito
        /// </summary>
        /// <param name="cartaoCredito"></param>
        /// <returns></returns>
        public static int Inserir(CartaoCredito cartaoCredito)
        {
            try
            {
                var _cartaoCredito = new TbCartaoCredito();
                Atribuir(cartaoCredito, _cartaoCredito);
                using (var context = new SaceContext())
                {
                    context.Add(_cartaoCredito);
                    context.SaveChanges();
                }

                return _cartaoCredito.CodCartao;
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados de um cartão de crédito
        /// </summary>
        /// <param name="cartaoCredito"></param>
        public static void Atualizar(CartaoCredito cartaoCredito)
        {
            try
            {
                var _cartaoCredito = new TbCartaoCredito();
                Atribuir(cartaoCredito, _cartaoCredito);
                using (var context = new SaceContext())
                {
                    context.Update(_cartaoCredito);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de um cartão de crédito
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        public static void Remover(int codCartaoCredito)
        {
            try
            {
                if (codCartaoCredito == 1)
                {
                    throw new NegocioException("Esse cartão de crédito não pode ser removido");
                }
                var cartaoCredito = new TbCartaoCredito();
                cartaoCredito.CodCartao = codCartaoCredito;
                using (var context = new SaceContext())
                {

                    context.Remove(cartaoCredito);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }


        /// <summary>
        /// Consulta padrão para retornar dados do cartão de crédito
        /// </summary>
        /// <returns></returns>
        private static IQueryable<CartaoCredito> GetQuery(SaceContext context)
        {

            var query = from cartao in context.TbCartaoCreditos
                        select new CartaoCredito
                        {
                            CodCartao = cartao.CodCartao,
                            CodContaBanco = cartao.CodContaBanco,
                            CodPessoa = (int)cartao.CodPessoa,
                            DiaBase = (int)cartao.DiaBase,
                            Mapeamento = cartao.Mapeamento,
                            Nome = cartao.Nome,
                            DescricaoContaBanco = cartao.CodContaBancoNavigation.Descricao,
                            NomePessoa = cartao.CodPessoaNavigation.NomeFantasia,
                            Desconto = cartao.Desconto,
                            MapeamentoCappta = cartao.MapeamentoCappta,
                            TipoCartao = cartao.TipoCartao
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos os cartões de crédito cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CartaoCredito> ObterTodos()
        {
            using (var context = new SaceContext())
            {

                return GetQuery(context).ToList();
            }
        }

        /// <summary>
        /// Obtém os dados do cartão pelo código
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        /// <returns>código do cartão</returns>
        public static IEnumerable<CartaoCredito> Obter(Int32 codCartaoCredito)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(cartao => cartao.CodCartao == codCartaoCredito).ToList();
            }
        }


        /// <summary>
        /// Obtém os dados do cartão pelo código
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        /// <returns>código do cartão</returns>
        public static IEnumerable<CartaoCredito> ObterPorMapeamentoCappta(String nomeBandeira)
        {
            using (var context = new SaceContext())
            {

                return GetQuery(context).Where(cartao => cartao.MapeamentoCappta == nomeBandeira).ToList();
            }
        }

        /// <summary>
        /// Obtém os dados do cartão pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>nome do cartão</returns>
        public static IEnumerable<CartaoCredito> ObterPorNome(string nome)
        {
            using (var context = new SaceContext())
            {

                return GetQuery(context).Where(cartao => cartao.Nome.StartsWith(nome)).ToList();
            }
        }


        /// <summary>
        /// Atribuição ente entidade e entidade persistente
        /// </summary>
        /// <param name="cartaoCredito"></param>
        /// <param name="_cartaoCredito"></param>
        private static void Atribuir(CartaoCredito cartaoCredito, TbCartaoCredito _cartaoCredito)
        {
            _cartaoCredito.CodCartao = cartaoCredito.CodCartao;
            _cartaoCredito.CodContaBanco = cartaoCredito.CodContaBanco;
            _cartaoCredito.CodPessoa = cartaoCredito.CodPessoa;
            _cartaoCredito.DiaBase = cartaoCredito.DiaBase;
            _cartaoCredito.Mapeamento = cartaoCredito.Mapeamento;
            _cartaoCredito.Nome = cartaoCredito.Nome;
            _cartaoCredito.Desconto = cartaoCredito.Desconto;
            _cartaoCredito.MapeamentoCappta = cartaoCredito.MapeamentoCappta;
            _cartaoCredito.TipoCartao = cartaoCredito.TipoCartao;
        }

    }
}