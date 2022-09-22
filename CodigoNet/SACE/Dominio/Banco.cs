namespace Dominio
{
    public class Banco
    {
        public int CodBanco { get; set; }
        public string Nome { get; set; }

     
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodBanco.Equals(((Banco) obj).CodBanco);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodBanco.GetHashCode();
        }
    }
}
