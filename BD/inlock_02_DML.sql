USE InLock_Games_Manha;
GO



INSERT INTO TIPO_USUARIO (titulo)
VALUES ('ADMINISTRADOR'), ('CLIENTE');
GO

INSERT INTO USUARIO (idTipoUsuario, email, senha)
VALUES (1, 'admin@admin.com', 'admin'), (2, 'cliente@cliente.com', 'cliente');
GO

INSERT INTO ESTUDIO (nomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix');
GO

INSERT INTO JOGOS (IdEstudio, nomeJogo, Descricao, dataLancamento, valor)
VALUES	(1, 'Diablo 3', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '20120515 00:00:00', 99.00), 
		(2, 'Red Dead Redemption II', 'jogo eletrônico de ação-aventura western', '20181026 00:00:00', 120.00);
GO



