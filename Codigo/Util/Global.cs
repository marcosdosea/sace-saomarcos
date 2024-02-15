using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public static class Global
    {

        public const int
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
        DEPOSITO_PADRAO = 2,
        CLIENTE_PADRAO = 1,
        PROFISSIONAL_PADRAO = 1,
        ENTRADA_PADRAO = 1,
        SAIDA_PADRAO = 1,
        VENDA_NORMAL = 5102,
        VENDA_ST = 5403,
        VENDA_OUTRAS = 9999,
        QUANTIDADE_DIAS_CREDIARIO = 30,
        DOCUMENTO_PADRAO = 1,
        CAIXA_PADRAO = 1,
        CARTAO_LOJA = 1,
        QUANTIDADE_EXIBIR_PEDIDOS = 100,
        CARTAO_BANESECARD_CREDITO = 5,
        CARTAO_PIX = 11;

        public enum Impressora { REDUZIDO1, REDUZIDO2 };

        public static System.Drawing.Color
            BACKCOLOR_FOCUS = System.Drawing.Color.LightYellow,
            BACKCOLOR_FOCUS_LEAVE = System.Drawing.Color.White;

        public const Decimal
            ACRESCIMO_PADRAO = (decimal)1.111111,
            DESCONTO_PADRAO = (decimal)10,
            SIMPLES = (decimal)11.0,  // para mercadorias tributação normal
            ICMS_LOCAL = (decimal)18;

        public static String chaveNFe = "";

        public const String
         AMBIENTE_NFE = "1", //1-PRODUÇÃO, 2- HOMOLOGAÇÃO
         C_ORGAO_IBGE_SERGIPE = "28",
         ENDERECO_SERVIDOR = "C:\\",

         LINHA_COMPRIMIDA = "==========================================",
         NFE_MENSAGEM_PADRAO = "DOCUMENTO EMITIDO POR ME OU EPP OPTANTE PELO SIMPLES NACIONAL. NÃO GERA DIREITO A CRÉDITO FISCAL DE IPI.",

        PASTA_COMUNICACAO_PRODUTOS_ATUALIZADOS = "C:\\Dropbox\\SACE\\ProdutosAtualizados\\";
    }
}