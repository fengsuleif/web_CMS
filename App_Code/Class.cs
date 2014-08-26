using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

/// <summary>
///数据库类
/// </summary>
public class Db
{
    public string strConn = ConfigurationSettings.AppSettings["connStr"];    
}
public static class sqldb
{
    public static string sqlConn = ConfigurationSettings.AppSettings["connStr"];
    public static SqlConnection Conn = new SqlConnection(sqldb.sqlConn);
    public static DataTable getDataAdapter()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("select id,Class,en from NewClass where id not in (171)  order by id asc ", sqldb.sqlConn);
        DataTable data = new DataTable();
        adapter.Fill(data);
        return data;
    }
}

public static class checkuser
{
	public static bool checkpower(){
	 try
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["TiName"]; 
            string transition = cookie.Value;

            if (transition != "4400")
            {
               return false;
            }
	return true;
        }
        catch { return false; }
}
   
}

 