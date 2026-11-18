<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="sabao.net.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>sabo.net</title>
    <link rel="stylesheet" type="text/css" href="saboes.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>E-mail:</p>
            <asp:TextBox ID="TxtMail" runat="server" CssClass="txt"></asp:TextBox>
        </div>
        <div>
            <p>Senha:</p>
            <asp:TextBox ID="TxtSenha" runat="server" CssClass="txt"></asp:TextBox>
            <asp:Label runat="server" Text="" ID="LblAviso" ForeColor="Red"></asp:Label>
        </div>
        <asp:Button runat="server" Text="Entrar" CssClass="btn" ID="BtnEntrar" OnClick="BtnEntrar_Click"/>
    </form>
</body>


</html>
