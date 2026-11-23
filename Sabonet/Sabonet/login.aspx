<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Sabonet.login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>
<link href="bolhas.css" type="text/css" rel="stylesheet"/>
    <title></title>
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
            <a href="introducao.aspx" id="linkConta" runat="server"><asp:Label ID="LblConta" runat="server" Text="Entrar"></asp:Label></a>
        </nav>
    </header>
    <form id="form1" runat="server">
        <h2>Entrar na Sabo.net</h2>
                <div>
            <p>E-mail:</p>
            <asp:TextBox ID="TxtMail" runat="server" CssClass="campo"></asp:TextBox>
        </div>

        <div>
            <p>Senha:</p>
            <asp:TextBox ID="TxtSenha" runat="server" CssClass="campo"></asp:TextBox>
            <asp:Label ID="LblAlerta" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:Button ID="BtnEntrar" runat="server" Text="Entrar" OnClick="BtnEntrar_Click" CssClass="botao" />
        </div>
    </form>
</body>
</html>
