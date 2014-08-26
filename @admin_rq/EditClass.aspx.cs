using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using FTchina;
 
   
public partial class EditClass : System.Web.UI.Page
{
    Db pn163 = new Db();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower()) { Response.Redirect("./Default.Aspx"); }

        if (!IsPostBack)
        {
            SqlConnection Conn = new SqlConnection(pn163.strConn);
            Conn.Open();
            LoadList();            
            SqlCommand Cmd = new SqlCommand("select * from NewClass where id =@id", Conn);
            {
                Cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
            }
            SqlDataReader Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                string sid = Dr["belong"].ToString();
                int id = Convert.ToInt32(sid);
                if (id == 1)
                {
                    TextBoxFclass.Text = Dr["Class"].ToString();
                    TextBoxFst.Text = Dr["St"].ToString();
                    Fen.Text = Dr["en"].ToString();
                    durl.Text = Dr["downurl"].ToString();
                    summary.Text = Dr["summary"].ToString();
                }
                else
                {
                    TextBox1.Text = Dr["Class"].ToString();
                    TextBox2.Text = Dr["St"].ToString();
                    Ten.Text = Dr["en"].ToString();
                }
                Conn.Close();
            }
        }
    }
    protected void Buttonf_Click(object sender, EventArgs e)
    {
        string ClassNew = TextBoxFclass.Text;
        string ClassSt = TextBoxFst.Text;
        string downurl = durl.Text.Trim();
        string dsummary = summary.Text.Trim();
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        Conn.Open();
        SqlCommand Cmd = new SqlCommand("update NewClass set Class=@Class,belong=@belong,St=@St,en=@en ,downurl=@downurl,summary=@summary where id =@id", Conn);
        {
            Cmd.Parameters.AddWithValue("@Class", ClassNew);
            Cmd.Parameters.AddWithValue("@belong", 1);
            Cmd.Parameters.AddWithValue("@St", ClassSt);
            Cmd.Parameters.AddWithValue("@en", Fen.Text.Trim());
            Cmd.Parameters.AddWithValue("@downurl", downurl);
            Cmd.Parameters.AddWithValue("@summary", dsummary);
            Cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        }

        Cmd.ExecuteNonQuery();
        SqlCommand Cmd_next = new SqlCommand("update NewView set Class=@Class where Class_id =@Class_id", Conn);
        {
            Cmd_next.Parameters.AddWithValue("@Class", ClassNew);
            Cmd_next.Parameters.AddWithValue("@Class_id", Request.QueryString["id"]);
        }
        Cmd_next.ExecuteNonQuery();
        Conn.Close();
        Response.Redirect("./Class.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string ClassNew = TextBox1.Text;
        string ClassSt = TextBox2.Text;
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        Conn.Open();
        SqlCommand Cmd = new SqlCommand("update NewClass set Class=@Class,belong=@belong,St=@St ,en=@en where id =@id", Conn);
        {
            Cmd.Parameters.AddWithValue("@Class", ClassNew);
            Cmd.Parameters.AddWithValue("@belong", ddllm.SelectedValue);
            Cmd.Parameters.AddWithValue("@St", ClassSt);
            Cmd.Parameters.AddWithValue("@en", Ten.Text.Trim());
            Cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        }

        Cmd.ExecuteNonQuery();
        SqlCommand Cmd_next = new SqlCommand("update NewView set Class=@Class where Class_id =@Class_id", Conn);
        {
            Cmd_next.Parameters.AddWithValue("@Class", ClassNew);
            Cmd_next.Parameters.AddWithValue("@Class_id", Request.QueryString["id"]);
        }
        Cmd_next.ExecuteNonQuery();
        Conn.Close();
        Response.Redirect("./Class.aspx");
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
