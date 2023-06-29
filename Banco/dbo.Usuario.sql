CREATE TABLE [dbo].[Usuario]
(
	[IdUsuario] INT NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Login] VARCHAR(20) NOT NULL, 
    [Senha] VARCHAR(40) NOT NULL, 
    [DataCadastro] DATETIME NOT NULL
)
