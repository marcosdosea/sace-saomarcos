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
    public class GerenciadorSaidaPagamento : IGerenciadorSaidaPagamento
    {
        private static IGerenciadorSaidaPagamento gSaidaPagamento;
        private static tb_saida_pagamentoTableAdapter tb_SaidaPagamentoTA;
        
        public static IGerenciadorSaidaPagamento getInstace()
        {
            if (gSaidaPagamento == null)
            {
                gSaidaPagamento = new GerenciadorSaidaPagamento();
                tb_SaidaPagamentoTA = new tb_saida_pagamentoTableAdapter();
            }
            return gSaidaPagamento;
        }

        public void inserir(SaidaPagamento saidaPagamento)
        {
            try
            {
                tb_SaidaPagamentoTA.Insert(saidaPagamento.CodSaida,
                    saidaPagamento.CodFormaPagamento, saidaPagamento.CodContaBanco,
                    saidaPagamento.Valor.ToString(), saidaPagamento.Data);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }

        public void atualizar(SaidaPagamento saidaPagamento)
        {
            try
            {
                tb_SaidaPagamentoTA.Update(saidaPagamento.CodSaida, saidaPagamento.CodFormaPagamento,
                    saidaPagamento.CodContaBanco, saidaPagamento.Valor, saidaPagamento.Data,
                    saidaPagamento.CodSaidaPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }

        public void remover(Int64 codSaidaPagamento)
        {
            try
            {
                tb_SaidaPagamentoTA.Delete(codSaidaPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamentos", e.Message, e);
            }
        }
    }
}
