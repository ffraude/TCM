create database DBresenhexxxx
go

use DBresenhexxxx
go

CREATE TABLE Endereco(
    id_end INT IDENTITY,
    cep VARCHAR(9),
    numero INT,
    complemento VARCHAR(100),
    bairro VARCHAR(100),
    cidade VARCHAR(100),
    estado VARCHAR(50),
    CONSTRAINT pk_end PRIMARY KEY(id_end)
)

GO

CREATE TABLE Usuario(
    id_usu INT IDENTITY,
    nome_usu VARCHAR(50) NOT NULL,
    senha_usu VARCHAR(50) NOT NULL,
    email_usu VARCHAR(40) NOT NULL,
    acesso_usu TINYINT NOT NULL,
    usu_id_end INT,
    CONSTRAINT pk_usu PRIMARY KEY(id_usu),
    CONSTRAINT fk_usu_end FOREIGN KEY(usu_id_end)
        REFERENCES Endereco(id_end)
)

go

CREATE TABLE Categoria(
    id_cat INT IDENTITY,
    nome_cat VARCHAR(100),
    desc_cat VARCHAR(200),
    CONSTRAINT pk_cat PRIMARY KEY(id_cat)
)

go

CREATE TABLE Produto(
    id_prod INT IDENTITY,
    nome_prod VARCHAR(100),
    preco DECIMAL(10,2),
    estoque INT,
    descricao_prod VARCHAR(100),
    id_cat INT,
    CONSTRAINT pk_prod PRIMARY KEY(id_prod),
    CONSTRAINT fk_prod_cat FOREIGN KEY(id_cat)
        REFERENCES Categoria(id_cat)
)

go

CREATE TABLE Pedido(
    id_pedido INT IDENTITY,
    id_end INT,
    id_usu INT,
    quant INT,
    data_ped DATE,
    status_ped VARCHAR(50),
    CONSTRAINT pk_pedido PRIMARY KEY(id_pedido),
    CONSTRAINT fk_pedido_end FOREIGN KEY(id_end)
        REFERENCES Endereco(id_end),
    CONSTRAINT fk_pedido_usu FOREIGN KEY(id_usu)
        REFERENCES Usuario(id_usu)
)

go

CREATE TABLE ItemPedido(
    id_itped INT IDENTITY,
    id_prod INT,
    id_pedido INT,
    quant INT,
    preco_unitario DECIMAL(10,2),
    CONSTRAINT pk_itempedido PRIMARY KEY(id_itped),
    CONSTRAINT fk_itempedido_prod FOREIGN KEY(id_prod)
        REFERENCES Produto(id_prod),
    CONSTRAINT fk_itempedido_pedido FOREIGN KEY(id_pedido)
        REFERENCES Pedido(id_pedido)
)

--Administrador

insert into Usuario (nome_usu, email_usu, senha_usu, acesso_usu) values ('Luiz Bombom Ricardo', 'luiz.bombom@gmail.com', 'Senhex_Fortex', 1)
