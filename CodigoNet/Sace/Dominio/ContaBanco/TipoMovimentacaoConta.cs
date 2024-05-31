namespace Dominio
{
    public class TipoMovimentacaoConta
    {
        public const int RECEBIMENTO_CLIENTE = 1;
        public const int PAGAMENTO_FORNECEDOR = 2;
        public const int TROCO = 3;
        public const int DEVOLUCAO_CLIENTE = 4;
        public const int RECEBIMENTO_CREDIARIO = 5;
        public const int ABERTURA_DIARIA_CONTA = 6;
        public const int TRANSFERENCIA_PARA_CONTA = 7;
        public const int RECEBIMENTO_TRANSFERENCIA = 8;
        public const int AJUSTE_SALDO = 9;
        public const int RECEBIMENTO_CREDITO = 10;
       
        public int CodTipoMovimentacao { get; set;  }
        public string? Descricao { get; set; }
        public bool SomaSaldo { get; set; }
    }
}
