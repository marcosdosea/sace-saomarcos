using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorCfop 
    {

        /// <summary>
        /// Insere um novo cfop na base de dados
        /// </summary>
        /// <param name="cfop"></param>
        /// <returns></returns>
        public int Inserir(Cfop cfop)
        {
            try
            {
                var _cfop = new TbCfop();
                _cfop.Cfop = cfop.CodCfop;
                _cfop.Descricao = cfop.Descricao;
                _cfop.Icms = cfop.Icms;
                using (var context = new SaceContext())
                {

                    context.Add(_cfop);
                    context.SaveChanges();
                }

                return _cfop.Cfop;
            }
            catch (Exception e)
            {
                throw new DadosException("Cfop", e.Message, e);
            }
        }


        /// <summary>
        /// Atualiza dados do cfop na base de dados
        /// </summary>
        /// <param name="cfop"></param>
        public void Atualizar(Cfop cfop)
        {
            try
            {
                using (var context = new SaceContext())
                {

                    var _cfop = context.TbCfops.Find(cfop.CodCfop);

                    if (_cfop != null)
                    {
                        _cfop.Descricao = cfop.Descricao;
                        _cfop.Icms = cfop.Icms;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("CFOP não encontrado para atualização.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cfop", e.Message, e);
            }
        }

        /// <summary>
        /// Remover um cfop da base de dados
        /// </summary>
        /// <param name="codCfop"></param>
        public void Remover(Int32 codCfop)
        {
            try
            {
                var cfop = new TbCfop();
                cfop.Cfop = codCfop;
                using (var context = new SaceContext())
                {

                    context.Remove(cfop);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cfop", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Cfop> GetQuery()
        {
            using (var context = new SaceContext())
            {

                var query = from cfop in context.TbCfops
                            select new Cfop
                            {
                                CodCfop = cfop.Cfop,
                                Descricao = cfop.Descricao,
                                Icms = cfop.Icms
                            };
                return query.AsNoTracking();
            }
        }

        /// <summary>
        /// Obtém todos os cfops cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cfop> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém cfop com a código especificado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Cfop> Obter(int codCfop)
        {
            return GetQuery().Where(cfop => cfop.CodCfop == codCfop).ToList();
        }

        /// <summary>
        /// Obtém cfops que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Cfop> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(cfop => cfop.Descricao.StartsWith(descricao)).ToList();
        }
    }
}