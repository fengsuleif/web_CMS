using System;
using System.Web;
using FTchina;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!checkuser.checkpower()) { Response.Redirect("./Default.Aspx"); }
            else
            {

                Name.Text = Server.MachineName;

                ip.Text = Request.UserHostAddress;

                Time.Text = DateTime.Now.ToString();

                Dk.Text = Request.ServerVariables["SERVER_PORT"];

                Os.Text = Environment.OSVersion.ToString().Remove(0, 10);

                Iis.Text = Request.ServerVariables["SERVER_SOFTWARE"];
            }
        }
        catch { Response.Redirect("./Default.Aspx"); }
    }
}
