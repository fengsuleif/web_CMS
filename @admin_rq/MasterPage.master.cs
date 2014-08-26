using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ac"] == "ck") { clearcook();  }
      
    }

    public void clearcook()
    {
        HttpCookie myCookie = new HttpCookie("TiName");
        myCookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(myCookie);
        Response.Redirect("./Default.Aspx");
    }
}
