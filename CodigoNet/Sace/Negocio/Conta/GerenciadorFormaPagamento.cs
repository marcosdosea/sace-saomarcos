using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorFormaPagamento 
    {
        private readonly SaceContext context;

        public GerenciadorFormaPagamento(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere uma nova forma de pagamento
        /// </summary>
        /// <param name="formaPagamento"></param>
        /// <returns></returns>
        public int Inserir(FormaPagamento formaPagamento)
        {
            try
            {
                var _formaPagamento = new TbFormaPagamento();
                Atribuir(formaPagamento, _formaPagamento);

                context.Add(_formaPagamento);
                context.SaveChanges();
                
                return _formaPagamento.CodFormaPagamento;
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
        public void Atualizar(FormaPagamento formaPagamento)
        {
            try
            {
                var _formaPagamento = new TbFormaPagamento();
                _formaPagamento.CodFormaPagamento = formaPagamento.CodFormaPagamento;

                _formaPagamento = context.TbFormaPagamentos.Find(_formaPagamento);
                if (_formaPagamento != null)
                {
                    Atribuir(formaPagamento, _formaPagamento);
                    context.Update(_formaPagamento);
                    context.SaveChanges();
                } 
                else
                {
                    throw new NegocioException("Forma de pagamento não encntrada para atualização.");
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
        public void Remover(int codFormaPagamento)
        {
            try
            {
                var _formaPagamento = new TbFormaPagamento();
                _formaPagamento.CodFormaPagamento = codFormaPagamento;

                context.Remove(_formaPagamento);
                context.SaveChanges();
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
        private IQueryable<FormaPagamento> GetQuery()
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
        public IEnumerable<FormaPagamento> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém formas de pagamento com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<FormaPagamento> Obter(int codFormaPagamento)
        {
            return GetQuery().Where(formaPagamento => formaPagamento.CodFormaPagamento == codFormaPagamento).ToList();
        }

        /// <summary>
        /// Atribuição entre entidade e entidade persistente
        /// </summary>
        /// <param name="formaPagamento"></param>
        /// <param name="_formaPagamento"></param>
        private void Atribuir(FormaPagamento formaPagamento, TbFormaPagamento _formaPagamento)
        {
            _formaPagamento.CodFormaPagamento = formaPagamento.CodFormaPagamento;
            _formaPagamento.DescontoAcrescimo = formaPagamento.DescontoAcrescimo;
            _formaPagamento.Descricao = formaPagamento.Descricao;
            _formaPagamento.Mapeamento = formaPagamento.Mapeamento;
            _formaPagamento.Parcelas = formaPagamento.Parcelas;
        }

    }
}