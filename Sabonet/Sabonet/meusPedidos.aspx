<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meusPedidos.aspx.cs" Inherits="Sabonet.meusPedidos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link rel="stylesheet" href="meusPedidos.css" />
    <title>Meus Pedidos - Sabo.net</title>
</head>
<body>

    <header>
        <a href="pagina-inicial.aspx">Sabo.net</a>

        <nav>
            <a href="admin.aspx" id="linkAdmin" runat="server" style="display: none;">Administração</a>
            <a href="louja.aspx">Loja</a>
            <a href="sobre.aspx">Sobre nós</a>
            <a href="Noscontate.aspx">Contato</a>
            <a href="perfil.aspx" class="btn-voltar" onclick="history.back(); return false;">Voltar</a>
        </nav>
    </header>

    <form id="form1" runat="server">

        <main class="conteudo">

            <section class="pedidos">
                <h1>Meus Pedidos</h1>

                <asp:GridView ID="gvPedidos" runat="server"
                    AutoGenerateColumns="False"
                    OnRowCommand="gvPedidos_RowCommand"
                    EmptyDataText="Você ainda não realizou nenhuma compra."
                    CssClass="tabela">

                    <Columns>
                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />

                        <asp:BoundField DataField="data_ped" HeaderText="Data"
                            DataFormatString="{0:dd/MM/yyyy}" />

                        <asp:BoundField DataField="status_ped" HeaderText="Status" />

                        <asp:BoundField DataField="quantidade_total" HeaderText="Quantidade" />

                        <asp:BoundField DataField="valor_total" HeaderText="Valor total"
                            DataFormatString="R$ {0:N2}" />

                        <asp:TemplateField HeaderText="Detalhes">
                            <ItemTemplate>
                                <asp:Button ID="btnDetalhes" runat="server"
                                    Text="Ver detalhes"
                                    CommandName="VerDetalhes"
                                    CommandArgument='<%# Eval("id_pedido") %>'
                                    CssClass="btn-detalhes" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </section>

            <section class="detalhes">

                <h2>Detalhes do pedido</h2>

                <asp:Label ID="lblPedidoSelecionado" runat="server"
                    CssClass="pedido-selecionado"></asp:Label>

                <div class="endereco">
                    <h3>Endereço de entrega</h3>

                    <asp:Label ID="lblCEP" runat="server"></asp:Label><br />
                    <asp:Label ID="lblNumero" runat="server"></asp:Label><br />
                    <asp:Label ID="lblComplemento" runat="server"></asp:Label><br />
                    <asp:Label ID="lblBairro" runat="server"></asp:Label><br />
                    <asp:Label ID="lblCidade" runat="server"></asp:Label><br />
                    <asp:Label ID="lblEstado" runat="server"></asp:Label><br />
                </div>

                <h3>Produtos do pedido</h3>

                <asp:GridView ID="gvItensPedido" runat="server"
                    AutoGenerateColumns="False"
                    EmptyDataText="Nenhum produto encontrado."
                    CssClass="tabela">

                    <Columns>
                        <asp:BoundField DataField="nome_prod" HeaderText="Produto" />

                        <asp:BoundField DataField="quant" HeaderText="Quantidade" />

                        <asp:BoundField DataField="preco_unitario"
                            HeaderText="Preço unitário"
                            DataFormatString="R$ {0:N2}" />

                        <asp:BoundField DataField="subtotal"
                            HeaderText="Subtotal"
                            DataFormatString="R$ {0:N2}" />
                    </Columns>

                </asp:GridView>

            </section>

        </main>

    </form>

</body>
</html>