using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using FTchina;

public partial class Admin_AddClass : System.Web.UI.Page
{
    Db pn163 = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower()) { Response.Redirect("./Default.Aspx"); }
        if (!IsPostBack) {    LoadList();    }   
    }

    protected void Buttonf_Click(object sender, EventArgs e)
    {
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        string ClassName = TextBoxFclass.Text.Trim();
        string St1 = TextBoxFst.Text.Trim();
        string en_name = Fen.Text.Trim();

        Conn.Open();
        SqlCommand Cmd = new SqlCommand("insert into NewClass(Class,belong,St,en,downurl,summary)" + "values(@Class ,@belong ,@St,@en,@downurl,@summary)", Conn);
        {
            Cmd.Parameters.AddWithValue("@Class", ClassName);
            Cmd.Parameters.AddWithValue("@belong", 1);
            Cmd.Parameters.AddWithValue("@St", St1);
            Cmd.Parameters.AddWithValue("@en", en_name);
            Cmd.Parameters.AddWithValue("@downurl", durl.Text.Trim());
            Cmd.Parameters.AddWithValue("@summary", summary.Text.Trim());   
        }
        if (TextBoxFclass.Text == "" && TextBoxFst.Text == "")
        {
            Response.Write("<script>alert('不能提交空值!');history.go(-1);</script>");
        }
        else
        {
            Cmd.ExecuteNonQuery();           
            Response.Redirect("./AddClass.Aspx");          
        }
        Conn.Close();   
    }
	
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["Admin"] == null) {   Response.Redirect("./Default.Aspx");  }		

        SqlConnection Conn = new SqlConnection(pn163.strConn);
        string ClassName = TextBox1.Text.Trim();
        string St2 = TextBox2.Text.Trim();
        string en_name = Ten.Text.Trim();       
        Conn.Open();        
        SqlCommand Cmd = new SqlCommand("insert into NewClass(Class,belong,St,en)" + "values(@Class,@belong,@St,@en)", Conn);
        {
            Cmd.Parameters.AddWithValue("@Class", ClassName);
            Cmd.Parameters.AddWithValue("@belong", ddllm.SelectedValue);
            Cmd.Parameters.AddWithValue("@St", St2);
            Cmd.Parameters.AddWithValue("@en", en_name);
        }
        if (TextBox1.Text == "" && TextBox2.Text == "")
        {
            Response.Write("<script>alert('不能提交空值!');history.go(-1);</script>");
        }
        else
        {
            Cmd.ExecuteNonQuery();
            Response.Redirect("./Class.Aspx");
        }
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
