<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebApp-2.aspx.cs" Inherits="WebApp_Unit_6.WebApp_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <h1>Formulario WEB APP - 2</h1>
  <%-- VARIABLE SESION --%>
    <form id="form1" runat="server">
      <div>
        <h3>Varible Session</h3>
        <span>Nombre de usuario: </span>
        <asp:Label runat="server" ID="lblShow" Text=""></asp:Label>
      </div>
      <hr />
 <%-- VARIABLE APLICACION--%>
      <div>
        <h3>Variable Aplicación</h3>
        <span>Resultado de Click: </span>
        <asp:Label runat="server" ID="lblCountResult"></asp:Label>
        <br />
        <asp:HyperLink ID="linkCoutClick" runat="server" NavigateUrl="~/WebForm1.aspx">Wep-app-1</asp:HyperLink>
      </div>
    </form>
</body>
</html>
