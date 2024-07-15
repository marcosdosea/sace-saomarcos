using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Util;

namespace Dados
{
    public partial class SaceContext : DbContext
    {
        public SaceContext()
        {
        }

        public SaceContext(DbContextOptions<SaceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAutorizacaoCartao> TbAutorizacaoCartaos { get; set; } = null!;
        public virtual DbSet<TbBanco> TbBancos { get; set; } = null!;
        public virtual DbSet<TbCartaoCredito> TbCartaoCreditos { get; set; } = null!;
        public virtual DbSet<TbCfop> TbCfops { get; set; } = null!;
        public virtual DbSet<TbContaBanco> TbContaBancos { get; set; } = null!;
        public virtual DbSet<TbContum> TbConta { get; set; } = null!;
        public virtual DbSet<TbCst> TbCsts { get; set; } = null!;
        public virtual DbSet<TbDocumentoFiscal> TbDocumentoFiscals { get; set; } = null!;
        public virtual DbSet<TbEntradaFormaPagamento> TbEntradaFormaPagamentos { get; set; } = null!;
        public virtual DbSet<TbEntradaProduto> TbEntradaProdutos { get; set; } = null!;
        public virtual DbSet<TbEntradum> TbEntrada { get; set; } = null!;
        public virtual DbSet<TbFormaPagamento> TbFormaPagamentos { get; set; } = null!;
        public virtual DbSet<TbFuncionalidade> TbFuncionalidades { get; set; } = null!;
        public virtual DbSet<TbGrupo> TbGrupos { get; set; } = null!;
        public virtual DbSet<TbGrupoContum> TbGrupoConta { get; set; } = null!;
        public virtual DbSet<TbImposto> TbImpostos { get; set; } = null!;
        public virtual DbSet<TbImprimirDocumento> TbImprimirDocumentos { get; set; } = null!;
        public virtual DbSet<TbLoja> TbLojas { get; set; } = null!;
        public virtual DbSet<TbMovimentacaoContum> TbMovimentacaoConta { get; set; } = null!;
        public virtual DbSet<TbMunicipiosIbge> TbMunicipiosIbges { get; set; } = null!;
        public virtual DbSet<TbNfe> TbNves { get; set; } = null!;
        public virtual DbSet<TbPerfil> TbPerfils { get; set; } = null!;
        public virtual DbSet<TbPermissao> TbPermissaos { get; set; } = null!;
        public virtual DbSet<TbPessoa> TbPessoas { get; set; } = null!;
        public virtual DbSet<TbPlanoContum> TbPlanoConta { get; set; } = null!;
        public virtual DbSet<TbPontaEstoque> TbPontaEstoques { get; set; } = null!;
        public virtual DbSet<TbProduto> TbProdutos { get; set; } = null!;
        public virtual DbSet<TbProdutoLoja> TbProdutoLojas { get; set; } = null!;
        public virtual DbSet<TbSaidaFormaPagamento> TbSaidaFormaPagamentos { get; set; } = null!;
        public virtual DbSet<TbSaidaPedido> TbSaidaPedidos { get; set; } = null!;
        public virtual DbSet<TbSaidaProduto> TbSaidaProdutos { get; set; } = null!;
        public virtual DbSet<TbSaidum> TbSaida { get; set; } = null!;
        public virtual DbSet<TbSituacaoContum> TbSituacaoConta { get; set; } = null!;
        public virtual DbSet<TbSituacaoPagamento> TbSituacaoPagamentos { get; set; } = null!;
        public virtual DbSet<TbSituacaoProduto> TbSituacaoProdutos { get; set; } = null!;
        public virtual DbSet<TbSolicitacaoDocumento> TbSolicitacaoDocumentos { get; set; } = null!;
        public virtual DbSet<TbSolicitacaoEventoNfe> TbSolicitacaoEventoNves { get; set; } = null!;
        public virtual DbSet<TbSolicitacaoPagamento> TbSolicitacaoPagamentos { get; set; } = null!;
        public virtual DbSet<TbSolicitacaoSaidum> TbSolicitacaoSaida { get; set; } = null!;
        public virtual DbSet<TbSubgrupo> TbSubgrupos { get; set; } = null!;
        public virtual DbSet<TbTipoContum> TbTipoConta { get; set; } = null!;
        public virtual DbSet<TbTipoMovimentacaoContum> TbTipoMovimentacaoConta { get; set; } = null!;
        public virtual DbSet<TbTipoSaidum> TbTipoSaida { get; set; } = null!;
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; } = null!;
        public virtual DbSet<TpTipoEntradum> TpTipoEntrada { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(UtilConfig.Default.SaceConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAutorizacaoCartao>(entity =>
            {
                entity.HasKey(e => e.CodAutorizacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_autorizacao_cartao");

                entity.Property(e => e.CodAutorizacao)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("codAutorizacao");

                entity.Property(e => e.AutorizacaoTransacao)
                    .HasMaxLength(6)
                    .HasColumnName("autorizacaoTransacao")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CodIdentificacao)
                    .HasColumnType("bigint(10)")
                    .HasColumnName("codIdentificacao");

                entity.Property(e => e.CupomFiscal)
                    .HasMaxLength(10)
                    .HasColumnName("cupomFiscal");

                entity.Property(e => e.DataHoraAutorizacao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataHoraAutorizacao");

                entity.Property(e => e.Header)
                    .HasMaxLength(5)
                    .HasColumnName("header");

                entity.Property(e => e.NomeBandeiraCartao)
                    .HasMaxLength(45)
                    .HasColumnName("nomeBandeiraCartao");

                entity.Property(e => e.NsuTransacao)
                    .HasColumnType("bigint(10)")
                    .HasColumnName("nsuTransacao");

                entity.Property(e => e.Processado).HasColumnName("processado");

                entity.Property(e => e.QuantidadeParcelas)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantidadeParcelas");

                entity.Property(e => e.StatusTransacao)
                    .HasMaxLength(10)
                    .HasColumnName("statusTransacao");

                entity.Property(e => e.TipoDocumentoFiscal)
                    .HasColumnType("enum('ECF','NFCE')")
                    .HasColumnName("tipoDocumentoFiscal")
                    .HasDefaultValueSql("'ECF'");

                entity.Property(e => e.TipoParcelamento)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipoParcelamento");

                entity.Property(e => e.TipoTransacao)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipoTransacao");

                entity.Property(e => e.Valor)
                    .HasPrecision(10)
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<TbBanco>(entity =>
            {
                entity.HasKey(e => e.CodBanco)
                    .HasName("PRIMARY");

                entity.ToTable("tb_banco");

                entity.HasIndex(e => e.Nome, "idx_uq_tb_banco_nome")
                    .IsUnique();

                entity.Property(e => e.CodBanco)
                    .HasColumnType("int(8)")
                    .HasColumnName("codBanco");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TbCartaoCredito>(entity =>
            {
                entity.HasKey(e => e.CodCartao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cartao_credito");

                entity.HasIndex(e => e.CodPessoa, "fk_tb_cartao_credito_tb_pessoa1_idx");

                entity.HasIndex(e => e.CodContaBanco, "idx_fk_tb_cartao_credito_codcontabanco");

                entity.HasIndex(e => e.Nome, "idx_uq_tb_cartao_credito_nome")
                    .IsUnique();

                entity.Property(e => e.CodCartao)
                    .HasColumnType("int(8)")
                    .HasColumnName("codCartao");

                entity.Property(e => e.CodContaBanco)
                    .HasColumnType("int(20)")
                    .HasColumnName("codContaBanco");

                entity.Property(e => e.CodPessoa)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPessoa");

                entity.Property(e => e.Desconto)
                    .HasPrecision(10)
                    .HasColumnName("desconto");

                entity.Property(e => e.DiaBase)
                    .HasColumnType("int(8)")
                    .HasColumnName("diaBase");

                entity.Property(e => e.Mapeamento)
                    .HasMaxLength(2)
                    .HasColumnName("mapeamento");

                entity.Property(e => e.MapeamentoCappta)
                    .HasMaxLength(45)
                    .HasColumnName("mapeamentoCappta")
                    .HasDefaultValueSql("'MASTERCARD'");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.TipoCartao)
                    .HasColumnType("enum('DEBITO','CREDITO','CREDIARIO')")
                    .HasColumnName("tipoCartao")
                    .HasDefaultValueSql("'CREDITO'");

                entity.HasOne(d => d.CodContaBancoNavigation)
                    .WithMany(p => p.TbCartaoCreditos)
                    .HasForeignKey(d => d.CodContaBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_cartao_credito_codcontabanco");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithMany(p => p.TbCartaoCreditos)
                    .HasForeignKey(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_cartao_credito_tb_pessoa1");
            });

            modelBuilder.Entity<TbCfop>(entity =>
            {
                entity.HasKey(e => e.Cfop)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cfop");

                entity.Property(e => e.Cfop)
                    .HasColumnType("int(8)")
                    .HasColumnName("cfop");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");

                entity.Property(e => e.Icms)
                    .HasPrecision(5)
                    .HasColumnName("icms");
            });

            modelBuilder.Entity<TbContaBanco>(entity =>
            {
                entity.HasKey(e => e.CodContaBanco)
                    .HasName("PRIMARY");

                entity.ToTable("tb_conta_banco");

                entity.HasIndex(e => e.CodBanco, "idx_fk_tb_conta_banco_codbanco");

                entity.HasIndex(e => e.Descricao, "idx_uq_tb_conta_banco_descricao")
                    .IsUnique();

                entity.HasIndex(e => new { e.Numeroconta, e.Agencia }, "idx_uq_tb_conta_banco_numeroconta_agencia")
                    .IsUnique();

                entity.Property(e => e.CodContaBanco)
                    .HasColumnType("int(20)")
                    .HasColumnName("codContaBanco");

                entity.Property(e => e.Agencia)
                    .HasMaxLength(10)
                    .HasColumnName("agencia");

                entity.Property(e => e.CodBanco)
                    .HasColumnType("int(8)")
                    .HasColumnName("codBanco");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(30)
                    .HasColumnName("descricao");

                entity.Property(e => e.Numeroconta)
                    .HasMaxLength(20)
                    .HasColumnName("numeroconta");

                entity.Property(e => e.Saldo)
                    .HasPrecision(10)
                    .HasColumnName("saldo");

                entity.HasOne(d => d.CodBancoNavigation)
                    .WithMany(p => p.TbContaBancos)
                    .HasForeignKey(d => d.CodBanco)
                    .HasConstraintName("fk_tb_conta_banco_codbanco");
            });

            modelBuilder.Entity<TbContum>(entity =>
            {
                entity.HasKey(e => e.CodConta)
                    .HasName("PRIMARY");

                entity.ToTable("tb_conta");

                entity.HasIndex(e => e.CodSituacao, "fk_tb_conta_tb_situacao_conta1_idx");

                entity.HasIndex(e => e.DataVencimento, "idx_dataVencimento");

                entity.HasIndex(e => e.CodEntrada, "idx_fk_tb_conta_codentrada");

                entity.HasIndex(e => e.CodPessoa, "idx_fk_tb_conta_codpessoa");

                entity.HasIndex(e => e.CodPlanoConta, "idx_fk_tb_conta_codplanoconta");

                entity.HasIndex(e => e.CodSaida, "idx_fk_tb_conta_codsaida");

                entity.Property(e => e.CodConta)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codConta");

                entity.Property(e => e.CodEntrada)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEntrada");

                entity.Property(e => e.CodPagamento)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPagamento");

                entity.Property(e => e.CodPessoa)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPessoa");

                entity.Property(e => e.CodPlanoConta)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPlanoConta");

                entity.Property(e => e.CodSaida)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codSaida");

                entity.Property(e => e.CodSituacao)
                    .HasMaxLength(1)
                    .HasColumnName("codSituacao")
                    .IsFixedLength();

                entity.Property(e => e.DataVencimento)
                    .HasColumnType("date")
                    .HasColumnName("dataVencimento");

                entity.Property(e => e.Desconto)
                    .HasPrecision(10)
                    .HasColumnName("desconto");

                entity.Property(e => e.FormatoConta)
                    .HasColumnType("enum('FICHA','BOLETO','CARTAO','CHEQUE','CREDITO')")
                    .HasColumnName("formatoConta")
                    .HasDefaultValueSql("'FICHA'");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(45)
                    .HasColumnName("numeroDocumento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(200)
                    .HasColumnName("observacao");

                entity.Property(e => e.Valor)
                    .HasPrecision(10)
                    .HasColumnName("valor");

                entity.HasOne(d => d.CodEntradaNavigation)
                    .WithMany(p => p.TbConta)
                    .HasForeignKey(d => d.CodEntrada)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_tb_conta_pagar_codentrada");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithMany(p => p.TbConta)
                    .HasForeignKey(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_conta_pagar_codpessoa");

                entity.HasOne(d => d.CodPlanoContaNavigation)
                    .WithMany(p => p.TbConta)
                    .HasForeignKey(d => d.CodPlanoConta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_conta_pagar_codplanoconta");

                entity.HasOne(d => d.CodSaidaNavigation)
                    .WithMany(p => p.TbConta)
                    .HasForeignKey(d => d.CodSaida)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_tb_conta_pagar_codsaida");

                entity.HasOne(d => d.CodSituacaoNavigation)
                    .WithMany(p => p.TbConta)
                    .HasForeignKey(d => d.CodSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_conta_tb_situacao_conta1");
            });

            modelBuilder.Entity<TbCst>(entity =>
            {
                entity.HasKey(e => e.CodCst)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cst");

                entity.Property(e => e.CodCst)
                    .HasMaxLength(4)
                    .HasColumnName("codCST")
                    .IsFixedLength();

                entity.Property(e => e.DescricaoCst)
                    .HasMaxLength(100)
                    .HasColumnName("descricaoCST");
            });

            modelBuilder.Entity<TbDocumentoFiscal>(entity =>
            {
                entity.HasKey(e => e.NumeroDocumentoFiscal)
                    .HasName("PRIMARY");

                entity.ToTable("tb_documento_fiscal");

                entity.Property(e => e.NumeroDocumentoFiscal)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("numeroDocumentoFiscal");

                entity.Property(e => e.DataSoliciticao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataSoliciticao");

                entity.Property(e => e.Situacao)
                    .HasColumnType("enum('SOLICITADO','CANCELADO','AUTORIZADO')")
                    .HasColumnName("situacao")
                    .HasDefaultValueSql("'SOLICITADO'");
            });

            modelBuilder.Entity<TbEntradaFormaPagamento>(entity =>
            {
                entity.HasKey(e => e.CodEntradaFormaPagamento)
                    .HasName("PRIMARY");

                entity.ToTable("tb_entrada_forma_pagamento");

                entity.HasIndex(e => e.CodContaBanco, "fk_tb_entrada_forma_pagamento_tb_conta_banco1");

                entity.HasIndex(e => e.CodEntrada, "fk_tb_entrada_has_tb_forma_pagamento_tb_entrada1_idx");

                entity.HasIndex(e => e.CodFormaPagamento, "fk_tb_entrada_has_tb_forma_pagamento_tb_forma_pagamento1_idx");

                entity.Property(e => e.CodEntradaFormaPagamento)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEntradaFormaPagamento");

                entity.Property(e => e.CodContaBanco)
                    .HasColumnType("int(20)")
                    .HasColumnName("codContaBanco");

                entity.Property(e => e.CodEntrada)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEntrada");

                entity.Property(e => e.CodFormaPagamento)
                    .HasColumnType("int(8)")
                    .HasColumnName("codFormaPagamento");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.PagamentoDoFrete)
                    .HasColumnName("pagamentoDoFrete")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Valor)
                    .HasPrecision(10)
                    .HasColumnName("valor");

                entity.HasOne(d => d.CodEntradaNavigation)
                    .WithMany(p => p.TbEntradaFormaPagamentos)
                    .HasForeignKey(d => d.CodEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_has_tb_forma_pagamento_tb_entrada1");

                entity.HasOne(d => d.CodFormaPagamentoNavigation)
                    .WithMany(p => p.TbEntradaFormaPagamentos)
                    .HasForeignKey(d => d.CodFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_has_tb_forma_pagamento_tb_forma_pagamento1");
            });

            modelBuilder.Entity<TbEntradaProduto>(entity =>
            {
                entity.HasKey(e => e.CodEntradaProduto)
                    .HasName("PRIMARY");

                entity.ToTable("tb_entrada_produto");

                entity.HasIndex(e => e.Cfop, "fk_tb_entrada_produto_tb_cfop1_idx");

                entity.HasIndex(e => e.CodCst, "fk_tb_entrada_produto_tb_cst1_idx");

                entity.HasIndex(e => e.CodEntrada, "idx_fk_tb_entrada_produto_codentrada");

                entity.HasIndex(e => e.CodProduto, "idx_fk_tb_entrada_produto_codproduto");

                entity.Property(e => e.CodEntradaProduto)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEntradaProduto");

                entity.Property(e => e.BaseCalculoIcms)
                    .HasPrecision(10)
                    .HasColumnName("baseCalculoICMS");

                entity.Property(e => e.BaseCalculoIcmsst)
                    .HasPrecision(10)
                    .HasColumnName("baseCalculoICMSST");

                entity.Property(e => e.Cfop)
                    .HasColumnType("int(8)")
                    .HasColumnName("cfop");

                entity.Property(e => e.CodCst)
                    .HasMaxLength(4)
                    .HasColumnName("codCST")
                    .IsFixedLength();

                entity.Property(e => e.CodEntrada)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEntrada");

                entity.Property(e => e.CodProduto)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codProduto");

                entity.Property(e => e.DataValidade)
                    .HasColumnType("date")
                    .HasColumnName("data_validade");

                entity.Property(e => e.Desconto)
                    .HasPrecision(10)
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PrecoCusto)
                    .HasPrecision(10)
                    .HasColumnName("preco_custo");

                entity.Property(e => e.Quantidade)
                    .HasPrecision(10)
                    .HasColumnName("quantidade");

                entity.Property(e => e.QuantidadeDisponivel)
                    .HasPrecision(10)
                    .HasColumnName("quantidade_disponivel")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Os produtos vendidos na loja incrementam esse valor atÃƒÂ© que o nÃƒÂºmero de vendidos seja igual ao de comprados.\n");

                entity.Property(e => e.QuantidadeEmbalagem)
                    .HasPrecision(10)
                    .HasColumnName("quantidadeEmbalagem")
                    .HasDefaultValueSql("'1.00'");

                entity.Property(e => e.UnidadeCompra)
                    .HasMaxLength(6)
                    .HasColumnName("unidadeCompra");

                entity.Property(e => e.ValorIcms)
                    .HasPrecision(10)
                    .HasColumnName("valorICMS");

                entity.Property(e => e.ValorIcmsst)
                    .HasPrecision(10)
                    .HasColumnName("valorICMSST");

                entity.Property(e => e.ValorIpi)
                    .HasPrecision(10)
                    .HasColumnName("valorIPI");

                entity.Property(e => e.ValorTotal)
                    .HasPrecision(10)
                    .HasColumnName("valorTotal");

                entity.Property(e => e.ValorUnitario)
                    .HasPrecision(10)
                    .HasColumnName("valorUnitario");

                entity.HasOne(d => d.CfopNavigation)
                    .WithMany(p => p.TbEntradaProdutos)
                    .HasForeignKey(d => d.Cfop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_produto_tb_cfop1");

                entity.HasOne(d => d.CodCstNavigation)
                    .WithMany(p => p.TbEntradaProdutos)
                    .HasForeignKey(d => d.CodCst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_produto_tb_cst1");

                entity.HasOne(d => d.CodEntradaNavigation)
                    .WithMany(p => p.TbEntradaProdutos)
                    .HasForeignKey(d => d.CodEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_produto_codentrada");

                entity.HasOne(d => d.CodProdutoNavigation)
                    .WithMany(p => p.TbEntradaProdutos)
                    .HasForeignKey(d => d.CodProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_produto_codproduto");
            });

            modelBuilder.Entity<TbEntradum>(entity =>
            {
                entity.HasKey(e => e.CodEntrada)
                    .HasName("PRIMARY");

                entity.ToTable("tb_entrada");

                entity.HasIndex(e => e.CodFornecedor, "fk_tb_entrada_codfornecedor_idx");

                entity.HasIndex(e => e.CodSituacaoPagamentos, "fk_tb_entrada_tb_situacao_pagamentos1_idx");

                entity.HasIndex(e => e.CodTipoEntrada, "fk_tb_entrada_tp_tipo_entrada1_idx");

                entity.HasIndex(e => e.CodEmpresaFrete, "idx_fk_tb_empresa_codigoempresafrete");

                entity.HasIndex(e => new { e.NumeroNotaFiscal, e.CodFornecedor }, "idx_unq_codEntrada_numeroNotaFiscal")
                    .IsUnique();

                entity.Property(e => e.CodEntrada)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEntrada");

                entity.Property(e => e.Chave)
                    .HasMaxLength(44)
                    .HasColumnName("chave")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CodEmpresaFrete)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEmpresaFrete");

                entity.Property(e => e.CodFornecedor)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codFornecedor");

                entity.Property(e => e.CodSituacaoPagamentos)
                    .HasColumnType("int(11)")
                    .HasColumnName("codSituacaoPagamentos");

                entity.Property(e => e.CodTipoEntrada)
                    .HasColumnType("int(11)")
                    .HasColumnName("codTipoEntrada");

                entity.Property(e => e.DataEmissao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataEmissao");

                entity.Property(e => e.DataEntrada)
                    .HasColumnType("datetime")
                    .HasColumnName("dataEntrada");

                entity.Property(e => e.Desconto)
                    .HasPrecision(10)
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.FretePagoEmitente).HasColumnName("fretePagoEmitente");

                entity.Property(e => e.NumeroNotaFiscal)
                    .HasMaxLength(20)
                    .HasColumnName("numeroNotaFiscal");

                entity.Property(e => e.OutrasDespesas)
                    .HasPrecision(10)
                    .HasColumnName("outrasDespesas")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Serie)
                    .HasMaxLength(20)
                    .HasColumnName("serie")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TotalBaseCalculo)
                    .HasPrecision(10)
                    .HasColumnName("totalBaseCalculo")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalBaseSubstituicao)
                    .HasPrecision(10)
                    .HasColumnName("totalBaseSubstituicao")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalIcms)
                    .HasPrecision(10)
                    .HasColumnName("totalICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalIpi)
                    .HasPrecision(10)
                    .HasColumnName("totalIPI")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalNota)
                    .HasPrecision(10)
                    .HasColumnName("totalNota")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalProdutos)
                    .HasPrecision(10)
                    .HasColumnName("totalProdutos")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalProdutosSt)
                    .HasPrecision(10)
                    .HasColumnName("totalProdutosST")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalSubstituicao)
                    .HasPrecision(10)
                    .HasColumnName("totalSubstituicao")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorFrete)
                    .HasPrecision(10)
                    .HasColumnName("valorFrete")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorSeguro)
                    .HasPrecision(10)
                    .HasColumnName("valorSeguro")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.CodEmpresaFreteNavigation)
                    .WithMany(p => p.TbEntradumCodEmpresaFreteNavigations)
                    .HasForeignKey(d => d.CodEmpresaFrete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_codempresafrete");

                entity.HasOne(d => d.CodFornecedorNavigation)
                    .WithMany(p => p.TbEntradumCodFornecedorNavigations)
                    .HasForeignKey(d => d.CodFornecedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_codfornecedor");

                entity.HasOne(d => d.CodSituacaoPagamentosNavigation)
                    .WithMany(p => p.TbEntrada)
                    .HasForeignKey(d => d.CodSituacaoPagamentos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_tb_situacao_pagamentos1");

                entity.HasOne(d => d.CodTipoEntradaNavigation)
                    .WithMany(p => p.TbEntrada)
                    .HasForeignKey(d => d.CodTipoEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_entrada_tp_tipo_entrada1");
            });

            modelBuilder.Entity<TbFormaPagamento>(entity =>
            {
                entity.HasKey(e => e.CodFormaPagamento)
                    .HasName("PRIMARY");

                entity.ToTable("tb_forma_pagamento");

                entity.Property(e => e.CodFormaPagamento)
                    .HasColumnType("int(8)")
                    .HasColumnName("codFormaPagamento");

                entity.Property(e => e.DescontoAcrescimo)
                    .HasPrecision(4)
                    .HasColumnName("descontoAcrescimo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");

                entity.Property(e => e.Mapeamento)
                    .HasMaxLength(2)
                    .HasColumnName("mapeamento");

                entity.Property(e => e.Parcelas)
                    .HasColumnType("int(3)")
                    .HasColumnName("parcelas")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<TbFuncionalidade>(entity =>
            {
                entity.HasKey(e => e.CodFuncionalidade)
                    .HasName("PRIMARY");

                entity.ToTable("tb_funcionalidade");

                entity.Property(e => e.CodFuncionalidade)
                    .HasColumnType("int(8)")
                    .HasColumnName("codFuncionalidade");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(30)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<TbGrupo>(entity =>
            {
                entity.HasKey(e => e.CodGrupo)
                    .HasName("PRIMARY");

                entity.ToTable("tb_grupo");

                entity.HasIndex(e => e.Descricao, "idx_uq_tb_grupo_descricao")
                    .IsUnique();

                entity.Property(e => e.CodGrupo)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codGrupo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<TbGrupoContum>(entity =>
            {
                entity.HasKey(e => e.CodGrupoConta)
                    .HasName("PRIMARY");

                entity.ToTable("tb_grupo_conta");

                entity.HasIndex(e => e.Descricao, "idx_uq_tb_grupo_conta_descricao")
                    .IsUnique();

                entity.Property(e => e.CodGrupoConta)
                    .HasColumnType("int(8)")
                    .HasColumnName("codGrupoConta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<TbImposto>(entity =>
            {
                entity.HasKey(e => e.Ncmsh)
                    .HasName("PRIMARY");

                entity.ToTable("tb_imposto");

                entity.HasIndex(e => e.Ncmsh, "idImposto_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Ncmsh)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("NCMSH");

                entity.Property(e => e.AliqImp)
                    .HasPrecision(10)
                    .HasColumnName("aliqImp");

                entity.Property(e => e.AliqNac)
                    .HasPrecision(10)
                    .HasColumnName("aliqNac");
            });

            modelBuilder.Entity<TbImprimirDocumento>(entity =>
            {
                entity.HasKey(e => e.CodImprimir)
                    .HasName("PRIMARY");

                entity.ToTable("tb_imprimir_documento");

                entity.HasIndex(e => new { e.TipoDocumento, e.CodDocumento }, "tipoDocumento_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CodImprimir)
                    .HasColumnType("bigint(10)")
                    .HasColumnName("codImprimir");

                entity.Property(e => e.CodDocumento)
                    .HasColumnType("bigint(10)")
                    .HasColumnName("codDocumento");

                entity.Property(e => e.Desconto)
                    .HasPrecision(10)
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.HostSolicitante)
                    .HasMaxLength(45)
                    .HasColumnName("hostSolicitante")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnType("enum('NFCE','NFE','REDUZIDO1','REDUZIDO2')")
                    .HasColumnName("tipoDocumento")
                    .HasDefaultValueSql("'NFCE'");

                entity.Property(e => e.Total)
                    .HasPrecision(10)
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalAvista)
                    .HasPrecision(10)
                    .HasColumnName("totalAVista")
                    .HasDefaultValueSql("'0.00'");

                entity.HasMany(d => d.CodSaida)
                    .WithMany(p => p.CodImprimirs)
                    .UsingEntity<Dictionary<string, object>>(
                        "TbImprimirDocumentoSaidum",
                        l => l.HasOne<TbSaidum>().WithMany().HasForeignKey("CodSaida").HasConstraintName("fk_tb_imprimir_documento_has_tb_saida_tb_saida1"),
                        r => r.HasOne<TbImprimirDocumento>().WithMany().HasForeignKey("CodImprimir").HasConstraintName("fk_tb_imprimir_documento_has_tb_saida_tb_imprimir_documento1"),
                        j =>
                        {
                            j.HasKey("CodImprimir", "CodSaida").HasName("PRIMARY");

                            j.ToTable("tb_imprimir_documento_saida");

                            j.HasIndex(new[] { "CodImprimir" }, "fk_tb_imprimir_documento_has_tb_saida_tb_imprimir_documento_idx");

                            j.HasIndex(new[] { "CodSaida" }, "fk_tb_imprimir_documento_has_tb_saida_tb_saida1_idx");

                            j.IndexerProperty<long>("CodImprimir").HasColumnType("bigint(10)").HasColumnName("codImprimir");

                            j.IndexerProperty<long>("CodSaida").HasColumnType("bigint(19)").HasColumnName("codSaida");
                        });
            });

            modelBuilder.Entity<TbLoja>(entity =>
            {
                entity.HasKey(e => e.CodLoja)
                    .HasName("PRIMARY");

                entity.ToTable("tb_loja");

                entity.HasIndex(e => e.CodPessoa, "fk_tb_loja_tb_pessoa1_idx");

                entity.HasIndex(e => e.Nome, "idx_uq_tb_loja_nome")
                    .IsUnique();

                entity.Property(e => e.CodLoja)
                    .HasColumnType("int(8)")
                    .HasColumnName("codLoja");

                entity.Property(e => e.CodPessoa)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPessoa");

                entity.Property(e => e.EnderecoServidorNfe)
                    .HasMaxLength(100)
                    .HasColumnName("enderecoServidorNfe")
                    .HasDefaultValueSql("'\\\\\\\\retaguarda\\\\'");

                entity.Property(e => e.Nome)
                    .HasMaxLength(40)
                    .HasColumnName("nome");

                entity.Property(e => e.NomeServidorNfe)
                    .HasMaxLength(100)
                    .HasColumnName("nomeServidorNfe")
                    .HasDefaultValueSql("'RETAGUARDA'");

                entity.Property(e => e.NumeroSequenciaNfeAtual)
                    .HasColumnType("int(8)")
                    .HasColumnName("numeroSequenciaNfeAtual");

                entity.Property(e => e.NumeroSequencialNfceAtual)
                    .HasColumnType("int(8)")
                    .HasColumnName("numeroSequencialNFCeAtual");

                entity.Property(e => e.PastaNfeAutorizados)
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeAutorizados")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Enviado\\\\Autorizados\\\\'");

                entity.Property(e => e.PastaNfeEnviado)
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeEnviado")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Enviado\\\\'");

                entity.Property(e => e.PastaNfeEnvio)
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeEnvio")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Envio\\\\'");

                entity.Property(e => e.PastaNfeErro)
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeErro")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Erro\\\\'");

                entity.Property(e => e.PastaNfeEspelho)
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeEspelho")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Espelho\\\\'");

                entity.Property(e => e.PastaNfeRetorno)
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeRetorno")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Retorno\\\\'");

                entity.Property(e => e.PastaNfeValidado)
                    .HasMaxLength(150)
                    .HasColumnName("pastaNfeValidado")
                    .HasDefaultValueSql("'c:\\\\Unimake\\\\UniNFe\\\\32799603000191\\\\Validar\\\\Validado\\\\'");

                entity.Property(e => e.PastaNfeValidar)
                    .HasMaxLength(150)
                    .HasColumnName("pastaNfeValidar")
                    .HasDefaultValueSql("'c:\\\\Unimake\\\\UniNFe\\\\32799603000191\\\\Validar\\\\'");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithMany(p => p.TbLojas)
                    .HasForeignKey(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_loja_tb_pessoa1");
            });

            modelBuilder.Entity<TbMovimentacaoContum>(entity =>
            {
                entity.HasKey(e => e.CodMovimentacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_movimentacao_conta");

                entity.HasIndex(e => e.CodConta, "fk_tb_movimentacao_conta_tb_conta1_idx");

                entity.HasIndex(e => e.DataHora, "idx_dataHora");

                entity.HasIndex(e => e.CodContaBanco, "idx_fk_tb_movimentacao_conta_codcontabanco");

                entity.HasIndex(e => e.CodResponsavel, "idx_fk_tb_movimentacao_conta_codresponsavel");

                entity.HasIndex(e => e.CodTipoMovimentacao, "idx_fk_tb_movimentacao_conta_codtipomovimentacao");

                entity.Property(e => e.CodMovimentacao)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codMovimentacao");

                entity.Property(e => e.CodConta)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codConta");

                entity.Property(e => e.CodContaBanco)
                    .HasColumnType("int(20)")
                    .HasColumnName("codContaBanco");

                entity.Property(e => e.CodResponsavel)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codResponsavel");

                entity.Property(e => e.CodTipoMovimentacao)
                    .HasColumnType("int(8)")
                    .HasColumnName("codTipoMovimentacao");

                entity.Property(e => e.DataHora)
                    .HasColumnType("datetime")
                    .HasColumnName("dataHora");

                entity.Property(e => e.Valor)
                    .HasPrecision(10)
                    .HasColumnName("valor");

                entity.HasOne(d => d.CodContaNavigation)
                    .WithMany(p => p.TbMovimentacaoConta)
                    .HasForeignKey(d => d.CodConta)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_tb_movimentacao_conta_tb_conta1");

                entity.HasOne(d => d.CodContaBancoNavigation)
                    .WithMany(p => p.TbMovimentacaoConta)
                    .HasForeignKey(d => d.CodContaBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_movimentacao_conta_codcontabanco");

                entity.HasOne(d => d.CodResponsavelNavigation)
                    .WithMany(p => p.TbMovimentacaoConta)
                    .HasForeignKey(d => d.CodResponsavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_movimentacao_conta_codresponsavel");

                entity.HasOne(d => d.CodTipoMovimentacaoNavigation)
                    .WithMany(p => p.TbMovimentacaoConta)
                    .HasForeignKey(d => d.CodTipoMovimentacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_movimentacao_conta_codtipomovimentacao");
            });

            modelBuilder.Entity<TbMunicipiosIbge>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PRIMARY");

                entity.ToTable("tb_municipios_ibge");

                entity.Property(e => e.Codigo)
                    .HasColumnType("int(7)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .HasColumnName("municipio");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("uf")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbNfe>(entity =>
            {
                entity.HasKey(e => e.CodNfe)
                    .HasName("PRIMARY");

                entity.ToTable("tb_nfe");

                entity.HasIndex(e => e.CodLoja, "fk_tb_nfe_tb_loja1_idx");

                entity.Property(e => e.CodNfe)
                    .HasColumnType("int(11)")
                    .HasColumnName("codNFe");

                entity.Property(e => e.Chave)
                    .HasMaxLength(44)
                    .HasColumnName("chave")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CodLoja)
                    .HasColumnType("int(8)")
                    .HasColumnName("codLoja")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodSolicitacao)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("codSolicitacao");

                entity.Property(e => e.Correcao)
                    .HasMaxLength(1000)
                    .HasColumnName("correcao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DataCancelamento)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCancelamento");

                entity.Property(e => e.DataCartaCorrecao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCartaCorrecao");

                entity.Property(e => e.DataEmissao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataEmissao");

                entity.Property(e => e.JustificativaCancelamento)
                    .HasMaxLength(200)
                    .HasColumnName("justificativaCancelamento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MensagemSituacaoProtocoloCancelamento)
                    .HasMaxLength(100)
                    .HasColumnName("mensagemSituacaoProtocoloCancelamento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MensagemSituacaoProtocoloUso)
                    .HasMaxLength(100)
                    .HasColumnName("mensagemSituacaoProtocoloUso")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MensagemSituacaoReciboEnvio)
                    .HasMaxLength(100)
                    .HasColumnName("mensagemSituacaoReciboEnvio")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MensagemSitucaoCartaCorrecao)
                    .HasMaxLength(100)
                    .HasColumnName("mensagemSitucaoCartaCorrecao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(2)
                    .HasColumnName("modelo")
                    .HasDefaultValueSql("'55'")
                    .IsFixedLength();

                entity.Property(e => e.NumeroLoteEnvio)
                    .HasMaxLength(15)
                    .HasColumnName("numeroLoteEnvio")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroProtocoloCancelamento)
                    .HasMaxLength(15)
                    .HasColumnName("numeroProtocoloCancelamento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroProtocoloCartaCorrecao)
                    .HasMaxLength(15)
                    .HasColumnName("numeroProtocoloCartaCorrecao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroProtocoloUso)
                    .HasMaxLength(15)
                    .HasColumnName("numeroProtocoloUso")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroRecibo)
                    .HasMaxLength(15)
                    .HasColumnName("numeroRecibo")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroSequenciaNfe)
                    .HasColumnType("int(8)")
                    .HasColumnName("numeroSequenciaNFe");

                entity.Property(e => e.SeqCartaCorrecao)
                    .HasColumnType("int(11)")
                    .HasColumnName("seqCartaCorrecao");

                entity.Property(e => e.SituacaoNfe)
                    .HasMaxLength(1)
                    .HasColumnName("situacaoNfe")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.SituacaoProtocoloCancelamento)
                    .HasMaxLength(4)
                    .HasColumnName("situacaoProtocoloCancelamento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SituacaoProtocoloCartaCorrecao)
                    .HasMaxLength(4)
                    .HasColumnName("situacaoProtocoloCartaCorrecao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SituacaoProtocoloUso)
                    .HasMaxLength(4)
                    .HasColumnName("situacaoProtocoloUso")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SituacaoReciboEnvio)
                    .HasMaxLength(4)
                    .HasColumnName("situacaoReciboEnvio")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.CodLojaNavigation)
                    .WithMany(p => p.TbNves)
                    .HasForeignKey(d => d.CodLoja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_nfe_tb_loja1");
            });

            modelBuilder.Entity<TbPerfil>(entity =>
            {
                entity.HasKey(e => e.CodPerfil)
                    .HasName("PRIMARY");

                entity.ToTable("tb_perfil");

                entity.Property(e => e.CodPerfil)
                    .HasColumnType("int(8)")
                    .HasColumnName("codPerfil");

                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .HasColumnName("nome");

                entity.HasMany(d => d.CodFuncionalidades)
                    .WithMany(p => p.CodPerfils)
                    .UsingEntity<Dictionary<string, object>>(
                        "TbPerfilFuncionalidade",
                        l => l.HasOne<TbFuncionalidade>().WithMany().HasForeignKey("CodFuncionalidade").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_tb_perfil_funcionalidade_codfuncionalidade"),
                        r => r.HasOne<TbPerfil>().WithMany().HasForeignKey("CodPerfil").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_tb_perfil_funcionalidade_codperfil"),
                        j =>
                        {
                            j.HasKey("CodPerfil", "CodFuncionalidade").HasName("PRIMARY");

                            j.ToTable("tb_perfil_funcionalidade");

                            j.HasIndex(new[] { "CodFuncionalidade" }, "idx_fk_tb_perfil_funcionalidade_codfuncionalidade");

                            j.IndexerProperty<int>("CodPerfil").HasColumnType("int(8)").HasColumnName("codPerfil");

                            j.IndexerProperty<int>("CodFuncionalidade").HasColumnType("int(8)").HasColumnName("codFuncionalidade");
                        });
            });

            modelBuilder.Entity<TbPermissao>(entity =>
            {
                entity.HasKey(e => new { e.CodPessoa, e.CodFuncionalidade })
                    .HasName("PRIMARY");

                entity.ToTable("tb_permissao");

                entity.HasIndex(e => e.CodFuncionalidade, "idx_fk_tb_permissao_codfuncionalidade");

                entity.HasIndex(e => e.CodPessoa, "idx_fk_tb_permissao_codpessoa");

                entity.Property(e => e.CodPessoa)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPessoa");

                entity.Property(e => e.CodFuncionalidade)
                    .HasColumnType("int(8)")
                    .HasColumnName("codFuncionalidade");

                entity.Property(e => e.Permissao)
                    .HasColumnType("int(8)")
                    .HasColumnName("permissao");

                entity.HasOne(d => d.CodFuncionalidadeNavigation)
                    .WithMany(p => p.TbPermissaos)
                    .HasForeignKey(d => d.CodFuncionalidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_permissao_codfuncionalidade");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithMany(p => p.TbPermissaos)
                    .HasForeignKey(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_permissao_codpessoa");
            });

            modelBuilder.Entity<TbPessoa>(entity =>
            {
                entity.HasKey(e => e.CodPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("tb_pessoa");

                entity.HasIndex(e => e.CodMunicipiosIbge, "fk_tb_pessoa_tb_municipios_ibge1_idx");

                entity.HasIndex(e => e.Nome, "idx_uq_tb_pessoa_nome")
                    .IsUnique();

                entity.Property(e => e.CodPessoa)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPessoa");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(40)
                    .HasColumnName("bairro");

                entity.Property(e => e.BloquearCrediario).HasColumnName("bloquearCrediario");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep")
                    .IsFixedLength();

                entity.Property(e => e.Cidade)
                    .HasMaxLength(40)
                    .HasColumnName("cidade");

                entity.Property(e => e.CodMunicipiosIbge)
                    .HasColumnType("int(7)")
                    .HasColumnName("codMunicipiosIBGE")
                    .HasDefaultValueSql("'2800308'");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(40)
                    .HasColumnName("complemento");

                entity.Property(e => e.CpfCnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cpf_Cnpj")
                    .IsFixedLength();

                entity.Property(e => e.EhFabricante).HasColumnName("ehFabricante");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(60)
                    .HasColumnName("endereco");

                entity.Property(e => e.Fone1)
                    .HasMaxLength(12)
                    .HasColumnName("fone1");

                entity.Property(e => e.Fone2)
                    .HasMaxLength(12)
                    .HasColumnName("fone2");

                entity.Property(e => e.Fone3)
                    .HasMaxLength(10)
                    .HasColumnName("fone3")
                    .HasComment("Telefone para contato 3");

                entity.Property(e => e.Ie)
                    .HasMaxLength(20)
                    .HasColumnName("ie")
                    .HasComment("InscriÃƒÂ§ÃƒÂ£o Estadual da empresa");

                entity.Property(e => e.IeSubstituto)
                    .HasMaxLength(20)
                    .HasColumnName("ieSubstituto");

                entity.Property(e => e.ImprimirCf).HasColumnName("imprimirCF");

                entity.Property(e => e.ImprimirDav)
                    .IsRequired()
                    .HasColumnName("imprimirDAV")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LimiteCompra)
                    .HasPrecision(10)
                    .HasColumnName("limiteCompra");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(50)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .HasColumnName("numero");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(300)
                    .HasColumnName("observacao");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("uf")
                    .IsFixedLength();

                entity.Property(e => e.ValorComissao)
                    .HasPrecision(5)
                    .HasColumnName("valorComissao")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.CodMunicipiosIbgeNavigation)
                    .WithMany(p => p.TbPessoas)
                    .HasForeignKey(d => d.CodMunicipiosIbge)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_pessoa_tb_municipios_ibge1");

                entity.HasMany(d => d.CodPessoas)
                    .WithMany(p => p.CodigoEmpresas)
                    .UsingEntity<Dictionary<string, object>>(
                        "TbContatoEmpresa",
                        l => l.HasOne<TbPessoa>().WithMany().HasForeignKey("CodPessoa").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_tb_contato_empresa_codpessoacontato"),
                        r => r.HasOne<TbPessoa>().WithMany().HasForeignKey("CodigoEmpresa").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_tb_contato_empresa_codpessoa"),
                        j =>
                        {
                            j.HasKey("CodigoEmpresa", "CodPessoa").HasName("PRIMARY");

                            j.ToTable("tb_contato_empresa");

                            j.HasIndex(new[] { "CodigoEmpresa" }, "idx_fk_tb_contato_empresa_codigoempresa");

                            j.HasIndex(new[] { "CodPessoa" }, "idx_fk_tb_contato_empresa_codpessoa");

                            j.IndexerProperty<long>("CodigoEmpresa").HasColumnType("bigint(19)").HasColumnName("codigoEmpresa");

                            j.IndexerProperty<long>("CodPessoa").HasColumnType("bigint(19)").HasColumnName("codPessoa");
                        });

                entity.HasMany(d => d.CodigoEmpresas)
                    .WithMany(p => p.CodPessoas)
                    .UsingEntity<Dictionary<string, object>>(
                        "TbContatoEmpresa",
                        l => l.HasOne<TbPessoa>().WithMany().HasForeignKey("CodigoEmpresa").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_tb_contato_empresa_codpessoa"),
                        r => r.HasOne<TbPessoa>().WithMany().HasForeignKey("CodPessoa").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_tb_contato_empresa_codpessoacontato"),
                        j =>
                        {
                            j.HasKey("CodigoEmpresa", "CodPessoa").HasName("PRIMARY");

                            j.ToTable("tb_contato_empresa");

                            j.HasIndex(new[] { "CodigoEmpresa" }, "idx_fk_tb_contato_empresa_codigoempresa");

                            j.HasIndex(new[] { "CodPessoa" }, "idx_fk_tb_contato_empresa_codpessoa");

                            j.IndexerProperty<long>("CodigoEmpresa").HasColumnType("bigint(19)").HasColumnName("codigoEmpresa");

                            j.IndexerProperty<long>("CodPessoa").HasColumnType("bigint(19)").HasColumnName("codPessoa");
                        });
            });

            modelBuilder.Entity<TbPlanoContum>(entity =>
            {
                entity.HasKey(e => e.CodPlanoConta)
                    .HasName("PRIMARY");

                entity.ToTable("tb_plano_conta");

                entity.HasIndex(e => e.CodTipoConta, "fk_tb_plano_conta_tb_tipo_conta1_idx");

                entity.HasIndex(e => e.CodGrupoConta, "idx_fk_tb_plano_conta_codgrupoconta");

                entity.HasIndex(e => e.Descricao, "idx_uq_tb_plano_conta_descricao")
                    .IsUnique();

                entity.Property(e => e.CodPlanoConta)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPlanoConta");

                entity.Property(e => e.CodGrupoConta)
                    .HasColumnType("int(8)")
                    .HasColumnName("codGrupoConta");

                entity.Property(e => e.CodTipoConta)
                    .HasMaxLength(1)
                    .HasColumnName("codTipoConta")
                    .IsFixedLength();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");

                entity.Property(e => e.DiaBase)
                    .HasColumnType("smallint(5)")
                    .HasColumnName("diaBase");

                entity.HasOne(d => d.CodGrupoContaNavigation)
                    .WithMany(p => p.TbPlanoConta)
                    .HasForeignKey(d => d.CodGrupoConta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_plano_conta_codgrupoconta");

                entity.HasOne(d => d.CodTipoContaNavigation)
                    .WithMany(p => p.TbPlanoConta)
                    .HasForeignKey(d => d.CodTipoConta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_plano_conta_tb_tipo_conta1");
            });

            modelBuilder.Entity<TbPontaEstoque>(entity =>
            {
                entity.HasKey(e => e.CodPontaEstoque)
                    .HasName("PRIMARY");

                entity.ToTable("tb_ponta_estoque");

                entity.HasIndex(e => e.CodProduto, "fk_tb_ponta_estoque_tb_produto1_idx");

                entity.Property(e => e.CodPontaEstoque)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPontaEstoque");

                entity.Property(e => e.Caracteristica)
                    .HasMaxLength(45)
                    .HasColumnName("caracteristica");

                entity.Property(e => e.CodProduto)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codProduto");

                entity.Property(e => e.Quantidade)
                    .HasPrecision(10)
                    .HasColumnName("quantidade");

                entity.HasOne(d => d.CodProdutoNavigation)
                    .WithMany(p => p.TbPontaEstoques)
                    .HasForeignKey(d => d.CodProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_ponta_estoque_tb_produto1");
            });

            modelBuilder.Entity<TbProduto>(entity =>
            {
                entity.HasKey(e => e.CodProduto)
                    .HasName("PRIMARY");

                entity.ToTable("tb_produto");

                entity.HasIndex(e => e.CodCst, "fk_tb_produto_tb_cst1_idx");

                entity.HasIndex(e => e.CodFabricante, "fk_tb_produto_tb_pessoa1_idx");

                entity.HasIndex(e => e.CodSituacaoProduto, "fk_tb_produto_tb_situacao_produto1_idx");

                entity.HasIndex(e => e.CodSubgrupo, "fk_tb_produto_tb_subgrupo1_idx");

                entity.HasIndex(e => e.CodigoBarra, "idx_codigoBarra");

                entity.HasIndex(e => e.CodGrupo, "idx_fk_tb_produto_codgrupo");

                entity.HasIndex(e => e.Ncmsh, "idx_ncmsh");

                entity.HasIndex(e => e.Nome, "idx_uq_tb_produto_nome")
                    .IsUnique();

                entity.Property(e => e.CodProduto)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codProduto");

                entity.Property(e => e.CodCst)
                    .HasMaxLength(4)
                    .HasColumnName("codCST")
                    .IsFixedLength();

                entity.Property(e => e.CodFabricante)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codFabricante")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodGrupo)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codGrupo")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodSituacaoProduto)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("codSituacaoProduto")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodSubgrupo)
                    .HasColumnType("int(11)")
                    .HasColumnName("codSubgrupo")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodigoBarra)
                    .HasMaxLength(40)
                    .HasColumnName("codigoBarra");

                entity.Property(e => e.DataPedidoCompra)
                    .HasColumnType("date")
                    .HasColumnName("dataPedidoCompra")
                    .HasDefaultValueSql("'1999-01-01'");

                entity.Property(e => e.DataSolicitacaoCompra)
                    .HasColumnType("date")
                    .HasColumnName("dataSolicitacaoCompra")
                    .HasDefaultValueSql("'1999-01-01'");

                entity.Property(e => e.DataUltimaMudancaPreco)
                    .HasColumnType("date")
                    .HasColumnName("dataUltimaMudancaPreco")
                    .HasDefaultValueSql("'1999-01-01'");

                entity.Property(e => e.DataUltimoPedido)
                    .HasColumnType("date")
                    .HasColumnName("dataUltimoPedido");

                entity.Property(e => e.Desconto)
                    .HasPrecision(5)
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.EmPromocao)
                    .HasColumnName("emPromocao")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ExibeNaListagem)
                    .HasColumnName("exibeNaListagem")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Frete)
                    .HasPrecision(5)
                    .HasColumnName("frete")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Icms)
                    .HasPrecision(5)
                    .HasColumnName("icms")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.IcmsSubstituto)
                    .HasPrecision(5)
                    .HasColumnName("icms_substituto");

                entity.Property(e => e.Ipi)
                    .HasPrecision(5)
                    .HasColumnName("ipi")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.LucroPrecoRevenda)
                    .HasPrecision(10)
                    .HasColumnName("lucroPrecoRevenda")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.LucroPrecoVendaAtacado)
                    .HasPrecision(5)
                    .HasColumnName("lucroPrecoVendaAtacado")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.LucroPrecoVendaVarejo)
                    .HasPrecision(5)
                    .HasColumnName("lucroPrecoVendaVarejo")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Ncmsh)
                    .HasMaxLength(8)
                    .HasColumnName("ncmsh")
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.NomeProdutoFabricante)
                    .HasMaxLength(50)
                    .HasColumnName("nomeProdutoFabricante");

                entity.Property(e => e.PrecoRevenda)
                    .HasPrecision(10, 3)
                    .HasColumnName("precoRevenda")
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.PrecoVendaAtacado)
                    .HasPrecision(10, 3)
                    .HasColumnName("precoVendaAtacado")
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.PrecoVendaVarejo)
                    .HasPrecision(10)
                    .HasColumnName("precoVendaVarejo")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.QtdProdutoAtacado)
                    .HasPrecision(10)
                    .HasColumnName("qtdProdutoAtacado")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.QuantidadeEmbalagem)
                    .HasPrecision(10)
                    .HasColumnName("quantidadeEmbalagem")
                    .HasDefaultValueSql("'1.00'");

                entity.Property(e => e.ReferenciaFabricante)
                    .HasMaxLength(20)
                    .HasColumnName("referenciaFabricante");

                entity.Property(e => e.Simples)
                    .HasPrecision(5)
                    .HasColumnName("simples")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TemVencimento)
                    .HasColumnName("temVencimento")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UltimaDataAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("ultimaDataAtualizacao");

                entity.Property(e => e.UltimoPrecoCompra)
                    .HasPrecision(10)
                    .HasColumnName("ultimoPrecoCompra")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Unidade)
                    .HasMaxLength(6)
                    .HasColumnName("unidade");

                entity.Property(e => e.UnidadeCompra)
                    .HasMaxLength(6)
                    .HasColumnName("unidadeCompra");

                entity.HasOne(d => d.CodCstNavigation)
                    .WithMany(p => p.TbProdutos)
                    .HasForeignKey(d => d.CodCst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_produto_tb_cst1");

                entity.HasOne(d => d.CodFabricanteNavigation)
                    .WithMany(p => p.TbProdutos)
                    .HasForeignKey(d => d.CodFabricante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_produto_tb_pessoa1");

                entity.HasOne(d => d.CodGrupoNavigation)
                    .WithMany(p => p.TbProdutos)
                    .HasForeignKey(d => d.CodGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_produto_codgrupo");

                entity.HasOne(d => d.CodSituacaoProdutoNavigation)
                    .WithMany(p => p.TbProdutos)
                    .HasForeignKey(d => d.CodSituacaoProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_produto_tb_situacao_produto1");

                entity.HasOne(d => d.CodSubgrupoNavigation)
                    .WithMany(p => p.TbProdutos)
                    .HasForeignKey(d => d.CodSubgrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_produto_tb_subgrupo1");
            });

            modelBuilder.Entity<TbProdutoLoja>(entity =>
            {
                entity.HasKey(e => new { e.CodLoja, e.CodProduto })
                    .HasName("PRIMARY");

                entity.ToTable("tb_produto_loja");

                entity.HasIndex(e => e.CodLoja, "idx_fk_tb_produto_loja_codloja");

                entity.HasIndex(e => e.CodProduto, "idx_fk_tb_produto_loja_codproduto");

                entity.Property(e => e.CodLoja)
                    .HasColumnType("int(8)")
                    .HasColumnName("codLoja");

                entity.Property(e => e.CodProduto)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codProduto");

                entity.Property(e => e.EstoqueMaximo)
                    .HasPrecision(10)
                    .HasColumnName("estoqueMaximo");

                entity.Property(e => e.Localizacao)
                    .HasMaxLength(30)
                    .HasColumnName("localizacao");

                entity.Property(e => e.Localizacao2)
                    .HasMaxLength(30)
                    .HasColumnName("localizacao2");

                entity.Property(e => e.QtdEstoque)
                    .HasPrecision(10)
                    .HasColumnName("qtdEstoque");

                entity.Property(e => e.QtdEstoqueAux)
                    .HasPrecision(10)
                    .HasColumnName("qtdEstoqueAux");

                entity.HasOne(d => d.CodLojaNavigation)
                    .WithMany(p => p.TbProdutoLojas)
                    .HasForeignKey(d => d.CodLoja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_produto_loja_codloja");

                entity.HasOne(d => d.CodProdutoNavigation)
                    .WithMany(p => p.TbProdutoLojas)
                    .HasForeignKey(d => d.CodProduto)
                    .HasConstraintName("fk_tb_produto_loja_codproduto");
            });

            modelBuilder.Entity<TbSaidaFormaPagamento>(entity =>
            {
                entity.HasKey(e => e.CodSaidaFormaPagamento)
                    .HasName("PRIMARY");

                entity.ToTable("tb_saida_forma_pagamento");

                entity.HasIndex(e => e.CodCartao, "fk_tb_saida_pagamento_tb_cartao_credito1_idx");

                entity.HasIndex(e => e.CodContaBanco, "fk_tb_saida_pagamento_tb_conta_banco1_idx");

                entity.HasIndex(e => e.CodFormaPagamento, "fk_tb_saida_pagamento_tb_forma_pagamento1_idx");

                entity.HasIndex(e => e.CodSaida, "fk_tb_saida_pagamento_tb_saida1_idx");

                entity.Property(e => e.CodSaidaFormaPagamento)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("codSaidaFormaPagamento");

                entity.Property(e => e.CodCartao)
                    .HasColumnType("int(8)")
                    .HasColumnName("codCartao")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodContaBanco)
                    .HasColumnType("int(20)")
                    .HasColumnName("codContaBanco");

                entity.Property(e => e.CodFormaPagamento)
                    .HasColumnType("int(8)")
                    .HasColumnName("codFormaPagamento");

                entity.Property(e => e.CodSaida)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codSaida");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.IntervaloDias)
                    .HasColumnType("int(8)")
                    .HasColumnName("intervaloDias");

                entity.Property(e => e.NumeroControle)
                    .HasMaxLength(45)
                    .HasColumnName("numeroControle");

                entity.Property(e => e.Parcelas)
                    .HasColumnType("int(8)")
                    .HasColumnName("parcelas");

                entity.Property(e => e.Valor)
                    .HasPrecision(10)
                    .HasColumnName("valor")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.CodCartaoNavigation)
                    .WithMany(p => p.TbSaidaFormaPagamentos)
                    .HasForeignKey(d => d.CodCartao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_pagamento_tb_cartao_credito1");

                entity.HasOne(d => d.CodContaBancoNavigation)
                    .WithMany(p => p.TbSaidaFormaPagamentos)
                    .HasForeignKey(d => d.CodContaBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_pagamento_tb_conta_banco1");

                entity.HasOne(d => d.CodFormaPagamentoNavigation)
                    .WithMany(p => p.TbSaidaFormaPagamentos)
                    .HasForeignKey(d => d.CodFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_pagamento_tb_forma_pagamento1");

                entity.HasOne(d => d.CodSaidaNavigation)
                    .WithMany(p => p.TbSaidaFormaPagamentos)
                    .HasForeignKey(d => d.CodSaida)
                    .HasConstraintName("fk_tb_saida_pagamento_tb_saida1");
            });

            modelBuilder.Entity<TbSaidaPedido>(entity =>
            {
                entity.HasKey(e => new { e.CodSaida, e.CodPedidoGerado })
                    .HasName("PRIMARY");

                entity.ToTable("tb_saida_pedido");

                entity.Property(e => e.CodSaida)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codSaida");

                entity.Property(e => e.CodPedidoGerado)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPedidoGerado");

                entity.Property(e => e.TotalAvista)
                    .HasPrecision(10)
                    .HasColumnName("totalAVista");
            });

            modelBuilder.Entity<TbSaidaProduto>(entity =>
            {
                entity.HasKey(e => e.CodSaidaProduto)
                    .HasName("PRIMARY");

                entity.ToTable("tb_saida_produto");

                entity.HasIndex(e => e.Cfop, "fk_tb_saida_produto_tb_cfop1_idx");

                entity.HasIndex(e => e.CodCst, "fk_tb_saida_produto_tb_cst1_idx");

                entity.HasIndex(e => e.CodProduto, "idx_fk_tb_saida_produto_codproduto");

                entity.HasIndex(e => e.CodSaida, "idx_fk_tb_saida_produto_codsaida");

                entity.Property(e => e.CodSaidaProduto)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codSaidaProduto");

                entity.Property(e => e.BaseCalculoIcms)
                    .HasPrecision(10)
                    .HasColumnName("baseCalculoICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.BaseCalculoIcmssubst)
                    .HasPrecision(10)
                    .HasColumnName("baseCalculoICMSSubst")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Cfop)
                    .HasColumnType("int(8)")
                    .HasColumnName("cfop");

                entity.Property(e => e.CodCst)
                    .HasMaxLength(4)
                    .HasColumnName("codCST")
                    .IsFixedLength();

                entity.Property(e => e.CodProduto)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codProduto");

                entity.Property(e => e.CodSaida)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codSaida");

                entity.Property(e => e.DataValidade)
                    .HasColumnType("datetime")
                    .HasColumnName("data_validade");

                entity.Property(e => e.Desconto)
                    .HasPrecision(10)
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Quantidade)
                    .HasPrecision(10)
                    .HasColumnName("quantidade")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(10)
                    .HasColumnName("subtotal")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.SubtotalAvista)
                    .HasPrecision(10)
                    .HasColumnName("subtotalAVista");

                entity.Property(e => e.ValorIcms)
                    .HasPrecision(10)
                    .HasColumnName("valorICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIcmssubst)
                    .HasPrecision(10)
                    .HasColumnName("valorICMSSubst")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIpi)
                    .HasPrecision(10)
                    .HasColumnName("valorIPI")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorVenda)
                    .HasPrecision(10, 3)
                    .HasColumnName("valorVenda")
                    .HasDefaultValueSql("'0.000'");

                entity.HasOne(d => d.CfopNavigation)
                    .WithMany(p => p.TbSaidaProdutos)
                    .HasForeignKey(d => d.Cfop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_produto_tb_cfop1");

                entity.HasOne(d => d.CodCstNavigation)
                    .WithMany(p => p.TbSaidaProdutos)
                    .HasForeignKey(d => d.CodCst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_produto_tb_cst1");

                entity.HasOne(d => d.CodProdutoNavigation)
                    .WithMany(p => p.TbSaidaProdutos)
                    .HasForeignKey(d => d.CodProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_produto_codproduto");

                entity.HasOne(d => d.CodSaidaNavigation)
                    .WithMany(p => p.TbSaidaProdutos)
                    .HasForeignKey(d => d.CodSaida)
                    .HasConstraintName("fk_tb_saida_produto_codsaida");
            });

            modelBuilder.Entity<TbSaidum>(entity =>
            {
                entity.HasKey(e => e.CodSaida)
                    .HasName("PRIMARY");

                entity.ToTable("tb_saida");

                entity.HasIndex(e => e.CodEntrada, "fk_tb_saida_tb_entrada1_idx");

                entity.HasIndex(e => e.CodLojaOrigem, "fk_tb_saida_tb_loja1_idx");

                entity.HasIndex(e => e.CodEmpresaFrete, "fk_tb_saida_tb_pessoa1_idx");

                entity.HasIndex(e => e.CodSituacaoPagamentos, "fk_tb_saida_tb_situacao_pagamentos1_idx");

                entity.HasIndex(e => e.CodTipoSaida, "fk_tb_saida_tb_tipo_saida1_idx");

                entity.HasIndex(e => e.CodCliente, "idx_fk_tb_saida_codcliente");

                entity.HasIndex(e => e.CodProfissional, "idx_fk_tb_saida_codprofissional");

                entity.HasIndex(e => e.PedidoGerado, "idx_pedido_gerado");

                entity.Property(e => e.CodSaida)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codSaida");

                entity.Property(e => e.BaseCalculoIcms)
                    .HasPrecision(10)
                    .HasColumnName("baseCalculoICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.BaseCalculoIcmssubst)
                    .HasPrecision(10)
                    .HasColumnName("baseCalculoICMSSubst")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CodCliente)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codCliente");

                entity.Property(e => e.CodEmpresaFrete)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEmpresaFrete")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodEntrada)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codEntrada")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodLojaOrigem)
                    .HasColumnType("int(8)")
                    .HasColumnName("codLojaOrigem")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodProfissional)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codProfissional");

                entity.Property(e => e.CodSituacaoPagamentos)
                    .HasColumnType("int(11)")
                    .HasColumnName("codSituacaoPagamentos");

                entity.Property(e => e.CodTipoSaida)
                    .HasColumnType("int(11)")
                    .HasColumnName("codTipoSaida");

                entity.Property(e => e.CpfCnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cpf_cnpj");

                entity.Property(e => e.DataEmissaoDocFiscal)
                    .HasColumnType("datetime")
                    .HasColumnName("dataEmissaoDocFiscal");

                entity.Property(e => e.DataSaida)
                    .HasColumnType("datetime")
                    .HasColumnName("dataSaida");

                entity.Property(e => e.Desconto)
                    .HasPrecision(10)
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.EntregaRealizada)
                    .IsRequired()
                    .HasColumnName("entregaRealizada")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.EspecieVolumes)
                    .HasMaxLength(30)
                    .HasColumnName("especieVolumes")
                    .HasDefaultValueSql("'VOLUMES'");

                entity.Property(e => e.Marca)
                    .HasMaxLength(30)
                    .HasColumnName("marca")
                    .HasDefaultValueSql("'DIVERSOS'");

                entity.Property(e => e.Nfe)
                    .HasMaxLength(30)
                    .HasColumnName("nfe");

                entity.Property(e => e.Numero)
                    .HasPrecision(10)
                    .HasColumnName("numero")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.NumeroCartaoVenda)
                    .HasColumnType("int(8)")
                    .HasColumnName("numeroCartaoVenda");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(350)
                    .HasColumnName("observacao");

                entity.Property(e => e.OutrasDespesas)
                    .HasPrecision(10)
                    .HasColumnName("outrasDespesas")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PedidoGerado)
                    .HasMaxLength(10)
                    .HasColumnName("pedidoGerado");

                entity.Property(e => e.PesoBruto)
                    .HasPrecision(10)
                    .HasColumnName("pesoBruto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PesoLiquido)
                    .HasPrecision(10)
                    .HasColumnName("pesoLiquido")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.QuantidadeVolumes)
                    .HasPrecision(10)
                    .HasColumnName("quantidadeVolumes")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TipoDocumentoFiscal)
                    .HasColumnType("enum('ECF','NFCE')")
                    .HasColumnName("tipoDocumentoFiscal")
                    .HasDefaultValueSql("'ECF'");

                entity.Property(e => e.Total)
                    .HasPrecision(10)
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalAvista)
                    .HasPrecision(10)
                    .HasColumnName("totalAVista")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalLucro)
                    .HasPrecision(10)
                    .HasColumnName("totalLucro")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalNotaFiscal)
                    .HasPrecision(10)
                    .HasColumnName("totalNotaFiscal")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalPago)
                    .HasPrecision(10)
                    .HasColumnName("totalPago")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Troco)
                    .HasPrecision(10)
                    .HasColumnName("troco")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorFrete)
                    .HasPrecision(10)
                    .HasColumnName("valorFrete")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIcms)
                    .HasPrecision(10)
                    .HasColumnName("valorICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIcmssubst)
                    .HasPrecision(10)
                    .HasColumnName("valorICMSSubst")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIpi)
                    .HasPrecision(10)
                    .HasColumnName("valorIPI")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorSeguro)
                    .HasPrecision(10)
                    .HasColumnName("valorSeguro")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.TbSaidumCodClienteNavigations)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_codcliente");

                entity.HasOne(d => d.CodEmpresaFreteNavigation)
                    .WithMany(p => p.TbSaidumCodEmpresaFreteNavigations)
                    .HasForeignKey(d => d.CodEmpresaFrete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_tb_pessoa1");

                entity.HasOne(d => d.CodEntradaNavigation)
                    .WithMany(p => p.TbSaida)
                    .HasForeignKey(d => d.CodEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_tb_entrada1");

                entity.HasOne(d => d.CodLojaOrigemNavigation)
                    .WithMany(p => p.TbSaida)
                    .HasForeignKey(d => d.CodLojaOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_tb_loja1");

                entity.HasOne(d => d.CodProfissionalNavigation)
                    .WithMany(p => p.TbSaidumCodProfissionalNavigations)
                    .HasForeignKey(d => d.CodProfissional)
                    .HasConstraintName("fk_tb_saida_codprofissional");

                entity.HasOne(d => d.CodSituacaoPagamentosNavigation)
                    .WithMany(p => p.TbSaida)
                    .HasForeignKey(d => d.CodSituacaoPagamentos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_tb_situacao_pagamentos1");

                entity.HasOne(d => d.CodTipoSaidaNavigation)
                    .WithMany(p => p.TbSaida)
                    .HasForeignKey(d => d.CodTipoSaida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_tb_tipo_saida1");

                entity.HasMany(d => d.CodAutorizacaos)
                    .WithMany(p => p.CodSaida)
                    .UsingEntity<Dictionary<string, object>>(
                        "TbAutorizacaoCartaoSaidum",
                        l => l.HasOne<TbAutorizacaoCartao>().WithMany().HasForeignKey("CodAutorizacao").HasConstraintName("fk_tb_autorizacao_cartao_saida_tb_autorizacao_cartao1"),
                        r => r.HasOne<TbSaidum>().WithMany().HasForeignKey("CodSaida").HasConstraintName("fk_tb_autorizacao_cartao_has_tb_saida_tb_saida1"),
                        j =>
                        {
                            j.HasKey("CodSaida", "CodAutorizacao").HasName("PRIMARY");

                            j.ToTable("tb_autorizacao_cartao_saida");

                            j.HasIndex(new[] { "CodSaida" }, "fk_tb_autorizacao_cartao_has_tb_saida_tb_saida1_idx");

                            j.HasIndex(new[] { "CodAutorizacao" }, "fk_tb_autorizacao_cartao_saida_tb_autorizacao_cartao1_idx");

                            j.IndexerProperty<long>("CodSaida").HasColumnType("bigint(19)").HasColumnName("codSaida");

                            j.IndexerProperty<long>("CodAutorizacao").HasColumnType("bigint(20)").HasColumnName("codAutorizacao");
                        });

                entity.HasMany(d => d.CodNves)
                    .WithMany(p => p.CodSaida)
                    .UsingEntity<Dictionary<string, object>>(
                        "TbSaidaNfe",
                        l => l.HasOne<TbNfe>().WithMany().HasForeignKey("CodNfe").HasConstraintName("fk_tb_saida_has_tb_nfe_tb_nfe1"),
                        r => r.HasOne<TbSaidum>().WithMany().HasForeignKey("CodSaida").HasConstraintName("fk_tb_saida_has_tb_nfe_tb_saida1"),
                        j =>
                        {
                            j.HasKey("CodSaida", "CodNfe").HasName("PRIMARY");

                            j.ToTable("tb_saida_nfe");

                            j.HasIndex(new[] { "CodNfe" }, "fk_tb_saida_has_tb_nfe_tb_nfe1_idx");

                            j.HasIndex(new[] { "CodSaida" }, "fk_tb_saida_has_tb_nfe_tb_saida1_idx");

                            j.IndexerProperty<long>("CodSaida").HasColumnType("bigint(19)").HasColumnName("codSaida");

                            j.IndexerProperty<int>("CodNfe").HasColumnType("int(11)").HasColumnName("codNFe");
                        });
            });

            modelBuilder.Entity<TbSituacaoContum>(entity =>
            {
                entity.HasKey(e => e.CodSituacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_situacao_conta");

                entity.Property(e => e.CodSituacao)
                    .HasMaxLength(1)
                    .HasColumnName("codSituacao")
                    .IsFixedLength();

                entity.Property(e => e.DescricaoSituacao)
                    .HasMaxLength(30)
                    .HasColumnName("descricaoSituacao");
            });

            modelBuilder.Entity<TbSituacaoPagamento>(entity =>
            {
                entity.HasKey(e => e.CodSituacaoPagamentos)
                    .HasName("PRIMARY");

                entity.ToTable("tb_situacao_pagamentos");

                entity.Property(e => e.CodSituacaoPagamentos)
                    .HasColumnType("int(11)")
                    .HasColumnName("codSituacaoPagamentos");

                entity.Property(e => e.DescricaoSituacaoPagamentos)
                    .HasMaxLength(20)
                    .HasColumnName("descricaoSituacaoPagamentos");
            });

            modelBuilder.Entity<TbSituacaoProduto>(entity =>
            {
                entity.HasKey(e => e.CodSituacaoProduto)
                    .HasName("PRIMARY");

                entity.ToTable("tb_situacao_produto");

                entity.Property(e => e.CodSituacaoProduto)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("codSituacaoProduto");

                entity.Property(e => e.DescricaoSituacao)
                    .HasMaxLength(45)
                    .HasColumnName("descricaoSituacao");
            });

            modelBuilder.Entity<TbSolicitacaoDocumento>(entity =>
            {
                entity.HasKey(e => e.CodSolicitacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_solicitacao_documento");

                entity.HasIndex(e => e.CodSolicitacao, "codSaida_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CodSolicitacao)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("codSolicitacao");

                entity.Property(e => e.CartaoAutorizado).HasColumnName("cartaoAutorizado");

                entity.Property(e => e.CartaoProcessado).HasColumnName("cartaoProcessado");

                entity.Property(e => e.CodMotivoCartaoNegado)
                    .HasColumnType("int(11)")
                    .HasColumnName("codMotivoCartaoNegado");

                entity.Property(e => e.DataSolicitacao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataSolicitacao");

                entity.Property(e => e.EhComplementar).HasColumnName("ehComplementar");

                entity.Property(e => e.EhEspelho).HasColumnName("ehEspelho");

                entity.Property(e => e.EmProcessamento).HasColumnName("emProcessamento");

                entity.Property(e => e.HaPagamentoCartao).HasColumnName("haPagamentoCartao");

                entity.Property(e => e.HostSolicitante)
                    .HasMaxLength(100)
                    .HasColumnName("hostSolicitante")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MotivoCartaoNegado)
                    .HasMaxLength(200)
                    .HasColumnName("motivoCartaoNegado")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NfeProcessada).HasColumnName("nfeProcessada");

                entity.Property(e => e.TipoSolicitacao)
                    .HasColumnType("enum('ECF','NFCE','NFE','CARTAO','CANCELAMENTO','CONSULTA')")
                    .HasColumnName("tipoSolicitacao")
                    .HasDefaultValueSql("'ECF'");
            });

            modelBuilder.Entity<TbSolicitacaoEventoNfe>(entity =>
            {
                entity.HasKey(e => e.IdSolicitacaoEvento)
                    .HasName("PRIMARY");

                entity.ToTable("tb_solicitacao_evento_nfe");

                entity.HasIndex(e => new { e.CodNfe, e.TipoSolicitacao }, "codNFetipoSolicitacao_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CodNfe, "fk_tb_solicitacao_evento_nfe_tb_nfe1_idx");

                entity.Property(e => e.IdSolicitacaoEvento)
                    .HasColumnType("int(10) unsigned zerofill")
                    .HasColumnName("idSolicitacaoEvento");

                entity.Property(e => e.CodNfe)
                    .HasColumnType("int(11)")
                    .HasColumnName("codNFe");

                entity.Property(e => e.TipoSolicitacao)
                    .HasColumnType("enum('CANCELAMENTO','CONSULTA')")
                    .HasColumnName("tipoSolicitacao")
                    .HasDefaultValueSql("'CONSULTA'");

                entity.HasOne(d => d.CodNfeNavigation)
                    .WithMany(p => p.TbSolicitacaoEventoNves)
                    .HasForeignKey(d => d.CodNfe)
                    .HasConstraintName("fk_tb_solicitacao_evento_nfe_tb_nfe1");
            });

            modelBuilder.Entity<TbSolicitacaoPagamento>(entity =>
            {
                entity.HasKey(e => e.CodSolicitacaoPagamento)
                    .HasName("PRIMARY");

                entity.ToTable("tb_solicitacao_pagamento");

                entity.HasIndex(e => e.CodCartao, "fk_tb_solicitacao_pagamentos_tb_cartao_credito1_idx");

                entity.HasIndex(e => e.CodFormaPagamento, "fk_tb_solicitacao_pagamentos_tb_forma_pagamento1_idx");

                entity.HasIndex(e => e.CodSolicitacao, "fk_tb_solicitacao_pagamentos_tb_solicitacao_documento_fisca_idx");

                entity.Property(e => e.CodSolicitacaoPagamento)
                    .HasColumnType("bigint(19) unsigned")
                    .HasColumnName("codSolicitacaoPagamento");

                entity.Property(e => e.CodCartao)
                    .HasColumnType("int(8)")
                    .HasColumnName("codCartao");

                entity.Property(e => e.CodFormaPagamento)
                    .HasColumnType("int(8)")
                    .HasColumnName("codFormaPagamento")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodSolicitacao)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("codSolicitacao");

                entity.Property(e => e.CupomCliente)
                    .HasMaxLength(500)
                    .HasColumnName("cupomCliente");

                entity.Property(e => e.CupomEstabelecimento)
                    .HasMaxLength(500)
                    .HasColumnName("cupomEstabelecimento");

                entity.Property(e => e.CupomReduzido)
                    .HasMaxLength(500)
                    .HasColumnName("cupomReduzido");

                entity.Property(e => e.Parcelas)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("parcelas")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Valor)
                    .HasPrecision(10)
                    .HasColumnName("valor");

                entity.HasOne(d => d.CodCartaoNavigation)
                    .WithMany(p => p.TbSolicitacaoPagamentos)
                    .HasForeignKey(d => d.CodCartao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_solicitacao_pagamentos_tb_cartao_credito1");

                entity.HasOne(d => d.CodFormaPagamentoNavigation)
                    .WithMany(p => p.TbSolicitacaoPagamentos)
                    .HasForeignKey(d => d.CodFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_solicitacao_pagamentos_tb_forma_pagamento1");

                entity.HasOne(d => d.CodSolicitacaoNavigation)
                    .WithMany(p => p.TbSolicitacaoPagamentos)
                    .HasForeignKey(d => d.CodSolicitacao)
                    .HasConstraintName("fk_tb_solicitacao_pagamentos_tb_solicitacao_documento_fiscal1");
            });

            modelBuilder.Entity<TbSolicitacaoSaidum>(entity =>
            {
                entity.HasKey(e => new { e.CodSolicitacao, e.CodSaida })
                    .HasName("PRIMARY");

                entity.ToTable("tb_solicitacao_saida");

                entity.HasIndex(e => e.CodSaida, "fk_tb_solicitacao_saida_tb_saida1_idx");

                entity.Property(e => e.CodSolicitacao)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("codSolicitacao");

                entity.Property(e => e.CodSaida)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codSaida");

                entity.Property(e => e.ValorTotal)
                    .HasPrecision(10)
                    .HasColumnName("valorTotal");

                entity.HasOne(d => d.CodSaidaNavigation)
                    .WithMany(p => p.TbSolicitacaoSaida)
                    .HasForeignKey(d => d.CodSaida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_solicitacao_saida_tb_saida1");

                entity.HasOne(d => d.CodSolicitacaoNavigation)
                    .WithMany(p => p.TbSolicitacaoSaida)
                    .HasForeignKey(d => d.CodSolicitacao)
                    .HasConstraintName("fk_tb_solicitacao_saida_tb_solicitacao_documento_fiscal1");
            });

            modelBuilder.Entity<TbSubgrupo>(entity =>
            {
                entity.HasKey(e => e.CodSubgrupo)
                    .HasName("PRIMARY");

                entity.ToTable("tb_subgrupo");

                entity.HasIndex(e => e.CodGrupo, "fk_tb_subgrupo_tb_grupo1_idx");

                entity.Property(e => e.CodSubgrupo)
                    .HasColumnType("int(11)")
                    .HasColumnName("codSubgrupo");

                entity.Property(e => e.CodGrupo)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codGrupo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");

                entity.HasOne(d => d.CodGrupoNavigation)
                    .WithMany(p => p.TbSubgrupos)
                    .HasForeignKey(d => d.CodGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_subgrupo_tb_grupo1");
            });

            modelBuilder.Entity<TbTipoContum>(entity =>
            {
                entity.HasKey(e => e.CodTipoConta)
                    .HasName("PRIMARY");

                entity.ToTable("tb_tipo_conta");

                entity.Property(e => e.CodTipoConta)
                    .HasMaxLength(1)
                    .HasColumnName("codTipoConta")
                    .IsFixedLength();

                entity.Property(e => e.DescricaoTipoConta)
                    .HasMaxLength(30)
                    .HasColumnName("descricaoTipoConta");
            });

            modelBuilder.Entity<TbTipoMovimentacaoContum>(entity =>
            {
                entity.HasKey(e => e.CodTipoMovimentacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_tipo_movimentacao_conta");

                entity.Property(e => e.CodTipoMovimentacao)
                    .HasColumnType("int(8)")
                    .HasColumnName("codTipoMovimentacao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");

                entity.Property(e => e.SomaSaldo).HasColumnName("somaSaldo");
            });

            modelBuilder.Entity<TbTipoSaidum>(entity =>
            {
                entity.HasKey(e => e.CodTipoSaida)
                    .HasName("PRIMARY");

                entity.ToTable("tb_tipo_saida");

                entity.HasIndex(e => e.Cfop, "fk_tb_tipo_saida_tb_cfop1_idx");

                entity.Property(e => e.CodTipoSaida)
                    .HasColumnType("int(11)")
                    .HasColumnName("codTipoSaida");

                entity.Property(e => e.Cfop)
                    .HasColumnType("int(8)")
                    .HasColumnName("cfop");

                entity.Property(e => e.DescricaoTipoSaida)
                    .HasMaxLength(45)
                    .HasColumnName("descricaoTipoSaida");

                entity.HasOne(d => d.CfopNavigation)
                    .WithMany(p => p.TbTipoSaida)
                    .HasForeignKey(d => d.Cfop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_tipo_saida_tb_cfop1");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.CodPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("tb_usuario");

                entity.HasIndex(e => e.CodPerfil, "idx_fk_tb_usuario_codperfil");

                entity.HasIndex(e => e.CodPessoa, "idx_fk_tb_usuario_codpessoa");

                entity.HasIndex(e => e.Login, "idx_uq_tb_usuario_login")
                    .IsUnique();

                entity.Property(e => e.CodPessoa)
                    .HasColumnType("bigint(19)")
                    .HasColumnName("codPessoa");

                entity.Property(e => e.CodPerfil)
                    .HasColumnType("int(8)")
                    .HasColumnName("codPerfil")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .HasColumnName("login");

                entity.Property(e => e.Senha)
                    .HasMaxLength(20)
                    .HasColumnName("senha");

                entity.HasOne(d => d.CodPerfilNavigation)
                    .WithMany(p => p.TbUsuarios)
                    .HasForeignKey(d => d.CodPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_usuario_acodperfil");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithOne(p => p.TbUsuario)
                    .HasForeignKey<TbUsuario>(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_usuario_codpessoa");
            });

            modelBuilder.Entity<TpTipoEntradum>(entity =>
            {
                entity.HasKey(e => e.CodTipoEntrada)
                    .HasName("PRIMARY");

                entity.ToTable("tp_tipo_entrada");

                entity.Property(e => e.CodTipoEntrada)
                    .HasColumnType("int(11)")
                    .HasColumnName("codTipoEntrada");

                entity.Property(e => e.DescricaoTipoEntrada)
                    .HasMaxLength(45)
                    .HasColumnName("descricaoTipoEntrada");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
