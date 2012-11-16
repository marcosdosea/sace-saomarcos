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
    public class GerenciadorFormaPagamento 
    {
        private static GerenciadorFormaPagamento gFormaPagamento;
        private static tb_forma_pagamentoTableAdapter tb_forma_pagamentoTA;
        
        public static GerenciadorFormaPagamento getInstace()
        {
            if (gFormaPagamento == null)
            {
                gFormaPagamento = new GerenciadorFormaPagamento();
                tb_forma_pagamentoTA = new tb_forma_pagamentoTableAdapter();
            }
            return gFormaPagamento;
        }

        public Int64 inserir(FormaPagamento formaPagamento)
        {
            try
            {
                tb_forma_pagamentoTA.Insert(formaPagamento.CodFormaPagamento, formaPagamento.Descricao,
                    formaPagamento.Parcelas, formaPagamento.DescontoAcrescimo.ToString());

                return 0;
            }
            catch (Exception e)
            {
                throw new DadosException("FormaPagamento", e.Message, e);
            }
        }

        public void atualizar(FormaPagamento formaPagamento)
        {
            try
            {
                tb_forma_pagamentoTA.Update(formaPagamento.Descricao, formaPagamento.Parcelas,
                    formaPagamento.DescontoAcrescimo, formaPagamento.CodFormaPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("FormaPagamento", e.Message, e);
            }
        }

        public void remover(Int32 codformaPagamento)
        {
            try
            {
                tb_forma_pagamentoTA.Delete(codformaPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("FormaPagamento", e.Message, e);
            }
        }
    }
}