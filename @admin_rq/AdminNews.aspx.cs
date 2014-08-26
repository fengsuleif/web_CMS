using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using FTchina;
public partial class Admin_AddNews : System.Web.UI.Page
{
    Db pn163 = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower())
        {
            Response.Redirect("./Default.Aspx");
        }
        if (!IsPostBack)
        {
            this.contrlRepeater();
            HiddenField1.Value = "0";
            LoadList();           
        }
    }    

    public int Mpage = 20;  //每页多少行
    public int Cpage = 1;    //当前页

    public int totalpage(int pnum)
    {
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlCommand mycomm = new SqlCommand("select count(id) from NewView", Conn);
        Conn.Open();
        int totalOrders = (int)mycomm.ExecuteScalar();
        Conn.Close();
        if (totalOrders <= pnum) {    return 1; }else {    return totalOrders / pnum + 1;   }        
    }
    public void Fwrite(int ipage)
    {

        if (string.IsNullOrEmpty(Request.QueryString["gpage"]))
        {

            this.Cpage = 1;
        }
        else
        {
            this.Cpage = int.Parse(Request.QueryString["gpage"]);
        }
        ipage = totalpage(ipage);//total page       
       
        int i=1;
        if (ipage <= 10)
        {
            i = 1;
        }
        else
        {
            if (this.Cpage >= 10) { i = ipage-this.Cpage; } else  { ipage = 10; }
            
        }
        Response.Write("<div class=\"pagination pagination-centered\"><ul>");
        for (; i <= ipage; i++)
        {
            if (Request.QueryString["gpage"] != null && int.Parse(Request.QueryString["gpage"]) == i)
            {
                Response.Write("<li class=\"disabled\"><a  href=\"AdminNews.aspx?gpage=" + i + "\" >" + i + "</a></li>");
            }
            else
            {
                Response.Write("<li><a  href=\"AdminNews.aspx?gpage=" + i + "\" >" + i + "</a></li>");
            }
        }

        Response.Write(" <button class=\"btn \" type=\"button\">共" + ipage + "页</button></ul></div>");
    }
    //按分类列表----------------------------------------------------
    public void  F_type()
    {
        HiddenField1.Value = "1";
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlDataAdapter Da = new SqlDataAdapter();
        Da.SelectCommand = new SqlCommand("select id,Titel,Class,Class_id,S_img,xulie  from NewView where Class_id=@Class_id order by id desc", Conn);
        {
            Da.SelectCommand.Parameters.AddWithValue("@Class_id",ddllm.SelectedValue);
        }
        DataSet Ds = new DataSet();
        Da.Fill(Ds, "NewView");        
        Repeater1.DataSource = Ds.Tables["NewView"].DefaultView;
        Repeater1.DataBind();
    }
    public void Button2_Click(object sender, EventArgs e)
    {        
        F_type(); 
    }
 //默认列表----------------------------------------------------
    protected void Button3_Click(object sender, EventArgs e)
    {      
        contrlRepeater();
    }
    public void contrlRepeater()
    {
        HiddenField1.Value = "0";
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlDataAdapter Da = new SqlDataAdapter();
        if (Request.QueryString["gpage"] != null && int.Parse(Request.QueryString["gpage"]) > 1)
        {
            this.Cpage = int.Parse(Request.QueryString["gpage"]);
            Da.SelectCommand = new SqlCommand("select top " + this.Mpage + " id,Titel,Class,Class_id,S_img,xulie from NewView where id<(select min(id) from (select top " + this.Mpage * (this.Cpage - 1) + " id from NewView order by id desc ) as t1 )  order by id desc", Conn);
         }
        else
        {
            Da.SelectCommand = new SqlCommand("select  top " + this.Mpage + "  id,Titel,Class,Class_id,S_img,xulie from NewView order by id desc", Conn);          
        }
        DataSet Ds = new DataSet();
        Da.Fill(Ds, "NewView");          
        Repeater1.DataSource = Ds.Tables["NewView"].DefaultView;       
        Repeater1.DataBind();
    } 

   //搜索开始------------------------------------------------------
    public void searc()
    {
        HiddenField1.Value = "2";
        string leftstr = key_word.Text.Trim(); //声明变量等于TextBox1的值。
        string word;
        word = "%" + leftstr + "%";
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        SqlDataAdapter Da = new SqlDataAdapter();
        Da.SelectCommand = new SqlCommand("select * from NewView where Titel like @Titel or authour like @authour or zhaiyao like @zhaiyao   order by id desc", Conn);
        {
            Da.SelectCommand.Parameters.AddWithValue("@Titel", word);
            Da.SelectCommand.Parameters.AddWithValue("@authour", word);
            Da.SelectCommand.Parameters.AddWithValue("@zhaiyao", word);
        }
        DataSet Ds = new DataSet();
        Da.Fill(Ds, "NewView");
        Repeater1.DataSource = Ds.Tables["NewView"].DefaultView;
        Repeater1.DataBind();
    }
    protected void search_Click(object sender, EventArgs e)
    {
     searc();
    }
  // 搜索结束------------------------------------------------------

    protected void DelComm_Click(object sender, CommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandName);
        SqlConnection Conn = new SqlConnection(pn163.strConn);
        Conn.Open();
        SqlCommand Cmd = new SqlCommand("delete from NewView where id=@id", Conn);
        {
            Cmd.Parameters.AddWithValue("@id", ID);
        }
        Cmd.ExecuteNonQuery();
        Conn.Close();
        Response.Redirect("./AdminNews.aspx");
    }
	
    protected void Del_Click(object sender, EventArgs e)
    {
        for (int x = 0; x < Repeater1.Items.Count; x++)
        {
            CheckBox Cb = (CheckBox)Repeater1.Items[x].FindControl("CheckBox1");
            HiddenField Hf = (HiddenField)Repeater1.Items[x].FindControl("HiddenField1");
            if (Cb.Checked)
            {
                int ID = Convert.ToInt32(Hf.Value);
                SqlConnection Conn = new SqlConnection(pn163.strConn);
                Conn.Open();
                SqlCommand Cmd = new SqlCommand("delete from NewView where id=@id", Conn);
                {
                    Cmd.Parameters.AddWithValue("@id", ID);
                }
                Cmd.ExecuteNonQuery();
                Conn.Close();                
            }
        }
        Response.Redirect("./AdminNews.aspx");
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
