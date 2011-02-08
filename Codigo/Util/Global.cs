
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public static class Global
    {
        public static int
        PRODUTOS = 1,
        PESSOAS = 2,
        EMPRESAS = 3,
        LOJAS = 4,
        BANCOS = 5,
        PLANO_DE_CONTAS = 6,
        CONTAS_BANCO_CAIXA = 7,
        CARTÕES_DE_CREDITO = 8,
        GRUPOS_DE_PRODUTOS = 9,
        GRUPOS_DE_CONTAS = 10,
        USUARIOS = 11,
        SAIDA = 12,
        PEDIDOS = 13,
        ENTRADA_PRODUTOS = 14,
        TRANFORMACOES = 15,
        CONTAS_PAGAR = 16,
        CONTAS_RECEBER = 17,
        BAIXAS = 18,
        MOVIMENTACAO_CONTAS = 19,
        ATUALIZAÇÃO_PREÇOS = 20,
        AJUSTE_ESTOQUE = 21,
        CONFIGURAÇÕES_SISTEMA = 22,
        BACKUP = 23,
        RELATORIO_CLIENTE = 24,
        RELATORIO_LISTAGEM_PRECOS = 25,
        RELATORIO_ESTOQUE = 26,
        RELATORIO_VENDAS = 27,
        RELATORIO_COMPRAS = 28,
        RELATORIO_CONTAS = 29,
        LOJA_PADRAO = 1,
        CLIENTE_PADRAO = 1,
        PROFISSIONAL_PADRAO = 1,
        VENDA_NORMAL = 5102,
        VENDA_ST = 5403,
        SAIDA_PRE_VENDA = 1,
        SAIDA_ORCAMENTO = 2,
        SAIDA_DEPOSITO = 3,
        SAIDA_CONSUMO_INTERNO = 4;



        public static Char
            FISCAL = 'F',
            AUXILIAR = 'A';
            
        public static Decimal
            ACRESCIMO_PADRAO = (decimal) 1.111111,
            DESCONTO_PADRAO = (decimal) 0.9;
    }
}
