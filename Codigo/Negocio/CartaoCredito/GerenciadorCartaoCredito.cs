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
    public class GerenciadorCartaoCredito
    {
        private static GerenciadorCartaoCredito gCartaoCredito;
        private static tb_cartao_creditoTableAdapter tb_cartaoCreditoTA;
        
        public static GerenciadorCartaoCredito getInstace()
        {
            if (gCartaoCredito == null)
            {
                gCartaoCredito = new GerenciadorCartaoCredito();
                tb_cartaoCreditoTA = new tb_cartao_creditoTableAdapter();
            }
            return gCartaoCredito;
        }

        public Int64 inserir(CartaoCredito cartaoCredito)
        {
            try
            {
                tb_cartaoCreditoTA.Insert(cartaoCredito.Nome, cartaoCredito.DiaBase,
                    cartaoCredito.CodContaBanco, cartaoCredito.CodPessoa, cartaoCredito.Mapeamento);

                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }

        public void atualizar(CartaoCredito cartaoCredito)
        {
            try
            {
                tb_cartaoCreditoTA.Update(cartaoCredito.Nome, cartaoCredito.DiaBase,
                    cartaoCredito.CodContaBanco, cartaoCredito.CodPessoa, cartaoCredito.Mapeamento, cartaoCredito.CodCartao);
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }

        public void remover(Int32 codCartaoCredito)
        {
            try
            {
                tb_cartaoCreditoTA.Delete(codCartaoCredito);
            }
            catch (Exception e)
            {
                throw new DadosException("Cartão de Crédito", e.Message, e);
            }
        }

        public CartaoCredito obterCartaoCredito(Int32 codCartaoCredito)
        {
            CartaoCredito cartaoCredito = new CartaoCredito();
            
            Dados.saceDataSetTableAdapters.tb_cartao_creditoTableAdapter tb_cartaoCreditoTA = new tb_cartao_creditoTableAdapter();
            Dados.saceDataSet.tb_cartao_creditoDataTable cartaoCreditoDT = tb_cartaoCreditoTA.GetDataByCodCartao(codCartaoCredito);

            cartaoCredito.CodCartao = Convert.ToInt32(cartaoCreditoDT.Rows[0]["codCartao"].ToString());
            cartaoCredito.CodContaBanco = Convert.ToInt32(cartaoCreditoDT.Rows[0]["codContaBanco"].ToString());
            cartaoCredito.CodPessoa = Convert.ToInt64(cartaoCreditoDT.Rows[0]["codPessoa"].ToString());
            cartaoCredito.DiaBase = Convert.ToInt32(cartaoCreditoDT.Rows[0]["diaBase"].ToString());
            cartaoCredito.Nome = cartaoCreditoDT.Rows[0]["nome"].ToString();
            cartaoCredito.Mapeamento = cartaoCreditoDT.Rows[0]["mapeamento"].ToString();

            return cartaoCredito;
        }
    }
}