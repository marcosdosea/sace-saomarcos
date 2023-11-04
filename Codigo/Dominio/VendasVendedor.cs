namespace Dominio
{
    public class VendasVendedor
    {
        public long CodProfissional { get; set; }
        public string Login { get; set; }
        public decimal? TotalVendas { get; set; } = 0;
        public decimal? TotalLucro { get; set; } = 0;
        public decimal? PercentualVendas { get; set; } = 0;
        public decimal? PercentualLucro { get; set; } = 0;
    }
}
