using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorCst 
    {
        private readonly SaceContext context;

        public GerenciadorCst(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere um novo cst na base de dados
        /// </summary>
        /// <param name="cst"></param>
        /// <returns></returns>
        public void Inserir(Cst cst)
        {
            try
            {
                var _cst = new TbCst();
                _cst.CodCst = cst.CodCST;
                _cst.DescricaoCst = cst.Descricao;
                
                context.Add(_cst);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Cst", e.Message, e);
            }
        }


        /// <summary>
        /// Atualiza dados do cst na base de dados
        /// </summary>
        /// <param name="cst"></param>
        public void Atualizar(Cst cst)
        {
            try
            {
                var _cst = context.TbCsts.Find(cst.CodCST);
                if (_cst != null)
                {
                    _cst.DescricaoCst = cst.Descricao;
                    _cst.CodCst = cst.CodCST;

                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("CST não encntrado para atualização.");
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Cst", e.Message, e);
            }
        }

        /// <summary>
        /// Remover um cst da base de dados
        /// </summary>
        /// <param name="codCst"></param>
        public void Remover(string codCst)
        {
            try
            {
                var cst = new TbCst();
                cst.CodCst = codCst;

                context.Remove(cst);
                context.SaveChanges();  
            }
            catch (Exception e)
            {
                throw new DadosException("Cst", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Cst> GetQuery()
        {
            var query = from cst in context.TbCsts
                        select new Cst
                        {
                            CodCST = cst.CodCst,
                            Descricao = cst.DescricaoCst,
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos os csts cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cst> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém cst com a código especificado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Cst> Obter(string codCst)
        {
            return GetQuery().Where(cst => cst.CodCST.Equals(codCst)).ToList();
        }

        /// <summary>
        /// Obtém csts que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Cst> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(cst => cst.Descricao.StartsWith(descricao)).ToList();
        }
    }
}