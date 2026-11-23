<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="Sabonet.carrinho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>Meu Carrinho</title>
    <link rel="stylesheet" href="carrinho.css" />
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link href="bolhas.css" type="text/css" rel="stylesheet"/>
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
            <a href="perfil.aspx" id="linkConta" runat="server">Entrar</a>
        </nav>
    </header>

    <form id="form1" runat="server">

        <h1>Meu Carrinho</h1>

        <asp:GridView ID="gvCarrinho" runat="server"
            AutoGenerateColumns="False"
            EmptyDataText="Seu carrinho está vazio."
            CssClass="tabela"
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

        <h2>Endereço de entrega</h2>

<div class="endereco">
    <asp:Label runat="server" Text="CEP:" />
    <asp:TextBox ID="txtCEP" runat="server" MaxLength="9" />

    <asp:Label runat="server" Text="Número:" />
    <asp:TextBox ID="txtNumero" runat="server" TextMode="Number" />

    <asp:Label runat="server" Text="Complemento:" />
    <asp:TextBox ID="txtComplemento" runat="server" />

    <asp:Label runat="server" Text="Bairro:" />
    <asp:TextBox ID="txtBairro" runat="server" />

    <asp:Label runat="server" Text="Cidade:" />
    <asp:TextBox ID="txtCidade" runat="server" />

    <asp:Label runat="server" Text="Estado:" />
    <asp:TextBox ID="txtEstado" runat="server" />

    <asp:Button ID="btnFinalizar" runat="server"
        Text="Finalizar compra"
        OnClick="btnFinalizar_Click" />

    <asp:Label ID="lblEnderecoAlerta" runat="server"></asp:Label>
    </form>
</body>
</html>