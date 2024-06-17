namespace Dominio
{
    public class VendasCartao
    {
        public int CodCartao { get; set; }
        public long CodSaida { get; set; }
        public string DescricaoCartao { get; set; }
        public string TipoCartao { get; set; }
        public int Parcelas { get; set; }
        public decimal TotalCartao { get; set; }
        public string NumeroControle { get; set; }
    }
}
