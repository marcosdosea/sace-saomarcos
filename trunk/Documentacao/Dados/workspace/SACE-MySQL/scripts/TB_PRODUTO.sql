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
     , icms DECIMAL(5, 2) DEFAULT 0
     , simples DECIMAL(5, 2) DEFAULT 0
     , ipi DECIMAL(5, 2) DEFAULT 0
     , frete DECIMAL(5, 2) DEFAULT 0
     , custoVenda DECIMAL(10, 2) DEFAULT 0
     , ultimaDataAtualizacao DATE
     , lucroPrecoVendaVarejo DECIMAL(5, 2) DEFAULT 0
     , precoVendaVarejo DECIMAL(10, 2) DEFAULT 0
     , lucroPrecoVendaAtacado DECIMAL(5, 2) DEFAULT 0
     , precoVendaAtacado DECIMAL(10, 2) DEFAULT 0
     , lucroPrecoVendaSuperAtacado DECIMAL(5, 2) DEFAULT 0
     , precoVendaSuperAtacado DECIMAL(10, 2) DEFAULT 0
     , exibiNaListagem BOOLEAN DEFAULT true
     , PRIMARY KEY (codProduto)
     , INDEX (codGrupo)
     , CONSTRAINT FK_TB_PRODUTO_1 FOREIGN KEY (codGrupo)
                  REFERENCES SACE.TB_GRUPO (codGrupo)
     , INDEX (codigoFabricante)
     , CONSTRAINT FK_TB_PRODUTO_2 FOREIGN KEY (codigoFabricante)
                  REFERENCES SACE.TB_EMPRESA (codigoEmpresa)
     , INDEX (cfop)
     , CONSTRAINT FK_TB_PRODUTO_3 FOREIGN KEY (cfop)
                  REFERENCES SACE.TB_CFOP (cfop)
);

