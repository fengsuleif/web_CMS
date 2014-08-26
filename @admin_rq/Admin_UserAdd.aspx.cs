using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class Admin_UserAdd : System.Web.UI.Page
{
    Db pn163 = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower()) { Response.Redirect("./Default.Aspx"); }
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlDataAdapter Da = new SqlDataAdapter("select * from Admin", Conn);
        DataSet Ds = new DataSet();
        Da.Fill(Ds, "Admin");
        Repeater1.DataSource = Ds.Tables[0].DefaultView;
        Repeater1.DataBind();

    }
    //修改
    protected void xiugai_Click(object sender, CommandEventArgs e)
    {

        int ID = Convert.ToInt32(e.CommandName);
        string Password = FormsAuthentication.HashPasswordForStoringInConfigFile(p_pass.Text.ToString(), "MD5");
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlDataAdapter adapter = new SqlDataAdapter("select * from Admin where id=@id", Conn);
        {
            adapter.SelectCommand.Parameters.AddWithValue("@id", ID);
        }
        DataTable data = new DataTable();
        adapter.Fill(data);
        int Dr = Convert.ToInt16(data.Rows[0]["id"].ToString());
        if (Dr > 0)
        {
            Panel1.Visible = true;
            u_user.Text = data.Rows[0]["UserAdmin"].ToString();
            p_pass.Text = data.Rows[0]["Mpw"].ToString();
            HiddenField1.Value = data.Rows[0]["id"].ToString();
        } else { Response.Write("<script>alert('用户id为空');history.go(-1);</script>"); }
    }
    protected void DelComm_Click(object sender, CommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandName);

        SqlConnection Conn = new SqlConnection(pn163.strConn);

        Conn.Open();

        SqlCommand Cmd = new SqlCommand("delete from Admin where id=" + ID, Conn);


        Cmd.ExecuteNonQuery();
        Response.Redirect("Admin_userAdd.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string Name = TextBox1.Text;
        //密码使用MD5加密
        string Pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text.ToString(), "MD5");

        string ChkPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox3.Text.ToString(), "MD5");
        string Mpw = TextBox4.Text;
        string Mpw2 = TextBox5.Text;

        SqlConnection Conn = new SqlConnection(pn163.strConn);


        Conn.Open();

        SqlCommand Cmd = new SqlCommand("insert into Admin(UserAdmin,UserPwd,Mpw)" + "values(@UserAdmin,@UserPwd,@Mpw)", Conn);
        {
            Cmd.Parameters.AddWithValue("@UserAdmin", Name);
            Cmd.Parameters.AddWithValue("@UserPwd", Pwd);
            Cmd.Parameters.AddWithValue("@Mpw", Mpw);
        }

        if (ChkPwd == Pwd && Mpw == Mpw2)
        {
            if (Name.Trim() != "")
            {
                Cmd.ExecuteNonQuery();
                Response.Write("<script>alert('添加成功');history.go(-1);</script>");
                Response.Redirect("Admin_userAdd.aspx");
            }
            else
            {
                Response.Write("<script>alert('用户名不能为空');history.go(-1);</script>");
                TextBox1.Focus();
            }
        }
        else
        {
            Response.Write("<script>alert('两次密码输入不一致或两次密匙不一致，请确认后再次输入！');history.go(-1);</script>");
        }
        Conn.Close();
    }
    //密码修改
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (p_npass.Text.ToString() == p_npass2.Text.ToString())
        {
            string x_Pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(p_npass.Text.ToString(), "MD5");
            SqlConnection Conn = new SqlConnection(pn163.strConn);



            SqlCommand Cmd = new SqlCommand("update Admin set UserAdmin=@UserAdmin,UserPwd=@UserPwd,Mpw=@Mpw where id=@id", Conn);
            {
                Cmd.Parameters.AddWithValue("@UserAdmin", u_user.Text.ToString());
                Cmd.Parameters.AddWithValue("@UserPwd", x_Pwd);
                Cmd.Parameters.AddWithValue("@Mpw", p_pass.Text.ToString());
                Cmd.Parameters.AddWithValue("@id", HiddenField1.Value.ToString());
            }
            Conn.Open();
            Cmd.ExecuteNonQuery();
            Response.Write("<script>alert('修改成功')</script>");
            Response.Redirect("Admin_userAdd.aspx");
            Panel1.Visible = false;

        }

    }
}
