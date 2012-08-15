using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorConta: IGerenciadorNegocio<Conta, Int64>
    {

        List<Conta> obterContasPorEntada(Int64 codEntrada);
        List<Conta> obterContasPorSaida(Int64 codSaida);
        List<Conta> obterContasEntradaPorCodPagamento(Int64 codEntrada, Int64 codPagamento);
        List<Conta> obterContasSaidaPorCodPagamento(Int64 codSaida, Int64 codPagamento);


        Dados.saceDataSetConsultas.ContasPessoaDataTable ObterContasPorPessoaSituacaoPeriodo(Int64 codPessoa, List<char> situacoes, DateTime dataInicial, DateTime dataFinal);
        
    }
}
