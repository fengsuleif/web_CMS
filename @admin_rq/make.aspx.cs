using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using FTchina;

public partial class _Management_ti_make : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower()) { Response.Redirect("./Default.Aspx"); }
        Label1.Text = "";
        LoadList();
    }
    protected void B_make_Click(object sender, EventArgs e)
    {
        string url = Turl.Text;
        HttpWebRequest request = null;
        HttpWebResponse response = null;
        Stream stream = null;
        StreamReader reader = null;
        request = (HttpWebRequest)WebRequest.Create(url.Trim());
        response = (HttpWebResponse)request.GetResponse();
        stream = response.GetResponseStream();
        reader = new StreamReader(stream);
        string result = reader.ReadToEnd();
        reader.Close();
        response.Close();

        string savePath = Server.MapPath("~/" + Tindex.Text.Trim());
        StreamWriter writer = new StreamWriter(savePath, false, Encoding.UTF8);
        writer.Write(result);
        writer.Close();

        Label1.Text = "生成成功";
    }


    public void makeht(string url, string makedhtm)
    {
        HttpWebRequest request = null;
        HttpWebResponse response = null;
        Stream stream = null;
        StreamReader reader = null;
        request = (HttpWebRequest)WebRequest.Create(url.Trim());
        response = (HttpWebResponse)request.GetResponse();
        stream = response.GetResponseStream();
        reader = new StreamReader(stream);
        string result = reader.ReadToEnd();
        reader.Close();
        response.Close();

        //string savePath = Server.MapPath("~/htm/" + makedhtm.Trim());
        string savePath = Server.MapPath("~/" + makedhtm.Trim());
        StreamWriter writer = new StreamWriter(savePath, false, Encoding.UTF8);
        writer.Write(result);
        writer.Close();
        Label2.Text = makedhtm + "生成成功";
    }
    public void makeMenu()
    {
        makeht("http://www.unhr.org/index.aspx", "index.htm");
        makeht("http://www.unhr.org/newlist.aspx?lid=162", "dongtai.htm");
        makeht("http://www.unhr.org/newlist.aspx?lid=163", "UNHRCc.htm");
        makeht("http://www.unhr.org/newlist.aspx?lid=164", "UPR.htm");
        makeht("http://www.unhr.org/newlist.aspx?lid=166", "pro.htm");
        makeht("http://www.unhr.org/newlist.aspx?lid=167", "human.htm");
        makeht("http://www.unhr.org/newlist.aspx?lid=169", "join.htm");
    }

    //首页
    protected void index_Click(object sender, EventArgs e)
    {
        makeht("http://www.unhr.org/index.aspx", "index.htm");
        for (int i = 1; i < 10; i++)
        {
            makeht("http://www.unhr.org/index.aspx?page="+i, "index-"+i+".htm");
        }  
    }
   
    protected void Button9_Click(object sender, EventArgs e)
    { makeMenu(); }

    protected void Button10_Click(object sender, EventArgs e)
    {
        string str = "Select id from NewView order by id desc";
        SqlDbHelper sqlDb = new SqlDbHelper();
        SqlDataReader dataReader=sqlDb.ExecuteReader(str, CommandType.Text, null);
        string url = "http://www.unhr.org/newview.aspx?id=";
        string userid = string.Empty;
       
        HttpWebRequest request = null;
        HttpWebResponse response = null;
        Stream stream = null;
        StreamReader reader = null;

        while (dataReader.Read())
        {
            userid = dataReader[0].ToString();
            request = (HttpWebRequest)WebRequest.Create(url+userid);
            response = (HttpWebResponse)request.GetResponse();
            stream = response.GetResponseStream();           
            reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            reader.Close();
            response.Close();
            string savePath = Server.MapPath("~/htm/View" + userid +".htm");
            StreamWriter writer = new StreamWriter(savePath, false, Encoding.UTF8);
            writer.Write(result);
            writer.Close();           
        }
        dataReader.Close();
        Label2.Text = "全站生成成功";
    }
   
    protected void Button21_Click(object sender, EventArgs e)
    {
        string str = "Select id from NewView order by id desc";
        SqlDbHelper sqlDb = new SqlDbHelper();
        SqlDataReader dataReader=sqlDb.ExecuteReader(str, CommandType.Text, null);
        string url = "http://www.unhr.org/ajaxview.aspx?id=";
        string userid = string.Empty;
       
        HttpWebRequest request = null;
        HttpWebResponse response = null;
        Stream stream = null;
        StreamReader reader = null;

        while (dataReader.Read())
        {
            userid = dataReader[0].ToString();
            request = (HttpWebRequest)WebRequest.Create(url+userid);
            response = (HttpWebResponse)request.GetResponse();
            stream = response.GetResponseStream();           
            reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            reader.Close();
            response.Close();

            string savePath = Server.MapPath("~/htm/ajax/Ax" + userid +".htm");
            StreamWriter writer = new StreamWriter(savePath, false, Encoding.UTF8);
            writer.Write(result);
            writer.Close();           
        }
        dataReader.Close();
        Label2.Text = "全站ajax生成成功";
    }
   
   protected void ajax_make()
    {
        string str = "Select top 15 id from NewView order by id desc";
        SqlDbHelper sqlDb = new SqlDbHelper();
        SqlDataReader dataReader=sqlDb.ExecuteReader(str, CommandType.Text, null);
        string url = "http://www.unhr.org/ajaxview.aspx?id=";
        string userid = string.Empty;
       
        HttpWebRequest request = null;
        HttpWebResponse response = null;
        Stream stream = null;
        StreamReader reader = null;

        while (dataReader.Read())
        {
            userid = dataReader[0].ToString();
            request = (HttpWebRequest)WebRequest.Create(url+userid);
            response = (HttpWebResponse)request.GetResponse();
            stream = response.GetResponseStream();
           
            reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            reader.Close();
            response.Close();

            string savePath = Server.MapPath("~/htm/ajax/Ax" + userid +".htm");
            StreamWriter writer = new StreamWriter(savePath, false, Encoding.UTF8);
            writer.Write(result);
            writer.Close();
        }
        dataReader.Close();  
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        string str = "Select top 15 id from NewView order by id desc";
        SqlDbHelper sqlDb = new SqlDbHelper();
        SqlDataReader dataReader = sqlDb.ExecuteReader(str, CommandType.Text, null);
        string url = "http://www.unhr.org/newview.aspx?id=";
        string userid = string.Empty;

        HttpWebRequest request = null;
        HttpWebResponse response = null;
        Stream stream = null;
        StreamReader reader = null;
        while (dataReader.Read())
        {
            userid = dataReader[0].ToString();
            request = (HttpWebRequest)WebRequest.Create(url + userid);
            response = (HttpWebResponse)request.GetResponse();
            stream = response.GetResponseStream();

            reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            reader.Close();
            response.Close();

            string savePath = Server.MapPath("~/htm/View" + userid + ".htm");
            StreamWriter writer = new StreamWriter(savePath, false, Encoding.UTF8);
            writer.Write(result);
            writer.Close();
        }
        dataReader.Close();//文章生成
        ajax_make();//ajax生成
        makeMenu(); ///首页栏目页生成 
        Label2.Text = "最新15条新闻生成成功";
    }
	
	protected void sc_Click(object sender, EventArgs e)
    {
	    string[] Sstr;
        char[] delimiter=new char[]{','};
        Sstr= ddllm.SelectedValue.ToString().Split(delimiter,2);
        makeht("http://www.unhr.org/newlist.aspx?lid="+Sstr[0], Sstr[1]+".htm");
        Label2.Text =ddllm.SelectedItem +"栏目生成"+ Sstr[1] + ".htm" + "生成成功";
        //Response.Write(Sstr[0]+"<br>"+Sstr[1]);
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
    
    