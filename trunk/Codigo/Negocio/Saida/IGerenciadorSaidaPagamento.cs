﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorSaidaPagamento: IGerenciadorNegocio<SaidaPagamento, Int64>
    {
        decimal totalPagamentos(Int64 codSaida);

        List<SaidaPagamento> obterSaidaPagamentos(Int64 codSaida);

        List<SaidaPagamento> obterSaidaPagamentosPorFormaPagamento(Int64 codSaida, Int32 codFormaPagamento);

    }
}