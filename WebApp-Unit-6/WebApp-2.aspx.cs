using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Unit_6
{
  public partial class WebApp_2 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        // Show session variable
        if(Session["nameUser"] != null)
        {
          lblShow.Text = Session["nameUser"].ToString(); 
        }
        // show application variable
        if(Application["countClick"] != null)
        {
          lblCountResult.Text = Application["countClick"].ToString();
        }
      }
    }
  }
}