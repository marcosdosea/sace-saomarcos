﻿using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSaidum
    {
        public TbSaidum()
        {
            TbConta = new HashSet<TbContum>();
            TbSaidaFormaPagamentos = new HashSet<TbSaidaFormaPagamento>();
            TbSaidaProdutos = new HashSet<TbSaidaProduto>();
            TbSolicitacaoSaida = new HashSet<TbSolicitacaoSaidum>();
            CodAutorizacaos = new HashSet<TbAutorizacaoCartao>();
            CodImprimirs = new HashSet<TbImprimirDocumento>();
            CodNves = new HashSet<TbNfe>();
        }

        public long CodSaida { get; set; }
        public DateTime DataSaida { get; set; }
        public long CodCliente { get; set; }
        public int CodTipoSaida { get; set; }
        public int CodLojaOrigem { get; set; }
        public long? CodProfissional { get; set; }
        public int? NumeroCartaoVenda { get; set; }
        public string? PedidoGerado { get; set; }
        public DateTime? DataEmissaoDocFiscal { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalAvista { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? TotalPago { get; set; }
        public decimal? TotalLucro { get; set; }
        public string? CpfCnpj { get; set; }
        public int CodSituacaoPagamentos { get; set; }
        public decimal? Troco { get; set; }
        public bool? EntregaRealizada { get; set; }
        public string? Nfe { get; set; }
        public decimal? BaseCalculoIcms { get; set; }
        public decimal? ValorIcms { get; set; }
        public decimal? BaseCalculoIcmssubst { get; set; }
        public decimal? ValorIcmssubst { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? ValorSeguro { get; set; }
        public decimal? OutrasDespesas { get; set; }
        public decimal? ValorIpi { get; set; }
        public decimal? TotalNotaFiscal { get; set; }
        public decimal? QuantidadeVolumes { get; set; }
        public string? EspecieVolumes { get; set; }
        public string? Marca { get; set; }
        public decimal? Numero { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
        public long CodEmpresaFrete { get; set; }
        public string Observacao { get; set; } = null!;
        public long CodEntrada { get; set; }
        public string TipoDocumentoFiscal { get; set; } = null!;

        public virtual TbPessoa CodClienteNavigation { get; set; } = null!;
        public virtual TbPessoa CodEmpresaFreteNavigation { get; set; } = null!;
        public virtual TbEntradum CodEntradaNavigation { get; set; } = null!;
        public virtual TbLoja CodLojaOrigemNavigation { get; set; } = null!;
        public virtual TbPessoa? CodProfissionalNavigation { get; set; }
        public virtual TbSituacaoPagamento CodSituacaoPagamentosNavigation { get; set; } = null!;
        public virtual TbTipoSaidum CodTipoSaidaNavigation { get; set; } = null!;
        public virtual ICollection<TbContum> TbConta { get; set; }
        public virtual ICollection<TbSaidaFormaPagamento> TbSaidaFormaPagamentos { get; set; }
        public virtual ICollection<TbSaidaProduto> TbSaidaProdutos { get; set; }
        public virtual ICollection<TbSolicitacaoSaidum> TbSolicitacaoSaida { get; set; }

        public virtual ICollection<TbAutorizacaoCartao> CodAutorizacaos { get; set; }
        public virtual ICollection<TbImprimirDocumento> CodImprimirs { get; set; }
        public virtual ICollection<TbNfe> CodNves { get; set; }
    }
}
