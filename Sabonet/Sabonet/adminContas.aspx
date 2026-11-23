<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminContas.aspx.cs" Inherits="Sabonet.adminContas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gerenciar Contas - Sabo.net</title>
    <link rel="stylesheet" href="adminContas.css" />
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

            <h1>Gerenciar Contas</h1>

            <section class="conteudo">

                <div class="pesquisa">

                    <asp:TextBox
                        ID="txtPesquisa"
                        runat="server"
                        placeholder="Pesquisar por nome ou e-mail">
                    </asp:TextBox>

                    <asp:Button
                        ID="btnPesquisar"
                        runat="server"
                        Text="Pesquisar"
                        OnClick="btnPesquisar_Click" />

                    <asp:Button
                        ID="btnLimpar"
                        runat="server"
                        Text="Limpar pesquisa"
                        OnClick="btnLimpar_Click" />

                </div>

                <asp:Label ID="lblMensagem" runat="server"></asp:Label>

                <div class="tabela-container">

                    <asp:GridView
                        ID="gvUsuarios"
                        runat="server"
                        AutoGenerateColumns="False"
                        EmptyDataText="Nenhuma conta encontrada."
                        GridLines="None">

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

                            <asp:TemplateField HeaderText="Tipo de conta">
                                <ItemTemplate>
                                    <%# Convert.ToInt32(Eval("acesso_usu")) == 1 ? "Administrador" : "Cliente" %>
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