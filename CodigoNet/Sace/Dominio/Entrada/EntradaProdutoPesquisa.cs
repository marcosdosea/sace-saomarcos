namespace Dominio
{
    public class EntradaProdutoPesquisa
    {
        public long CodEntradaProduto { get; set; }
        public long CodEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
        public string NomeFornecedor {  get; set; }
        public string CodCST { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal PrecoCusto { get; set; }
    }
}
