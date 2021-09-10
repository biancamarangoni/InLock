USE InLock_Games_Manha;
GO

SELECT * FROM USUARIO;

SELECT * FROM ESTUDIO;

SELECT * FROM JOGO;

SELECT idJogo,nomeJogo 'Jogo', nomeEstudio 'Estudio' 
FROM JOGOS jogo
LEFT JOIN ESTUDIOS estudio
ON jogo.idEstudio = estudio.idEstudio;

SELECT nomeEstudio 'Estudio', nomeJogo 'Jogo'
FROM ESTUDIO estudio
LEFT JOIN JOGO jogo
ON estudio.idEstudio = jogo.idEstudio;

SELECT idJogo, nomeEstudio 'Estudio', nomeJogo 'Jogo', descricao, dataLancamento 'Data de Lançamento', valor
FROM JOGO jogo 
LEFT JOIN ESTUDIO estudio
ON estudio.idEstudio = jogo.idEstudio
WHERE idJogo = 1;

SELECT idEstudio, nomeEstudio 'Nome do Estúdio'
FROM ESTUDIO
WHERE idEstudio = 1;
