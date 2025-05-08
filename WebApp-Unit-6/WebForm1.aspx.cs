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
        this.loadGrid();
      }
    }

    private void loadGrid()
    {
      HandleLibros handleLibros = new HandleLibros();
      gridLibros.DataSource = handleLibros.getAllBooks();
      gridLibros.DataBind();
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

    protected void gridLibros_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      string idlibroSelected;
      // First , I find a index of the identificator for deteled
      idlibroSelected = ((Label)gridLibros.Rows[e.RowIndex].FindControl("itemTemplate_IDLibro")).Text;

      // Create a instance Lirbro: 
      Libro libro = new Libro(Convert.ToInt32(idlibroSelected));

      // Create a instance HandleLibro:
      HandleLibros handleLibros = new HandleLibros();
      handleLibros.DeleteLibro(libro);

      // Upload Grid
      this.loadGrid();
      


    }
  }
}