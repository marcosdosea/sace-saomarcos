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
    public class GerenciadorSaida : IGerenciadorSaida
    {
        private static IGerenciadorSaida gSaida;
        private static tb_saidaTableAdapter tb_SaidaTA;
        
        public static IGerenciadorSaida getInstace()
        {
            if (gSaida == null)
            {
                gSaida = new GerenciadorSaida();
                tb_SaidaTA = new tb_saidaTableAdapter();
            }
            return gSaida;
        }

        public void inserir(Saida saida)
        {
            try
            {
                tb_SaidaTA.Insert(saida.DataSaida, saida.CodCliente, saida.TipoSaida, saida.CodProfissional,
                    saida.NumeroCartaoVenda, saida.PedidoGerado, saida.Total.ToString(), saida.Desconto.ToString(),
                    saida.TotalPago.ToString(), saida.TotalLucro.ToString());
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        public void atualizar(Saida saida)
        {
            try
            {
                tb_SaidaTA.Update(saida.DataSaida, saida.CodCliente, saida.TipoSaida, saida.CodProfissional,
                    saida.NumeroCartaoVenda, saida.PedidoGerado, saida.Total, saida.Desconto,
                    saida.TotalPago, saida.TotalLucro, saida.CodSaida);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        public void remover(Int32 codSaida)
        {
            try
            {
                tb_SaidaTA.Delete(codSaida);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        public Saida obterSaida(Int64 codSaida)
        {
            Saida saida = new Saida();
            Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTA = new tb_saidaTableAdapter();
            Dados.saceDataSet.tb_saidaDataTable saidaDT = tb_saidaTA.GetDataByCodSaida(codSaida);

            saida.CodSaida = codSaida;
            saida.DataSaida = DateTime.Parse(saidaDT.Rows[0]["dataSaida"].ToString());
            saida.TipoSaida = int.Parse(saidaDT.Rows[0]["tipoSaida"].ToString());
            saida.CodCliente = long.Parse(saidaDT.Rows[0]["codCliente"].ToString());
            saida.CodProfissional = long.Parse(saidaDT.Rows[0]["codProfissional"].ToString());
            saida.NumeroCartaoVenda = int.Parse(saidaDT.Rows[0]["numeroCartaoVenda"].ToString());
            saida.PedidoGerado = saidaDT.Rows[0]["pedidoGerado"].ToString();
            saida.Desconto = decimal.Parse(saidaDT.Rows[0]["desconto"].ToString());
            saida.Total = decimal.Parse(saidaDT.Rows[0]["total"].ToString());
            saida.TotalLucro = decimal.Parse(saidaDT.Rows[0]["totalLucro"].ToString());
            saida.TotalPago = decimal.Parse(saidaDT.Rows[0]["totalPago"].ToString());
            return saida;
        }
    }
}
