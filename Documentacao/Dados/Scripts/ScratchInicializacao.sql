insert into tb_funcionalidade (codfuncionalidade, descricao)
values
(1, 'Produtos'),
(2, 'Pessoas'),
(3, 'Empresas'),
(4, 'Lojas'),
(5, 'Bancos'),
(6, 'Plano de contas'),
(7, 'Contas Banco/Caixa'),
(8, 'Cartões de credito'),
(9, 'Grupos de produtos'),
(10, 'Grupos de contas'),
(11, 'Usuarios'),
(12, 'Pré-venda'),
(13, 'Pedidos'),
(14, 'Entrada de produtos'),
(15, 'Tranformacoes'),
(16, 'Contas a Pagar'),
(17, 'Contas a receber'),
(18, 'Baixas'),
(19, 'Movimentacao Contas'),
(20, 'Atualização de preços'),
(21, 'Ajuste de Estoque'),
(22, 'Configurações Sistema'),
(23, 'Backup'),
(24, 'Relatorio Cliente'),
(25, 'Relatorio Listagem preços'),
(26, 'Relatorio Estoque'),
(27, 'Relatorio Vendas'),
(28, 'Relatorio Compras'),
(29, 'Relatorio Contas');

insert into tb_perfil (codPerfil, nome)
values (1, 'Administrador');

insert into tb_perfil_funcionalidade (codPerfil, codFuncionalidade)
values
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(1,6),
(1,7),
(1,8),
(1,9),
(1,10),
(1,11),
(1,12),
(1,13),
(1,14),
(1,15),
(1,16),
(1,17),
(1,18),
(1,19),
(1,20),
(1,21),
(1,22),
(1,23),
(1,24),
(1,25),
(1,26),
(1,27),
(1,28),
(1,29);

INSERT INTO tb_pessoa(nome, Tipo) VALUES("Marcos", "F");

INSERT INTO tb_usuario VALUES(1, '1', '1', 1);