﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Util;

namespace Negocio
{
    public class GerenciadorLoja
    {
        private static GerenciadorLoja gLoja;
        
        public static GerenciadorLoja GetInstance()
        {
            if (gLoja == null)
            {
                gLoja = new GerenciadorLoja();
            }
            return gLoja;
        }

        /// <summary>
        /// Insere um nova loja
        /// </summary>
        /// <param name="loja"></param>
        /// <returns></returns>
        public Int64 Inserir(Loja loja)
        {
            try
            {
                var repLoja = new RepositorioGenerico<tb_loja>();

                tb_loja _lojaE = new tb_loja();
                Atribuir(loja, _lojaE);
                repLoja.Inserir(_lojaE);
                repLoja.SaveChanges();
                
                return _lojaE.codLoja;
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
                var repLoja = new RepositorioGenerico<tb_loja>();

                tb_loja _lojaE = repLoja.ObterEntidade(l => l.codLoja == loja.CodLoja);
                Atribuir(loja, _lojaE);

                repLoja.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza apemas o número da nfe
        /// </summary>
        /// <param name="loja"></param>
        public int IncrementarNumeroNfe(int codLoja, SaceEntities saceContext)
        {
            try
            {
                var query = from loja in saceContext.tb_loja
                            where loja.codLoja == codLoja
                            select loja;

                tb_loja _loja = query.FirstOrDefault();
                if (_loja != null)
                {
                    _loja.numeroSequenciaNfeAtual += 1;
                }
                saceContext.SaveChanges();
                return _loja.numeroSequenciaNfeAtual;
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
        public void Remover(Int32 codloja)
        {
            if (codloja == 1)
                throw new NegocioException("A loja matriz não pode ser excluída.");
                
            try
            {
                var repLoja = new RepositorioGenerico<tb_loja>();

                repLoja.Remover(loja => loja.codLoja == codloja);
                repLoja.SaveChanges();
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
            var repLoja = new RepositorioGenerico<tb_loja>();

            var saceEntities = (SaceEntities) repLoja.ObterContexto();
            var query = from loja in saceEntities.tb_loja
                        select new Loja
                        {
                            CodLoja = loja.codLoja,
                            CodPessoa = loja.codPessoa,
                            Nome = loja.nome,
                            NomeServidorNfe = loja.nomeServidorNfe,
                            PastaNfeAutorizados = loja.pastaNfeAutorizados,
                            PastaNfeEnviado = loja.pastaNfeEnviado,
                            PastaNfeEnvio = loja.pastaNfeEnvio,
                            PastaNfeErro = loja.pastaNfeErro,
                            PastaNfeEspelho = loja.pastaNfeEspelho,
                            PastaNfeRetorno = loja.pastaNfeRetorno,
                            Cnpj = loja.tb_pessoa.cpf_Cnpj,
                            CodMunicipioIBGE = loja.tb_pessoa.codMunicipiosIBGE,
                            Estado = loja.tb_pessoa.uf,
                            Ie = loja.tb_pessoa.ie,
                            NomePessoa = loja.tb_pessoa.nome,
                            NumeroSequenciaNFeAtual = (int) loja.numeroSequenciaNfeAtual,
                            NumeroSequenciaNFCeAtual = (int)loja.numeroSequencialNFCeAtual
                        };
            return query;
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
                lojas = Obter(Global.LOJA_PADRAO);
            }
            return lojas;
        }

        private static void Atribuir(Loja loja, tb_loja _lojaE)
        {
            _lojaE.codPessoa = loja.CodPessoa;
            _lojaE.nome = loja.Nome;
            _lojaE.nomeServidorNfe = loja.NomeServidorNfe;
            _lojaE.pastaNfeAutorizados = loja.PastaNfeAutorizados;
            _lojaE.pastaNfeEnviado = loja.PastaNfeEnviado;
            _lojaE.pastaNfeEnvio = loja.PastaNfeEnvio;
            _lojaE.pastaNfeErro = loja.PastaNfeErro;
            _lojaE.pastaNfeEspelho = loja.PastaNfeEspelho;
            _lojaE.pastaNfeRetorno = loja.PastaNfeRetorno;
            _lojaE.numeroSequenciaNfeAtual = loja.NumeroSequenciaNFeAtual;
            _lojaE.numeroSequencialNFCeAtual = loja.NumeroSequenciaNFCeAtual;
        }
    }
}