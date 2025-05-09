<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebApp-3.aspx.cs" Inherits="WebApp_Unit_6.WebApp_3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <h3>Web APP - 3</h3>
      <asp:HyperLink ID="linkCoutClick" runat="server" NavigateUrl="~/WebForm1.aspx">Wep-app-1</asp:HyperLink>
    <form id="form1" runat="server">
      <%-- GRID TABLA --%>
      <div>         
        <asp:GridView ID="gridCountries" runat="server">
        </asp:GridView>
       </div>
      <asp:Button runat="server" ID="btnDelete" Text="Eliminar Tabla" OnClick="btnDelete_Click"/>
      <br />
      <hr />
      <h3>Información de COOKIES (Usuario)</h3>
      <span>Usuario:
        <asp:Label Text="" runat="server" ID="lblUser"/>
      </span>
      <br />
      <span>Password:
        <asp:Label Text="" runat="server" ID="lblPassword"/>
      </span>
      <hr />
      <asp:Button Text="Eliminar Usuario" runat="server" ID="btnDeleteCookie" OnClick="btnDeleteCookie_Click"/>
    </form>
</body>
</html>
