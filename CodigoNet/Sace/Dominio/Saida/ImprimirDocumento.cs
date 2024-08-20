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

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.CodImprimir == ((ImprimirDocumento)obj).CodImprimir;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodImprimir.GetHashCode();
        }
    }
}
