namespace Dominio
{
    public class SaidaProdutoRelatorio
    {
        public long CodSaidaProduto { get; set; }
        public long CodProduto { get; set; }
        public string Nome { get; set; }
        public long CodSaida { get; set; }
        public long CodCliente { get; set;}
        public DateTime DataSaida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorVendaAVista { get; set; }
        public decimal TotalSaida { get; set; }
        public decimal TotalSaidaAVista { get; set; }
        public decimal Desconto { get; set; }
        public string Pedido { get; set; }
        public decimal Subtotal { get; set; }
        public decimal SubtotalAVista { get; set; }
        public string Unidade { get; set; }
    }
}