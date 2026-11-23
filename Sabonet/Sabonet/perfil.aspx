<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="Sabonet.perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet"/>
    <link href="bolhas.css" type="text/css" rel="stylesheet"/>
    <title>Meu Perfil - Sabo.net</title>
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
                <a href="perfil.aspx" id="linkConta" runat="server"><asp:Label ID="LblConta" runat="server" Text=""></asp:Label></a>
            </nav>
        </header>

        <main class="sect-perfil">

            <div class="titulo-perfil">
                <h1>Meu Perfil</h1>
                <p>Gerencie suas informações pessoais e sua conta.</p>
            </div>

            <div class="div-perfil">
                <div class="info-perfil">
                    <p class="nome-campo">Nome</p>
                    <p class="valor-campo">
                        <asp:Label ID="LblNome" runat="server" Text=""></asp:Label>
                    </p>
                </div>

                <a class="link-editar" href="editar-nome.aspx">
                    Alterar nome
                </a>
            </div>

            <div class="div-perfil">
                <div class="info-perfil">
                    <p class="nome-campo">E-mail</p>
                    <p class="valor-campo">
                        <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label>
                    </p>
                </div>

                <a class="link-editar" href="editar-email.aspx">
                    Alterar e-mail
                </a>
            </div>

            <div class="div-perfil">
                <div class="info-perfil">
                    <p class="nome-campo">Senha</p>
                    <p class="valor-campo">••••••••</p>
                </div>

                <a class="link-editar" href="editar-senha.aspx">
                    Alterar senha
                </a>
            </div>
            <div class="div-perfil">
    <div class="info-perfil">
        <p class="nome-campo">Meus pedidos</p>
        <p class="valor-campo">
            Consulte suas compras e acompanhe os detalhes dos seus pedidos.
        </p>
    </div>

    <a class="link-editar" href="meusPedidos.aspx">
        Ver meus pedidos
    </a>
</div>
            <form id="formn" runat="server">
                <div class="acoes-perfil">
                    <asp:Button ID="BtnSair" runat="server" Text="Sair da conta" CssClass="botao-sair" OnClick="BtnSair_Click" />
                    <asp:Button ID="BtnExcluir" runat="server" Text="Excluir conta" CssClass="botao-excluir" OnClick="BtnExcluir_Click" />
                </div>
            </form>
        </main>

    

</body>
</html>