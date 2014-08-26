using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using FTchina;


public partial class Class1 : System.Web.UI.Page
{
    Db pn163 = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower()) { Response.Redirect("./Default.Aspx"); }
        if (!IsPostBack)
        {
            LoadList();
            BindData();
        }
    }

    public void BindData()
    {
        string sql = "select * from NewClass where belong=1  order by id asc ";
        //略去声明myAdapter   和   DataSet   
        //以下是填充数据方法 
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlDataAdapter myAdapter = new SqlDataAdapter("select * from NewClass where belong=1  order by id asc", Conn);
        DataSet ds = new DataSet();
        myAdapter.Fill(ds, "dtable ");
        this.Repeater1.DataSource = ds.Tables[0].DefaultView;
        this.Repeater1.DataBind();
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


    protected void DelComm_Click(object sender, CommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandName);
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        Conn.Open();
        SqlCommand Cmd = new SqlCommand("delete from NewClass where id=@id", Conn);
        {
            Cmd.Parameters.AddWithValue("@id", ID);
        }
        Cmd.ExecuteNonQuery();
        Conn.Close();
        Response.Redirect("Class.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection Conn1 = new SqlConnection(pn163.strConn);
        SqlCommand mycomm = new SqlCommand("select * from NewClass where belong=@belong order by id asc ", Conn1);
        {
            mycomm.Parameters.AddWithValue("@belong", ddllm.SelectedValue);
        }
        Conn1.Open();
        this.Repeater1.DataSource = mycomm.ExecuteReader();
        this.Repeater1.DataBind();
        Conn1.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection Conn1 = new SqlConnection(pn163.strConn);
        SqlCommand mycomm = new SqlCommand("select * from NewClass order by id asc ", Conn1);
        Conn1.Open();
        this.Repeater1.DataSource = mycomm.ExecuteReader();
        this.Repeater1.DataBind();
        Conn1.Close();
    }
}
