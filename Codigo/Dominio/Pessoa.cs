using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Pessoa
    {
        public const String PESSOA_FISICA = "F";
        public const String PESSOA_JURIDICA = "J";

        public Int64 CodPessoa { get; set; }
        public String Nome { get; set; }
        public String CpfCnpj { get; set; }
        public String IeSubstituto { get; set; }
        public String Ie { get; set; }
        public String Endereco { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Cep { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Uf { get; set; }
        public String Email { get; set; }
        public String Fone1 { get; set; }
        public String Fone2 { get; set; }
        public String Fone3 { get; set; }
        public Decimal LimiteCompra { get; set; }
        public Decimal ValorComissao { get; set; }
        public String Observacao { get; set; }
        public Char Tipo { get; set; }
        public bool EhFabricante { get; set; }
        public bool ImprimirCF { get; set; }
        public bool ImprimirDAV { get; set; }
    }
}
