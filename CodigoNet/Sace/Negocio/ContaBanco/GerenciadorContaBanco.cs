using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorContaBanco 
    {
        private readonly SaceContext context;

        public GerenciadorContaBanco(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere os dados de uma conta bancária
        /// </summary>
        /// <param name="contaBanco"></param>
        /// <returns></returns>
        public Int64 Inserir(ContaBanco contaBanco)
        {
            try
            {
                var _contaBanco = new TbContaBanco();
                Atribuir(contaBanco, _contaBanco);

                context.Add(_contaBanco);
                context.SaveChanges();
                
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
        public void Atualizar(ContaBanco contaBanco)
        {
            try
            {
                TbContaBanco? _contaBanco = context.TbContaBancos.Find(contaBanco.CodContaBanco);
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
            catch (Exception e)
            {
                throw new DadosException("Conta do Banco", e.Message, e);
            }
        }

        /// <summary>
        /// Remove os dados de uma conta bancária
        /// </summary>
        /// <param name="codcontaBanco"></param>
        public void Remover(Int32 codcontaBanco)
        {
            if (codcontaBanco == 1)
                throw new NegocioException("A conta bancária/Caixa não pode ser excluída.");
            try
            {
                var contaBanco = new TbContaBanco();
                contaBanco.CodContaBanco = codcontaBanco;
                context.Remove(contaBanco);
                context.SaveChanges();
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
        private IQueryable<ContaBanco> GetQuery()
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
        public IEnumerable<ContaBanco> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém contas bancárias com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<ContaBanco> Obter(int codContaBanco)
        {
            return GetQuery().Where(contaBanco => contaBanco.CodContaBanco == codContaBanco).ToList();
        }

        /// <summary>
        /// Obtém contas bancárias que iniciam com o numero
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<ContaBanco> ObterPorNumero(string numero)
        {
            return GetQuery().Where(contaBanco => contaBanco.NumeroConta.StartsWith(numero)).ToList();
        }

        /// <summary>
        /// Obtém contas bancárias que iniciam com a descricao
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<ContaBanco> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(contaBanco => contaBanco.Descricao.StartsWith(descricao)).ToList();
        }

        /// <summary>
        /// Atribui a classe Conta Banco às entidade persistente correpondente
        /// </summary>
        /// <param name="contaBanco"></param>
        /// <param name="_contaBanco"></param>
        private void Atribuir(ContaBanco contaBanco, TbContaBanco _contaBanco)
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