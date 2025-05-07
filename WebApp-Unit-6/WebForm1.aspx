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
    <link rel="stylesheet" type="text/css" href="WebApp-1.css"/>
</head>
<body>
  <h1>Grid View</h1>

  <form id="form1" runat="server">
      <div>
        <asp:GridView ID="gridLibros" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" CssClass="gridLibros">
          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          <%-- Columnas --%>
          <Columns>
            <%-- Columna: LIBRO ID --%>
            <asp:TemplateField HeaderText="Libro (ID)">
              <ItemTemplate>
                <asp:Label ID="itemTemplate_IDTema" runat="server" Text='<%# Bind("IdTema") %>'></asp:Label>
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
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
              </ItemTemplate>
            <%-- Columna: AUTOR--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Autor">
              <ItemTemplate>
                <asp:Label ID="itemTemplate_Autor" runat="server" Text='<%# Bind("Autor") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EditRowStyle BackColor="#999999" />
          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <SortedAscendingCellStyle BackColor="#E9E7E2" />
          <SortedAscendingHeaderStyle BackColor="#506C8C" />
          <SortedDescendingCellStyle BackColor="#FFFDF8" />
          <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

      </div>
  </form>
</body>
</html>
