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
        QUANTIDADE_EXIBIR_PEDIDOS = 100;


        public enum Impressora { NORMAL, DARUMA, BEMATECH };

        public static System.Drawing.Color
            BACKCOLOR_FOCUS = System.Drawing.Color.LightYellow,
            BACKCOLOR_FOCUS_LEAVE = System.Drawing.Color.White;

        public static Decimal
            ACRESCIMO_PADRAO = (decimal)1.111111,
            DESCONTO_PADRAO = (decimal) 10,
            SIMPLES = (decimal)8.0,
            ICMS_LOCAL = (decimal)19,
            CUSTO_MANUTENCAO_LOJA = 0;

        public static String
         AMBIENTE_NFE = "1", //1-PRODUÇÃO, 2- HOMOLOGAÇÃO
         C_ORGAO_IBGE_SERGIPE = "28",
         ENDERECO_SERVIDOR = "C:\\",
         PASTA_COMUNICACAO_CARTAO = ENDERECO_SERVIDOR + "MKS\\CAIXA1\\CUPONS",
         PASTA_COMUNICACAO_FRENTE_LOJA = ENDERECO_SERVIDOR + "MKS\\PEDIDOS\\",
         PASTA_COMUNICACAO_FRENTE_LOJA_RETORNO = ENDERECO_SERVIDOR + "MKS\\CAIXA\\Retorno\\",
         PASTA_COMUNICACAO_FRENTE_LOJA_BACKUP = ENDERECO_SERVIDOR + "MKS\\CAIXA\\BACKUP\\",

         PASTA_COMUNICACAO_NFCE_RECEBER  = ENDERECO_SERVIDOR + "MKS\\CaixaTerceiro\\Receber\\",
         PASTA_COMUNICACAO_NFCE_DEVOLVER = ENDERECO_SERVIDOR + "MKS\\CaixaTerceiro\\Devolver\\",
         PASTA_COMUNICACAO_NFCE_XML = ENDERECO_SERVIDOR + "MKS\\CaixaTerceiro\\XmlProducao\\",

         PASTA_COMUNICACAO_TEF_REQUISICAO = ENDERECO_SERVIDOR + "MKS\\TefMKS\\Requisicao\\",
         PASTA_COMUNICACAO_TEF_RETORNO = ENDERECO_SERVIDOR + "MKS\\TefMKS\\Retorno\\",


         PORTA_IMPRESSORA_NORMAL = "LPT1",
         PORTA_IMPRESSORA_REDUZIDA = "\\\\SERVIDOR\\Bematech",
         PORTA_IMPRESSORA_REDUZIDA2 = "\\\\SM-VENDAS01\\Daruma",
         LINHA = "================================================================================",
         LINHA_COMPRIMIDA = "============================================================",
         NFE_MENSAGEM_PADRAO = "DOCUMENTO EMITIDO POR ME OU EPP OPTANTE PELO SIMPLES NACIONAL. NÃO GERA DIREITO A CRÉDITO FISCAL DE IPI.";
        
    }
}