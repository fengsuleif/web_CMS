using System;
using System.Data;
using System.Data.SqlClient;


public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        caidan();
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