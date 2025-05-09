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
        // Show country and cities
        if(Session["Table"] != null)
        {
          gridCountries.DataSource = ((DataTable)Session["Table"]);
          gridCountries.DataBind();
        }
        // Show User and Password
        if(Request.Cookies["User"] != null )
        {
          if(Request.Cookies["User"].Value.Trim().Length > 0)
          {
            HttpCookie cookieUser = Request.Cookies["User"];
            lblUser.Text = cookieUser.Value;
          }
        }
        if (Request.Cookies["Password"] != null)
        {
          if (Request.Cookies["Password"].Value.Trim().Length > 0)
          {
            HttpCookie cookiePassword = Request.Cookies["Password"];
            lblPassword.Text = cookiePassword.Value;
          }
        }
      }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      Session["Table"] = null;
      gridCountries.DataSource = null;
      gridCountries.DataBind();
    }

    protected void btnDeleteCookie_Click(object sender, EventArgs e)
    {
      HttpCookie cookie;
      if(Request.Cookies["User"] != null)
      {
        cookie = Request.Cookies["User"];
        cookie.Expires = DateTime.Now.AddDays(-1);
        this.Request.Cookies.Add(cookie);
        lblUser.Text = string.Empty;
      }
      if (Request.Cookies["Password"] != null)
      {
        cookie = Request.Cookies["Password"];
        cookie.Expires = DateTime.Now.AddDays(-1);
        this.Request.Cookies.Add(cookie);
        lblPassword.Text = string.Empty;
      }

    }
  }
}