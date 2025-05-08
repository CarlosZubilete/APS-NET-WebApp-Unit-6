<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebApp-3.aspx.cs" Inherits="WebApp_Unit_6.WebApp_3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <h3>Web APP - 3</h3>
    <form id="form1" runat="server">
        
      <div>         
        <asp:GridView ID="gridCountries" runat="server">
        </asp:GridView>
       </div>

      <asp:Button runat="server" ID="btnDelete" Text="Eliminar Tabla"/>
      <br />
      <asp:HyperLink ID="linkCoutClick" runat="server" NavigateUrl="~/WebForm1.aspx">Wep-app-1</asp:HyperLink>
    </form>
</body>
</html>
