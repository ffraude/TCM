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
    </header>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblDescartavel" runat="server" Text="" ForeColor="White" Font-Size="Medium"></asp:Label>
        </div>
        
    </form>
</body>
</html>
