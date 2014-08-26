using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using FTchina;
public partial class _Management_ti_addnew_ti : System.Web.UI.Page
{
    Db pn163 = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower()) { Response.Redirect("./Default.Aspx"); }
       
        if (!IsPostBack)
        {
            LoadList();
           
            SqlConnection Conn = new SqlConnection(pn163.strConn); 
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = ddllm.SelectedItem.Text;
        str = str.Replace('├', ' '); //将├字换为  字 
        SqlConnection Conn = new SqlConnection(pn163.strConn);

        SqlCommand Cmd = new SqlCommand("Insert Into NewView(Titel,ViewFrom,Class,Class_id,authour,s_img,zhaiyao,AltView,xulie)" + "values(@Titel,@ViewFrom,@Class,@Class_id,@authour,@s_img,@zhaiyao,@AltView,@xulie)", Conn);
            {
                Cmd.Parameters.AddWithValue("@Titel",Titel.Text);
                Cmd.Parameters.AddWithValue("@xulie",xl.Text);
                Cmd.Parameters.AddWithValue("@ViewFrom", ViewFrom.Text);
                Cmd.Parameters.AddWithValue("@authour", authour.Text);
                Cmd.Parameters.AddWithValue("@s_img", ximg.Text);
                Cmd.Parameters.AddWithValue("@zhaiyao", zhaiyao.Text);
                Cmd.Parameters.AddWithValue("@AltView", content.Text.ToString());
                Cmd.Parameters.AddWithValue("@Class_id", ddllm.SelectedValue);
                Cmd.Parameters.AddWithValue("@Class", str.Trim());
            }
            if (Titel.Text == "")
            {
                Response.Write("<script>alert('新闻标题不能为空!');history.go(-1);</script>");
            }
            else
            {
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close(); 
                Response.Redirect("./AdminNews.aspx");
            }
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
