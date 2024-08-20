namespace Dominio
{
    public class Grupo
    {
        public long CodGrupo { get; set; }
        public string Descricao { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodGrupo == ((Grupo)obj).CodGrupo;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodGrupo.GetHashCode();
        }
    }
}
