<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="louja.aspx.cs" Inherits="Sabonet.louja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <link rel="stylesheet" href="louja.css" />
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

    <header runat="server">
        <a href="pagina-inicial.aspx">Sabo.net</a>
        <nav>
            <a href="louja.aspx">Loja</a>
            <a href="sobre.aspx">Sobre nós</a>
            <a href="">Contato</a>
            <a href="perfil.aspx" id="linkConta" runat="server"><asp:Label ID="LblConta" runat="server" Text="Entrar"></asp:Label></a>
            <a href="carrinho.aspx" class="aiai"><img src="imgexxxx/carro_fofinho.png" alt="Logo" width="70" height="50"></a>

        </nav>
    </header>
    <form id="form1" runat="server">
        <div class="cu">
            <div class="produto">
                <h2>Eudora Frutas Vermelhas</h2>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/imgexxxx/frutas_vermelhas.jpg" CssClass="image"/>
                <p>R$ 34,00</p>
                <div class="qtt">
                    <asp:Button ID="btnMenos1" OnCommand="AlterarQuantidade_Command" CommandName="Menos" CommandArgument="1" runat="server" Text="-" CssClass="btncarro"/>
                    <asp:Label ID="lblQuantidade1" runat="server" Text="1"></asp:Label>
                    <asp:Button ID="btnMais1" OnCommand="AlterarQuantidade_Command" CommandName="Mais" CommandArgument="1" runat="server" Text="+" CssClass="btncarro"/>
                </div>
                <asp:Button ID="btnAdd1" runat="server" Text="adicionar ao carrinho" CommandArgument="1" OnCommand="AdicionarCarrinho_Command" CssClass="button"/>
            </div>
            <div class="produto">
                <h2>Eudora Baunilha</h2>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/imgexxxx/baunilha.jpg" CssClass="image"/>
                <p>R$ 34,00</p>
                <div class="qtt">
                    <asp:Button ID="btnMenos2" OnCommand="AlterarQuantidade_Command" CommandName="Menos" CommandArgument="2" runat="server" Text="-" CssClass="btncarro"/>
                    <asp:Label ID="lblQuantidade2" runat="server" Text="1"></asp:Label>
                    <asp:Button ID="btnMais2" OnCommand="AlterarQuantidade_Command" CommandName="Mais" CommandArgument="2" runat="server" Text="+" CssClass="btncarro" OnClick="btnMais2_Click"/>
                </div>
                <asp:Button ID="btnAdd2" runat="server" Text="adicionar ao carrinho" CommandArgument="2" OnCommand="AdicionarCarrinho_Command" CssClass="button"/>
            </div>
            <div class="produto">
                <h2>Sabonete Artesanal Maracujá</h2>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/imgexxxx/aura_maracuja.jpg" CssClass="image"/>
                <p>R$ 40,00</p>
                <div class="qtt">
                    <asp:Button ID="btnMenos3" OnCommand="AlterarQuantidade_Command" CommandName="Menos" CommandArgument="3" runat="server" Text="-" CssClass="btncarro"/>
                    <asp:Label ID="lblQuantidade3" runat="server" Text="1"></asp:Label>
                    <asp:Button ID="btnMais3" OnCommand="AlterarQuantidade_Command" CommandName="Mais" CommandArgument="3" runat="server" Text="+" CssClass="btncarro"/>
                </div>
                <asp:Button ID="btnAdd3" runat="server" Text="adicionar ao carrinho" CommandArgument="3" OnCommand="AdicionarCarrinho_Command" CssClass="button"/>
            </div>
            <div class="produto">
                <h2>Sabonete Granado</h2>
                <asp:Image ID="Image4" runat="server" ImageUrl="~/imgexxxx/granado_azul.jpg" CssClass="image"/>
                <p>R$ 9,00</p>
                <div class="qtt">
                    <asp:Button ID="btnMenos4" OnCommand="AlterarQuantidade_Command" CommandName="Menos" CommandArgument="4" runat="server" Text="-" CssClass="btncarro"/>
                    <asp:Label ID="lblQuantidade4" runat="server" Text="1"></asp:Label>
                    <asp:Button ID="btnMais4" OnCommand="AlterarQuantidade_Command" CommandName="Mais" CommandArgument="4" runat="server" Text="+" CssClass="btncarro"/>
                </div>
                <asp:Button ID="btnAdd4" runat="server" Text="adicionar ao carrinho" CommandArgument="4" OnCommand="AdicionarCarrinho_Command" CssClass="button"/>
            </div>
            <div class="produto">
                <h2>Sabonete Protex</h2>
                <asp:Image ID="Image5" runat="server" ImageUrl="~/imgexxxx/protex_aveia.jpg" CssClass="image"/>
                <p>R$ 15,00</p>
                <div class="qtt">
                    <asp:Button ID="btnMenos5" OnCommand="AlterarQuantidade_Command" CommandName="Menos" CommandArgument="5" runat="server" Text="-" CssClass="btncarro"/>
                    <asp:Label ID="lblQuantidade5" runat="server" Text="1"></asp:Label>
                    <asp:Button ID="btnMais5" OnCommand="AlterarQuantidade_Command" CommandName="Mais" CommandArgument="5" runat="server" Text="+" CssClass="btncarro"/>
                </div>
                <asp:Button ID="btnAdd" runat="server" Text="adicionar ao carrinho" CommandArgument="5" OnCommand="AdicionarCarrinho_Command" CssClass="button"/>
            </div>
        </div>
    </form>
</body>
</html>
