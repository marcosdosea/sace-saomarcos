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
    public class GerenciadorEntrada : IGerenciadorEntrada
    {
        private static IGerenciadorEntrada gEntrada;
        private static tb_entradaTableAdapter tb_entradaTA;
        
        
        public static IGerenciadorEntrada getInstace()
        {
            if (gEntrada == null)
            {
                gEntrada = new GerenciadorEntrada();
                tb_entradaTA = new tb_entradaTableAdapter();
            }
            return gEntrada;
        }

        public void inserir(Entrada entrada)
        {
            try
            {
                tb_entradaTA.Insert(entrada.CodEmpresaFrete, entrada.CodFornecedor, entrada.ValorCustoFrete.ToString(),
                    entrada.DataEntrada, entrada.ValorTotal.ToString(), entrada.TipoEntrada.ToString(),
                    entrada.NumeroNotaFiscal, entrada.ValorICMSSubstituto.ToString(),
                    entrada.ICMSPadrao.ToString());
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        public void atualizar(Entrada entrada)
        {
            try
            {
                tb_entradaTA.Update(entrada.CodEmpresaFrete, entrada.CodFornecedor, entrada.ValorCustoFrete,
                    entrada.DataEntrada, entrada.ValorTotal, entrada.TipoEntrada.ToString(),
                    entrada.NumeroNotaFiscal, entrada.ValorICMSSubstituto,
                    entrada.ICMSPadrao, entrada.CodEntrada);
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        public void remover(Int32 codEntrada)
        {
            try
            {
                tb_entradaTA.Delete(codEntrada);
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }
    }
}
