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

drop procedure AterarNomexxxx

CREATE PROCEDURE AterarNomexxxx
    @id_usu INT,
    @senha_atual VARCHAR(50),
    @novo_nome VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Usuario
        WHERE id_usu = @id_usu
        AND senha_usu = @senha_atual
    )
    BEGIN
        UPDATE Usuario
        SET nome_usu = @novo_nome
        WHERE id_usu = @id_usu;

        RETURN 1;
    END

    RETURN 0;
END
GO

CREATE PROCEDURE AlterarEmailexxxx
    @id_usu INT,
    @senha_atual VARCHAR(50),
    @novo_email VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Usuario
        WHERE id_usu = @id_usu
        AND senha_usu = @senha_atual
    )
    BEGIN
        UPDATE Usuario
        SET email_usu = @novo_email
        WHERE id_usu = @id_usu;

        RETURN 1;
    END

    RETURN 0;
END

CREATE PROCEDURE AlterarSenhexxxx
    @id_usu INT,
    @senha_atual VARCHAR(50),
    @senhexxxx VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Usuario
        WHERE id_usu = @id_usu
        AND senha_usu = @senha_atual
    )
    BEGIN
        UPDATE Usuario
        SET senha_usu = @senhexxxx
        WHERE id_usu = @id_usu;

        RETURN 1;
    END

    RETURN 0;
END

CREATE PROCEDURE spConsultarProduto
    @idProduto INT
AS
BEGIN
    SELECT
        id_prod,
        nome_prod,
        preco,
        estoque
    FROM Produto
    WHERE id_prod = @idProduto;
END

CREATE PROCEDURE spConsultarPedidosUsuario
    @idUsuario INT
AS
BEGIN
    SELECT
        Pedido.id_pedido,
        Pedido.data_ped,
        Pedido.status_ped,
        Pedido.quant AS quantidade_total,
        SUM(ItemPedido.quant * ItemPedido.preco_unitario) AS valor_total
    FROM Pedido
    INNER JOIN ItemPedido
        ON Pedido.id_pedido = ItemPedido.id_pedido
    WHERE Pedido.id_usu = @idUsuario
    GROUP BY
        Pedido.id_pedido,
        Pedido.data_ped,
        Pedido.status_ped,
        Pedido.quant
    ORDER BY Pedido.data_ped DESC;
END;

CREATE PROCEDURE spConsultarItensPedido
    @idPedido INT
AS
BEGIN
    SELECT
        Produto.nome_prod,
        ItemPedido.quant,
        ItemPedido.preco_unitario,
        (ItemPedido.quant * ItemPedido.preco_unitario) AS subtotal
    FROM ItemPedido
    INNER JOIN Produto
        ON ItemPedido.id_prod = Produto.id_prod
    WHERE ItemPedido.id_pedido = @idPedido;
END;

CREATE PROCEDURE spConsultarEnderecoPedido
    @idPedido INT
AS
BEGIN
    SELECT
        Endereco.cep,
        Endereco.numero,
        Endereco.complemento,
        Endereco.bairro,
        Endereco.cidade,
        Endereco.estado
    FROM Pedido
    INNER JOIN Endereco
        ON Pedido.id_end = Endereco.id_end
    WHERE Pedido.id_pedido = @idPedido;
END;

create procedure spConsultarAcesso
	@id_usu int
as
begin
	select acesso_usu from Usuario where(@id_usu = id_usu)
end

insert into Categoria(nome_cat, desc_cat) values
('sabonete em pedra', 'sabonetes em pedra para higiene'),
('sabonete liquido', 'sabonetes liquido para higiene'),
('sabao em po', 'saboes em po para limpeza'),
('sabao para louca', 'saboes e detergente para louca'),
('sabao para limpeza', 'saboes para limpeza de casa'),
('sabonete para comer', 'sabonetes comestível gourmet'),
('sabonete suspeito', 'sabonetes no minimo suspeitos')

insert into Produto (nome_prod, preco, estoque, descricao_prod, id_cat) VALUES
('Eudora Frutas Vermelhas',34.00, 100, 'Sabonete Eudora Instance de Frutas Vermelhas', 2),
('Eudora Baunilha', 34.00, 100, 'Sabonete Eudora Instance de Baunilha', 2),
('Sabao artesanal Maracuja', 40.00, 100, 'Sabonete de Maracuja artesanal', 1),
('Sabao Granado', 9.00, 100, 'Sabonete Granado', 1),
('Sabao Protex', 15.00, 100, 'Sabonete liquido Protex', 2)

--Administrador

select * from Usuario
select * from Categoria
select * from Produto
select * from Endereco
select * from Pedido;
select * from ItemPedido;

ALTER TABLE Usuario
ADD usu_id_end INT NULL;

ALTER TABLE Usuario
ADD CONSTRAINT fk_usu_end
FOREIGN KEY (usu_id_end)
REFERENCES Endereco(id_end);
SELECT id_usu, nome_usu, usu_id_end FROM Usuario;

ALTER TABLE Produto
ADD imagem_prod VARCHAR(255);

ALTER TABLE Produto
ADD ativo_prod BIT NOT NULL DEFAULT 1;

insert into Usuario (nome_usu, email_usu, senha_usu, acesso_usu) values ('Luiz Bombom Ricardo', 'luiz.bombom@gmail.com', 'Senhex_Fortex', 1)
