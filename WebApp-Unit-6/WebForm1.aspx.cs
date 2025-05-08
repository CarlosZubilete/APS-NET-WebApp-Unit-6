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
      // Look up or select the index of the field of Grid INTO <ItemTemplate>
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

    // Edit
    protected void gridLibros_RowEditing(object sender, GridViewEditEventArgs e)
    {
      gridLibros.EditIndex = e.NewEditIndex;
      this.loadGrid();
    }

    // Cancel
    protected void gridLibros_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      gridLibros.EditIndex = -1;
      this.loadGrid();
    }

    protected void gridLibros_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      // Captured the changes entered from browser
      string idLibro = ((Label)gridLibros.Rows[e.RowIndex].FindControl("edit_itemTemp_idLibro")).Text;
      string title = ((TextBox)gridLibros.Rows[e.RowIndex].FindControl("edit_txtBox_Titulo")).Text;
      string price = ((TextBox)gridLibros.Rows[e.RowIndex].FindControl("edit_txtBox_Precio")).Text;
      string author = ((TextBox)gridLibros.Rows[e.RowIndex].FindControl("edit_txtBox_Autor")).Text;

      // Create Libro instance
      Libro libro = new Libro(Convert.ToInt32(idLibro), title, Convert.ToDecimal(price), author);

      HandleLibros handle = new HandleLibros();
      handle.UpDateLibro(libro);

      gridLibros.EditIndex = -1;
      this.loadGrid();
      
    }
  }
}