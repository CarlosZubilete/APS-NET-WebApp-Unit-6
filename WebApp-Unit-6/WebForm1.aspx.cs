using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp_Unit_6.Connection; // exportamos la carpeta

namespace WebApp_Unit_6
{
  public partial class WebForm1 : System.Web.UI.Page
  {

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        HandleLibros handleLibros = new HandleLibros();
        gridLibros.DataSource = handleLibros.getAllBooks();
        gridLibros.DataBind();
      }
    }

    protected void gridLibros_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
      string respuesta;

      string fielSelected;
      fielSelected = ((Label)gridLibros.Rows[e.NewSelectedIndex].FindControl("itemTemplate_IDLibro")).Text;      
      respuesta = $"Usted seleccion: Libro (ID = {fielSelected})";


      fielSelected = ((Label)gridLibros.Rows[e.NewSelectedIndex].FindControl("itemTemplate_IDTema")).Text;
      respuesta += $" - Tema (ID = {fielSelected})";


      fielSelected = ((Label)gridLibros.Rows[e.NewSelectedIndex].FindControl("itemTemplate_Titulo")).Text;
      respuesta += $" - Titulo = {fielSelected}";

      fielSelected = ((Label)gridLibros.Rows[e.NewSelectedIndex].FindControl("itemTemplate_Precio")).Text;
      respuesta += $" - Precio = {fielSelected}";


      fielSelected = ((Label)gridLibros.Rows[e.NewSelectedIndex].FindControl("itemTemplate_Autor")).Text;
      respuesta += $" - Autor = {fielSelected}";

      lblRowSelected.Text = respuesta;


    }
  }
}