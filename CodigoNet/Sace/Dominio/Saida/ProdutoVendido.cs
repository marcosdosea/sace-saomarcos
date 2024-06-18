namespace Dominio
{
    public class ProdutoVendido
    {
        public long CodProduto { get; set; }
        public string Nome { get; set; }
        public decimal QuantidadeVendida { get; set; }
        public string MesAno { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}
