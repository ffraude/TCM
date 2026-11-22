<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editar-senha.aspx.cs" Inherits="Sabonet.editar_senha" %>

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
    <form id="formn" runat="server">
    <header>
        
        <nav>
            <a href="admin.aspx" id="linkAdmin" runat="server" style="display: none;">Administração</a>
            <a href="louja.aspx">Loja</a>
            <a href="sobre.aspx">Sobre nós</a>
            <a href="#">Contato</a>
            <a href="perfil.aspx" id="linkConta" runat="server"><asp:Label ID="LblConta" runat="server" Text="Entrar"></asp:Label></a>
        </nav>
    </header>
        <section class="sect-perfil">
            <div class="titulo-perfil">
                <h1>Editar Senha</h1>
                <p>senhexxxx</p>
            </div>
        <div class="div-perfil">
            <p>Novo endereço de email:</p>
            <p><asp:TextBox ID="TxtUsu" runat="server"></asp:TextBox></p>
        </div>
            <div class="div-perfil">
                <p>Sua Senha:</p>
                <p><asp:TextBox ID="TxtSenha" runat="server"></asp:TextBox></p>
            </div>
                
            <div class="div-perfil">
                <p><asp:Label ID="LblAlerta" runat="server" Text=""></asp:Label></p>
                <p><asp:Button ID="BtnSalvar" runat="server" Text="Salvar Alterações" CssClass="botao-excluir" OnClick="BtnSalvar_Click"/></p>
            </div>
                        
        </section>
    </form>
</body>
</html>
