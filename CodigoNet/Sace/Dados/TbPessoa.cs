using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbPessoa
    {
        public TbPessoa()
        {
            TbCartaoCreditos = new HashSet<TbCartaoCredito>();
            TbConta = new HashSet<TbContum>();
            TbEntradumCodEmpresaFreteNavigations = new HashSet<TbEntradum>();
            TbEntradumCodFornecedorNavigations = new HashSet<TbEntradum>();
            TbLojas = new HashSet<TbLoja>();
            TbMovimentacaoConta = new HashSet<TbMovimentacaoContum>();
            TbProdutos = new HashSet<TbProduto>();
            TbSaidumCodClienteNavigations = new HashSet<TbSaidum>();
            TbSaidumCodEmpresaFreteNavigations = new HashSet<TbSaidum>();
            TbSaidumCodProfissionalNavigations = new HashSet<TbSaidum>();
            CodPessoas = new HashSet<TbPessoa>();
            CodigoEmpresas = new HashSet<TbPessoa>();
        }

        public long CodPessoa { get; set; }
        public string Nome { get; set; } = null!;
        public string? CpfCnpj { get; set; }
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public int CodMunicipiosIbge { get; set; }
        public string? Cidade { get; set; }
        public string? Complemento { get; set; }
        public string? Cep { get; set; }
        public string? Uf { get; set; }
        public string? Fone1 { get; set; }
        public string? Fone2 { get; set; }
        public decimal? LimiteCompra { get; set; }
        public decimal? ValorComissao { get; set; }
        public string? Observacao { get; set; }
        public string Tipo { get; set; } = null!;
        /// <summary>
        /// InscriÃƒÂ§ÃƒÂ£o Estadual da empresa
        /// </summary>
        public string? Ie { get; set; }
        public string? IeSubstituto { get; set; }
        /// <summary>
        /// Telefone para contato 3
        /// </summary>
        public string? Fone3 { get; set; }
        public string? Email { get; set; }
        public bool EhFabricante { get; set; }
        public bool? ImprimirDav { get; set; }
        public bool ImprimirCf { get; set; }
        public string? NomeFantasia { get; set; }
        public bool BloquearCrediario { get; set; }

        public virtual TbMunicipiosIbge CodMunicipiosIbgeNavigation { get; set; } = null!;
        public virtual TbUsuario? TbUsuario { get; set; }
        public virtual ICollection<TbCartaoCredito> TbCartaoCreditos { get; set; }
        public virtual ICollection<TbContum> TbConta { get; set; }
        public virtual ICollection<TbEntradum> TbEntradumCodEmpresaFreteNavigations { get; set; }
        public virtual ICollection<TbEntradum> TbEntradumCodFornecedorNavigations { get; set; }
        public virtual ICollection<TbLoja> TbLojas { get; set; }
        public virtual ICollection<TbMovimentacaoContum> TbMovimentacaoConta { get; set; }
        public virtual ICollection<TbProduto> TbProdutos { get; set; }
        public virtual ICollection<TbSaidum> TbSaidumCodClienteNavigations { get; set; }
        public virtual ICollection<TbSaidum> TbSaidumCodEmpresaFreteNavigations { get; set; }
        public virtual ICollection<TbSaidum> TbSaidumCodProfissionalNavigations { get; set; }

        public virtual ICollection<TbPessoa> CodPessoas { get; set; }
        public virtual ICollection<TbPessoa> CodigoEmpresas { get; set; }
    }
}
