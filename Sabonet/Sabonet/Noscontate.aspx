<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Noscontate.aspx.cs" Inherits="Sabonet.Noscontate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Nos contate - Sabo.net</title>

    <link href="bolhas.css" type="text/css" rel="stylesheet" />
    <link href="Noscontate.css" type="text/css" rel="stylesheet" />
</head>

<body>

    <div class="bolhas bolhas-esq" aria-hidden="true">
        <span class="bolha"></span>
        <span class="bolha"></span>
        <span class="bolha"></span>
        <span class="bolha"></span>
    </div>

    <div class="bolhas bolhas-dir" aria-hidden="true">
        <span class="bolha"></span>
        <span class="bolha"></span>
        <span class="bolha"></span>
        <span class="bolha"></span>
    </div>

    <header>
        <a href="pagina-inicial.aspx">Sabo.net</a>

        <nav>
            <a href="admin.aspx" id="linkAdmin" runat="server" style="display: none;">Administração</a>
            <a href="louja.aspx">Loja</a>
            <a href="sobre.aspx">Sobre nós</a>
            <a href="Noscontate.aspx">Contato</a>

            <a href="perfil.aspx" id="linkConta" runat="server">
                <asp:Label ID="LblConta" runat="server" Text="Entrar"></asp:Label>
            </a>
        </nav>
    </header>

    <form id="form1" runat="server">

        <main>

            <h1>Entre em contato conosco!</h1>

            <section class="contatos">

                <div class="cartao-contato">

                    <h2>José Everardo da Silva Junior</h2>

                    <table>
                        <tr>
                            <th>Nome</th>
                            <td>José Everardo da Silva Junior</td>
                        </tr>

                        <tr>
                            <th>Telefone</th>
                            <td>(11) 4002-8922</td>
                        </tr>

                        <tr>
                            <th>E-mail</th>
                            <td>AURAtop22brGOAT@gmail.com</td>
                        </tr>
                    </table>

                    <a href="https://www.instagram.com/everardojj/"
                       class="botao-instagram"
                       target="_blank"
                       rel="noopener noreferrer">
                        Instagram
                    </a>

                    <div class="imagem-contato">
                        <img src="imgexxxx/juse.jpeg" alt="Foto de José Everardo" />
                    </div>

                </div>

                <div class="cartao-contato">

                    <h2>Pedro Máximo de Souza</h2>

                    <table>
                        <tr>
                            <th>Nome</th>
                            <td>Pedro Máximo de Souza</td>
                        </tr>

                        <tr>
                            <th>Telefone</th>
                            <td>(11) 6742-2222</td>
                        </tr>

                        <tr>
                            <th>E-mail</th>
                            <td>AURAffraudefiscal@gmail.com</td>
                        </tr>
                    </table>

                    <a href="https://www.instagram.com/p.maximo_/"
                       class="botao-instagram"
                       target="_blank"
                       rel="noopener noreferrer">
                        Instagram
                    </a>

                    <div class="imagem-contato">
                        <img src="imgexxxx/maximiliano.jpeg" alt="Foto de Pedro Máximo" />
                    </div>

                </div>

            </section>

        </main>

    </form>

</body>
</html>