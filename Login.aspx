<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PetStore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Email : <asp:TextBox ID="email" runat ="server" ></asp:TextBox> <br />
        <br />
        Password : <asp:TextBox ID="password" runat ="server" ></asp:TextBox><br />
        <br />
        <br />
        <asp:button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click"   />
        <asp:Label ID ="error" runat="server" ForeColor="Red" />
        <a href="Pages/PasswordRetrieve.aspx"> Password Retrieve</a>
        
    </div>
    </form>
</body>
</html>
