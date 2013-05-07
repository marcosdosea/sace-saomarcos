using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Pessoa
    {
        public const string PESSOA_FISICA = "F";
        public const string PESSOA_JURIDICA = "J";

        public long CodPessoa { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string IeSubstituto { get; set; }
        public string Ie { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Email { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Fone3 { get; set; }
        public decimal LimiteCompra { get; set; }
        public decimal ValorComissao { get; set; }
        public string Observacao { get; set; }
        public string Tipo { get; set; }
        public bool EhFabricante { get; set; }
        public bool ImprimirCF { get; set; }
        public bool ImprimirDAV { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.CodPessoa == ((Pessoa)obj).CodPessoa;    
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodPessoa.GetHashCode();
        }


        public int CodMunicipioIBGE { get; set; }
        public string NomeMunicipioIBGE { get; set; }
    }
}
