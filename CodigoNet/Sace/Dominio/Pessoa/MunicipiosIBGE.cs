namespace Dominio
{
    public class MunicipiosIBGE
    {
        public int Codigo { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
       
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Codigo == ((MunicipiosIBGE)obj).Codigo;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }
    }
}
