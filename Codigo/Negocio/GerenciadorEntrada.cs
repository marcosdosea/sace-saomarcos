using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SACE.Negocio
{
    public static class GerenciadorEntrada
    {
        public static void excluirProdutoEntrada(long codEntrada, long codProduto)
        {
            try
            {
                    //SACE.Dados.saceDataSet.tb_entrada_produtoDataTable.
                    
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public static void inserirProdutoEntrada(long codEntrada, long codProduto)
        {
            try
            {
                //SACE.Dados.saceDataSet.tb_entrada_produtoTableAdapter.Delete(codEntrada, codProduto);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
