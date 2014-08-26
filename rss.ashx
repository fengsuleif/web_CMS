<%@ WebHandler Language="C#" Class="RSS" %>
using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using RssToolkit;

public class RSS : GenericRssHttpHandlerBase
{
    protected override void PopulateChannel(string channelName, string userName)
    {
        //添加频道
        Channel["title"] = "人权捍卫者";
        //如果频道名称不为空
        if (!string.IsNullOrEmpty(channelName))
        {
            //设置频道名称
            Channel["title"] += " '" + channelName + "'";
        }
        //如果访问用户名不为空
        if (!string.IsNullOrEmpty(userName))
        {
            //设置用户名名称
            Channel["title"] += " (generated for " + userName + ")";
        }

        //设置频道的属性
        Channel["link"] = "~/index.aspx";
        Channel["description"] = "人权捍卫者";
        Channel["ttl"] = "10";
        Channel["name"] = channelName;
        Channel["user"] = userName;
        //获取保存到数据库中的订阅频道
        DataSet ds = new DataSet();
           
            SqlDataAdapter da = new SqlDataAdapter("Select top 24 * from NewView   order by id desc", sqldb.Conn);

            da.Fill(ds);
        GenericRssElement item;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //定义项
            //创建一个频道内的项
            item = new GenericRssElement();
            //为项的基本属性赋值
            item["title"] = ds.Tables[0].Rows[i][1].ToString();
            item["description"] =  ds.Tables[0].Rows[i][9].ToString();
            item["link"] ="http://hrdcare.org/ajaxview.aspx?id="+ds.Tables[0].Rows[i][0].ToString();
            //将项添加到频道内
            Channel.Items.Add(item);
        }
    }
 
}