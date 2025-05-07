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
  }
}