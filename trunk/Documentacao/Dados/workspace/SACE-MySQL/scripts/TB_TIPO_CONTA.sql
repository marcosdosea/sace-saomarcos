
DROP TABLE IF EXISTS SACE.TB_PLANO_CONTA;
DROP TABLE IF EXISTS SACE.TB_TIPO_CONTA;

CREATE TABLE SACE.TB_TIPO_CONTA (
       codTipoConta INT NOT NULL AUTO_INCREMENT
     , descricao VARCHAR(40) NOT NULL
     , PRIMARY KEY (codTipoConta)
);

CREATE TABLE SACE.TB_PLANO_CONTA (
       codPlanoConta BIGINT NOT NULL AUTO_INCREMENT
     , codTipoConta INT NOT NULL
     , descricao VARCHAR(40) NOT NULL
     , tipoConta CHAR(1) NOT NULL
     , diaBase SMALLINT
     , PRIMARY KEY (codPlanoConta)
     , INDEX (codTipoConta)
     , CONSTRAINT FK_TB_PLANO_CONTA_2 FOREIGN KEY (codTipoConta)
                  REFERENCES SACE.TB_TIPO_CONTA (codTipoConta)
);

