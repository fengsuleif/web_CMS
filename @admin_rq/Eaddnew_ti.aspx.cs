using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using FTchina;
public partial class Eaddnew_ti : System.Web.UI.Page
{
    Db pn163 = new Db();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower()) { Response.Redirect("./Default.Aspx"); }

        SqlConnection Conn = new SqlConnection(pn163.strConn);
        Conn.Open();
        SqlCommand Cmd = new SqlCommand("select * from NewView where id =@id", Conn);
        {
            Cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        }
        if (!IsPostBack)
        {
            LoadList();
            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())
            {
                Titel.Text = Dr["Titel"].ToString();

                ViewFrom.Text = Dr["ViewFrom"].ToString();
                authour.Text = Dr["authour"].ToString();
                xl.Text = Dr["xulie"].ToString();                
                ximg.Text = Dr["S_img"].ToString();
                zhaiyao.Text = Dr["zhaiyao"].ToString();
                content.Text = Dr["AltView"].ToString();
                ListItem item = ddllm.Items.FindByText(Dr["Class"].ToString());

                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        string str = ddllm.SelectedItem.Text;
        str = str.Replace('├', ' '); //将├字换为  字 

        SqlCommand Cmd = new SqlCommand("update NewView set Titel=@Titel,authour=@authour,Class=@Class,zhaiyao=@zhaiyao,AltView=@AltView, ViewFrom=@ViewFrom,Class_id=@Class_id,s_img=@s_img , xulie=@xulie where id=@id", Conn);
        {
            Cmd.Parameters.AddWithValue("@Titel", Titel.Text);
            Cmd.Parameters.AddWithValue("@Class", str.Trim());
            Cmd.Parameters.AddWithValue("@AltView", content.Text);
            Cmd.Parameters.AddWithValue("@ViewFrom", ViewFrom.Text);
            Cmd.Parameters.AddWithValue("@xulie", xl.Text);
            Cmd.Parameters.AddWithValue("@zhaiyao", zhaiyao.Text.Trim());
            Cmd.Parameters.AddWithValue("@authour", authour.Text.Trim());
            Cmd.Parameters.AddWithValue("@Class_id", ddllm.SelectedValue);

            Cmd.Parameters.AddWithValue("@S_img", ximg.Text.Trim());
            Cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        }
        Conn.Open();
        Cmd.ExecuteNonQuery();
        Response.Redirect("./AdminNews.aspx");
        Conn.Close();
    }

    /// <summary>
    /// 生成多级下拉菜单
    /// </summary>
    private void LoadList()
    {
        int MTcount = 0;//执行遍历的次数        
        MakeTr("1", MTcount);//开始迭代加载
    }

    private void MakeTr(string id, int count)
    {
        DataView dv = new DataView(shujuku.GetDataTable("select * from NewClass where belong=" + id + " order by id asc"));
        foreach (DataRowView drv in dv)
        {
            ListItem li = new ListItem(MakeFelgefu(count) + drv["Class"].ToString(), drv["id"].ToString());
            ddllm.Items.Add(li);
            MakeTr(drv["id"].ToString(), count + 1);  //再次遍历
        }
    }

    private string MakeFelgefu(int count)
    {
        string Returnwords = string.Empty;
        if (count == 0) { Returnwords = ""; } else { Returnwords = ("├").PadLeft(count, '　'); }
        return Returnwords;
    }
}
