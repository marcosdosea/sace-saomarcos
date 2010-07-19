

CREATE TABLE sace.tb_baixa_conta (
                codPagamento BIGINT(19) AUTO_INCREMENT NOT NULL,
                codFormaPagamento INT(8) NOT NULL,
                codConta BIGINT(19) NOT NULL,
                valorPago DECIMAL(10,2) NOT NULL,
                valorDiferenca DECIMAL(10,2) DEFAULT 0.00,
                codContaBanco BIGINT(19) NOT NULL,
                dataBaixa DATETIME,
                PRIMARY KEY (codPagamento)
);


CREATE TABLE sace.tb_banco (
                codBanco INT(8) AUTO_INCREMENT NOT NULL,
                nome VARCHAR(30) NOT NULL,
                PRIMARY KEY (codBanco)
);


CREATE TABLE sace.tb_cartao_credito (
                codCartao INT(8) AUTO_INCREMENT NOT NULL,
                nome VARCHAR(30) NOT NULL,
                diaBase INT(8),
                codContaBanco BIGINT(19) NOT NULL,
                PRIMARY KEY (codCartao)
);


CREATE TABLE sace.tb_cfop (
                cfop INT(8) NOT NULL,
                codCfop INT(8) NOT NULL,
                descricao VARCHAR(40),
                icms DECIMAL(5,2),
                PRIMARY KEY (cfop)
);


CREATE TABLE sace.tb_configuracao_sistema (
                codigo INT(8) NOT NULL,
                lucro_minimo DECIMAL(5,2),
                PRIMARY KEY (codigo)
);


CREATE TABLE sace.tb_conta (
                codConta BIGINT(19) AUTO_INCREMENT NOT NULL,
                codEntrada BIGINT(19),
                codSaida BIGINT(19),
                documento VARCHAR(20),
                codPlanoConta BIGINT(19) NOT NULL,
                codPessoa BIGINT(19),
                dataVencimento DATE NOT NULL,
                valor DECIMAL(10,2) NOT NULL,
                situacao CHAR(1),
                observacao VARCHAR(64),
                tipoConta CHAR(1) NOT NULL,
                PRIMARY KEY (codConta)
);


CREATE TABLE sace.tb_conta_banco (
                codContaBanco BIGINT(19) NOT NULL,
                agencia VARCHAR(10),
                descricao VARCHAR(30),
                saldo DECIMAL(10,2),
                codBanco INT(8),
                PRIMARY KEY (codContaBanco)
);


CREATE TABLE sace.tb_contato_empresa (
                codigoEmpresa BIGINT(19) NOT NULL,
                codPessoa BIGINT(19) NOT NULL,
                PRIMARY KEY (codigoEmpresa, codPessoa)
);


CREATE TABLE sace.tb_entrada (
                codEntrada BIGINT(19) AUTO_INCREMENT NOT NULL,
                codigoEmpresaFrete BIGINT(19) NOT NULL,
                valorCustoFrete DECIMAL(10,2),
                dataEntrada DATETIME,
                valorTotal DECIMAL(10,2),
                tipoEntrada CHAR(1),
                numeroNotaFiscal BIGINT(19),
                valorICMSSubstituto DECIMAL(10,2),
                icmsPadrao DECIMAL(5,2),
                codigoFornecedor BIGINT(19) NOT NULL,
                PRIMARY KEY (codEntrada)
);


CREATE TABLE sace.tb_entrada_produto (
                codEntrada BIGINT(19) NOT NULL,
                codProduto BIGINT(19) NOT NULL,
                quantidade DECIMAL(10,2),
                valor_compra DECIMAL(10,2),
                ipi DECIMAL(5,2),
                icms DECIMAL(5,2),
                icms_substituto DECIMAL(5,2),
                preco_custo DECIMAL(10,2),
                PRIMARY KEY (codEntrada, codProduto)
);


CREATE TABLE sace.tb_forma_pagamento (
                codFormaPagamento INT(8) NOT NULL,
                descricao VARCHAR(40) NOT NULL,
                PRIMARY KEY (codFormaPagamento)
);


CREATE TABLE sace.tb_funcionalidade (
                codFuncionalidade INT(8) AUTO_INCREMENT NOT NULL,
                descricao VARCHAR(30) NOT NULL,
                PRIMARY KEY (codFuncionalidade)
);


CREATE TABLE sace.tb_grupo (
                codGrupo BIGINT(19) AUTO_INCREMENT NOT NULL,
                descricao VARCHAR(40) NOT NULL,
                PRIMARY KEY (codGrupo)
);


CREATE TABLE sace.tb_grupo_conta (
                codGrupoConta INT(8) AUTO_INCREMENT NOT NULL,
                descricao VARCHAR(40) NOT NULL,
                PRIMARY KEY (codGrupoConta)
);


CREATE TABLE sace.tb_loja (
                codLoja INT(8) AUTO_INCREMENT NOT NULL,
                nome VARCHAR(40) NOT NULL,
                cnpj CHAR(14),
                ie CHAR(10),
                endereco VARCHAR(64),
                bairro VARCHAR(40),
                cep CHAR(8),
                cidade VARCHAR(40),
                uf CHAR(2),
                fone CHAR(10),
                PRIMARY KEY (codLoja)
);


CREATE TABLE sace.tb_movimentacao_conta (
                codMovimentacao BIGINT(19) AUTO_INCREMENT NOT NULL,
                codTipoMovimentacao INT(8) NOT NULL,
                valor DECIMAL(10,2) NOT NULL,
                dataHora DATETIME NOT NULL,
                codResponsavel BIGINT(19) NOT NULL,
                codContaBanco BIGINT(19) NOT NULL,
                PRIMARY KEY (codMovimentacao)
);


CREATE TABLE sace.tb_perfil (
                codPerfil INT(8) NOT NULL,
                nome VARCHAR(20) NOT NULL,
                PRIMARY KEY (codPerfil)
);


CREATE TABLE sace.tb_perfil_funcionalidade (
                codPerfil INT(8) NOT NULL,
                codFuncionalidade INT(8) NOT NULL,
                PRIMARY KEY (codPerfil, codFuncionalidade)
);


CREATE TABLE sace.tb_permissao (
                codPessoa BIGINT(19) NOT NULL,
                codFuncionalidade INT(8) NOT NULL,
                permissao INT(8) NOT NULL,
                PRIMARY KEY (codPessoa, codFuncionalidade)
);


CREATE TABLE sace.tb_pessoa (
                codPessoa BIGINT(19) AUTO_INCREMENT NOT NULL,
                nome VARCHAR(40) NOT NULL,
                cpf_Cnpj CHAR(14),
                endereco VARCHAR(64),
                cep CHAR(8),
                bairro VARCHAR(40),
                cidade VARCHAR(40),
                uf CHAR(2),
                fone1 VARCHAR(10),
                fone2 VARCHAR(10),
                limiteCompra DECIMAL(10,2),
                valorComissao DECIMAL(5,2) DEFAULT 0.00,
                observacao VARCHAR(64),
                Tipo CHAR(1) NOT NULL,
                PRIMARY KEY (codPessoa)
);


CREATE TABLE sace.tb_plano_conta (
                codPlanoConta BIGINT(19) AUTO_INCREMENT NOT NULL,
                codGrupoConta INT(8) NOT NULL,
                descricao VARCHAR(40) NOT NULL,
                tipoConta CHAR(1) NOT NULL,
                diaBase SMALLINT(5),
                PRIMARY KEY (codPlanoConta)
);


CREATE TABLE sace.tb_produto (
                codProduto BIGINT(19) AUTO_INCREMENT NOT NULL,
                nome VARCHAR(40) NOT NULL,
                nomeFabricante VARCHAR(40),
                unidade CHAR(3),
                codigoBarra VARCHAR(40),
                codGrupo BIGINT(19),
                codigoFabricante BIGINT(19),
                temVencimento TINYINT(1) DEFAULT 0,
                cfop INT(8),
                icms DECIMAL(5,2) DEFAULT 0.00,
                icms_substituto DECIMAL(5,2),
                simples DECIMAL(5,2) DEFAULT 0.00,
                ipi DECIMAL(5,2) DEFAULT 0.00,
                frete DECIMAL(5,2) DEFAULT 0.00,
                custoVenda DECIMAL(10,4) DEFAULT 0.0000,
                ultimoPrecoCompra DECIMAL(10,4) DEFAULT 0.0000,
                ultimaDataAtualizacao DATE,
                ultimoPrecoCusto DECIMAL(10,4) DEFAULT 0.0000,
                ultimoPrecoMedio DECIMAL(10,4) DEFAULT 0.0000,
                lucroPrecoVendaVarejo DECIMAL(5,2) DEFAULT 0.00,
                precoVendaVarejo DECIMAL(10,4) DEFAULT 0.0000,
                qtdProdutoAtacado DECIMAL(10,2) DEFAULT 0.00,
                lucroPrecoVendaAtacado DECIMAL(5,2) DEFAULT 0.00,
                precoVendaAtacado DECIMAL(10,4) DEFAULT 0.0000,
                qtdProdutoSuperAtacado DECIMAL(10,2) DEFAULT 0.00,
                lucroPrecoVendaSuperAtacado DECIMAL(5,2) DEFAULT 0.00,
                precoVendaSuperAtacado DECIMAL(10,4) DEFAULT 0.0000,
                exibeNaListagem TINYINT(1) DEFAULT 1,
                PRIMARY KEY (codProduto)
);


CREATE TABLE sace.tb_produto_loja (
                codLoja INT(8) NOT NULL,
                codProduto BIGINT(19) NOT NULL,
                codEntrada BIGINT(19),
                qtdEstoqueFiscal DECIMAL(10,2) DEFAULT 0.00 NOT NULL,
                qtdEstoqueNFiscal DECIMAL(10,2) DEFAULT 0.00 NOT NULL,
                dataValidade DATE,
                precoCusto DECIMAL(10,2) NOT NULL,
                localizacao VARCHAR(30),
                PRIMARY KEY (codLoja, codProduto)
);


CREATE TABLE sace.tb_saida (
                codSaida BIGINT(19) AUTO_INCREMENT NOT NULL,
                dataSaida DATETIME NOT NULL,
                tipoSaida CHAR(1) NOT NULL,
                codCliente BIGINT(19) NOT NULL,
                codProfissional BIGINT(19),
                numeroCartaoVenda INT(8),
                pedidoGerado VARCHAR(10) DEFAULT 'false' NOT NULL,
                total DECIMAL(10,2),
                desconto DECIMAL(10,2),
                totalPago DECIMAL(10,2),
                totalLucro DECIMAL(10,2),
                PRIMARY KEY (codSaida)
);


CREATE TABLE sace.tb_saida_produto (
                codProduto BIGINT(19) NOT NULL,
                codSaida BIGINT(19) NOT NULL,
                quantidade DECIMAL(10,4),
                valorVenda DECIMAL(10,2),
                desconto DECIMAL(10,2),
                subtotal DECIMAL(10,2),
                PRIMARY KEY (codProduto, codSaida)
);


CREATE TABLE sace.tb_tipo_movimentacao_conta (
                codTipoMovimentacao INT(8) NOT NULL,
                descricao VARCHAR(40),
                PRIMARY KEY (codTipoMovimentacao)
);


CREATE TABLE sace.tb_usuario (
                codPessoa BIGINT(19) NOT NULL,
                login VARCHAR(20),
                senha VARCHAR(20),
                codPerfil INT(8),
                PRIMARY KEY (codPessoa)
);


CREATE INDEX idx_pk_tb_conta
 ON sace.tb_conta
 ( codConta );

CREATE UNIQUE INDEX idx_uq_tb_usuario_login
 ON sace.tb_usuario
 ( login );

CREATE UNIQUE INDEX idx_uq_tb_produto_nome
 ON sace.tb_produto
 ( nome );

CREATE INDEX idx_fk_tb_produto_cfop USING BTREE
 ON sace.tb_produto
 ( cfop ASC );

CREATE INDEX idx_fk_tb_conta_banco_codbanco USING BTREE
 ON sace.tb_conta_banco
 ( codBanco ASC );

CREATE INDEX idx_fk_tb_saida_codcliente USING BTREE
 ON sace.tb_saida
 ( codCliente ASC );

CREATE INDEX idx_fk_tb_baixa_conta_codcontabanco USING BTREE
 ON sace.tb_baixa_conta
 ( codContaBanco ASC );

CREATE INDEX idx_fk_tb_baixa_conta_codcontapagar USING BTREE
 ON sace.tb_baixa_conta
 ( codConta ASC );

CREATE INDEX idx_fk_tb_conta_codentrada USING BTREE
 ON sace.tb_conta
 ( codEntrada ASC );

CREATE INDEX idx_fk_tb_baixa_conta_codformapagamento USING BTREE
 ON sace.tb_baixa_conta
 ( codFormaPagamento ASC );

CREATE INDEX idx_fk_tb_perfil_funcionalidade_codfuncionalidade USING BTREE
 ON sace.tb_perfil_funcionalidade
 ( codFuncionalidade ASC );

CREATE INDEX idx_fk_tb_produto_codgrupo USING BTREE
 ON sace.tb_produto
 ( codGrupo ASC );

CREATE INDEX idx_fk_tb_plano_conta_codgrupoconta USING BTREE
 ON sace.tb_plano_conta
 ( codGrupoConta ASC );

CREATE INDEX idx_fk_tb_contato_empresa_codigoempresa USING BTREE
 ON sace.tb_contato_empresa
 ( codigoEmpresa ASC );

CREATE INDEX idx_fk_tb_empresa_codigoempresafrete USING BTREE
 ON sace.tb_entrada
 ( codigoEmpresaFrete ASC );

CREATE INDEX idx_fk_tb_produto_codigofabricante USING BTREE
 ON sace.tb_produto
 ( codigoFabricante ASC );

CREATE INDEX idx_fk_tb_produto_loja_codloja USING BTREE
 ON sace.tb_produto_loja
 ( codLoja ASC );

CREATE INDEX idx_fk_tb_usuario_codperfil USING BTREE
 ON sace.tb_usuario
 ( codPerfil ASC );

CREATE INDEX idx_fk_tb_conta_codpessoa USING BTREE
 ON sace.tb_conta
 ( codPessoa ASC );

CREATE INDEX idx_fk_tb_conta_codplanoconta USING BTREE
 ON sace.tb_conta
 ( codPlanoConta ASC );

CREATE INDEX idx_fk_tb_entrada_produto_codproduto USING BTREE
 ON sace.tb_entrada_produto
 ( codProduto ASC );

CREATE INDEX idx_fk_tb_saida_codprofissional USING BTREE
 ON sace.tb_saida
 ( codProfissional ASC );

CREATE INDEX idx_fk_tb_movimentacao_conta_codresponsavel USING BTREE
 ON sace.tb_movimentacao_conta
 ( codResponsavel ASC );

CREATE INDEX idx_fk_tb_conta_codsaida USING BTREE
 ON sace.tb_conta
 ( codSaida ASC );

CREATE INDEX idx_fk_tb_movimentacao_conta_codtipomovimentacao USING BTREE
 ON sace.tb_movimentacao_conta
 ( codTipoMovimentacao ASC );

CREATE INDEX idx_pk_tb_cfop USING BTREE
 ON sace.tb_cfop
 ( cfop ASC );

CREATE INDEX idx_pk_tb_banco USING BTREE
 ON sace.tb_banco
 ( codBanco ASC );

CREATE INDEX idx_pk_tb_cartao_credito USING BTREE
 ON sace.tb_cartao_credito
 ( codCartao ASC );

CREATE INDEX idx_pk_tb_conta_banco USING BTREE
 ON sace.tb_conta_banco
 ( codContaBanco ASC );

CREATE INDEX idx_pk_tb_entrada USING BTREE
 ON sace.tb_entrada
 ( codEntrada ASC );

CREATE INDEX idx_pk_tb_entrada_produto USING BTREE
 ON sace.tb_entrada_produto
 ( codEntrada ASC, codProduto ASC );

CREATE INDEX idx_pk_tb_forma_pagamento USING BTREE
 ON sace.tb_forma_pagamento
 ( codFormaPagamento ASC );

CREATE INDEX idx_pk_tb_funcionalidade USING BTREE
 ON sace.tb_funcionalidade
 ( codFuncionalidade ASC );

CREATE INDEX idx_pk_tb_perfil_funcionalidade USING BTREE
 ON sace.tb_perfil_funcionalidade
 ( codPerfil ASC, codFuncionalidade ASC );

CREATE INDEX idx_pk_tb_permissao USING BTREE
 ON sace.tb_permissao
 ( codPessoa ASC, codFuncionalidade ASC );

CREATE INDEX idx_fk_tb_grupo USING BTREE
 ON sace.tb_grupo
 ( codGrupo ASC );

CREATE INDEX idx_pk_tb_grupo_conta USING BTREE
 ON sace.tb_grupo_conta
 ( codGrupoConta ASC );

CREATE INDEX idx_pk_tb_cartao_credito USING BTREE
 ON sace.tb_configuracao_sistema
 ( codigo ASC );

CREATE INDEX idx_pk_tb_contato_empresa USING BTREE
 ON sace.tb_contato_empresa
 ( codigoEmpresa ASC, codPessoa ASC );

CREATE INDEX idx_pk_tb_produto_loja USING BTREE
 ON sace.tb_produto_loja
 ( codLoja ASC, codProduto ASC );

CREATE INDEX idx_pk_tb_loja USING BTREE
 ON sace.tb_loja
 ( codLoja );

CREATE INDEX idx_pk_tb_movimentacao_conta USING BTREE
 ON sace.tb_movimentacao_conta
 ( codMovimentacao ASC );

CREATE INDEX idx_pk_tb_baixa_conta USING BTREE
 ON sace.tb_baixa_conta
 ( codPagamento ASC );

CREATE INDEX idx_pk_tb_perfil USING BTREE
 ON sace.tb_perfil
 ( codPerfil ASC );

CREATE INDEX idx_pk_tb_pessoa USING BTREE
 ON sace.tb_pessoa
 ( codPessoa ASC );

CREATE INDEX idx_pk_tb_plano_conta USING BTREE
 ON sace.tb_plano_conta
 ( codPlanoConta ASC );

CREATE INDEX idx_pk_tb_produto USING BTREE
 ON sace.tb_produto
 ( codProduto ASC );

CREATE INDEX idx_pk_tb_saida_produto USING BTREE
 ON sace.tb_saida_produto
 ( codProduto ASC, codSaida ASC );

CREATE INDEX idx_pk_tb_saida USING BTREE
 ON sace.tb_saida
 ( codSaida ASC );

CREATE INDEX idx_pk_tb_tipo_movimentacao_conta USING BTREE
 ON sace.tb_tipo_movimentacao_conta
 ( codTipoMovimentacao ASC );

CREATE UNIQUE INDEX idx_uq_tb_grupo_descricao USING BTREE
 ON sace.tb_grupo
 ( descricao ASC );

CREATE UNIQUE INDEX idx_uq_tb_banco_nome USING BTREE
 ON sace.tb_banco
 ( nome ASC );

ALTER TABLE sace.tb_conta_banco ADD CONSTRAINT fk_tb_conta_banco_codbanco
FOREIGN KEY (codBanco)
REFERENCES sace.tb_banco (codBanco)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_produto ADD CONSTRAINT fk_tb_produto_cfop
FOREIGN KEY (cfop)
REFERENCES sace.tb_cfop (cfop)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_baixa_conta ADD CONSTRAINT fk_tb_pagamento_codconta
FOREIGN KEY (codConta)
REFERENCES sace.tb_conta (codConta)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_baixa_conta ADD CONSTRAINT fk_tb_pagamento_codcontabanco
FOREIGN KEY (codContaBanco)
REFERENCES sace.tb_conta_banco (codContaBanco)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_cartao_credito ADD CONSTRAINT fk_tb_cartao_credito_codcontabanco
FOREIGN KEY (codContaBanco)
REFERENCES sace.tb_conta_banco (codContaBanco)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_movimentacao_conta ADD CONSTRAINT fk_tb_movimentacao_conta_codcontabanco
FOREIGN KEY (codContaBanco)
REFERENCES sace.tb_conta_banco (codContaBanco)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_conta ADD CONSTRAINT fk_tb_conta_pagar_codentrada
FOREIGN KEY (codEntrada)
REFERENCES sace.tb_entrada (codEntrada)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_entrada_produto ADD CONSTRAINT fk_tb_entrada_produto_codentrada
FOREIGN KEY (codEntrada)
REFERENCES sace.tb_entrada (codEntrada)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_produto_loja ADD CONSTRAINT fk_tb_produto_loja_codentrada
FOREIGN KEY (codEntrada)
REFERENCES sace.tb_entrada (codEntrada)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_baixa_conta ADD CONSTRAINT fk_tb_pagamento_codformapagamento
FOREIGN KEY (codFormaPagamento)
REFERENCES sace.tb_forma_pagamento (codFormaPagamento)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_perfil_funcionalidade ADD CONSTRAINT fk_tb_perfil_funcionalidade_codfuncionalidade
FOREIGN KEY (codFuncionalidade)
REFERENCES sace.tb_funcionalidade (codFuncionalidade)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_permissao ADD CONSTRAINT fk_tb_permissao_codfuncionalidade
FOREIGN KEY (codFuncionalidade)
REFERENCES sace.tb_funcionalidade (codFuncionalidade)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_produto ADD CONSTRAINT fk_tb_produto_codgrupo
FOREIGN KEY (codGrupo)
REFERENCES sace.tb_grupo (codGrupo)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_plano_conta ADD CONSTRAINT fk_tb_plano_conta_codgrupoconta
FOREIGN KEY (codGrupoConta)
REFERENCES sace.tb_grupo_conta (codGrupoConta)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_produto_loja ADD CONSTRAINT fk_tb_produto_loja_codloja
FOREIGN KEY (codLoja)
REFERENCES sace.tb_loja (codLoja)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_perfil_funcionalidade ADD CONSTRAINT fk_tb_perfil_funcionalidade_codperfil
FOREIGN KEY (codPerfil)
REFERENCES sace.tb_perfil (codPerfil)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_usuario ADD CONSTRAINT fk_tb_usuario_acodperfil
FOREIGN KEY (codPerfil)
REFERENCES sace.tb_perfil (codPerfil)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_conta ADD CONSTRAINT fk_conta_pagar_codpessoa
FOREIGN KEY (codPessoa)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_contato_empresa ADD CONSTRAINT fk_tb_contato_empresa_codpessoa
FOREIGN KEY (codigoEmpresa)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_contato_empresa ADD CONSTRAINT fk_tb_contato_empresa_codpessoacontato
FOREIGN KEY (codPessoa)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_entrada ADD CONSTRAINT fk_tb_entrada_codempresafrete
FOREIGN KEY (codigoEmpresaFrete)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_entrada ADD CONSTRAINT fk_tb_entrada_codfornecedor
FOREIGN KEY (codigoFornecedor)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_movimentacao_conta ADD CONSTRAINT fk_movimentacao_conta_codresponsavel
FOREIGN KEY (codResponsavel)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_produto ADD CONSTRAINT fk_tb_produto_codfabricante
FOREIGN KEY (codigoFabricante)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_saida ADD CONSTRAINT fk_tb_saida_codcliente
FOREIGN KEY (codCliente)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_saida ADD CONSTRAINT fk_tb_saida_codprofissional
FOREIGN KEY (codProfissional)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_usuario ADD CONSTRAINT fk_tb_usuario_codpessoa
FOREIGN KEY (codPessoa)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_conta ADD CONSTRAINT fk_conta_pagar_codplanoconta
FOREIGN KEY (codPlanoConta)
REFERENCES sace.tb_plano_conta (codPlanoConta)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_entrada_produto ADD CONSTRAINT fk_tb_entrada_produto_codproduto
FOREIGN KEY (codProduto)
REFERENCES sace.tb_produto (codProduto)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_produto_loja ADD CONSTRAINT fk_tb_produto_loja_codproduto
FOREIGN KEY (codProduto)
REFERENCES sace.tb_produto (codProduto)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_saida_produto ADD CONSTRAINT fk_tb_saida_produto_codproduto
FOREIGN KEY (codProduto)
REFERENCES sace.tb_produto (codProduto)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_conta ADD CONSTRAINT fk_tb_conta_pagar_codsaida
FOREIGN KEY (codSaida)
REFERENCES sace.tb_saida (codSaida)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_saida_produto ADD CONSTRAINT fk_tb_saida_produto_codsaida
FOREIGN KEY (codSaida)
REFERENCES sace.tb_saida (codSaida)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_movimentacao_conta ADD CONSTRAINT fk_movimentacao_conta_codtipomovimentacao
FOREIGN KEY (codTipoMovimentacao)
REFERENCES sace.tb_tipo_movimentacao_conta (codTipoMovimentacao)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_permissao ADD CONSTRAINT fk_tb_permissao_codpessoa
FOREIGN KEY (codPessoa)
REFERENCES sace.tb_usuario (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
