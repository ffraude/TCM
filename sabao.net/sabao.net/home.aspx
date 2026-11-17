<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="home.aspx.cs"
    Inherits="sabao.net.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Home Page</title>

    <link href="padrao.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">

        <div class="container">

            <header>
                <h1>
                    <asp:Label ID="LblTitulo" runat="server"
                        Text="Minha Aplicação"></asp:Label>
                </h1>

                <p>
                    <asp:Label ID="LblDescricao" runat="server"
                        Text="Bem-vindo à página inicial!"></asp:Label>
                </p>
            </header>

            <div class="conteudo">

                <div class="card">
                    <h2>Informação 1</h2>
                    <p class="valor">
                        <asp:Label ID="LblInfo1" runat="server"
                            Text="[Aguardando dados...]"></asp:Label>
                    </p>
                </div>

                <div class="card">
                    <h2>Informação 2</h2>
                    <p class="valor">
                        <asp:Label ID="LblInfo2" runat="server"
                            Text="[Aguardando dados...]"></asp:Label>
                    </p>
                </div>

                <div class="card">
                    <h2>Informação 3</h2>
                    <p class="valor">
                        <asp:Label ID="LblInfo3" runat="server"
                            Text="[Aguardando dados...]"></asp:Label>
                    </p>
                </div>

            </div>

            <footer>
                <p>Minha Aplicação - 2026</p>
            </footer>

        </div>

    </form>
</body>
</html>

