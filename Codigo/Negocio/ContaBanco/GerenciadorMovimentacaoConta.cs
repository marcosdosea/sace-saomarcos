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

        public Int64 inserir(MovimentacaoConta movimentacaoConta)
        {
            try
            {
                tb_movimentacao_contaTA.Insert(movimentacaoConta.CodContaBanco,
                    movimentacaoConta.CodResponsavel, movimentacaoConta.CodTipoMovimentacao,
                    movimentacaoConta.CodConta, movimentacaoConta.Valor.ToString(), movimentacaoConta.DataHora);

                TipoMovimentacaoConta tipoMovimentacaoConta = GerenciadorTipoMovimentacaoConta.getInstace().obterTipoMovimentacaoConta(movimentacaoConta.CodTipoMovimentacao);

                if (tipoMovimentacaoConta.SomaSaldo)
                {
                    GerenciadorContaBanco.getInstace().atualizaSaldo(movimentacaoConta.CodContaBanco, movimentacaoConta.Valor);
                }
                else
                {
                    GerenciadorContaBanco.getInstace().atualizaSaldo(movimentacaoConta.CodContaBanco, movimentacaoConta.Valor * (-1));
                }

                return 0;
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
                tb_movimentacao_contaTA.Update(movimentacaoConta.CodContaBanco,
                    movimentacaoConta.CodResponsavel, movimentacaoConta.CodTipoMovimentacao,
                    movimentacaoConta.CodContaBanco, movimentacaoConta.Valor, 
                    movimentacaoConta.DataHora, movimentacaoConta.CodMovimentacao);
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
                MovimentacaoConta movimentacaoConta = obterMovimentacaoConta(codMovimentacaoConta);
                tb_movimentacao_contaTA.Delete(codMovimentacaoConta);

                if (movimentacaoConta.SomaSaldo)
                {
                    GerenciadorContaBanco.getInstace().atualizaSaldo(movimentacaoConta.CodContaBanco, movimentacaoConta.Valor * (-1));
                }
                else
                {
                    GerenciadorContaBanco.getInstace().atualizaSaldo(movimentacaoConta.CodContaBanco, movimentacaoConta.Valor);
                }

            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
        }

        public void removerMovimentacoesConta(Conta conta)
        {
            List<MovimentacaoConta> movimentosConta = obterMovimentacaoConta(conta);

            foreach (MovimentacaoConta movimento in movimentosConta)
            {
                remover(movimento.CodMovimentacao);
            }
        }

        public List<MovimentacaoConta> obterMovimentacaoConta(Conta conta)
        {
            tb_movimentacao_contaTableAdapter tb_movimentacaoTA = new tb_movimentacao_contaTableAdapter();
            Dados.saceDataSet.tb_movimentacao_contaDataTable movimentacaoDT = tb_movimentacaoTA.GetDataByCodConta(conta.CodConta);

            return converterListaMovimentacaoConta(movimentacaoDT);
        }
        public MovimentacaoConta obterMovimentacaoConta(Int64 codMovimentacaoConta)
        {
            tb_movimentacao_contaTableAdapter tb_movimentacaoTA = new tb_movimentacao_contaTableAdapter();
            Dados.saceDataSet.tb_movimentacao_contaDataTable movimentacaoDT = tb_movimentacaoTA.GetDataByCodMovimentacao(codMovimentacaoConta);

            return converterListaMovimentacaoConta(movimentacaoDT)[0];
        }

        private List<MovimentacaoConta> converterListaMovimentacaoConta(Dados.saceDataSet.tb_movimentacao_contaDataTable movimentacaoDT)
        {
            List<MovimentacaoConta> contas = new List<MovimentacaoConta>();
            for (int i = 0; i < movimentacaoDT.Rows.Count; i++)
            {
                MovimentacaoConta movimentacaoConta = new MovimentacaoConta();
                movimentacaoConta.CodConta = Convert.ToInt32(movimentacaoDT.Rows[0]["codConta"].ToString());
                movimentacaoConta.CodContaBanco = Convert.ToInt32(movimentacaoDT.Rows[0]["codContaBanco"].ToString());
                movimentacaoConta.CodMovimentacao = Convert.ToInt64(movimentacaoDT.Rows[0]["codMovimentacao"].ToString());
                movimentacaoConta.CodResponsavel = Convert.ToInt32(movimentacaoDT.Rows[0]["codResponsavel"].ToString());
                movimentacaoConta.CodTipoMovimentacao = Convert.ToInt32(movimentacaoDT.Rows[0]["codTipoMovimentacao"].ToString());
                movimentacaoConta.DataHora = Convert.ToDateTime(movimentacaoDT.Rows[0]["dataHora"].ToString());
                movimentacaoConta.SomaSaldo = Convert.ToBoolean(movimentacaoDT.Rows[0]["somaSaldo"].ToString());
                movimentacaoConta.Valor = Convert.ToDecimal(movimentacaoDT.Rows[0]["valor"].ToString());

                contas.Add(movimentacaoConta);
            }

            return contas;
        }
    }
}
