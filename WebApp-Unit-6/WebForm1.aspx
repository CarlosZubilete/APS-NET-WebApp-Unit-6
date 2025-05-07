<%@ Page 
  Language="C#" 
  AutoEventWireup="true" 
  CodeBehind="WebForm1.aspx.cs" 
  UnobtrusiveValidationMode="None"
  Inherits="WebApp_Unit_6.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unidad 6</title>
    <%--<link rel="stylesheet" type="text/css" href="WebApp-1.css"/>--%>
</head>
<body>
  <h1>Grid View</h1>

  <form id="form1" runat="server">
      <div>
        <asp:GridView ID="gridLibros" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gridLibros_SelectedIndexChanging">
          <%-- Columnas --%>
          <Columns>
            <%-- Columna: LIBRO ID --%>
            <asp:TemplateField HeaderText="Libro (ID)">
              <ItemTemplate>
                <asp:Label ID="itemTemplate_IDLibro" runat="server" Text='<%# Bind("IdLibro") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <%-- Columna: TEMA ID --%>
            <asp:TemplateField HeaderText="Tema (ID)">
              <ItemTemplate>
                <asp:Label ID="itemTemplate_IDTema" runat="server" Text='<%# Bind("IdTema") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <%-- Columna: TITULO--%>
            <asp:TemplateField HeaderText="Titulo">
              <ItemTemplate>
                <asp:Label ID="itemTemplate_Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <%-- Columna: PRECIO--%>
            <asp:TemplateField HeaderText="Precio">
              <ItemTemplate>
                <asp:Label ID="itemTemplate_Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
              </ItemTemplate>
            <%-- Columna: AUTOR--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Autor">
              <ItemTemplate>
                <asp:Label ID="itemTemplate_Autor" runat="server" Text='<%# Bind("Autor") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
        <hr />
        <asp:Label ID="lblRowSelected" runat="server" Text=""></asp:Label>
      </div>
  </form>
</body>
</html>
