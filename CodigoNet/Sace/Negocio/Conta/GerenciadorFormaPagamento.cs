using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorFormaPagamento
    {

        /// <summary>
        /// Insere uma nova forma de pagamento
        /// </summary>
        /// <param name="formaPagamento"></param>
        /// <returns></returns>
        public static int Inserir(FormaPagamento formaPagamento)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _formaPagamento = new TbFormaPagamento();
                    Atribuir(formaPagamento, _formaPagamento);

                    context.Add(_formaPagamento);
                    context.SaveChanges();

                    return _formaPagamento.CodFormaPagamento;
                }
            }
            catch (Exception e)
            {
                throw new DadosException("FormaPagamento", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza forma de pagamento
        /// </summary>
        /// <param name="formaPagamento"></param>
        public static void Atualizar(FormaPagamento formaPagamento)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _formaPagamento = context.TbFormaPagamentos.Find(formaPagamento.CodFormaPagamento);
                    if (_formaPagamento != null)
                    {
                        Atribuir(formaPagamento, _formaPagamento);
                        context.Update(_formaPagamento);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Forma de pagamento não encontrada para atualização.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("FormaPagamento", e.Message, e);
            }
        }

        /// <summary>
        /// Remove uma forma de pagamento
        /// </summary>
        /// <param name="codformaPagamento"></param>
        public static void Remover(int codFormaPagamento)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _formaPagamento = context.TbFormaPagamentos.Find(codFormaPagamento);
                    if (_formaPagamento != null)
                    {
                        context.Remove(_formaPagamento);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Forma de pagamento não encontrada.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("FormaPagamento", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private static IQueryable<FormaPagamento> GetQuery(SaceContext context)
        {

            var query = from formaPagamento in context.TbFormaPagamentos
                        select new FormaPagamento
                        {
                            CodFormaPagamento = formaPagamento.CodFormaPagamento,
                            DescontoAcrescimo = formaPagamento.DescontoAcrescimo,
                            Descricao = formaPagamento.Descricao,
                            Mapeamento = formaPagamento.Mapeamento,
                            Parcelas = formaPagamento.Parcelas
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos as formas de pagamento cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<FormaPagamento> ObterTodos()
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).ToList();
            }
        }

        /// <summary>
        /// Obtém formas de pagamento com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static IEnumerable<FormaPagamento> Obter(int codFormaPagamento)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(formaPagamento => formaPagamento.CodFormaPagamento == codFormaPagamento).ToList();
            }
        }

        /// <summary>
        /// Atribuição entre entidade e entidade persistente
        /// </summary>
        /// <param name="formaPagamento"></param>
        /// <param name="_formaPagamento"></param>
        private static void Atribuir(FormaPagamento formaPagamento, TbFormaPagamento _formaPagamento)
        {
            _formaPagamento.CodFormaPagamento = formaPagamento.CodFormaPagamento;
            _formaPagamento.DescontoAcrescimo = formaPagamento.DescontoAcrescimo;
            _formaPagamento.Descricao = formaPagamento.Descricao;
            _formaPagamento.Mapeamento = formaPagamento.Mapeamento;
            _formaPagamento.Parcelas = formaPagamento.Parcelas;
        }

    }
}