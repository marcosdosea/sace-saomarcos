using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorTipoMovimentacaoConta
    {
        /// <summary>
        /// Insere um novo tipo de movimentacao
        /// </summary>
        /// <param name="tipoMovimentacaoConta"></param>
        /// <returns></returns>
        public int Inserir(TipoMovimentacaoConta tipoMovimentacaoConta)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _tipoMovimentacaoConta = new TbTipoMovimentacaoContum();
                    _tipoMovimentacaoConta.Descricao = tipoMovimentacaoConta.Descricao;
                    _tipoMovimentacaoConta.SomaSaldo = tipoMovimentacaoConta.SomaSaldo;

                    context.Add(_tipoMovimentacaoConta);
                    context.SaveChanges();

                    return _tipoMovimentacaoConta.CodTipoMovimentacao;
                }
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
            using (var context = new SaceContext())
            {
                try
                {
                    var _tipoMovimentacaoConta = context.TbTipoMovimentacaoConta.Find(tipoMovimentacaoConta.CodTipoMovimentacao);

                    if (_tipoMovimentacaoConta != null)
                    {
                        _tipoMovimentacaoConta.Descricao = tipoMovimentacaoConta.Descricao;
                        _tipoMovimentacaoConta.SomaSaldo = tipoMovimentacaoConta.SomaSaldo;

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
        }

        /// <summary>
        /// Remove um tipo de movimentacao de conta
        /// </summary>
        /// <param name="codTipoMovimentacaoConta"></param>
        public void Remover(int codTipoMovimentacaoConta)
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<TipoMovimentacaoConta> GetQuery(SaceContext context)
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
            using (var context = new SaceContext())
            {
                return GetQuery(context).ToList();
            }
        }

        /// <summary>
        /// Obtém tipoMovimentacao de contas com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<TipoMovimentacaoConta> Obter(int codTipoMovimentacaoConta)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(tmc => tmc.CodTipoMovimentacao == codTipoMovimentacaoConta).ToList();
            }
        }

        /// <summary>
        /// Obtém tipoMovimentacaos de contas que iniciam com a descrição
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<TipoMovimentacaoConta> ObterPorDescricao(string descricao)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(tmc => tmc.Descricao.StartsWith(descricao)).ToList();
            }
        }
    }
}
