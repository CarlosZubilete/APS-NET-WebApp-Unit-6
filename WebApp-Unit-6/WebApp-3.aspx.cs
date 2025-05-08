using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace WebApp_Unit_6
{
  public partial class WebApp_3 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        if(Session["Table"] != null)
        {
          gridCountries.DataSource = ((DataTable)Session["Table"]);
          gridCountries.DataBind();
        }
      }
    }
  }
}