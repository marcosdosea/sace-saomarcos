namespace Dominio
{
    public class ImprimirDocumento
    {
        public long CodImprimir { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public long CodDocumento { get; set; }
        public string HostSolicitante { get; set; } = null!;
        public decimal? Total { get; set; }
        public decimal? TotalAvista { get; set; }
        public decimal? Desconto { get; set; }
    }
}
