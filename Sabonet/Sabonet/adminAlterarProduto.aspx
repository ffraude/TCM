<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminAlterarProduto.aspx.cs" Inherits="Sabonet.adminAlterarProduto" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Alterar Produto - Sabonet</title>
</head>
<body>

    <form id="form1" runat="server">

        <h1>Alterar produto</h1>

        <asp:Label ID="lblMensagem" runat="server"></asp:Label>

        <br /><br />

        <asp:Label runat="server" Text="Nome do produto:"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>

        <br /><br />

        <asp:Label runat="server" Text="Preço:"></asp:Label>
        <br />
        <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox>

        <br /><br />

        <asp:Label runat="server" Text="Estoque:"></asp:Label>
        <br />
        <asp:TextBox ID="txtEstoque" runat="server"></asp:TextBox>

        <br /><br />

        <asp:Label runat="server" Text="Descrição:"></asp:Label>
        <br />
        <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine"></asp:TextBox>

        <br /><br />

        <asp:Label runat="server" Text="Categoria:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>

        <br /><br />

        <asp:CheckBox ID="chkAtivo" runat="server" Text="Produto ativo" />

        <br /><br />

        <asp:Button ID="btnSalvar" runat="server"
            Text="Salvar alterações"
            OnClick="btnSalvar_Click" />

        <asp:Button ID="btnCancelar" runat="server"
            Text="Cancelar"
            PostBackUrl="~/adminProdutos.aspx" />

    </form>

</body>
</html>