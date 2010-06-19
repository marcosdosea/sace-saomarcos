

ALTER TABLE sace.tb_conta_pagar DROP FOREIGN KEY FK_CONTA_PAGAR_3;

ALTER TABLE sace.tb_conta_receber DROP FOREIGN KEY FK_CONTA_RECEBER_3;

ALTER TABLE sace.tb_contato_empresa DROP FOREIGN KEY FK_TB_CONTATO_EMPRESA_1;

ALTER TABLE sace.tb_entrada DROP FOREIGN KEY FK_TB_ENTRADA_2;

ALTER TABLE sace.tb_entrada DROP FOREIGN KEY FK_TB_ENTRADA_1;

ALTER TABLE sace.tb_produto DROP FOREIGN KEY FK_TB_PRODUTO_2;

DROP TABLE sace.tb_ecfdiario;

DROP TABLE sace.tb_empresa;

DROP TABLE sace.tb_indice_aliquota;

ALTER TABLE sace.tb_pessoa DROP COLUMN cpf;

ALTER TABLE sace.tb_pessoa ADD COLUMN cpf_Cnpj CHAR(14) AFTER nome;

ALTER TABLE sace.tb_conta_pagar ADD CONSTRAINT tb_pessoa_tb_conta_pagar_fk
FOREIGN KEY (codigoEmpresa)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_conta_receber ADD CONSTRAINT tb_pessoa_tb_conta_receber_fk
FOREIGN KEY (codigoEmpresa)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_contato_empresa ADD CONSTRAINT tb_pessoa_tb_contato_empresa_fk
FOREIGN KEY (codigoEmpresa)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_entrada ADD CONSTRAINT tb_pessoa_tb_entrada_fk
FOREIGN KEY (codigoEmpresaFrete)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_entrada ADD CONSTRAINT tb_pessoa_tb_entrada_fk
FOREIGN KEY (codigoFornecedor)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE sace.tb_produto ADD CONSTRAINT tb_pessoa_tb_produto_fk
FOREIGN KEY (codigoFabricante)
REFERENCES sace.tb_pessoa (codPessoa)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
