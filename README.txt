****** Script do Banco de Dados SQL Server segue abaixo,

CREATE TABLE Livro (  
LivroID int IDENTITY(1,1) NOT NULL PRIMARY KEY,  
Nome varchar(50) NOT NULL ,  
Autor varchar(50) NOT NULL ,  
Editora varchar(50) NOT NULL ,  
AnoPublicacao int NULL   
)  