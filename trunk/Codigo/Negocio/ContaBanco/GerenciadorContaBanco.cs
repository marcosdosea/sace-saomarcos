using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados;
using Util;
using System.Data.Common;

namespace Negocio
{
    public class GerenciadorContaBanco 
    {
        private static GerenciadorContaBanco gContaBanco;
        private static RepositorioGenerico<ContaBancoE, SaceEntities> repContaBanco;
        
        public static GerenciadorContaBanco GetInstance()
        {
            if (gContaBanco == null)
            {
                gContaBanco = new GerenciadorContaBanco();
                repContaBanco = new RepositorioGenerico<ContaBancoE, SaceEntities>("chave");
            }
            return gContaBanco;
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
                ContaBancoE _contaBanco = new ContaBancoE();
                Atribuir(contaBanco, _contaBanco);
                repContaBanco.Inserir(_contaBanco);
                
                repContaBanco.SaveChanges();
                
                return _contaBanco.codContaBanco;
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
                ContaBancoE _contaBanco = repContaBanco.ObterEntidade(c => c.codContaBanco == contaBanco.CodContaBanco);
                Atribuir(contaBanco, _contaBanco);

                repContaBanco.SaveChanges();
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
                repContaBanco.Remover(c => c.codContaBanco == codcontaBanco);
                repContaBanco.SaveChanges();
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
            var saceEntities = (SaceEntities)repContaBanco.ObterContexto();
            var query = from contaBanco in saceEntities.ContaBancoSet
                        join banco in saceEntities.BancoSet
                        on contaBanco.codBanco equals banco.codBanco
                        select new ContaBanco
                        {
                            CodContaBanco = contaBanco.codContaBanco,
                            NumeroConta = contaBanco.numeroconta,
                            Agencia = contaBanco.agencia,
                            Descricao = contaBanco.descricao,
                            Saldo = (decimal)contaBanco.saldo,
                            CodBanco = (int)contaBanco.codBanco,
                            NomeBanco = contaBanco.tb_banco.nome
                        };
            return query;
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
        private void Atribuir(ContaBanco contaBanco, ContaBancoE _contaBanco)
        {
            _contaBanco.agencia = contaBanco.Agencia;
            _contaBanco.codBanco = contaBanco.CodBanco;
            _contaBanco.codContaBanco = contaBanco.CodContaBanco;
            _contaBanco.descricao = contaBanco.Descricao;
            _contaBanco.numeroconta = contaBanco.NumeroConta;
            _contaBanco.saldo = contaBanco.Saldo;
        }
    }
}