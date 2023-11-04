namespace Dominio
{
    public class Subgrupo
    {
        public int CodSubgrupo { get; set; }
        public string Descricao { get; set; }
        public int CodGrupo { get; set; }
        public string DescricaoGrupo { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.CodSubgrupo == ((Subgrupo)obj).CodSubgrupo;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodSubgrupo.GetHashCode();
        }
    }
}
