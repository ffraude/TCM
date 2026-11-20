<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="introducao.aspx.cs" Inherits="Sabonet.introducao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet"/>
    <title>Sabo.net</title>

    <style>
        .botao{
            width: 100%;
            padding: 14px;
            border: none;
            border-radius: 9px;
            background: #ADD8F0;
            color: #34566B;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
            transition: 0.3s;
            margin-top: 15px;
        }
            .botao:hover {
                background: #87C5E5;
                transform: translateY(-2px);
            }

    </style>
</head>
<body>
<form id="form1" runat="server">
    <h2>Seja bem vindo a Sabo.Net!!</h2>

    <div>
        <asp:Button ID="butao_semseropais" runat="server" Text="Fazer Login" CssClass="botao" OnClick="butao_semseropais_Click" />
    </div>

    <p>Ainda não tem uma conta? Crie uma</p>

    <div>
    <asp:Button ID="butao_maseopais" runat="server" Text="Fazer Cadastro" CssClass="botao" OnClick="butao_maseopais_Click" />
    </div>

</form>
</body>
</html>
