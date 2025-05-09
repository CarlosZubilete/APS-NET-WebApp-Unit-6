using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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

    protected void gridLibros_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      gridLibros.PageIndex = e.NewPageIndex;
      this.loadGrid();
    }

    protected void gridLibros_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if(e.CommandName == "buyEnvent")
      {
        // Get the row of the grid.
        int row = Convert.ToInt32(e.CommandArgument);

        string title = ((Label)gridLibros.Rows[row].FindControl("itemTemplate_Titulo")).Text;

        string price = ((Label)gridLibros.Rows[row].FindControl("itemTemplate_Precio")).Text;

        lblRowSelected.Text = $"Compó '{title}' . Precio ${price}";
      }
    }
    /// SECTOR VARIABLE SESION
    protected void btnSend_Click(object sender, EventArgs e)
    {
      // Declarate a sesion Variable
      Session["nameUser"] = txtBoxNameUser.Text;
      // Send a information towards the othe form
      Server.Transfer("WebApp-2.aspx");
    }

    protected void btnCountClick_Click(object sender, EventArgs e)
    {
      // is there a Application variable ? 
      if (Application["countClick"] == null)
      {
        // Create and init
        Application["countClick"] = 1;
      }
      else
      {
        //Convert.ToInt32(Application["countClick"]) += 1; 
        Application["countClick"] = Convert.ToInt32(Application["countClick"]) + 1; 
      }
    }

    protected void btnAddData_Click(object sender, EventArgs e)
    {
      // is thre a Sesion variable
      if(Session["Table"] == null)
      {
        Session["Table"] = this.CreateTable(); 
      }

      this.AddRegister((DataTable)Session["Table"], txtBoxCountry.Text, txtBoxCity.Text);
      this.CleanControl();   
    }

    private DataTable CreateTable()
    {
      // Create a Object Table
      DataTable table = new DataTable();
      // Create a Object Column
      DataColumn column = new DataColumn("Country", System.Type.GetType("System.String"));
      // Add column to table
      table.Columns.Add(column);

      column = new DataColumn("City", System.Type.GetType("System.String"));
      table.Columns.Add(column);

      return table;
    }
    
    private DataTable AddRegister(DataTable dataTable, string country, string city)
    {
      DataRow row = dataTable.NewRow();
      row["Country"] = country;
      row["City"] = city;

      dataTable.Rows.Add(row);

      return dataTable;
    }
    
    private void CleanControl()
    {// Only clean controls about 'AddRegister'
      txtBoxCountry.Text = string.Empty;
      txtBoxCity.Text = string.Empty;
    }

    protected void btnInitSesion_Click(object sender, EventArgs e)
    {
      // Declatare a variable Cookie
      HttpCookie cookie = new HttpCookie("User",txtBoxUser.Text);
      // Add how long the cookie will be on the page.
      cookie.Expires = DateTime.Now.AddSeconds(60);
      // Add cookie at the server
      this.Response.Cookies.Add(cookie);

      // Another way to do the same: 
      this.Response.Cookies["Password"].Value = txtBoxPassword.Text;
      this.Response.Cookies["Password"].Expires = DateTime.Now.AddSeconds(60);



      Server.Transfer("WebApp-3.aspx");
    }

    // TODO : Bad declate name Variable, we have two variables 
    // 'txtUserName' and 'txtUser' , check out! 
  }
}