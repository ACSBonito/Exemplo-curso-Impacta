<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <br /><br />

            <asp:Label ID="lblLogin" runat="server" Text="Login :"></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Label ID="lblSenha" runat="server" Text="Senha : "></asp:Label>
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Button ID="btnProsseguir" runat="server" Text="Prosseguir" OnClick="btnProsseguir_Click" />

        </div>
    </form>
</body>
</html>
