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
    public class GerenciadorCfop 
    {
        private static GerenciadorCfop gCfop;
        private static RepositorioGenerico<CfopE, SaceEntities> repCfop;


        public static GerenciadorCfop GetInstance()
        {
            if (gCfop == null)
            {
                gCfop = new GerenciadorCfop();
                repCfop = new RepositorioGenerico<CfopE, SaceEntities>("chave");
            }
            return gCfop;
        }

        /// <summary>
        /// Insere um novo cfop na base de dados
        /// </summary>
        /// <param name="cfop"></param>
        /// <returns></returns>
        public Int64 Inserir(Cfop cfop)
        {
            try
            {
                CfopE _cfop = new CfopE();
                _cfop.cfop = cfop.CodCfop;
                _cfop.descricao = cfop.Descricao;
                _cfop.icms = cfop.Icms;

                repCfop.Inserir(_cfop);
                repCfop.SaveChanges();

                return _cfop.cfop;
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
                CfopE _cfop = repCfop.ObterEntidade(cf => cf.cfop.Equals(cfop.CodCfop));
                _cfop.descricao = cfop.Descricao;
                _cfop.icms = cfop.Icms;

                repCfop.SaveChanges();
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
                repCfop.Remover(c => c.cfop == codCfop);
                repCfop.SaveChanges();
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
            var saceEntities = (SaceEntities)repCfop.ObterContexto();
            var query = from cfop in saceEntities.CfopSet
                        select new Cfop
                        {
                            CodCfop = cfop.cfop,
                            Descricao = cfop.descricao,
                            Icms = (decimal) cfop.icms
                        };
            return query;
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