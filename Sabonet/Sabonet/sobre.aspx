<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sobre.aspx.cs" Inherits="Sabonet.sobre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sobre-nós</title>
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet"/>
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
    <div class="bonzi"></div>
    <div class="textex">
        <p>Desenvolvido por Pedro Máximo de Souza e José Everardo da Silva Júnior, este site é o maior, melhor, primeiro, único e 
            provavelmente último TCM do segundo ano de DS sobre sabão. Espero que gostem do nosso trabalho!
        </p>
    </div>
</body>
</html>
