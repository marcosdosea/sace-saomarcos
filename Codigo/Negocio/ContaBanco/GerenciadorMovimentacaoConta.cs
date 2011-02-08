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
    public class GerenciadorMovimentacaoConta : IGerenciadorMovimentacaoConta
    {
        private static IGerenciadorMovimentacaoConta gMovimentacaoConta;
        private static tb_movimentacao_contaTableAdapter tb_movimentacao_contaTA;
        
        public static IGerenciadorMovimentacaoConta getInstace()
        {
            if (gMovimentacaoConta == null)
            {
                gMovimentacaoConta = new GerenciadorMovimentacaoConta();
                tb_movimentacao_contaTA = new tb_movimentacao_contaTableAdapter();
            }
            return gMovimentacaoConta;
        }

        public void inserir(MovimentacaoConta movimentacaoConta)
        {
            try
            {
                tb_movimentacao_contaTA.Insert(movimentacaoConta.CodTipoMovimentacao, movimentacaoConta.Valor.ToString(),
                    movimentacaoConta.DataHora, movimentacaoConta.CodResponsavel, movimentacaoConta.CodContaBanco,
                    movimentacaoConta.CodPagamento);
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
        }

        public void atualizar(MovimentacaoConta movimentacaoConta)
        {
            try
            {
                tb_movimentacao_contaTA.Update(movimentacaoConta.CodTipoMovimentacao, movimentacaoConta.Valor,
                    movimentacaoConta.DataHora, movimentacaoConta.CodResponsavel, movimentacaoConta.CodContaBanco,
                    movimentacaoConta.CodPagamento, movimentacaoConta.CodMovimentacao);
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
        }

        public void remover(Int64 codMovimentacaoConta)
        {
            try
            {
                tb_movimentacao_contaTA.Delete(codMovimentacaoConta);
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
        }
    }
}
