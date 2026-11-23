<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminProdutos.aspx.cs" Inherits="Sabonet.adminProdutos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gerenciar Produtos - Sabonet</title>
    <link rel="stylesheet" href="adminProdutos.css" />
</head>
<body>

    <form id="form1" runat="server">

        <header>
            <a href="pagina-inicial.aspx">Sabonet</a>

            <nav>
                <a href="louja.aspx">Loja</a>
                <a href="sobre.aspx">Sobre nós</a>
                <a href="Noscontate.aspx">Contato</a>
                <a href="admin.aspx" class="btn-voltar">Voltar</a>
            </nav>
        </header>

        <main>

            <div class="topo-produtos">
                <h1>Gerenciar produtos</h1>
            </div>

            <section class="conteudo">

                <asp:GridView ID="gvProdutos" runat="server"
                    AutoGenerateColumns="False"
                    EmptyDataText="Nenhum produto cadastrado."
                    CssClass="tabela"
                    OnRowCommand="gvProdutos_RowCommand">

                    <Columns>

                        <asp:BoundField DataField="id_prod"
                            HeaderText="Código" />

                        <asp:BoundField DataField="nome_prod"
                            HeaderText="Produto" />

                        <asp:BoundField DataField="preco"
                            HeaderText="Preço"
                            DataFormatString="R$ {0:N2}" />

                        <asp:BoundField DataField="estoque"
                            HeaderText="Estoque" />

                        <asp:BoundField DataField="ativo_prod"
                            HeaderText="Ativo" />

                        <asp:TemplateField HeaderText="Ações">

                            <ItemTemplate>

                                <asp:LinkButton ID="btnAlterar" runat="server"
                                    Text="Alterar"
                                    CommandName="Alterar"
                                    CommandArgument='<%# Eval("id_prod") %>' />

                                <asp:LinkButton ID="btnExcluir" runat="server"
                                    Text="Excluir"
                                    CommandName="Excluir"
                                    CommandArgument='<%# Eval("id_prod") %>'
                                    OnClientClick="return confirm('Deseja realmente desativar este produto?');" />

                            </ItemTemplate>

                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </section>

        </main>

    </form>

</body>
</html>