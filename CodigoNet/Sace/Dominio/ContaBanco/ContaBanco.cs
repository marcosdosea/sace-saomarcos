namespace Dominio
{
    public class ContaBanco
    {
        public int CodContaBanco { get; set;}
        public string? NumeroConta { get; set; }
        public string? Agencia { get; set; }
        public string? Descricao{ get; set; }
        public decimal Saldo { get; set; }
        public int CodBanco { get; set; }
        public string? NomeBanco { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodContaBanco == ((ContaBanco)obj).CodContaBanco;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodContaBanco.GetHashCode();
        }
    }
}
