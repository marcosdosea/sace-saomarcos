using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        private string pastaNfeEnvio;
        public string PastaNfeEnvio 
        {
            get { return pastaNfeEnvio; }
            set { pastaNfeEnvio = value; }
        }
        private string pastaNfeEnviado;
        public string PastaNfeEnviado
        {
            get { return pastaNfeEnviado; }
            set { pastaNfeEnviado = value; }
        }

        private string pastaNfeRetorno;
        public string PastaNfeRetorno
        {
            get { return pastaNfeRetorno; }
            set { pastaNfeRetorno = value; }
        }

        private string pastaNfeErro;
        public string PastaNfeErro
        {
            get { return pastaNfeErro; }
            set { pastaNfeErro = value; }
        }

        private string pastaNfeAutorizados;
        public string PastaNfeAutorizados
        {
            get { return pastaNfeAutorizados; }
            set { pastaNfeAutorizados = value; }
        }

        private string pastaNfeEspelho;
        public string PastaNfeEspelho
        {
            get { return pastaNfeEspelho; }
            set { pastaNfeEspelho = value; }
        }
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
