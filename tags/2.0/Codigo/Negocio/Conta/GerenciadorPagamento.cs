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
    public class GerenciadorPagamento : IGerenciadorPagamento
    {
        private static IGerenciadorPagamento gPagamento;
        private static tb_pagamentoTableAdapter tb_pagamentoTA;
        
        public static IGerenciadorPagamento getInstace()
        {
            if (gPagamento == null)
            {
                gPagamento = new GerenciadorPagamento();
                tb_pagamentoTA = new tb_pagamentoTableAdapter();
            }
            return gPagamento;
        }

        public void inserir(Pagamento pagamento)
        {
            try
            {
                tb_pagamentoTA.Insert(pagamento.CodFormaPagamento, pagamento.CodConta,
                    pagamento.ValorPago.ToString(), pagamento.ValorDiferenca.ToString(),
                    pagamento.CodContaBanco, pagamento.DataBaixa);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamento", e.Message, e);
            }
        }

        public void atualizar(Pagamento pagamento)
        {
            try
            {
                tb_pagamentoTA.Update(pagamento.CodFormaPagamento, pagamento.CodConta, pagamento.ValorPago,
                    pagamento.ValorDiferenca, pagamento.CodContaBanco, pagamento.DataBaixa,
                    pagamento.CodPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamento", e.Message, e);
            }
        }

        public void remover(Int64 codpagamento)
        {
            try
            {
                tb_pagamentoTA.Delete(codpagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Pagamento", e.Message, e);
            }
        }
    }
}
