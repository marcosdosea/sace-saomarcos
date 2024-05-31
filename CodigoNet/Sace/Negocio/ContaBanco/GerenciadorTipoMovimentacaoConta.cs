using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorTipoMovimentacaoConta
    {
        private readonly SaceContext context;

        public GerenciadorTipoMovimentacaoConta(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere um novo tipo de movimentacao
        /// </summary>
        /// <param name="tipoMovimentacaoConta"></param>
        /// <returns></returns>
        public int Inserir(TipoMovimentacaoConta tipoMovimentacaoConta)
        {
            try
            {
                var _tipoMovimentacaoConta = new TbTipoMovimentacaoContum();
                _tipoMovimentacaoConta.Descricao = tipoMovimentacaoConta.Descricao;
                _tipoMovimentacaoConta.SomaSaldo = tipoMovimentacaoConta.SomaSaldo;

                context.Add(_tipoMovimentacaoConta);
                context.SaveChanges();

                return _tipoMovimentacaoConta.CodTipoMovimentacao;
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados do tipo de movimentacao
        /// </summary>
        /// <param name="tipoMovimentacaoConta"></param>
        public void Atualizar(TipoMovimentacaoConta tipoMovimentacaoConta)
        {
            try
            {
                var _tipoMovimentacaoConta = context.TbTipoMovimentacaoConta.Find(tipoMovimentacaoConta.CodTipoMovimentacao);

                if (_tipoMovimentacaoConta != null)
                {
                    _tipoMovimentacaoConta.Descricao = tipoMovimentacaoConta.Descricao;
                    _tipoMovimentacaoConta.SomaSaldo = tipoMovimentacaoConta.SomaSaldo;

                    context.Update(_tipoMovimentacaoConta);
                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("Tipo Mvimentação conta não encontrado");
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Remove um tipo de movimentacao de conta
        /// </summary>
        /// <param name="codTipoMovimentacaoConta"></param>
        public void Remover(Int32 codTipoMovimentacaoConta)
        {
            try
            {
                var tipoMovimentacaoConta = new TbTipoMovimentacaoContum();
                tipoMovimentacaoConta.CodTipoMovimentacao = codTipoMovimentacaoConta;
                context.Remove(tipoMovimentacaoConta);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<TipoMovimentacaoConta> GetQuery()
        {
            var query = from tipoMovimentacaoConta in context.TbTipoMovimentacaoConta
                        select new TipoMovimentacaoConta
                        {
                            CodTipoMovimentacao = tipoMovimentacaoConta.CodTipoMovimentacao,
                            Descricao = tipoMovimentacaoConta.Descricao,
                            SomaSaldo = tipoMovimentacaoConta.SomaSaldo
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos os tipoMovimentacoes de contas cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TipoMovimentacaoConta> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém tipoMovimentacao de contas com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<TipoMovimentacaoConta> Obter(int codTipoMovimentacaoConta)
        {
            return GetQuery().Where(tmc => tmc.CodTipoMovimentacao == codTipoMovimentacaoConta).ToList();
        }

        /// <summary>
        /// Obtém tipoMovimentacaos de contas que iniciam com a descrição
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<TipoMovimentacaoConta> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(tmc => tmc.Descricao.StartsWith(descricao)).ToList();
        }
    }
}
