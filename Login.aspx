<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background: url('../Img/Vani.jpg') no-repeat center fixed; background-size: cover;">
    <form id="form1" runat="server">
        <div style="font-variant: small-caps; font-weight: bold; position: absolute; left: 50%; transform:translate(-50%, 50%); ">
            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Stanje.aspx" DisplayRememberMe="False" OnAuthenticate="Login1_Authenticate"></asp:Login>
        </div>
    </form>
</body>
</html>
