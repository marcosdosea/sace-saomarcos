using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorMovimentacaoConta : IGerenciadorNegocio<MovimentacaoConta, Int64>
    {

        MovimentacaoConta obterMovimentacaoConta(Int64 codMovimentacaoConta);
        List<MovimentacaoConta> obterMovimentacaoConta(Conta conta);
        void removerMovimentacoesConta(Conta conta);
        Dados.saceDataSet.tb_movimentacao_contaDataTable ObterMovimentacaoPorContas(List<Int64> listaCodContas);
        
    }
}
