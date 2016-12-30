using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorFormaPagamento 
    {
        private static GerenciadorFormaPagamento gFormaPagamento;
        
        public static GerenciadorFormaPagamento GetInstance()
        {
            if (gFormaPagamento == null)
            {
                gFormaPagamento = new GerenciadorFormaPagamento();
            }
            return gFormaPagamento;
        }

        /// <summary>
        /// Insere uma nova forma de pagamento
        /// </summary>
        /// <param name="formaPagamento"></param>
        /// <returns></returns>
        public Int64 Inserir(FormaPagamento formaPagamento)
        {
            try
            {
                var repFormaPagamento = new RepositorioGenerico<tb_forma_pagamento>();

                tb_forma_pagamento _formaPagamento = new tb_forma_pagamento();
                Atribuir(formaPagamento, _formaPagamento);

                repFormaPagamento.Inserir(_formaPagamento);
                repFormaPagamento.SaveChanges();
                
                return _formaPagamento.codFormaPagamento;
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
                var repFormaPagamento = new RepositorioGenerico<tb_forma_pagamento>();

                tb_forma_pagamento _formaPagamento = repFormaPagamento.Obter(f => f.codFormaPagamento == formaPagamento.CodFormaPagamento).ElementAt(0);
                Atribuir(formaPagamento, _formaPagamento);

                repFormaPagamento.SaveChanges();
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
        public void Remover(Int32 codformaPagamento)
        {
            try
            {
                var repFormaPagamento = new RepositorioGenerico<tb_forma_pagamento>();

                repFormaPagamento.Remover(f => f.codFormaPagamento == codformaPagamento);
                repFormaPagamento.SaveChanges();
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
            var repFormaPagamento = new RepositorioGenerico<tb_forma_pagamento>();
            var saceEntities = (SaceEntities)repFormaPagamento.ObterContexto();
            var query = from formaPagamento in saceEntities.tb_forma_pagamento
                        select new FormaPagamento
                        {
                            CodFormaPagamento = formaPagamento.codFormaPagamento,
                            DescontoAcrescimo = formaPagamento.descontoAcrescimo,
                            Descricao = formaPagamento.descricao,
                            Mapeamento = formaPagamento.mapeamento,
                            Parcelas = formaPagamento.parcelas
                        };
            return query;
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
        private void Atribuir(FormaPagamento formaPagamento, tb_forma_pagamento _formaPagamento)
        {
            _formaPagamento.codFormaPagamento = formaPagamento.CodFormaPagamento;
            _formaPagamento.descontoAcrescimo = formaPagamento.DescontoAcrescimo;
            _formaPagamento.descricao = formaPagamento.Descricao;
            _formaPagamento.mapeamento = formaPagamento.Mapeamento;
            _formaPagamento.parcelas = formaPagamento.Parcelas;
        }

    }
}