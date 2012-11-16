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
    public class GerenciadorTipoMovimentacaoConta
    {
        private static GerenciadorTipoMovimentacaoConta gTipoMovimentacaoConta;
        private static tb_tipo_movimentacao_contaTableAdapter tb_tipoMovimentacaoContaTA;
        
        public static GerenciadorTipoMovimentacaoConta getInstace()
        {
            if (gTipoMovimentacaoConta == null)
            {
                gTipoMovimentacaoConta = new GerenciadorTipoMovimentacaoConta();
                tb_tipoMovimentacaoContaTA = new tb_tipo_movimentacao_contaTableAdapter();
            }
            return gTipoMovimentacaoConta;
        }

        public Int64 inserir(TipoMovimentacaoConta tipoMovimentacaoConta)
        {
            try
            {
                tb_tipoMovimentacaoContaTA.Insert(tipoMovimentacaoConta.Descricao, tipoMovimentacaoConta.SomaSaldo);
                return 0;
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
                tb_tipoMovimentacaoContaTA.Update(tipoMovimentacaoConta.Descricao, tipoMovimentacaoConta.SomaSaldo, tipoMovimentacaoConta.CodTipoMovimentacao);
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

        public TipoMovimentacaoConta obterTipoMovimentacaoConta(Int32 codTipoMovimentacaoConta)
        {
            TipoMovimentacaoConta tipoMovimentacaoConta = new TipoMovimentacaoConta();

            tb_tipo_movimentacao_contaTableAdapter tb_tipomcTA = new tb_tipo_movimentacao_contaTableAdapter();
            Dados.saceDataSet.tb_tipo_movimentacao_contaDataTable tipomcDT = tb_tipomcTA.GetDataByCodTipoMovimentacao(codTipoMovimentacaoConta);

            tipoMovimentacaoConta.CodTipoMovimentacao = Convert.ToInt32(tipomcDT.Rows[0]["codTipoMovimentacao"].ToString());
            tipoMovimentacaoConta.Descricao = tipomcDT.Rows[0]["descricao"].ToString();
            tipoMovimentacaoConta.SomaSaldo = Convert.ToBoolean(tipomcDT.Rows[0]["somaSaldo"].ToString());

            return tipoMovimentacaoConta;
        }
    }
}
