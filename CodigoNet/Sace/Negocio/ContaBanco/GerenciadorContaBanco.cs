using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorContaBanco
    {
        /// <summary>
        /// Insere os dados de uma conta bancária
        /// </summary>
        /// <param name="contaBanco"></param>
        /// <returns></returns>
        public static long Inserir(ContaBanco contaBanco)
        {
            try
            {
                var _contaBanco = new TbContaBanco();
                Atribuir(contaBanco, _contaBanco);
                using (var context = new SaceContext())
                {
                    context.Add(_contaBanco);
                    context.SaveChanges();
                }

                return _contaBanco.CodContaBanco;
            }
            catch (Exception e)
            {
                throw new DadosException("Conta do Banco", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma conta bancária
        /// </summary>
        /// <param name="contaBanco"></param>
        public static void Atualizar(ContaBanco contaBanco)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _contaBanco = context.TbContaBancos.FirstOrDefault(c => c.CodContaBanco == contaBanco.CodContaBanco);
                    if (_contaBanco != null)
                    {
                        Atribuir(contaBanco, _contaBanco);
                        context.Update(_contaBanco);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Conta bancária não encontrada");
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Conta do Banco", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de uma conta bancária
        /// </summary>
        /// <param name="codcontaBanco"></param>
        public static void Remover(int codContaBanco)
        {
            if (codContaBanco == 1)
                throw new NegocioException("A conta bancária/Caixa não pode ser excluída.");
            try
            {
                using (var context = new SaceContext())
                {
                    var _contaBanco = context.TbContaBancos.FirstOrDefault(c => c.CodContaBanco == codContaBanco);
                    if (_contaBanco != null)
                    {
                        context.Remove(_contaBanco);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Conta bancária não encontrada");
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Conta do Banco", e.Message, e);
            }
        }

        /// <summary>
        /// Query Geral para obter dados das contas
        /// </summary>
        /// <returns></returns>
        private static IQueryable<ContaBanco> GetQuery(SaceContext context)
        {
            var query = from contaBanco in context.TbContaBancos
                        select new ContaBanco
                        {
                            CodContaBanco = contaBanco.CodContaBanco,
                            NumeroConta = contaBanco.Numeroconta,
                            Agencia = contaBanco.Agencia,
                            Descricao = contaBanco.Descricao,
                            Saldo = (decimal)contaBanco.Saldo,
                            CodBanco = (int)contaBanco.CodBanco,
                            NomeBanco = contaBanco.CodBancoNavigation.Nome
                        };
            return query.AsNoTracking();
        }


        /// <summary>
        /// Obtém todos as contas bancárias
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ContaBanco> ObterTodos()
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).ToList();
            }
        }

        /// <summary>
        /// Obtém contas bancárias com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<ContaBanco> Obter(int codContaBanco)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(contaBanco => contaBanco.CodContaBanco == codContaBanco).ToList();
            }
        }

        /// <summary>
        /// Obtém contas bancárias que iniciam com o numero
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static IEnumerable<ContaBanco> ObterPorNumero(string numero)
        {
            using (var context = new SaceContext()) {
                return GetQuery(context).Where(contaBanco => contaBanco.NumeroConta.StartsWith(numero)).ToList();
            }
        }

        /// <summary>
        /// Obtém contas bancárias que iniciam com a descricao
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static IEnumerable<ContaBanco> ObterPorDescricao(string descricao)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(contaBanco => contaBanco.Descricao.StartsWith(descricao)).ToList();
            }
        }

        /// <summary>
        /// Atribui a classe Conta Banco às entidade persistente correpondente
        /// </summary>
        /// <param name="contaBanco"></param>
        /// <param name="_contaBanco"></param>
        private static void Atribuir(ContaBanco contaBanco, TbContaBanco _contaBanco)
        {
            _contaBanco.Agencia = contaBanco.Agencia;
            _contaBanco.CodBanco = contaBanco.CodBanco;
            _contaBanco.CodContaBanco = contaBanco.CodContaBanco;
            _contaBanco.Descricao = contaBanco.Descricao;
            _contaBanco.Numeroconta = contaBanco.NumeroConta;
            _contaBanco.Saldo = contaBanco.Saldo;
        }
    }
}