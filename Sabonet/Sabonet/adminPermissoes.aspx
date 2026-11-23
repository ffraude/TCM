<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPermissoes.aspx.cs" Inherits="Sabonet.adminPermissoes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gerenciar Permissões - Sabo.net</title>
    <link rel="stylesheet" href="adminPermissoes.css" />
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
            <a href="admin.aspx" class="btn-voltar">Voltar</a>
        </nav>
    </header>

    <form id="form1" runat="server">

        <main>

            <h1>Gerenciar Permissões</h1>

            <section class="conteudo">

                <p class="descricao">
                    Consulte os usuários e gerencie suas permissões administrativas.
                </p>

                <asp:Label ID="lblMensagem" runat="server"></asp:Label>

                <div class="tabela-container">

                    <asp:GridView
                        ID="gvUsuarios"
                        runat="server"
                        AutoGenerateColumns="False"
                        EmptyDataText="Nenhuma conta encontrada."
                        GridLines="None"
                        DataKeyNames="id_usu"
                        OnRowCommand="gvUsuarios_RowCommand">

                        <Columns>

                            <asp:BoundField
                                DataField="id_usu"
                                HeaderText="Código" />

                            <asp:BoundField
                                DataField="nome_usu"
                                HeaderText="Nome" />

                            <asp:BoundField
                                DataField="email_usu"
                                HeaderText="E-mail" />

                            <asp:TemplateField HeaderText="Permissão atual">
                                <ItemTemplate>
                                    <%# Convert.ToInt32(Eval("acesso_usu")) == 1 ? "Administrador" : "Cliente" %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ação">
                                <ItemTemplate>

                                    <asp:LinkButton
                                        ID="btnAlterarPermissao"
                                        runat="server"
                                        CommandName="AlterarPermissao"
                                        CommandArgument='<%# Eval("id_usu") %>'
                                        CssClass="btn-permissao"
                                        Text='<%# Convert.ToInt32(Eval("acesso_usu")) == 1 ? "Remover administrador" : "Tornar administrador" %>'
                                        OnClientClick="return confirm('Deseja realmente alterar esta permissão?');">
                                    </asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>

            </section>

        </main>

    </form>

</body>
</html>