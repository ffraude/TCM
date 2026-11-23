<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Sabonet.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Administração - Sabo.net</title>
    <link rel="stylesheet" href="admin.css" />
    <link rel="stylesheet" href="bolhas.css" />
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
    <a href="pagina-inicial.aspx" class="logo">Sabo.net</a>

    <nav>
        <a href="louja.aspx">Loja</a>
        <a href="sobre.aspx">Sobre nós</a>
        <a href="Noscontate.aspx">Contato</a>
        <a href="javascript:history.back();" class="btn-voltar">Voltar</a>
    </nav>
</header>

    <form id="form1" runat="server">

        <main>

            <h1>Painel Administrativo</h1>

            <section class="painel">

                <div class="opcao">
                    <h2>Produtos</h2>
                    <p>Adicione, altere e remova produtos da loja.</p>
                    <asp:Button ID="btnProdutos" runat="server"
    Text="Gerenciar produtos"
    PostBackUrl="adminProdutos.aspx" />
                </div>

                <div class="opcao">
                    <h2>Estoque</h2>
                    <p>Consulte e atualize a quantidade de produtos disponíveis.</p>
                    <asp:Button ID="btnEstoque" runat="server"
    Text="Gerenciar estoque"
    PostBackUrl="adminEstoque.aspx" />
                </div>

                <div class="opcao">
                    <h2>Contas</h2>
                    <p>Consulte e gerencie as contas dos usuários.</p>
                    <asp:Button ID="btnContas" runat="server"
    Text="Gerenciar contas"
    PostBackUrl="adminContas.aspx" />
                </div>

                <div class="opcao">
                    <h2>Permissões</h2>
                    <p>Conceda ou remova permissões administrativas.</p>
                    <asp:Button ID="btnPermissoes" runat="server"
    Text="Gerenciar permissões"
    PostBackUrl="adminPermissoes.aspx" />
                </div>

            </section>

        </main>

    </form>

</body>
</html>