namespace Dominio
{
    public class SolicitacoesCompra
    {
        public long CodProduto { get; set; }
        public string Nome { get; set; }
        public string? ReferenciaFabricante { get; set; }
        public string Unidade { get; set; }
        public DateTime DataSolicitacaoCompra { get; set; }
        public DateTime DataPedidoCompra { get; set; }
        public sbyte CodSituacaoProduto { get; set; }
    }
}
