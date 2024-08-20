namespace Dominio
{
    public class GrupoConta
    {
        public int CodGrupoConta { get; set;  }
        public string Descricao { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodGrupoConta == ((GrupoConta)obj).CodGrupoConta;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodGrupoConta.GetHashCode();
        }
    }
}
