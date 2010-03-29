CREATE TABLE SACE.TB_LOJA (
       codLoja INT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(40) NOT NULL unique
     , cnpj CHAR(14)
     , ie CHAR(10)
     , endereco VARCHAR(40)
     , numero VARCHAR(10)
     , bairro VARCHAR(40)
     , cidade VARCHAR(40)
     , PRIMARY KEY (codLoja)
);

CREATE TABLE SACE.TB_EMPRESA (
       codigoEmpresa BIGINT NOT NULL
     , nome VARCHAR(40) NOT NULL  unique
     , cnpj VARCHAR(14)
     , ie VARCHAR(14)
     , foneEmpresa CHAR(10)
     , PRIMARY KEY (codigoEmpresa)
);

CREATE TABLE SACE.TB_FORMA_PAGAMENTO (
       codFormaPagamento INT NOT NULL
     , descricao VARCHAR(40) NOT NULL  unique
     , PRIMARY KEY (codFormaPagamento)
);

CREATE TABLE SACE.TB_GRUPO (
       codGrupo BIGINT NOT NULL AUTO_INCREMENT
     , descricao VARCHAR(40) NOT NULL  unique
     , PRIMARY KEY (codGrupo)
);

CREATE TABLE SACE.TB_PESSOA (
       codPessoa BIGINT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(40) NOT NULL  unique
     , endereco VARCHAR(40)
     , cpf CHAR(11)
     , numero VARCHAR(10)
     , bairro VARCHAR(40)
     , cidade VARCHAR(40)
     , fone1 VARCHAR(10)
     , fone2 VARCHAR(10)
     , limiteCompra DECIMAL(10, 2)
     , recebeComissao BOOLEAN NOT NULL DEFAULT false
     , PRIMARY KEY (codPessoa)
);

CREATE TABLE SACE.TB_ENTRADA (
       codEntrada BIGINT(10) NOT NULL
     , codigoFornecedor BIGINT NOT NULL
     , dtEntrada DATE
     , valorTotal DECIMAL(10, 2)
     , tipoEntrada CHAR
     , PRIMARY KEY (codEntrada)
     , INDEX (codigoFornecedor)
     , CONSTRAINT FK_TB_ENTRADA_1 FOREIGN KEY (codigoFornecedor)
                  REFERENCES SACE.TB_EMPRESA (codigoEmpresa)
);

CREATE TABLE SACE.TB_SAIDA (
       codSaida BIGINT NOT NULL AUTO_INCREMENT
     , dataSaida DATE NOT NULL
     , tipoSaida CHAR NOT NULL
     , codCliente BIGINT NOT NULL
     , codProfissional BIGINT
     , desconto DECIMAL(10, 2)
     , total DECIMAL(10, 2)
     , gerouCupom BOOLEAN NOT NULL DEFAULT false
     , PRIMARY KEY (codSaida)
     , INDEX (codCliente)
     , CONSTRAINT FK_TB_SAIDA_1 FOREIGN KEY (codCliente)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
     , INDEX (codProfissional)
     , CONSTRAINT FK_TB_SAIDA_2 FOREIGN KEY (codProfissional)
                  REFERENCES SACE.TB_PESSOA (codPessoa)
);

CREATE TABLE SACE.TB_PRODUTO (
       codProduto BIGINT NOT NULL AUTO_INCREMENT
     , nome VARCHAR(40) NOT NULL  unique
     , codigoBarra VARCHAR(40)
     , qtdMinima DECIMAL(10, 2)
     , icms DECIMAL(5, 2)
     , simples DECIMAL(5, 2)
     , ipi DECIMAL(5, 2)
     , custoVenda DECIMAL(5, 2)
     , lucroVarejo DECIMAL(5, 2)
     , lucroAtacado DECIMAL(5, 2)
     , precoCompra DECIMAL(10, 2)
     , precoCusto DECIMAL(10, 2)
     , precoVendaVarejo DECIMAL(10, 2)
     , precoVendaAtacado DECIMAL(10, 2)
     , dtUltimaCompra DATE
     , cfop CHAR(4)
     , codGrupo BIGINT NOT NULL
     , PRIMARY KEY (codProduto)
     , INDEX (codGrupo)
     , CONSTRAINT FK_TB_PRODUTO_1 FOREIGN KEY (codGrupo)
                  REFERENCES SACE.TB_GRUPO (codGrupo)
);

CREATE TABLE SACE.TB_ENTRADA_PRODUTO (
       codEntrada BIGINT(10) NOT NULL
     , codProduto BIGINT NOT NULL
     , quantidade DECIMAL(10, 2)
     , valor_compra DECIMAL(10, 2)
     , ipi DECIMAL(5, 2)
     , icms DECIMAL(5, 2)
     , PRIMARY KEY (codEntrada, codProduto)
     , INDEX (codEntrada)
     , CONSTRAINT FK_TB_ENTRADA_PRODUTO_1 FOREIGN KEY (codEntrada)
                  REFERENCES SACE.TB_ENTRADA (codEntrada)
     , INDEX (codProduto)
     , CONSTRAINT FK_TB_ENTRADA_PRODUTO_2 FOREIGN KEY (codProduto)
                  REFERENCES SACE.TB_PRODUTO (codProduto)
);

CREATE TABLE SACE.TB_ENTRADA_PAGAMENTO (
       codigo BIGINT NOT NULL AUTO_INCREMENT
     , codEntrada BIGINT(10) NOT NULL
     , codFormaPagamento INT NOT NULL
     , valor CHAR(10)
     , dataVencimento DATE
     , PRIMARY KEY (codigo)
     , INDEX (codEntrada)
     , CONSTRAINT FK_TB_ENTRADA_PAGAMENTO_1 FOREIGN KEY (codEntrada)
                  REFERENCES SACE.TB_ENTRADA (codEntrada)
     , INDEX (codFormaPagamento)
     , CONSTRAINT FK_TB_ENTRADA_PAGAMENTO_2 FOREIGN KEY (codFormaPagamento)
                  REFERENCES SACE.TB_FORMA_PAGAMENTO (codFormaPagamento)
);

CREATE TABLE SACE.TB_SAIDA_PRODUTO (
       codProduto BIGINT NOT NULL
     , codSaida BIGINT NOT NULL
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

CREATE TABLE SACE.TB_SAIDA_PAGAMENTO (
       codigo BIGINT NOT NULL
     , codSaida BIGINT NOT NULL
     , codFormaPagamento INT NOT NULL
     , valor DECIMAL(10, 2)
     , dtVencimento DATE
     , PRIMARY KEY (codigo)
     , INDEX (codSaida)
     , CONSTRAINT FK_TB_SAIDA_PAGAMENTO_1 FOREIGN KEY (codSaida)
                  REFERENCES SACE.TB_SAIDA (codSaida)
     , INDEX (codFormaPagamento)
     , CONSTRAINT FK_TB_SAIDA_PAGAMENTO_2 FOREIGN KEY (codFormaPagamento)
                  REFERENCES SACE.TB_FORMA_PAGAMENTO (codFormaPagamento)
);

CREATE TABLE SACE.TB_PRODUTO_LOJA (
       codLoja INT NOT NULL
     , codProduto BIGINT NOT NULL
     , qtdEstoqueFiscal DECIMAL(10, 2) DEFAULT 0
     , qtdEstoqueNFiscal DECIMAL(10, 2) DEFAULT 0
     , PRIMARY KEY (codLoja, codProduto)
     , INDEX (codLoja)
     , CONSTRAINT FK_TB_PRODUTO_LOJA_1 FOREIGN KEY (codLoja)
                  REFERENCES SACE.TB_LOJA (codLoja)
     , INDEX (codProduto)
     , CONSTRAINT FK_TB_PRODUTO_LOJA_2 FOREIGN KEY (codProduto)
                  REFERENCES SACE.TB_PRODUTO (codProduto)
);
