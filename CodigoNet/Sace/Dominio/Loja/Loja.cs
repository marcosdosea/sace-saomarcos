namespace Dominio
{
    public class Loja
    {
        public int CodLoja { get; set; }
        public string Nome { get; set; }
        public long CodPessoa { get; set; }
        public string NomePessoa { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public int CodMunicipioIBGE { get; set; }
        public string Estado { get; set; }
        public string NomeServidorNfe { get; set; }
        public string PastaNfeValidar { get; set; }
        public string PastaNfeValidado { get; set; }
        public string PastaNfeEnvio { get; set; }
        public string PastaNfeEnviado { get; set; }
        public string PastaNfeRetorno { get; set; }
        public string PastaNfeErro { get; set; }
        public string PastaNfeAutorizados { get; set; }
        public string PastaNfeEspelho { get; set; }
        public int NumeroSequenciaNFeAtual { get; set; }
        public int NumeroSequenciaNFCeAtual { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodLoja == ((Loja)obj).CodLoja;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodLoja.GetHashCode();
        }
    }
}
