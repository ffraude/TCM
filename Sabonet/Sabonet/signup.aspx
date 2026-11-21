<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Sabonet.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastrar</title>
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <header>
        <a href="introducao.aspx">Sabo.net</a>
    </header>
    <form id="form1" runat="server">
        <h2>Cadastrar na Sabo.net</h2>
        <div>
            <p>Nome de Usuário:</p>
            <asp:TextBox ID="TxtUsu" runat="server" CssClass="campo"></asp:TextBox>
        </div>

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
            <asp:Button ID="BtnEntrar" runat="server" Text="Cadastrar" OnClick="BtnEntrar_Click" CssClass="botao" />
        </div>
    </form>
</body>
</html>
