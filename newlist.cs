using System;
using System.Data;
using System.Data.SqlClient;


public partial class newlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "Select Titel,zhaiyao,id,Class,Class_id ,S_img from NewView where Class_id=@Class_id order by xulie desc";
        SqlDbHelper sqlDb = new SqlDbHelper();
        SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Class_id",SqlDbType.Int)
            };
        parameters[0].Value = Request.QueryString["lid"];
        Repeater1.DataSource = sqlDb.ExecuteReader(str, CommandType.Text, parameters);
        Repeater1.DataBind();       
        caidan();
       
    }
    public string[] getDsum()
    {
        string str = "select id,class,downurl,summary  from NewClass where id=@id  order by id asc";
        SqlDbHelper sqlDb = new SqlDbHelper();
        SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int)
            };
        parameters[0].Value = Request.QueryString["lid"];
        DataTable data = sqlDb.ExecuteDataTable(str, CommandType.Text, parameters);
        string[] dsum = new string[4];
        dsum[0] = data.Rows[0]["downurl"].ToString() ;
        dsum[1]=data.Rows[0]["summary"].ToString(); 
		dsum[2]=data.Rows[0]["class"].ToString();
		dsum[3]=data.Rows[0]["id"].ToString();
        return dsum;
    }
    public void caidan()
    {
        SqlConnection Conn = new SqlConnection(sqldb.sqlConn);
        Conn.Open();
        SqlCommand cmdx1 = new SqlCommand("select id,Class  from NewClass   order by id asc", Conn);
        menudh.DataSource = cmdx1.ExecuteReader();
        menudh.DataBind();
        Conn.Close();
    }
   
    public string ShortTitle(string str, int length)
    {
        if (str.Length > length)
            str = str.Substring(0, length);
        //str = str.Substring(0, length)+"...";
        return str;
    }
   

}