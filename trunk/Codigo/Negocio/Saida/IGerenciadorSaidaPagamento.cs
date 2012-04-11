using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorSaidaPagamento
    {
        decimal totalPagamentos(Int64 codSaida);

        List<SaidaPagamento> obterSaidaPagamentos(Int64 codSaida);

        List<SaidaPagamento> obterSaidaPagamentosPorFormaPagamento(Int64 codSaida, Int32 codFormaPagamento);

        Int64 inserir(SaidaPagamento saidaPagamento);
        void atualizar(SaidaPagamento saidaPagamento);
        void remover(Int64 codSaidaPagamento, Saida saida);
    }
}