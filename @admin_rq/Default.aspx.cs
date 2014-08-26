using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AddHeader("Pragma", "No-Cache");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Db pn163 = new Db();
        //密码使用MD5加密
        string Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Pwd.Text.ToString(), "MD5");
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlCommand Cmd = new SqlCommand("select * from Admin where UserAdmin=@UserAdmin and UserPwd = @UserPwd and Mpw = @Mpw", Conn);
        {
            Cmd.Parameters.AddWithValue("@UserAdmin", Uid.Text);
            Cmd.Parameters.AddWithValue("@UserPwd", Password);
            Cmd.Parameters.AddWithValue("@Mpw", Mpw.Text);
        }
        Conn.Open();

        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Uid.Text != "" && Pwd.Text != "" && Mpw.Text != "")
        {
            if (Dr.Read())
            {
                Session["Admin"] = "4400";
                HttpCookie cookie = new HttpCookie("TiName");
                cookie.Value = "4400"; //cookie["name"] = "zhangsan";   
                cookie.Expires = DateTime.Now.AddMinutes(60);//这里设置要保存多长时间.  不设置expires，默认为关闭浏览器 就删除cookie
                Response.Cookies.Add(cookie);
                Response.Write("<script>alert('登陆成功！');history.go(-1);</script>");
                Response.Redirect("./Main.aspx");
            }
            else
            {
                Response.Write("<script>alert('用户名，密码错误或密匙错误！');history.go(-1);</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('请输入用户名，密码和密匙！');history.go(-1);</script>");
        }

    }
}
