using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorCartaoCredito
    {
        private readonly SaceContext context;

        public GerenciadorCartaoCredito(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere os dados de um cartão de crédito
        /// </summary>
        /// <param name="cartaoCredito"></param>
        /// <returns></returns>
        public int Inserir(CartaoCredito cartaoCredito)
        {
            try
            {
                var _cartaoCredito = new TbCartaoCredito();
                Atribuir(cartaoCredito, _cartaoCredito);

                context.Add(_cartaoCredito);
                context.SaveChanges();

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
        public void Atualizar(CartaoCredito cartaoCredito)
        {
            try
            {
                var _cartaoCredito = new TbCartaoCredito();
                Atribuir(cartaoCredito, _cartaoCredito);
                context.Update(_cartaoCredito);
                context.SaveChanges();
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
        public void Remover(int codCartaoCredito)
        {
            try
            {
                if (codCartaoCredito == 1)
                {
                    throw new NegocioException("Esse cartão de crédito não pode ser removido");
                }
                var cartaoCredito = new TbCartaoCredito();
                cartaoCredito.CodCartao = codCartaoCredito;
                context.Remove(cartaoCredito);
                context.SaveChanges();
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
        private IQueryable<CartaoCredito> GetQuery()
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
        public IEnumerable<CartaoCredito> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém os dados do cartão pelo código
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        /// <returns>código do cartão</returns>
        public IEnumerable<CartaoCredito> Obter(Int32 codCartaoCredito)
        {
            return GetQuery().Where(cartao => cartao.CodCartao == codCartaoCredito).ToList();
        }


        /// <summary>
        /// Obtém os dados do cartão pelo código
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        /// <returns>código do cartão</returns>
        public IEnumerable<CartaoCredito> ObterPorMapeamentoCappta(String nomeBandeira)
        {
            return GetQuery().Where(cartao => cartao.MapeamentoCappta == nomeBandeira).ToList();
        }

        /// <summary>
        /// Obtém os dados do cartão pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>nome do cartão</returns>
        public IEnumerable<CartaoCredito> ObterPorNome(string nome)
        {
            return GetQuery().Where(cartao => cartao.Nome.StartsWith(nome)).ToList();
        }


        /// <summary>
        /// Atribuição ente entidade e entidade persistente
        /// </summary>
        /// <param name="cartaoCredito"></param>
        /// <param name="_cartaoCredito"></param>
        private void Atribuir(CartaoCredito cartaoCredito, TbCartaoCredito _cartaoCredito)
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