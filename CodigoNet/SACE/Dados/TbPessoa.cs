using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbPessoa
    {
        public long CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public int CodMunicipiosIbge { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public decimal? LimiteCompra { get; set; }
        public decimal? ValorComissao { get; set; }
        public string Observacao { get; set; }
        public string Tipo { get; set; }
        public string Ie { get; set; }
        public string IeSubstituto { get; set; }
        public string Fone3 { get; set; }
        public string Email { get; set; }
        public bool EhFabricante { get; set; }
        public bool? ImprimirDav { get; set; }
        public bool ImprimirCf { get; set; }
        public string NomeFantasia { get; set; }
        public bool BloquearCrediario { get; set; }
    }
}
