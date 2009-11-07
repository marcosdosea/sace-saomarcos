CREATE TABLE SACE.TB_LOJA (
       codLoja INT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(40) NOT NULL
     , cnpj CHAR(14)
     , ie CHAR(10)
     , endereco VARCHAR(100)
     , bairro VARCHAR(40)
     , cep CHAR(8)
     , cidade VARCHAR(40)
     , uf CHAR(2)
     , fone CHAR(10)
     , UNIQUE UQ_TB_LOJA_1 (nome)
     , PRIMARY KEY (codLoja)
);

CREATE TABLE SACE.TB_EMPRESA (
       codigoEmpresa BIGINT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(40) NOT NULL
     , cnpj VARCHAR(14)
     , ie VARCHAR(14)
     , fone CHAR(10)
     , endereco VARCHAR(100)
     , bairro VARCHAR(40)
     , cep CHAR(8)
     , cidade VARCHAR(40)
     , uf CHAR(2)
     , limiteCompra DECIMAL(10, 2)
     , observacao VARCHAR(300)
     , UNIQUE UQ_TB_EMPRESA_1 (nome)
     , PRIMARY KEY (codigoEmpresa)
);

CREATE TABLE SACE.TB_FORMA_PAGAMENTO (
       codFormaPagamento INT NOT NULL
     , descricao VARCHAR(40) NOT NULL
     , PRIMARY KEY (codFormaPagamento)
);

CREATE TABLE SACE.TB_GRUPO (
       codGrupo BIGINT NOT NULL AUTO_INCREMENT
     , descricao VARCHAR(40) NOT NULL
     , UNIQUE UQ_TB_GRUPO_1 (descricao)
     , PRIMARY KEY (codGrupo)
);

CREATE TABLE SACE.TB_TIPO_MOVIMENTACAO_CONTA (
       codTipoMovimentacao INT NOT NULL
     , descricao VARCHAR(40)
     , PRIMARY KEY (codTipoMovimentacao)
);

CREATE TABLE SACE.TB_GRUPO_CONTA (
       codGrupoConta INT NOT NULL AUTO_INCREMENT
     , descricao VARCHAR(40) NOT NULL
     , PRIMARY KEY (codGrupoConta)
);

CREATE TABLE SACE.TB_BANCO (
       codBanco INT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(30) NOT NULL
     , UNIQUE UQ_TB_BANCO_1 (nome)
     , PRIMARY KEY (codBanco)
);

CREATE TABLE SACE.TB_CONFIGURACAO_SISTEMA (
       codigo INT NOT NULL
     , lucro_minimo DECIMAL(5, 2)
     , PRIMARY KEY (codigo)
);

CREATE TABLE SACE.TB_FUNCIONALIDADE (
       codFuncionalidade INT NOT NULL AUTO_INCREMENT
     , descricao VARCHAR(30) NOT NULL
     , PRIMARY KEY (codFuncionalidade)
);

CREATE TABLE SACE.TB_PESSOA (
       codPessoa BIGINT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(40) NOT NULL
     , cpf CHAR(11)
     , endereco VARCHAR(100)
     , cep CHAR(8)
     , bairro VARCHAR(40)
     , cidade VARCHAR(40)
     , uf CHAR(2)
     , fone1 VARCHAR(10)
     , fone2 VARCHAR(10)
     , limiteCompra DECIMAL(10, 2)
     , valorComissao DECIMAL(5, 2) DEFAULT 0
     , observacao VARCHAR(300)
     , UNIQUE UQ_TB_PESSOA_1 (nome)
     , PRIMARY KEY (codPessoa)
);

CREATE TABLE SACE.TB_ENTRADA (
       codEntrada BIGINT(10) NOT NULL AUTO_INCREMENT
     , codigoFornecedor BIGINT NOT NULL
     , codigoEmpresaFrete BIGINT NOT NULL
     , valorCustoFrete DECIMAL(10, 2)
     , dataEntrada DATETIME
     , valorTotal DECIMAL(10, 2)
     , tipoEntrada CHAR
     , numeroNotaFiscal BIGINT
     , PRIMARY KEY (codEntrada)
     , INDEX (codigoFornecedor)
     , CONSTRAINT FK_TB_ENTRADA_1 FOREIGN KEY (codigoFornecedor)
                  REFERENCES SACE.TB_EMPRESA (codigoEmpresa)
     , INDEX (codigoEmpresaFrete)
     , CONSTRAINT FK_TB_ENTRADA_2 FOREIGN KEY (codigoEmpresaFrete)
                  REFERENCES SACE.TB_EMPRESA (codigoEmpresa)
);

CREATE TABLE SACE.TB_SAIDA (
       codSaida BIGINT NOT NULL AUTO_INCREMENT
     , dataSaida DATETIME NOT NULL
     , tipoSaida CHAR NOT NULL
     , codCliente BIGINT NOT NULL
     , codProfissional BIGINT
     , numeroCartaoVenda INT
     , pedidoGerado VARCHAR(10) NOT NULL DEFAULT 'false'
     , total DECIMAL(10, 2)
     , desconto DECIMAL(10, 2)
     , totalPago DECIMAL(10, 2)
     , totalLucro DECIMAL(10, 2)
     , PRIMARY KEY (codSaida)
     , INDEX (codCliente)
     , CONSTRAINT FK_TB_SAIDA_1 FOREIGN KEY (codCliente)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
     , INDEX (codProfissional)
     , CONSTRAINT FK_TB_SAIDA_2 FOREIGN KEY (codProfissional)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
);

CREATE TABLE SACE.TB_PLANO_CONTA (
       codPlanoConta BIGINT NOT NULL AUTO_INCREMENT
     , codGrupoConta INT NOT NULL
     , descricao VARCHAR(40) NOT NULL
     , tipoConta CHAR(1) NOT NULL
     , diaBase SMALLINT
     , PRIMARY KEY (codPlanoConta)
     , INDEX (codGrupoConta)
     , CONSTRAINT FK_TB_PLANO_CONTA_2 FOREIGN KEY (codGrupoConta)
                  REFERENCES SACE.TB_GRUPO_CONTA (codGrupoConta)
);

CREATE TABLE SACE.TB_PRODUTO (
       codProduto BIGINT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(40) NOT NULL
     , nomeFabricante VARCHAR(40)
     , unidade CHAR(3) NOT NULL
     , codigoBarra VARCHAR(40)
     , codGrupo BIGINT NOT NULL
     , codigoFabricante BIGINT
     , temVencimento BOOLEAN DEFAULT false
     , cfop CHAR(4)
     , icms DECIMAL(5, 2)
     , simples DECIMAL(5, 2) DEFAULT 0
     , ipi DECIMAL(5, 2) DEFAULT 0
     , frete DECIMAL(5, 2) DEFAULT 0
     , custoVenda DECIMAL(10, 2) DEFAULT 0
     , ultimoPrecoCompra DECIMAL(10, 2) DEFAULT 0
     , ultimoPrecoCusto DECIMAL(10, 2) DEFAULT 0
     , ultimaDataCompra DATE
     , ultimaDataAtualizacao DATE
     , lucroPrecoVendaVarejo DECIMAL(5, 2) DEFAULT 0
     , precoVendaVarejo DECIMAL(10, 2) DEFAULT 0
     , lucroPrecoVendaAtacado DECIMAL(5, 2) DEFAULT 0
     , precoVendaAtacado DECIMAL(10, 2) DEFAULT 0
     , lucroPrecoVendaSuperAtacado DECIMAL(5, 2) DEFAULT 0
     , precoVendaSuperAtacado DECIMAL(10, 2) DEFAULT 0
     , exibiNaListagem BOOLEAN
     , PRIMARY KEY (codProduto)
     , INDEX (codGrupo)
     , CONSTRAINT FK_TB_PRODUTO_1 FOREIGN KEY (codGrupo)
                  REFERENCES SACE.TB_GRUPO (codGrupo)
     , INDEX (codigoFabricante)
     , CONSTRAINT FK_TB_PRODUTO_2 FOREIGN KEY (codigoFabricante)
                  REFERENCES SACE.TB_EMPRESA (codigoEmpresa)
);

CREATE TABLE SACE.TB_CONTA_RECEBER (
       codContaReceber BIGINT NOT NULL AUTO_INCREMENT
     , codEntrada BIGINT(10)
     , codSaida BIGINT
     , documento VARCHAR(20)
     , codPlanoConta BIGINT NOT NULL
     , codPessoa BIGINT NOT NULL
     , codigoEmpresa BIGINT NOT NULL
     , dataVencimento DATE
     , valorRecebimento DECIMAL(10, 2)
     , situacaoRecebimento CHAR(1)
     , observacao VARCHAR(200)
     , PRIMARY KEY (codContaReceber)
     , INDEX (codPlanoConta)
     , CONSTRAINT FK_CONTA_RECEBER_1 FOREIGN KEY (codPlanoConta)
                  REFERENCES SACE.TB_PLANO_CONTA (codPlanoConta)
     , INDEX (codPessoa)
     , CONSTRAINT FK_CONTA_RECEBER_2 FOREIGN KEY (codPessoa)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
     , INDEX (codigoEmpresa)
     , CONSTRAINT FK_CONTA_RECEBER_3 FOREIGN KEY (codigoEmpresa)
                  REFERENCES SACE.TB_EMPRESA (codigoEmpresa)
     , INDEX (codSaida)
     , CONSTRAINT FK_TB_CONTA_RECEBER_5 FOREIGN KEY (codSaida)
                  REFERENCES SACE.TB_SAIDA (codSaida)
     , INDEX (codEntrada)
     , CONSTRAINT FK_TB_CONTA_RECEBER_6 FOREIGN KEY (codEntrada)
                  REFERENCES SACE.TB_ENTRADA (codEntrada)
);

CREATE TABLE SACE.TB_CONTA_BANCO (
       codContaBanco BIGINT NOT NULL
     , agencia VARCHAR(10)
     , descricao VARCHAR(30)
     , saldo DECIMAL(10, 2)
     , codBanco INT
     , PRIMARY KEY (codContaBanco)
     , INDEX (codBanco)
     , CONSTRAINT FK_TB_CONTA_BANCO_1 FOREIGN KEY (codBanco)
                  REFERENCES SACE.TB_BANCO (codBanco)
);

CREATE TABLE SACE.TB_USUARIO (
       codPessoa BIGINT NOT NULL
     , login VARCHAR(20)
     , senha VARCHAR(20)
     , PRIMARY KEY (codPessoa)
     , INDEX (codPessoa)
     , CONSTRAINT FK_TABLE_24_1 FOREIGN KEY (codPessoa)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
);

CREATE TABLE SACE.TB_CONTA_PAGAR (
       codContaPagar BIGINT NOT NULL AUTO_INCREMENT
     , codEntrada BIGINT(10)
     , codSaida BIGINT
     , documento VARCHAR(20)
     , codPlanoConta BIGINT NOT NULL
     , codPessoa BIGINT
     , codigoEmpresa BIGINT
     , dataVencimento DATE NOT NULL
     , valorPagamento DECIMAL(10, 2) NOT NULL
     , situacaoPagamento CHAR(1)
     , observacao VARCHAR(200)
     , PRIMARY KEY (codContaPagar)
     , INDEX (codPessoa)
     , CONSTRAINT FK_CONTA_PAGAR_2 FOREIGN KEY (codPessoa)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
     , INDEX (codigoEmpresa)
     , CONSTRAINT FK_CONTA_PAGAR_3 FOREIGN KEY (codigoEmpresa)
                  REFERENCES SACE.TB_EMPRESA (codigoEmpresa)
     , INDEX (codEntrada)
     , CONSTRAINT FK_TB_CONTA_PAGAR_4 FOREIGN KEY (codEntrada)
                  REFERENCES SACE.TB_ENTRADA (codEntrada)
     , INDEX (codSaida)
     , CONSTRAINT FK_TB_CONTA_PAGAR_6 FOREIGN KEY (codSaida)
                  REFERENCES SACE.TB_SAIDA (codSaida)
     , INDEX (codPlanoConta)
     , CONSTRAINT FK_CONTA_PAGAR_1 FOREIGN KEY (codPlanoConta)
                  REFERENCES SACE.TB_PLANO_CONTA (codPlanoConta)
);

CREATE TABLE SACE.TB_ENTRADA_PRODUTO (
       codEntrada BIGINT(10) NOT NULL
     , codProduto BIGINT NOT NULL
     , quantidade DECIMAL(10, 2)
     , valor_compra DECIMAL(10, 2)
     , ipi DECIMAL(5, 2)
     , icms DECIMAL(5, 2)
     , preco_custo DECIMAL(10, 2)
     , PRIMARY KEY (codEntrada, codProduto)
     , INDEX (codEntrada)
     , CONSTRAINT FK_TB_ENTRADA_PRODUTO_1 FOREIGN KEY (codEntrada)
                  REFERENCES SACE.TB_ENTRADA (codEntrada)
     , INDEX (codProduto)
     , CONSTRAINT FK_TB_ENTRADA_PRODUTO_2 FOREIGN KEY (codProduto)
                  REFERENCES SACE.TB_PRODUTO (codProduto)
);

CREATE TABLE SACE.TB_SAIDA_PRODUTO (
       codProduto BIGINT NOT NULL
     , codSaida BIGINT NOT NULL
     , quantidade DECIMAL(10, 4)
     , valorVenda DECIMAL(10, 2)
     , desconto DECIMAL(10, 2)
     , subtotal DECIMAL(10, 2)
     , PRIMARY KEY (codProduto, codSaida)
     , INDEX (codProduto)
     , CONSTRAINT FK_TB_SAIDA_PRODUTO_1 FOREIGN KEY (codProduto)
                  REFERENCES SACE.TB_PRODUTO (codProduto)
     , INDEX (codSaida)
     , CONSTRAINT FK_TB_SAIDA_PRODUTO_2 FOREIGN KEY (codSaida)
                  REFERENCES SACE.TB_SAIDA (codSaida)
);

CREATE TABLE SACE.TB_CONTATO_EMPRESA (
       codigoEmpresa BIGINT NOT NULL
     , codPessoa BIGINT NOT NULL
     , PRIMARY KEY (codigoEmpresa, codPessoa)
     , INDEX (codigoEmpresa)
     , CONSTRAINT FK_TB_CONTATO_EMPRESA_1 FOREIGN KEY (codigoEmpresa)
                  REFERENCES SACE.TB_EMPRESA (codigoEmpresa)
     , INDEX (codPessoa)
     , CONSTRAINT FK_TB_CONTATO_EMPRESA_2 FOREIGN KEY (codPessoa)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
);

CREATE TABLE SACE.TB_MOVIMENTACAO_CONTA (
       codMovimentacao BIGINT NOT NULL AUTO_INCREMENT
     , codTipoMovimentacao INT NOT NULL
     , valor DECIMAL(10, 2) NOT NULL
     , dataHora DATETIME NOT NULL
     , codResponsavel BIGINT NOT NULL
     , codContaBanco BIGINT NOT NULL
     , PRIMARY KEY (codMovimentacao)
     , INDEX (codTipoMovimentacao)
     , CONSTRAINT FK_MOVIMENTACAO_CONTA_1 FOREIGN KEY (codTipoMovimentacao)
                  REFERENCES SACE.TB_TIPO_MOVIMENTACAO_CONTA (codTipoMovimentacao)
     , INDEX (codResponsavel)
     , CONSTRAINT FK_MOVIMENTACAO_CONTA_3 FOREIGN KEY (codResponsavel)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
     , INDEX (codContaBanco)
     , CONSTRAINT FK_TB_MOVIMENTACAO_CONTA_3 FOREIGN KEY (codContaBanco)
                  REFERENCES SACE.TB_CONTA_BANCO (codContaBanco)
);

CREATE TABLE SACE.TB_CARTAO_CREDITO (
       codCartao INT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(30) NOT NULL
     , diaBase INT
     , codContaBanco BIGINT NOT NULL
     , UNIQUE UQ_TB_CARTAO_CREDITO_1 (nome)
     , PRIMARY KEY (codCartao)
     , INDEX (codContaBanco)
     , CONSTRAINT FK_TB_CARTAO_CREDITO_1 FOREIGN KEY (codContaBanco)
                  REFERENCES SACE.TB_CONTA_BANCO (codContaBanco)
);

CREATE TABLE SACE.TB_PERMISSAO (
       codPessoa BIGINT NOT NULL
     , codFuncionalidade INT NOT NULL
     , permissao INT NOT NULL
     , PRIMARY KEY (codPessoa, codFuncionalidade)
     , INDEX (codPessoa)
     , CONSTRAINT FK_TB_PERMISSAO_1 FOREIGN KEY (codPessoa)
                  REFERENCES SACE.TB_USUARIO (codPessoa)
     , INDEX (codFuncionalidade)
     , CONSTRAINT FK_TB_PERMISSAO_2 FOREIGN KEY (codFuncionalidade)
                  REFERENCES SACE.TB_FUNCIONALIDADE (codFuncionalidade)
);

CREATE TABLE SACE.TB_PAGAMENTO (
       codPagamento BIGINT NOT NULL AUTO_INCREMENT
     , codFormaPagamento INT NOT NULL
     , codContaPagar BIGINT NOT NULL
     , valorPago DECIMAL(10, 2) NOT NULL
     , valorDiferenca DECIMAL(10, 2) DEFAULT 0
     , codContaBanco BIGINT NOT NULL
     , dataPagamento DATETIME
     , PRIMARY KEY (codPagamento)
     , INDEX (codFormaPagamento)
     , CONSTRAINT FK_TB_PAGAMENTO_1 FOREIGN KEY (codFormaPagamento)
                  REFERENCES SACE.TB_FORMA_PAGAMENTO (codFormaPagamento)
     , INDEX (codContaPagar)
     , CONSTRAINT FK_TB_PAGAMENTO_2 FOREIGN KEY (codContaPagar)
                  REFERENCES SACE.TB_CONTA_PAGAR (codContaPagar)
     , INDEX (codContaBanco)
     , CONSTRAINT FK_TB_PAGAMENTO_3 FOREIGN KEY (codContaBanco)
                  REFERENCES SACE.TB_CONTA_BANCO (codContaBanco)
);

CREATE TABLE SACE.TB_RECEBIMENTO (
       codRecebimento BIGINT NOT NULL AUTO_INCREMENT
     , codFormaPagamento INT NOT NULL
     , codContaReceber BIGINT NOT NULL
     , valorRecebido DECIMAL(10, 2)
     , valorDiferenca DECIMAL(10, 2)
     , codContaBanco BIGINT NOT NULL
     , PRIMARY KEY (codRecebimento)
     , INDEX (codFormaPagamento)
     , CONSTRAINT FK_TB_RECEBIMENTO_1 FOREIGN KEY (codFormaPagamento)
                  REFERENCES SACE.TB_FORMA_PAGAMENTO (codFormaPagamento)
     , INDEX (codContaReceber)
     , CONSTRAINT FK_TB_RECEBIMENTO_2 FOREIGN KEY (codContaReceber)
                  REFERENCES SACE.TB_CONTA_RECEBER (codContaReceber)
     , INDEX (codContaBanco)
     , CONSTRAINT FK_TB_RECEBIMENTO_3 FOREIGN KEY (codContaBanco)
                  REFERENCES SACE.TB_CONTA_BANCO (codContaBanco)
);

CREATE TABLE SACE.TB_PRODUTO_LOJA (
       codLoja INT NOT NULL
     , codProduto BIGINT NOT NULL
     , codEntrada BIGINT(10) NOT NULL
     , qtdEstoqueFiscal DECIMAL(10, 2) NOT NULL DEFAULT 0
     , qtdEstoqueNFiscal DECIMAL(10, 2) NOT NULL DEFAULT 0
     , dataValidade DATE
     , precoCusto DECIMAL(10, 2) NOT NULL
     , PRIMARY KEY (codLoja, codProduto)
     , INDEX (codLoja)
     , CONSTRAINT FK_TB_PRODUTO_LOJA_1 FOREIGN KEY (codLoja)
                  REFERENCES SACE.TB_LOJA (codLoja)
     , INDEX (codProduto)
     , CONSTRAINT FK_TB_PRODUTO_LOJA_2 FOREIGN KEY (codProduto)
                  REFERENCES SACE.TB_PRODUTO (codProduto)
     , INDEX (codEntrada)
     , CONSTRAINT FK_TB_PRODUTO_LOJA_3 FOREIGN KEY (codEntrada)
                  REFERENCES SACE.TB_ENTRADA (codEntrada)
);

