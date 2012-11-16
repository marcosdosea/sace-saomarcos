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
    public class GerenciadorLoja
    {
        private static GerenciadorLoja gLoja;
        private static tb_lojaTableAdapter tb_lojaTA;
        
        public static GerenciadorLoja getInstace()
        {
            if (gLoja == null)
            {
                gLoja = new GerenciadorLoja();
                tb_lojaTA = new tb_lojaTableAdapter();
            }
            return gLoja;
        }

        public Int64 inserir(Loja loja)
        {
            try
            {
                tb_lojaTA.Insert(loja.Nome, loja.CodPessoa);

                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        public void atualizar(Loja loja)
        {
            try
            {
                tb_lojaTA.Update(loja.Nome, loja.CodPessoa, loja.CodLoja);
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        public void remover(Int32 codloja)
        {
            if (codloja == 1)
                throw new NegocioException("A loja matriz não pode ser excluída.");
                
            try
            {
                tb_lojaTA.Delete(codloja);
            }
            catch (Exception e)
            {
                throw new DadosException("Loja", e.Message, e);
            }
        }

        public Loja obter(int codLoja)
        {
            Loja loja = new Loja();

            Dados.saceDataSetTableAdapters.tb_lojaTableAdapter tb_lojaTA = new tb_lojaTableAdapter();
            Dados.saceDataSet.tb_lojaDataTable lojaDT = tb_lojaTA.GetDataByCodLoja(codLoja);

            loja.CodLoja  = Convert.ToInt32(lojaDT.Rows[0]["codLoja"].ToString());
            loja.CodPessoa = Convert.ToInt64(lojaDT.Rows[0]["codPessoa"].ToString());
            loja.Nome = lojaDT.Rows[0]["nome"].ToString();
            return loja;
        }

        public Loja obterByCodPessoa(long codPessoa)
        {
            Loja loja = new Loja();

            Dados.saceDataSetTableAdapters.tb_lojaTableAdapter tb_lojaTA = new tb_lojaTableAdapter();
            Dados.saceDataSet.tb_lojaDataTable lojaDT = tb_lojaTA.GetDataByCodPessoa(codPessoa);

            loja.CodLoja = Convert.ToInt32(lojaDT.Rows[0]["codLoja"].ToString());
            loja.CodPessoa = Convert.ToInt64(lojaDT.Rows[0]["codPessoa"].ToString());
            loja.Nome = lojaDT.Rows[0]["nome"].ToString();
            return loja;
        }
    }
}