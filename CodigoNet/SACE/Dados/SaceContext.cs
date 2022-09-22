using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<TbAutorizacaoCartao> TbAutorizacaoCartaos { get; set; }
        public virtual DbSet<TbAutorizacaoCartaoSaidum> TbAutorizacaoCartaoSaida { get; set; }
        public virtual DbSet<TbBanco> TbBancos { get; set; }
        public virtual DbSet<TbCartaoCredito> TbCartaoCreditos { get; set; }
        public virtual DbSet<TbCfop> TbCfops { get; set; }
        public virtual DbSet<TbContaBanco> TbContaBancos { get; set; }
        public virtual DbSet<TbContatoEmpresa> TbContatoEmpresas { get; set; }
        public virtual DbSet<TbContum> TbConta { get; set; }
        public virtual DbSet<TbCst> TbCsts { get; set; }
        public virtual DbSet<TbDocumentoFiscal> TbDocumentoFiscals { get; set; }
        public virtual DbSet<TbEntradaFormaPagamento> TbEntradaFormaPagamentos { get; set; }
        public virtual DbSet<TbEntradaProduto> TbEntradaProdutos { get; set; }
        public virtual DbSet<TbEntradum> TbEntrada { get; set; }
        public virtual DbSet<TbFormaPagamento> TbFormaPagamentos { get; set; }
        public virtual DbSet<TbFuncionalidade> TbFuncionalidades { get; set; }
        public virtual DbSet<TbGrupo> TbGrupos { get; set; }
        public virtual DbSet<TbGrupoContum> TbGrupoConta { get; set; }
        public virtual DbSet<TbImposto> TbImpostos { get; set; }
        public virtual DbSet<TbImprimirDocumento> TbImprimirDocumentos { get; set; }
        public virtual DbSet<TbImprimirDocumentoSaidum> TbImprimirDocumentoSaida { get; set; }
        public virtual DbSet<TbLoja> TbLojas { get; set; }
        public virtual DbSet<TbMovimentacaoContum> TbMovimentacaoConta { get; set; }
        public virtual DbSet<TbMunicipiosIbge> TbMunicipiosIbges { get; set; }
        public virtual DbSet<TbNfe> TbNves { get; set; }
        public virtual DbSet<TbPerfil> TbPerfils { get; set; }
        public virtual DbSet<TbPerfilFuncionalidade> TbPerfilFuncionalidades { get; set; }
        public virtual DbSet<TbPermissao> TbPermissaos { get; set; }
        public virtual DbSet<TbPessoa> TbPessoas { get; set; }
        public virtual DbSet<TbPlanoContum> TbPlanoConta { get; set; }
        public virtual DbSet<TbPontaEstoque> TbPontaEstoques { get; set; }
        public virtual DbSet<TbProduto> TbProdutos { get; set; }
        public virtual DbSet<TbProdutoLoja> TbProdutoLojas { get; set; }
        public virtual DbSet<TbSaidaFormaPagamento> TbSaidaFormaPagamentos { get; set; }
        public virtual DbSet<TbSaidaNfe> TbSaidaNves { get; set; }
        public virtual DbSet<TbSaidaPedido> TbSaidaPedidos { get; set; }
        public virtual DbSet<TbSaidaProduto> TbSaidaProdutos { get; set; }
        public virtual DbSet<TbSaidum> TbSaida { get; set; }
        public virtual DbSet<TbSituacaoContum> TbSituacaoConta { get; set; }
        public virtual DbSet<TbSituacaoPagamento> TbSituacaoPagamentos { get; set; }
        public virtual DbSet<TbSituacaoProduto> TbSituacaoProdutos { get; set; }
        public virtual DbSet<TbSolicitacaoDocumento> TbSolicitacaoDocumentos { get; set; }
        public virtual DbSet<TbSolicitacaoEventoNfe> TbSolicitacaoEventoNves { get; set; }
        public virtual DbSet<TbSolicitacaoPagamento> TbSolicitacaoPagamentos { get; set; }
        public virtual DbSet<TbSolicitacaoSaidum> TbSolicitacaoSaida { get; set; }
        public virtual DbSet<TbSubgrupo> TbSubgrupos { get; set; }
        public virtual DbSet<TbTipoContum> TbTipoConta { get; set; }
        public virtual DbSet<TbTipoMovimentacaoContum> TbTipoMovimentacaoConta { get; set; }
        public virtual DbSet<TbTipoSaidum> TbTipoSaida { get; set; }
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; }
        public virtual DbSet<TpTipoEntradum> TpTipoEntrada { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=sace;password=sace;database=sace");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAutorizacaoCartao>(entity =>
            {
                entity.HasKey(e => e.CodAutorizacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_autorizacao_cartao");

                entity.Property(e => e.CodAutorizacao).HasColumnName("codAutorizacao");

                entity.Property(e => e.AutorizacaoTransacao)
                    .HasMaxLength(6)
                    .HasColumnName("autorizacaoTransacao")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CodIdentificacao).HasColumnName("codIdentificacao");

                entity.Property(e => e.CupomFiscal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cupomFiscal");

                entity.Property(e => e.DataHoraAutorizacao).HasColumnName("dataHoraAutorizacao");

                entity.Property(e => e.Header)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("header");

                entity.Property(e => e.NomeBandeiraCartao)
                    .HasMaxLength(45)
                    .HasColumnName("nomeBandeiraCartao");

                entity.Property(e => e.NsuTransacao).HasColumnName("nsuTransacao");

                entity.Property(e => e.Processado).HasColumnName("processado");

                entity.Property(e => e.QuantidadeParcelas).HasColumnName("quantidadeParcelas");

                entity.Property(e => e.StatusTransacao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("statusTransacao");

                entity.Property(e => e.TipoDocumentoFiscal)
                    .IsRequired()
                    .HasColumnType("enum('ECF','NFCE')")
                    .HasColumnName("tipoDocumentoFiscal")
                    .HasDefaultValueSql("'ECF'");

                entity.Property(e => e.TipoParcelamento).HasColumnName("tipoParcelamento");

                entity.Property(e => e.TipoTransacao).HasColumnName("tipoTransacao");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<TbAutorizacaoCartaoSaidum>(entity =>
            {
                entity.HasKey(e => new { e.CodSaida, e.CodAutorizacao })
                    .HasName("PRIMARY");

                entity.ToTable("tb_autorizacao_cartao_saida");

                entity.HasIndex(e => e.CodSaida, "fk_tb_autorizacao_cartao_has_tb_saida_tb_saida1_idx");

                entity.HasIndex(e => e.CodAutorizacao, "fk_tb_autorizacao_cartao_saida_tb_autorizacao_cartao1_idx");

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.Property(e => e.CodAutorizacao).HasColumnName("codAutorizacao");

                entity.HasOne(d => d.CodAutorizacaoNavigation)
                    .WithMany(p => p.TbAutorizacaoCartaoSaida)
                    .HasForeignKey(d => d.CodAutorizacao)
                    .HasConstraintName("fk_tb_autorizacao_cartao_saida_tb_autorizacao_cartao1");
            });

            modelBuilder.Entity<TbBanco>(entity =>
            {
                entity.HasKey(e => e.CodBanco)
                    .HasName("PRIMARY");

                entity.ToTable("tb_banco");

                entity.HasIndex(e => e.Nome, "idx_uq_tb_banco_nome")
                    .IsUnique();

                entity.Property(e => e.CodBanco).HasColumnName("codBanco");

                entity.Property(e => e.Nome)
                    .IsRequired()
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

                entity.Property(e => e.CodCartao).HasColumnName("codCartao");

                entity.Property(e => e.CodContaBanco).HasColumnName("codContaBanco");

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("desconto");

                entity.Property(e => e.DiaBase).HasColumnName("diaBase");

                entity.Property(e => e.Mapeamento)
                    .HasMaxLength(2)
                    .HasColumnName("mapeamento");

                entity.Property(e => e.MapeamentoCappta)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("mapeamentoCappta")
                    .HasDefaultValueSql("'MASTERCARD'");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.TipoCartao)
                    .IsRequired()
                    .HasColumnType("enum('DEBITO','CREDITO','CREDIARIO')")
                    .HasColumnName("tipoCartao")
                    .HasDefaultValueSql("'CREDITO'");
            });

            modelBuilder.Entity<TbCfop>(entity =>
            {
                entity.HasKey(e => e.Cfop)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cfop");

                entity.Property(e => e.Cfop).HasColumnName("cfop");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");

                entity.Property(e => e.Icms)
                    .HasColumnType("decimal(5,2)")
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

                entity.Property(e => e.CodContaBanco).HasColumnName("codContaBanco");

                entity.Property(e => e.Agencia)
                    .HasMaxLength(10)
                    .HasColumnName("agencia");

                entity.Property(e => e.CodBanco).HasColumnName("codBanco");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(30)
                    .HasColumnName("descricao");

                entity.Property(e => e.Numeroconta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("numeroconta");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("saldo");
            });

            modelBuilder.Entity<TbContatoEmpresa>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("tb_contato_empresa");

                entity.HasIndex(e => e.CodigoEmpresa, "idx_fk_tb_contato_empresa_codigoempresa");

                entity.HasIndex(e => e.CodPessoa, "idx_fk_tb_contato_empresa_codpessoa");

                entity.Property(e => e.CodigoEmpresa).HasColumnName("codigoEmpresa");

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");
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

                entity.Property(e => e.CodConta).HasColumnName("codConta");

                entity.Property(e => e.CodEntrada).HasColumnName("codEntrada");

                entity.Property(e => e.CodPagamento).HasColumnName("codPagamento");

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");

                entity.Property(e => e.CodPlanoConta).HasColumnName("codPlanoConta");

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.Property(e => e.CodSituacao)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("codSituacao")
                    .IsFixedLength(true);

                entity.Property(e => e.DataVencimento)
                    .HasColumnType("date")
                    .HasColumnName("dataVencimento");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("desconto");

                entity.Property(e => e.FormatoConta)
                    .IsRequired()
                    .HasColumnType("enum('FICHA','BOLETO','CARTAO','CHEQUE','CREDITO')")
                    .HasColumnName("formatoConta")
                    .HasDefaultValueSql("'FICHA'");

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("numeroDocumento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(200)
                    .HasColumnName("observacao");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<TbCst>(entity =>
            {
                entity.HasKey(e => e.CodCst)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cst");

                entity.Property(e => e.CodCst)
                    .HasMaxLength(4)
                    .HasColumnName("codCST")
                    .IsFixedLength(true);

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
                    .HasColumnType("int unsigned")
                    .HasColumnName("numeroDocumentoFiscal");

                entity.Property(e => e.DataSoliciticao).HasColumnName("dataSoliciticao");

                entity.Property(e => e.Situacao)
                    .IsRequired()
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

                entity.Property(e => e.CodEntradaFormaPagamento).HasColumnName("codEntradaFormaPagamento");

                entity.Property(e => e.CodContaBanco).HasColumnName("codContaBanco");

                entity.Property(e => e.CodEntrada).HasColumnName("codEntrada");

                entity.Property(e => e.CodFormaPagamento).HasColumnName("codFormaPagamento");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.PagamentoDoFrete)
                    .HasColumnName("pagamentoDoFrete")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valor");
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

                entity.Property(e => e.CodEntradaProduto).HasColumnName("codEntradaProduto");

                entity.Property(e => e.BaseCalculoIcms)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("baseCalculoICMS");

                entity.Property(e => e.BaseCalculoIcmsst)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("baseCalculoICMSST");

                entity.Property(e => e.Cfop).HasColumnName("cfop");

                entity.Property(e => e.CodCst)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("codCST")
                    .IsFixedLength(true);

                entity.Property(e => e.CodEntrada).HasColumnName("codEntrada");

                entity.Property(e => e.CodProduto).HasColumnName("codProduto");

                entity.Property(e => e.DataValidade)
                    .HasColumnType("date")
                    .HasColumnName("data_validade");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PrecoCusto)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("preco_custo");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.QuantidadeDisponivel)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("quantidade_disponivel")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("Os produtos vendidos na loja incrementam esse valor atÃƒÂ© que o nÃƒÂºmero de vendidos seja igual ao de comprados.\n");

                entity.Property(e => e.QuantidadeEmbalagem)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("quantidadeEmbalagem")
                    .HasDefaultValueSql("'1.00'");

                entity.Property(e => e.UnidadeCompra)
                    .HasMaxLength(6)
                    .HasColumnName("unidadeCompra");

                entity.Property(e => e.ValorIcms)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorICMS");

                entity.Property(e => e.ValorIcmsst)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorICMSST");

                entity.Property(e => e.ValorIpi)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorIPI");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorTotal");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorUnitario");
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

                entity.Property(e => e.CodEntrada).HasColumnName("codEntrada");

                entity.Property(e => e.Chave)
                    .HasMaxLength(44)
                    .HasColumnName("chave")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CodEmpresaFrete).HasColumnName("codEmpresaFrete");

                entity.Property(e => e.CodFornecedor).HasColumnName("codFornecedor");

                entity.Property(e => e.CodSituacaoPagamentos).HasColumnName("codSituacaoPagamentos");

                entity.Property(e => e.CodTipoEntrada).HasColumnName("codTipoEntrada");

                entity.Property(e => e.DataEmissao).HasColumnName("dataEmissao");

                entity.Property(e => e.DataEntrada).HasColumnName("dataEntrada");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.FretePagoEmitente).HasColumnName("fretePagoEmitente");

                entity.Property(e => e.NumeroNotaFiscal)
                    .HasMaxLength(20)
                    .HasColumnName("numeroNotaFiscal");

                entity.Property(e => e.OutrasDespesas)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("outrasDespesas")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Serie)
                    .HasMaxLength(20)
                    .HasColumnName("serie")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TotalBaseCalculo)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalBaseCalculo")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalBaseSubstituicao)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalBaseSubstituicao")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalIcms)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalIpi)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalIPI")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalNota)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalNota")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalProdutos)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalProdutos")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalProdutosSt)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalProdutosST")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalSubstituicao)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalSubstituicao")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorFrete)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorFrete")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorSeguro)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorSeguro")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<TbFormaPagamento>(entity =>
            {
                entity.HasKey(e => e.CodFormaPagamento)
                    .HasName("PRIMARY");

                entity.ToTable("tb_forma_pagamento");

                entity.Property(e => e.CodFormaPagamento).HasColumnName("codFormaPagamento");

                entity.Property(e => e.DescontoAcrescimo)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("descontoAcrescimo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("descricao");

                entity.Property(e => e.Mapeamento)
                    .HasMaxLength(2)
                    .HasColumnName("mapeamento");

                entity.Property(e => e.Parcelas)
                    .HasColumnName("parcelas")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<TbFuncionalidade>(entity =>
            {
                entity.HasKey(e => e.CodFuncionalidade)
                    .HasName("PRIMARY");

                entity.ToTable("tb_funcionalidade");

                entity.Property(e => e.CodFuncionalidade).HasColumnName("codFuncionalidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
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

                entity.Property(e => e.CodGrupo).HasColumnName("codGrupo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
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

                entity.Property(e => e.CodGrupoConta).HasColumnName("codGrupoConta");

                entity.Property(e => e.Descricao)
                    .IsRequired()
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

                entity.Property(e => e.Ncmsh).HasColumnName("NCMSH");

                entity.Property(e => e.AliqImp)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("aliqImp");

                entity.Property(e => e.AliqNac)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("aliqNac");
            });

            modelBuilder.Entity<TbImprimirDocumento>(entity =>
            {
                entity.HasKey(e => e.CodImprimir)
                    .HasName("PRIMARY");

                entity.ToTable("tb_imprimir_documento");

                entity.HasIndex(e => new { e.TipoDocumento, e.CodDocumento }, "tipoDocumento_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CodImprimir).HasColumnName("codImprimir");

                entity.Property(e => e.CodDocumento).HasColumnName("codDocumento");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.HostSolicitante)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("hostSolicitante")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasColumnType("enum('NFCE','NFE','REDUZIDO1','REDUZIDO2')")
                    .HasColumnName("tipoDocumento")
                    .HasDefaultValueSql("'NFCE'");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalAvista)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalAVista")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<TbImprimirDocumentoSaidum>(entity =>
            {
                entity.HasKey(e => new { e.CodImprimir, e.CodSaida })
                    .HasName("PRIMARY");

                entity.ToTable("tb_imprimir_documento_saida");

                entity.HasIndex(e => e.CodImprimir, "fk_tb_imprimir_documento_has_tb_saida_tb_imprimir_documento_idx");

                entity.HasIndex(e => e.CodSaida, "fk_tb_imprimir_documento_has_tb_saida_tb_saida1_idx");

                entity.Property(e => e.CodImprimir).HasColumnName("codImprimir");

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.HasOne(d => d.CodImprimirNavigation)
                    .WithMany(p => p.TbImprimirDocumentoSaida)
                    .HasForeignKey(d => d.CodImprimir)
                    .HasConstraintName("fk_tb_imprimir_documento_has_tb_saida_tb_imprimir_documento1");

                entity.HasOne(d => d.CodSaidaNavigation)
                    .WithMany(p => p.TbImprimirDocumentoSaida)
                    .HasForeignKey(d => d.CodSaida)
                    .HasConstraintName("fk_tb_imprimir_documento_has_tb_saida_tb_saida1");
            });

            modelBuilder.Entity<TbLoja>(entity =>
            {
                entity.HasKey(e => e.CodLoja)
                    .HasName("PRIMARY");

                entity.ToTable("tb_loja");

                entity.HasIndex(e => e.CodPessoa, "fk_tb_loja_tb_pessoa1_idx");

                entity.HasIndex(e => e.Nome, "idx_uq_tb_loja_nome")
                    .IsUnique();

                entity.Property(e => e.CodLoja).HasColumnName("codLoja");

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");

                entity.Property(e => e.EnderecoServidorNfe)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("enderecoServidorNfe")
                    .HasDefaultValueSql("'\\\\\\\\retaguarda\\\\'");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nome");

                entity.Property(e => e.NomeServidorNfe)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nomeServidorNfe")
                    .HasDefaultValueSql("'RETAGUARDA'");

                entity.Property(e => e.NumeroSequenciaNfeAtual).HasColumnName("numeroSequenciaNfeAtual");

                entity.Property(e => e.NumeroSequencialNfceAtual).HasColumnName("numeroSequencialNFCeAtual");

                entity.Property(e => e.PastaNfeAutorizados)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeAutorizados")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Enviado\\\\Autorizados\\\\'");

                entity.Property(e => e.PastaNfeEnviado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeEnviado")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Enviado\\\\'");

                entity.Property(e => e.PastaNfeEnvio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeEnvio")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Envio\\\\'");

                entity.Property(e => e.PastaNfeErro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeErro")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Erro\\\\'");

                entity.Property(e => e.PastaNfeEspelho)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeEspelho")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Espelho\\\\'");

                entity.Property(e => e.PastaNfeRetorno)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pastaNfeRetorno")
                    .HasDefaultValueSql("'Unimake\\\\UniNFe\\\\32799603000191\\\\Retorno\\\\'");

                entity.Property(e => e.PastaNfeValidado)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("pastaNfeValidado")
                    .HasDefaultValueSql("'c:\\\\Unimake\\\\UniNFe\\\\32799603000191\\\\Validar\\\\'");

                entity.Property(e => e.PastaNfeValidar)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("pastaNfeValidar")
                    .HasDefaultValueSql("'c:\\\\Unimake\\\\UniNFe\\\\32799603000191\\\\Validar\\\\'");
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

                entity.Property(e => e.CodMovimentacao).HasColumnName("codMovimentacao");

                entity.Property(e => e.CodConta).HasColumnName("codConta");

                entity.Property(e => e.CodContaBanco).HasColumnName("codContaBanco");

                entity.Property(e => e.CodResponsavel).HasColumnName("codResponsavel");

                entity.Property(e => e.CodTipoMovimentacao).HasColumnName("codTipoMovimentacao");

                entity.Property(e => e.DataHora).HasColumnName("dataHora");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<TbMunicipiosIbge>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PRIMARY");

                entity.ToTable("tb_municipios_ibge");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("municipio");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("uf")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TbNfe>(entity =>
            {
                entity.HasKey(e => e.CodNfe)
                    .HasName("PRIMARY");

                entity.ToTable("tb_nfe");

                entity.HasIndex(e => e.CodLoja, "fk_tb_nfe_tb_loja1_idx");

                entity.Property(e => e.CodNfe).HasColumnName("codNFe");

                entity.Property(e => e.Chave)
                    .IsRequired()
                    .HasMaxLength(44)
                    .HasColumnName("chave")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CodLoja)
                    .HasColumnName("codLoja")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodSolicitacao).HasColumnName("codSolicitacao");

                entity.Property(e => e.Correcao)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("correcao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DataCancelamento).HasColumnName("dataCancelamento");

                entity.Property(e => e.DataCartaCorrecao).HasColumnName("dataCartaCorrecao");

                entity.Property(e => e.DataEmissao).HasColumnName("dataEmissao");

                entity.Property(e => e.JustificativaCancelamento)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("justificativaCancelamento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MensagemSituacaoProtocoloCancelamento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("mensagemSituacaoProtocoloCancelamento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MensagemSituacaoProtocoloUso)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("mensagemSituacaoProtocoloUso")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MensagemSituacaoReciboEnvio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("mensagemSituacaoReciboEnvio")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MensagemSitucaoCartaCorrecao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("mensagemSitucaoCartaCorrecao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("modelo")
                    .HasDefaultValueSql("'55'")
                    .IsFixedLength(true);

                entity.Property(e => e.NumeroLoteEnvio)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("numeroLoteEnvio")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroProtocoloCancelamento)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("numeroProtocoloCancelamento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroProtocoloCartaCorrecao)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("numeroProtocoloCartaCorrecao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroProtocoloUso)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("numeroProtocoloUso")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroRecibo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("numeroRecibo")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroSequenciaNfe).HasColumnName("numeroSequenciaNFe");

                entity.Property(e => e.SeqCartaCorrecao).HasColumnName("seqCartaCorrecao");

                entity.Property(e => e.SituacaoNfe)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("situacaoNfe")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.SituacaoProtocoloCancelamento)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("situacaoProtocoloCancelamento")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SituacaoProtocoloCartaCorrecao)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("situacaoProtocoloCartaCorrecao")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SituacaoProtocoloUso)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("situacaoProtocoloUso")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SituacaoReciboEnvio)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("situacaoReciboEnvio")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<TbPerfil>(entity =>
            {
                entity.HasKey(e => e.CodPerfil)
                    .HasName("PRIMARY");

                entity.ToTable("tb_perfil");

                entity.Property(e => e.CodPerfil).HasColumnName("codPerfil");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TbPerfilFuncionalidade>(entity =>
            {
                entity.HasKey(e => new { e.CodPerfil, e.CodFuncionalidade })
                    .HasName("PRIMARY");

                entity.ToTable("tb_perfil_funcionalidade");

                entity.HasIndex(e => e.CodFuncionalidade, "idx_fk_tb_perfil_funcionalidade_codfuncionalidade");

                entity.Property(e => e.CodPerfil).HasColumnName("codPerfil");

                entity.Property(e => e.CodFuncionalidade).HasColumnName("codFuncionalidade");
            });

            modelBuilder.Entity<TbPermissao>(entity =>
            {
                entity.HasKey(e => new { e.CodPessoa, e.CodFuncionalidade })
                    .HasName("PRIMARY");

                entity.ToTable("tb_permissao");

                entity.HasIndex(e => e.CodFuncionalidade, "idx_fk_tb_permissao_codfuncionalidade");

                entity.HasIndex(e => e.CodPessoa, "idx_fk_tb_permissao_codpessoa");

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");

                entity.Property(e => e.CodFuncionalidade).HasColumnName("codFuncionalidade");

                entity.Property(e => e.Permissao).HasColumnName("permissao");
            });

            modelBuilder.Entity<TbPessoa>(entity =>
            {
                entity.HasKey(e => e.CodPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("tb_pessoa");

                entity.HasIndex(e => e.CodMunicipiosIbge, "fk_tb_pessoa_tb_municipios_ibge1_idx");

                entity.HasIndex(e => e.Nome, "idx_uq_tb_pessoa_nome")
                    .IsUnique();

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(40)
                    .HasColumnName("bairro");

                entity.Property(e => e.BloquearCrediario).HasColumnName("bloquearCrediario");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep")
                    .IsFixedLength(true);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(40)
                    .HasColumnName("cidade");

                entity.Property(e => e.CodMunicipiosIbge)
                    .HasColumnName("codMunicipiosIBGE")
                    .HasDefaultValueSql("'2800308'");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(40)
                    .HasColumnName("complemento");

                entity.Property(e => e.CpfCnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cpf_Cnpj")
                    .IsFixedLength(true);

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
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("limiteCompra");

                entity.Property(e => e.Nome)
                    .IsRequired()
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
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("uf")
                    .IsFixedLength(true);

                entity.Property(e => e.ValorComissao)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("valorComissao")
                    .HasDefaultValueSql("'0.00'");
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

                entity.Property(e => e.CodPlanoConta).HasColumnName("codPlanoConta");

                entity.Property(e => e.CodGrupoConta).HasColumnName("codGrupoConta");

                entity.Property(e => e.CodTipoConta)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("codTipoConta")
                    .IsFixedLength(true);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("descricao");

                entity.Property(e => e.DiaBase).HasColumnName("diaBase");
            });

            modelBuilder.Entity<TbPontaEstoque>(entity =>
            {
                entity.HasKey(e => e.CodPontaEstoque)
                    .HasName("PRIMARY");

                entity.ToTable("tb_ponta_estoque");

                entity.HasIndex(e => e.CodProduto, "fk_tb_ponta_estoque_tb_produto1_idx");

                entity.Property(e => e.CodPontaEstoque).HasColumnName("codPontaEstoque");

                entity.Property(e => e.Caracteristica)
                    .HasMaxLength(45)
                    .HasColumnName("caracteristica");

                entity.Property(e => e.CodProduto).HasColumnName("codProduto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("quantidade");
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

                entity.Property(e => e.CodProduto).HasColumnName("codProduto");

                entity.Property(e => e.CodCst)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("codCST")
                    .IsFixedLength(true);

                entity.Property(e => e.CodFabricante)
                    .HasColumnName("codFabricante")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodGrupo)
                    .HasColumnName("codGrupo")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodSituacaoProduto)
                    .HasColumnType("tinyint")
                    .HasColumnName("codSituacaoProduto")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodSubgrupo)
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
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.EmPromocao)
                    .HasColumnName("emPromocao")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ExibeNaListagem)
                    .HasColumnName("exibeNaListagem")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Frete)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("frete")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Icms)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("icms")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.IcmsSubstituto)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("icms_substituto");

                entity.Property(e => e.Ipi)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("ipi")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.LucroPrecoRevenda)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("lucroPrecoRevenda")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.LucroPrecoVendaAtacado)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("lucroPrecoVendaAtacado")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.LucroPrecoVendaVarejo)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("lucroPrecoVendaVarejo")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Ncmsh)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("ncmsh")
                    .IsFixedLength(true);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.NomeProdutoFabricante)
                    .HasMaxLength(50)
                    .HasColumnName("nomeProdutoFabricante");

                entity.Property(e => e.PrecoRevenda)
                    .HasColumnType("decimal(10,3)")
                    .HasColumnName("precoRevenda")
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.PrecoVendaAtacado)
                    .HasColumnType("decimal(10,3)")
                    .HasColumnName("precoVendaAtacado")
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.PrecoVendaVarejo)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("precoVendaVarejo")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.QtdProdutoAtacado)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("qtdProdutoAtacado")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.QuantidadeEmbalagem)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("quantidadeEmbalagem")
                    .HasDefaultValueSql("'1.00'");

                entity.Property(e => e.ReferenciaFabricante)
                    .HasMaxLength(20)
                    .HasColumnName("referenciaFabricante");

                entity.Property(e => e.Simples)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("simples")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TemVencimento)
                    .HasColumnName("temVencimento")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UltimaDataAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("ultimaDataAtualizacao");

                entity.Property(e => e.UltimoPrecoCompra)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("ultimoPrecoCompra")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Unidade)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("unidade");

                entity.Property(e => e.UnidadeCompra)
                    .HasMaxLength(6)
                    .HasColumnName("unidadeCompra");
            });

            modelBuilder.Entity<TbProdutoLoja>(entity =>
            {
                entity.HasKey(e => new { e.CodLoja, e.CodProduto })
                    .HasName("PRIMARY");

                entity.ToTable("tb_produto_loja");

                entity.HasIndex(e => e.CodLoja, "idx_fk_tb_produto_loja_codloja");

                entity.HasIndex(e => e.CodProduto, "idx_fk_tb_produto_loja_codproduto");

                entity.Property(e => e.CodLoja).HasColumnName("codLoja");

                entity.Property(e => e.CodProduto).HasColumnName("codProduto");

                entity.Property(e => e.EstoqueMaximo)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("estoqueMaximo");

                entity.Property(e => e.Localizacao)
                    .HasMaxLength(30)
                    .HasColumnName("localizacao");

                entity.Property(e => e.Localizacao2)
                    .HasMaxLength(30)
                    .HasColumnName("localizacao2");

                entity.Property(e => e.QtdEstoque)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("qtdEstoque");

                entity.Property(e => e.QtdEstoqueAux)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("qtdEstoqueAux");
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

                entity.Property(e => e.CodSaidaFormaPagamento).HasColumnName("codSaidaFormaPagamento");

                entity.Property(e => e.CodCartao)
                    .HasColumnName("codCartao")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodContaBanco).HasColumnName("codContaBanco");

                entity.Property(e => e.CodFormaPagamento).HasColumnName("codFormaPagamento");

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IntervaloDias).HasColumnName("intervaloDias");

                entity.Property(e => e.NumeroControle)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("numeroControle");

                entity.Property(e => e.Parcelas).HasColumnName("parcelas");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valor")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<TbSaidaNfe>(entity =>
            {
                entity.HasKey(e => new { e.CodSaida, e.CodNfe })
                    .HasName("PRIMARY");

                entity.ToTable("tb_saida_nfe");

                entity.HasIndex(e => e.CodNfe, "fk_tb_saida_has_tb_nfe_tb_nfe1_idx");

                entity.HasIndex(e => e.CodSaida, "fk_tb_saida_has_tb_nfe_tb_saida1_idx");

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.Property(e => e.CodNfe).HasColumnName("codNFe");

                entity.HasOne(d => d.CodNfeNavigation)
                    .WithMany(p => p.TbSaidaNves)
                    .HasForeignKey(d => d.CodNfe)
                    .HasConstraintName("fk_tb_saida_has_tb_nfe_tb_nfe1");

                entity.HasOne(d => d.CodSaidaNavigation)
                    .WithMany(p => p.TbSaidaNves)
                    .HasForeignKey(d => d.CodSaida)
                    .HasConstraintName("fk_tb_saida_has_tb_nfe_tb_saida1");
            });

            modelBuilder.Entity<TbSaidaPedido>(entity =>
            {
                entity.HasKey(e => new { e.CodSaida, e.CodPedidoGerado })
                    .HasName("PRIMARY");

                entity.ToTable("tb_saida_pedido");

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.Property(e => e.CodPedidoGerado).HasColumnName("codPedidoGerado");

                entity.Property(e => e.TotalAvista)
                    .HasColumnType("decimal(10,2)")
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

                entity.Property(e => e.CodSaidaProduto).HasColumnName("codSaidaProduto");

                entity.Property(e => e.BaseCalculoIcms)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("baseCalculoICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.BaseCalculoIcmssubst)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("baseCalculoICMSSubst")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Cfop).HasColumnName("cfop");

                entity.Property(e => e.CodCst)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("codCST")
                    .IsFixedLength(true);

                entity.Property(e => e.CodProduto).HasColumnName("codProduto");

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.Property(e => e.DataValidade).HasColumnName("data_validade");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("desconto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("quantidade")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("subtotal")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.SubtotalAvista)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("subtotalAVista");

                entity.Property(e => e.ValorIcms)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIcmssubst)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorICMSSubst")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIpi)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorIPI")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorVenda)
                    .HasColumnType("decimal(10,3)")
                    .HasColumnName("valorVenda")
                    .HasDefaultValueSql("'0.000'");

                entity.HasOne(d => d.CodCstNavigation)
                    .WithMany(p => p.TbSaidaProdutos)
                    .HasForeignKey(d => d.CodCst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_saida_produto_tb_cst1");
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

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.Property(e => e.BaseCalculoIcms)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("baseCalculoICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.BaseCalculoIcmssubst)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("baseCalculoICMSSubst")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.CodCliente).HasColumnName("codCliente");

                entity.Property(e => e.CodEmpresaFrete)
                    .HasColumnName("codEmpresaFrete")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodEntrada)
                    .HasColumnName("codEntrada")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodLojaOrigem)
                    .HasColumnName("codLojaOrigem")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodProfissional).HasColumnName("codProfissional");

                entity.Property(e => e.CodSituacaoPagamentos).HasColumnName("codSituacaoPagamentos");

                entity.Property(e => e.CodTipoSaida).HasColumnName("codTipoSaida");

                entity.Property(e => e.CpfCnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cpf_cnpj");

                entity.Property(e => e.DataEmissaoDocFiscal).HasColumnName("dataEmissaoDocFiscal");

                entity.Property(e => e.DataSaida).HasColumnName("dataSaida");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(10,2)")
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
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("numero")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.NumeroCartaoVenda).HasColumnName("numeroCartaoVenda");

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasMaxLength(350)
                    .HasColumnName("observacao");

                entity.Property(e => e.OutrasDespesas)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("outrasDespesas")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PedidoGerado)
                    .HasMaxLength(10)
                    .HasColumnName("pedidoGerado");

                entity.Property(e => e.PesoBruto)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("pesoBruto")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PesoLiquido)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("pesoLiquido")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.QuantidadeVolumes)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("quantidadeVolumes")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TipoDocumentoFiscal)
                    .IsRequired()
                    .HasColumnType("enum('ECF','NFCE')")
                    .HasColumnName("tipoDocumentoFiscal")
                    .HasDefaultValueSql("'ECF'");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalAvista)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalAVista")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalLucro)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalLucro")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalNotaFiscal)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalNotaFiscal")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.TotalPago)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("totalPago")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Troco)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("troco")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorFrete)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorFrete")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIcms)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorICMS")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIcmssubst)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorICMSSubst")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorIpi)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorIPI")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ValorSeguro)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorSeguro")
                    .HasDefaultValueSql("'0.00'");

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
            });

            modelBuilder.Entity<TbSituacaoContum>(entity =>
            {
                entity.HasKey(e => e.CodSituacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_situacao_conta");

                entity.Property(e => e.CodSituacao)
                    .HasMaxLength(1)
                    .HasColumnName("codSituacao")
                    .IsFixedLength(true);

                entity.Property(e => e.DescricaoSituacao)
                    .HasMaxLength(30)
                    .HasColumnName("descricaoSituacao");
            });

            modelBuilder.Entity<TbSituacaoPagamento>(entity =>
            {
                entity.HasKey(e => e.CodSituacaoPagamentos)
                    .HasName("PRIMARY");

                entity.ToTable("tb_situacao_pagamentos");

                entity.Property(e => e.CodSituacaoPagamentos).HasColumnName("codSituacaoPagamentos");

                entity.Property(e => e.DescricaoSituacaoPagamentos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("descricaoSituacaoPagamentos");
            });

            modelBuilder.Entity<TbSituacaoProduto>(entity =>
            {
                entity.HasKey(e => e.CodSituacaoProduto)
                    .HasName("PRIMARY");

                entity.ToTable("tb_situacao_produto");

                entity.Property(e => e.CodSituacaoProduto)
                    .HasColumnType("tinyint")
                    .HasColumnName("codSituacaoProduto");

                entity.Property(e => e.DescricaoSituacao)
                    .IsRequired()
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

                entity.Property(e => e.CodSolicitacao).HasColumnName("codSolicitacao");

                entity.Property(e => e.CartaoAutorizado).HasColumnName("cartaoAutorizado");

                entity.Property(e => e.CartaoProcessado).HasColumnName("cartaoProcessado");

                entity.Property(e => e.CodMotivoCartaoNegado).HasColumnName("codMotivoCartaoNegado");

                entity.Property(e => e.DataSolicitacao).HasColumnName("dataSolicitacao");

                entity.Property(e => e.EhComplementar).HasColumnName("ehComplementar");

                entity.Property(e => e.EhEspelho).HasColumnName("ehEspelho");

                entity.Property(e => e.EmProcessamento).HasColumnName("emProcessamento");

                entity.Property(e => e.HaPagamentoCartao).HasColumnName("haPagamentoCartao");

                entity.Property(e => e.HostSolicitante)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("hostSolicitante")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MotivoCartaoNegado)
                    .IsRequired()
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

                entity.Property(e => e.CodNfe).HasColumnName("codNFe");

                entity.Property(e => e.TipoSolicitacao)
                    .IsRequired()
                    .HasColumnType("enum('CANCELAMENTO','CONSULTA')")
                    .HasColumnName("tipoSolicitacao")
                    .HasDefaultValueSql("'CONSULTA'");
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
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("codSolicitacaoPagamento");

                entity.Property(e => e.CodCartao).HasColumnName("codCartao");

                entity.Property(e => e.CodFormaPagamento)
                    .HasColumnName("codFormaPagamento")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CodSolicitacao).HasColumnName("codSolicitacao");

                entity.Property(e => e.CupomCliente)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("cupomCliente");

                entity.Property(e => e.CupomEstabelecimento)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("cupomEstabelecimento");

                entity.Property(e => e.CupomReduzido)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("cupomReduzido");

                entity.Property(e => e.Parcelas)
                    .HasColumnType("int unsigned")
                    .HasColumnName("parcelas")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valor");

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

                entity.Property(e => e.CodSolicitacao).HasColumnName("codSolicitacao");

                entity.Property(e => e.CodSaida).HasColumnName("codSaida");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("valorTotal");

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

                entity.Property(e => e.CodSubgrupo).HasColumnName("codSubgrupo");

                entity.Property(e => e.CodGrupo).HasColumnName("codGrupo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<TbTipoContum>(entity =>
            {
                entity.HasKey(e => e.CodTipoConta)
                    .HasName("PRIMARY");

                entity.ToTable("tb_tipo_conta");

                entity.Property(e => e.CodTipoConta)
                    .HasMaxLength(1)
                    .HasColumnName("codTipoConta")
                    .IsFixedLength(true);

                entity.Property(e => e.DescricaoTipoConta)
                    .HasMaxLength(30)
                    .HasColumnName("descricaoTipoConta");
            });

            modelBuilder.Entity<TbTipoMovimentacaoContum>(entity =>
            {
                entity.HasKey(e => e.CodTipoMovimentacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_tipo_movimentacao_conta");

                entity.Property(e => e.CodTipoMovimentacao).HasColumnName("codTipoMovimentacao");

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

                entity.Property(e => e.CodTipoSaida).HasColumnName("codTipoSaida");

                entity.Property(e => e.Cfop).HasColumnName("cfop");

                entity.Property(e => e.DescricaoTipoSaida)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("descricaoTipoSaida");
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

                entity.Property(e => e.CodPessoa).HasColumnName("codPessoa");

                entity.Property(e => e.CodPerfil)
                    .HasColumnName("codPerfil")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .HasColumnName("login");

                entity.Property(e => e.Senha)
                    .HasMaxLength(20)
                    .HasColumnName("senha");
            });

            modelBuilder.Entity<TpTipoEntradum>(entity =>
            {
                entity.HasKey(e => e.CodTipoEntrada)
                    .HasName("PRIMARY");

                entity.ToTable("tp_tipo_entrada");

                entity.Property(e => e.CodTipoEntrada).HasColumnName("codTipoEntrada");

                entity.Property(e => e.DescricaoTipoEntrada)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("descricaoTipoEntrada");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
