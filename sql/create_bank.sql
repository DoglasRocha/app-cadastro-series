CREATE DATABASE SeriesDB;

CREATE TABLE Series (
    ID INT NOT NULL IDENTITY(1,1),
    Genero VARCHAR(50) NOT NULL,
    Titulo VARCHAR(50) NOT NULL,
    Descricao VARCHAR(250) NOT NULL,
    Ano INT NOT NULL,
    Removido BIT NOT NULL
);

use SeriesDB;
select * from Series