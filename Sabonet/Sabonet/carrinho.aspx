<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="Sabonet.carrinho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>Meu Carrinho</title>
    <link rel="stylesheet" href="carrinho.css" />
</head>
<body>
    <form id="form1" runat="server">

        <h1>Meu Carrinho</h1>

        <asp:GridView ID="gvCarrinho" runat="server"
            AutoGenerateColumns="False"
            EmptyDataText="Seu carrinho está vazio."
            OnRowCommand="gvCarrinho_RowCommand">


            <Columns>
                <asp:BoundField DataField="NomeProduto" HeaderText="Produto" />

                <asp:BoundField DataField="Preco" HeaderText="Preço unitário"
                    DataFormatString="R$ {0:N2}" />

                <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />

                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal"
                    DataFormatString="R$ {0:N2}" />

                <asp:TemplateField HeaderText="Ações">
    <ItemTemplate>
        <asp:Button ID="btnDiminuir" runat="server"
            Text="-"
            CommandName="Diminuir"
            CommandArgument='<%# Eval("IdProduto") %>' />

        <asp:Button ID="btnAumentar" runat="server"
            Text="+"
            CommandName="Aumentar"
            CommandArgument='<%# Eval("IdProduto") %>' />

        <asp:Button ID="btnRemover" runat="server"
            Text="Remover"
            CommandName="Remover"
            CommandArgument='<%# Eval("IdProduto") %>' />
    </ItemTemplate>
</asp:TemplateField>
            </Columns>

        </asp:GridView>

        <h2>
            Total:
            <asp:Label ID="lblTotal" runat="server" Text="R$ 0,00"></asp:Label>
        </h2>

    </form>
</body>
</html>