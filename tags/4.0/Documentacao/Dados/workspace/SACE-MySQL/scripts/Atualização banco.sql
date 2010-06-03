

ALTER TABLE sace.tb_cfop DROP COLUMN cfop;

ALTER TABLE sace.tb_cfop ADD COLUMN codCfop INT(10) NOT NULL FIRST;

ALTER TABLE sace.tb_cfop DROP PRIMARY KEY;

ALTER TABLE sace.tb_cfop ADD PRIMARY KEY (codCfop);

CREATE TABLE sace.tb_ECFDiario (
                DataEmissao DATE NOT NULL,
                NumeroCaixa CHAR(4) NOT NULL,
                SituaTributAliq CHAR(4) NOT NULL,
                Tipo SMALLINT(10) NOT NULL,
                SubTipo CHAR(1) NOT NULL,
                NumeroSerie VARCHAR(15) NOT NULL,
                ModeloCod CHAR(2) NOT NULL,
                COOInicio CHAR(6) NOT NULL,
                COOFim CHAR(6) NOT NULL,
                ContadorReducao CHAR(6) NOT NULL,
                ContReinicioOperacao CHAR(4) NOT NULL,
                ModeloImpressora VARCHAR(20) NOT NULL,
                VlrBruto NUMERIC(10,2) NOT NULL,
                VlrLiquido NUMERIC(10,2) NOT NULL,
                PRIMARY KEY (DataEmissao, NumeroCaixa, SituaTributAliq)
);


CREATE TABLE sace.tb_indice_Aliquota (
                codIndiceAliq INT(10) NOT NULL,
                Descricao VARCHAR(10) NOT NULL,
                Valor NUMERIC(5,2) NOT NULL,
                PRIMARY KEY (codIndiceAliq)
);


CREATE TABLE sace.tb_perfil (
                codPerfil INT(10) NOT NULL,
                nome VARCHAR(20) NOT NULL,
                PRIMARY KEY (codPerfil)
);


CREATE TABLE sace.tb_perfil_funcionalidade (
                codPerfil INT(10) NOT NULL,
                codFuncionalidade INT(10) NOT NULL,
                PRIMARY KEY (codPerfil, codFuncionalidade)
);


ALTER TABLE sace.tb_saida ADD COLUMN codCaixa CHAR(4) NOT NULL AFTER NumCupomFiscal;

ALTER TABLE sace.tb_saida ADD COLUMN NumCupomFiscal CHAR(6) NOT NULL AFTER totalLucro;

ALTER TABLE sace.tb_saida ADD COLUMN NumSerieECF VARCHAR(15) NOT NULL AFTER codCaixa;

ALTER TABLE sace.tb_saida_produto ADD COLUMN codCfop INT(10) NOT NULL AFTER codIndiceAliq;

ALTER TABLE sace.tb_saida_produto ADD COLUMN codIndiceAliq INT(10) NOT NULL AFTER subtotal;

ALTER TABLE sace.tb_saida_produto ADD COLUMN Unidade CHAR(3) NOT NULL AFTER codCfop;

ALTER TABLE sace.tb_saida_produto ADD CONSTRAINT tb_cfop_tb_saida_produto_fk
FOREIGN KEY (codCfop)
REFERENCES sace.tb_cfop (codCfop)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_perfil_funcionalidade ADD CONSTRAINT tb_funcionalidade_tb_perfil_funcionalidade_fk
FOREIGN KEY (codFuncionalidade)
REFERENCES sace.tb_funcionalidade (codFuncionalidade)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_saida_produto ADD CONSTRAINT tb_indice_aliquota_tb_saida_produto_fk
FOREIGN KEY (codIndiceAliq)
REFERENCES sace.tb_indice_Aliquota (codIndiceAliq)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_perfil_funcionalidade ADD CONSTRAINT tb_perfil_tb_perfil_usuario_fk
FOREIGN KEY (codPerfil)
REFERENCES sace.tb_perfil (codPerfil)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_usuario ADD CONSTRAINT tb_perfil_tb_usuario_fk
FOREIGN KEY (codPerfil)
REFERENCES sace.tb_perfil (codPerfil)
ON DELETE NO ACTION
ON UPDATE NO ACTION;