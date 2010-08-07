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
    public class GerenciadorCartaoCredito : IGerenciadorCartaoCredito
    {
        private static IGerenciadorCartaoCredito gCartaoCredito;
        private static tb_cartao_creditoTableAdapter tb_cartaoCreditoTA;
        
        public static IGerenciadorCartaoCredito getInstace()
        {
            if (gCartaoCredito == null)
            {
                gCartaoCredito = new GerenciadorCartaoCredito();
                tb_cartaoCreditoTA = new tb_cartao_creditoTableAdapter();
            }
            return gCartaoCredito;
        }

        public void inserir(CartaoCredito cartaoCredito)
        {
            try
            {
                tb_cartaoCreditoTA.Insert(cartaoCredito.Nome, cartaoCredito.DiaBase,
                    cartaoCredito.CodContaBanco);
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
                    cartaoCredito.CodContaBanco, cartaoCredito.CodCartao);
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
    }
}
