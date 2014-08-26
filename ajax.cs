using System;
using System.Data;
using System.Data.SqlClient;


public partial class newview : System.Web.UI.Page 
{
      
    protected void Page_Load(object sender, EventArgs e)
    {        
        string str;
        str = "Select * from NewView where id=@id order by Time desc";
        sqldb.Conn.Open();
        SqlCommand cmd = new SqlCommand(str, sqldb.Conn);
        {
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        }
        newslist.DataSource = cmd.ExecuteReader();
        newslist.DataBind();
        sqldb.Conn.Close();			
    }

    public string ShortTitle(string str, int length)
    {
        if (str.Length > length)
            str = str.Substring(0, length);
        //str = str.Substring(0, length)+"...";
        return str;
    }
    public DataTable getMC()
    {
        Db newdb = new Db();
        SqlConnection Conn = new SqlConnection(newdb.strConn);
        SqlDataAdapter adapter = new SqlDataAdapter("select id,Titel from NewView where Class_id=170  order by id asc ", Conn);
        DataTable data2 = new DataTable();
        adapter.Fill(data2);
        return data2;

    }
    public string rp(string str)
    {
        // Hashtable ht = new Hashtable(); //创建一个Hashtable实例
        DataTable dt = getMC();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            // ht.Add(dt.Rows[i]["id"],dt.Rows[i]["Title"]);  //添加key/value键值对         
            str = str.Replace(dt.Rows[i]["Titel"].ToString(), "<A href=http://unhr.org/htm/ajax/Ax" + dt.Rows[i]["id"] + ".htm  class='pop_view'>[" + dt.Rows[i]["Titel"] + "]</A>");//替换为空
        }
        return str;

    }
}