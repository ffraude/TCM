<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminEstoque.aspx.cs" Inherits="Sabonet.adminEstoque" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gerenciar Estoque - Sabonet</title>

    <style>
        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', Arial, sans-serif;
        }

        body {
            background: #f4f4f4;
            padding-top: 15vh;
        }

        header {
            position: fixed;
            top: 0;
            width: 100%;
            height: 12vh;
            background: #2e4981;
            color: antiquewhite;
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 0 40px;
        }

        header a {
            text-decoration: none;
            color: antiquewhite;
        }

        header > a {
            font-size: 3rem;
            font-weight: bold;
        }

        nav {
            display: flex;
            align-items: center;
            gap: 30px;
        }

        nav a {
            font-size: 1.1rem;
            font-weight: 600;
            transition: 0.3s;
        }

        nav a:hover {
            transform: translateY(-2px);
            color: #87C5E5;
        }

        main {
            width: 90%;
            margin: 40px auto;
        }

        h1 {
            color: #2e4981;
            margin-bottom: 25px;
        }

        .tabela {
            width: 100%;
            border-collapse: collapse;
            background: white;
        }

        .tabela th, .tabela td {
            padding: 15px;
            border: 1px solid #ddd;
            text-align: center;
        }

        .tabela th {
            background: #2e4981;
            color: white;
        }

        .tabela input {
            width: 80px;
            padding: 7px;
        }

        .mensagem {
            display: block;
            margin-bottom: 20px;
            font-weight: bold;
        }

        .baixo {
            color: #c0392b;
            font-weight: bold;
        }

        .normal {
            color: #27834a;
            font-weight: bold;
        }

        .botao {
            padding: 7px 14px;
            background: #2e4981;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }
    </style>
</head>

<body>

    <form id="form1" runat="server">

        <header>
            <a href="pagina-inicial.aspx">Sabonet</a>

            <nav>
                <a href="louja.aspx">Loja</a>
                <a href="sobre.aspx">Sobre nós</a>
                <a href="Noscontate.aspx">Contato</a>
                <a href="admin.aspx">Voltar</a>
            </nav>
        </header>

        <main>

            <h1>Gerenciar estoque</h1>

            <asp:Label ID="lblMensagem" runat="server"
                CssClass="mensagem"></asp:Label>

            <asp:GridView ID="gvEstoque" runat="server"
    DataKeyNames="id_prod"
                AutoGenerateColumns="False"
                CssClass="tabela"
                EmptyDataText="Nenhum produto ativo encontrado."
                OnRowEditing="gvEstoque_RowEditing"
                OnRowCancelingEdit="gvEstoque_RowCancelingEdit"
                OnRowUpdating="gvEstoque_RowUpdating">

                <Columns>

                    <asp:BoundField DataField="id_prod"
                        HeaderText="Código"
                        ReadOnly="True" />

                    <asp:BoundField DataField="nome_prod"
                        HeaderText="Produto"
                        ReadOnly="True" />

                    <asp:TemplateField HeaderText="Quantidade">

                        <ItemTemplate>
                            <%# Eval("estoque") %>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtQuantidade" runat="server"
                                Text='<%# Bind("estoque") %>'
                                TextMode="Number">
                            </asp:TextBox>
                        </EditItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Situação">

                        <ItemTemplate>
                            <asp:Label runat="server"
                                Text='<%# Convert.ToInt32(Eval("estoque")) <= 5 ? "Estoque baixo" : "Normal" %>'
                                CssClass='<%# Convert.ToInt32(Eval("estoque")) <= 5 ? "baixo" : "normal" %>'>
                            </asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:CommandField
                        ShowEditButton="True"
                        EditText="Alterar"
                        UpdateText="Salvar"
                        CancelText="Cancelar"
                        HeaderText="Ações" />

                </Columns>

            </asp:GridView>

        </main>

    </form>

</body>
</html>