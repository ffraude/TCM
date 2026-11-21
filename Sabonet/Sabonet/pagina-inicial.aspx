
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagina-inicial.aspx.cs" Inherits="Sabonet.pagina_inicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet"/>
    <title>Bem-vindo!!!</title>
</head>
<body>
    <header>
        <a href="pagina-inicial.aspx">Sabo.net</a>

        <nav>
            <a href="#">Loja</a>
            <a href="sobre.aspx">Sobre nós</a>
            <a href="#">Contato</a>
            <a href="#"><asp:Label ID="LblConta" runat="server" Text=""></asp:Label></a>
        </nav>
    </header>

    <main>
        <section class="boas-vindas">
            <h1><asp:Label ID="LblBoasVindas" runat="server" Text="Bem-vindo à Sabo.net!"></asp:Label></h1>

            <p>
                Sabões de corpo, em pó, para rosto, comestíveis e muito mais! Tudo isso em um só lugar, com a melhor qualidade e preço do mercado.
            </p>

            <a href="compras.aspx" class="botao-compras">
                Começar a comprar
            </a>
        </section>
    </main>
</body>
</html>

