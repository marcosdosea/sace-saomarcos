﻿using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using Util;

namespace Negocio
{
    public class GerenciadorLoja
    {
        private readonly SaceContext context;

        public GerenciadorLoja(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere um nova loja
        /// </summary>
        /// <param name="loja"></param>
        /// <returns></returns>
        public int Inserir(Loja loja)
        {
            try
            {
                var _loja = new TbLoja();
                Atribuir(loja, _loja);
                context.Add(_loja);
                context.SaveChanges();

                return _loja.CodLoja;
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma loja
        /// </summary>
        /// <param name="loja"></param>
        public void Atualizar(Loja loja)
        {
            try
            {
                var _loja = new TbLoja();
                _loja.CodLoja = loja.CodLoja;

                _loja = context.TbLojas.Find(_loja);
                if (_loja != null)
                {
                    Atribuir(loja, _loja);
                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("A loja não foi encontrada para realização da atualização");
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }


        /// <summary>
        /// Remove os dados de uma loja
        /// </summary>
        /// <param name="codloja"></param>
        public void Remover(int codLoja)
        {
            if (codLoja == 1)
                throw new NegocioException("A loja matriz não pode ser excluída.");

            try
            {
                var _loja = new TbLoja();
                _loja.CodLoja = codLoja;

                context.Remove(_loja);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Loja> GetQuery()
        {
            var query = from loja in context.TbLojas
                        select new Loja
                        {
                            CodLoja = loja.CodLoja,
                            CodPessoa = loja.CodPessoa,
                            Nome = loja.Nome,
                            NomeServidorNfe = loja.NomeServidorNfe,
                            PastaNfeAutorizados = loja.PastaNfeAutorizados,
                            PastaNfeEnviado = loja.PastaNfeEnviado,
                            PastaNfeEnvio = loja.PastaNfeEnvio,
                            PastaNfeErro = loja.PastaNfeErro,
                            PastaNfeEspelho = loja.PastaNfeEspelho,
                            PastaNfeRetorno = loja.PastaNfeRetorno,
                            PastaNfeValidado = loja.PastaNfeValidado,
                            PastaNfeValidar = loja.PastaNfeValidar,
                            Cnpj = loja.CodPessoaNavigation.CpfCnpj,
                            CodMunicipioIBGE = loja.CodPessoaNavigation.CodMunicipiosIbge,
                            Estado = loja.CodPessoaNavigation.Uf,
                            Ie = loja.CodPessoaNavigation.Ie,
                            NomePessoa = loja.CodPessoaNavigation.Nome,
                            NumeroSequenciaNFeAtual = loja.NumeroSequenciaNfeAtual,
                            NumeroSequenciaNFCeAtual = loja.NumeroSequencialNfceAtual
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos os lojas cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Loja> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém loja com a código especificado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public List<Loja> Obter(int codLoja)
        {
            return GetQuery().Where(loja => loja.CodLoja == codLoja).ToList();
        }

        /// <summary>
        /// Obtém lojas que iniciam com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<Loja> ObterPorNome(string nome)
        {
            return GetQuery().Where(loja => loja.Nome.StartsWith(nome)).ToList();
        }

        /// <summary>
        /// Obtém loja associada a uma pessoa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public List<Loja> ObterPorPessoa(long codPessoa)
        {
            return GetQuery().Where(loja => loja.CodPessoa == codPessoa).ToList();
        }

        /// <summary>
        /// Obtém dados da loja associada a um computador com cartão de Nf-e instalado
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public List<Loja> ObterPorServidorNfe(string nomeComputador)
        {
            List<Loja> lojas = GetQuery().Where(loja => loja.NomeServidorNfe.Equals(nomeComputador)).ToList();
            if ((lojas == null) || (lojas.Count == 0))
            {
                lojas = Obter(UtilConfig.Default.LOJA_PADRAO);
            }
            return lojas;
        }

        /// <summary>
        /// Atualiza apemas o número da nfe
        /// </summary>
        /// <param name="loja"></param>
        public int IncrementarNumeroNFe(int codLoja, string modelo)
        {
            var transaction = context.Database.BeginTransaction();
            try
            {
                DateTime ontem = DateTime.Now.AddDays(-1);
                var query = from nfe in context.TbNves
                            where (nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_NAO_VALIDADA) || nfe.SituacaoNfe.Equals(NfeControle.SITUACAO_SOLICITADA)) &&
                                  (nfe.DataEmissao.Value <= ontem) && nfe.Modelo.Equals(modelo)
                            select nfe;
                List<TbNfe> nfes = query.ToList();
                if (nfes.Count > 0)
                {
                    var nfe = nfes.First();
                    int codigo = nfe.NumeroSequenciaNfe;
                    context.Remove(nfe);
                    context.SaveChanges();
                    return codigo;
                }
                if (modelo.Equals(NfeControle.MODELO_NFCE))
                {
                    var _loja = new TbLoja();
                    _loja.CodLoja = codLoja;
                    _loja = context.TbLojas.Find(_loja);
                    _loja.NumeroSequencialNfceAtual += 1;
                    context.SaveChanges();
                    transaction.Commit();
                    return _loja.NumeroSequencialNfceAtual;
                }
                else
                {
                    var _loja = new TbLoja();
                    _loja.CodLoja = codLoja;
                    _loja = context.TbLojas.Find(_loja);
                    _loja.NumeroSequenciaNfeAtual += 1;
                    context.SaveChanges();
                    transaction.Commit();
                    return _loja.NumeroSequenciaNfeAtual;
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Loja", e.Message, e);
            }
        }


        private static void Atribuir(Loja loja, TbLoja _loja)
        {
            _loja.CodPessoa = loja.CodPessoa;
            _loja.Nome = loja.Nome;
            _loja.NomeServidorNfe = loja.NomeServidorNfe;
            _loja.PastaNfeAutorizados = loja.PastaNfeAutorizados;
            _loja.PastaNfeEnviado = loja.PastaNfeEnviado;
            _loja.PastaNfeEnvio = loja.PastaNfeEnvio;
            _loja.PastaNfeErro = loja.PastaNfeErro;
            _loja.PastaNfeEspelho = loja.PastaNfeEspelho;
            _loja.PastaNfeRetorno = loja.PastaNfeRetorno;
            _loja.PastaNfeValidar = loja.PastaNfeValidar;
            _loja.PastaNfeValidado = loja.PastaNfeValidado;
            _loja.NumeroSequenciaNfeAtual = loja.NumeroSequenciaNFeAtual;
            _loja.NumeroSequencialNfceAtual = loja.NumeroSequenciaNFCeAtual;
        }
    }
}