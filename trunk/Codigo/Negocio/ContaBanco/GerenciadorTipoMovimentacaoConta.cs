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
    public class GerenciadorTipoMovimentacaoConta: IGerenciadorTipoMovimentacaoConta
    {
        private static IGerenciadorTipoMovimentacaoConta gTipoMovimentacaoConta;
        private static tb_tipo_movimentacao_contaTableAdapter tb_tipoMovimentacaoContaTA;
        
        public static IGerenciadorTipoMovimentacaoConta getInstace()
        {
            if (gTipoMovimentacaoConta == null)
            {
                gTipoMovimentacaoConta = new GerenciadorTipoMovimentacaoConta();
                tb_tipoMovimentacaoContaTA = new tb_tipo_movimentacao_contaTableAdapter();
            }
            return gTipoMovimentacaoConta;
        }

        public void inserir(TipoMovimentacaoConta tipoMovimentacaoConta)
        {
            try
            {
                tb_tipoMovimentacaoContaTA.Insert(tipoMovimentacaoConta.Descricao);
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }

        public void atualizar(TipoMovimentacaoConta tipoMovimentacaoConta)
        {
            try
            {
                tb_tipoMovimentacaoContaTA.Update(tipoMovimentacaoConta.Descricao, tipoMovimentacaoConta.CodTipoMovimentacao);
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }

        public void remover(Int32 codTipoMovimentacaoConta)
        {
            try
            {
                tb_tipoMovimentacaoContaTA.Delete(codTipoMovimentacaoConta);
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }
    }
}
