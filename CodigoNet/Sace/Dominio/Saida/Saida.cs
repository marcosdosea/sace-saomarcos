namespace Dominio
{
    public class Saida : SaidaPesquisa
    {
        public const string TIPO_DOCUMENTO_ECF  = "ECF";
        public const string TIPO_DOCUMENTO_NFCE = "NFCE";

        public const int TIPO_ORCAMENTO = 1;
        public const int TIPO_PRE_VENDA = 2;
        public const int TIPO_VENDA = 3;

        public const int TIPO_PRE_CREDITO = 17;
        public const int TIPO_CREDITO = 18;

        public const int TIPO_PRE_REMESSA_DEPOSITO = 9;
        public const int TIPO_REMESSA_DEPOSITO = 4;

        public const int TIPO_PRE_DEVOLUCAO_FORNECEDOR = 10;
        public const int TIPO_DEVOLUCAO_FORNECEDOR = 7;

        public const int TIPO_PRE_RETORNO_FORNECEDOR = 22;
        public const int TIPO_RETORNO_FORNECEDOR = 23;

        public const int TIPO_PRE_DEVOLUCAO_CONSUMIDOR = 14;
        public const int TIPO_DEVOLUCAO_CONSUMIDOR = 15;
        

        public const int TIPO_RETORNO_DEPOSITO = 11;
        public const int TIPO_PRE_RETORNO_DEPOSITO = 12;

        public const int TIPO_REMESSA_CONSERTO = 6;
        public const int TIPO_PRE_REMESSA_CONSERTO = 13;

        public const int TIPO_USO_INTERNO = 5;

        public const int TIPO_BAIXA_ESTOQUE_PERDA = 21;

        public static List<int> LISTA_TIPOS_REMESSA_CONSERTO = new List<int>() { Saida.TIPO_PRE_REMESSA_CONSERTO, Saida.TIPO_REMESSA_CONSERTO };
        public static List<int> LISTA_TIPOS_REMESSA_DEPOSITO = new List<int>() { Saida.TIPO_PRE_REMESSA_DEPOSITO, Saida.TIPO_REMESSA_DEPOSITO };
        public static List<int> LISTA_TIPOS_RETORNO_DEPOSITO = new List<int>() { Saida.TIPO_PRE_RETORNO_DEPOSITO, Saida.TIPO_RETORNO_DEPOSITO };
        public static List<int> LISTA_TIPOS_DEVOLUCAO_FORNECEDOR = new List<int>() { Saida.TIPO_PRE_DEVOLUCAO_FORNECEDOR, Saida.TIPO_DEVOLUCAO_FORNECEDOR };
        public static List<int> LISTA_TIPOS_RETORNO_FORNECEDOR = new List<int>() { Saida.TIPO_PRE_RETORNO_FORNECEDOR, Saida.TIPO_RETORNO_FORNECEDOR };
        public static List<int> LISTA_TIPOS_DEVOLUCAO_CONSUMIDOR = new List<int>() { Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR, Saida.TIPO_DEVOLUCAO_CONSUMIDOR };
        public static List<int> LISTA_TIPOS_VENDA = new List<int>() { Saida.TIPO_ORCAMENTO, Saida.TIPO_PRE_VENDA, Saida.TIPO_VENDA, Saida.TIPO_CREDITO, Saida.TIPO_PRE_CREDITO };


        public int CodLojaOrigem { get; set; }
        public string CpfCnpj { get; set; }
        public string TipoDocumentoFiscal { get; set; }
        public long CodProfissional { get; set; }
        public long CodEntrada { get; set; }
        public int NumeroCartaoVenda { get; set; }
        public DateTime DataEmissaoCupomFiscal { get; set; }
        public decimal Total { get; set; }
        public decimal Desconto { get; set; }
        public decimal TotalPago { get; set; }
        public decimal TotalLucro { get; set; }
        public decimal Troco { get; set; }
        public Boolean EntregaRealizada { get; set; }
        public string Nfe { get; set; }
        public decimal BaseCalculoICMS { get; set; }
        public decimal ValorICMS { get; set; }
        public decimal BaseCalculoICMSSubst { get; set; }
        public decimal ValorICMSSubst { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal OutrasDespesas { get; set; }
        public decimal ValorIPI { get; set; }
        public decimal TotalNotaFiscal { get; set; }
        public decimal QuantidadeVolumes { get; set; }
        public string EspecieVolumes { get; set; }
        public string Marca { get; set; }
        public decimal Numero { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
        public long CodEmpresaFrete { get; set; }
        public string DescricaoTipoSaida { get; set; }
        public string DescricaoSituacaoPagamentos { get; set; }
        public string Observacao { get; set; }
        public string LoginVendedor { get; set;  }
        public string NumeroECF { get { return "01"; } }
    }
}