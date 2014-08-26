<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" MasterPageFile="./MasterPage.master" Inherits="Main" %>
<asp:Content ID="Mainx" ContentPlaceHolderID="Conut1" runat="server">
<%@ Import Namespace="System.Globalization"%> 
 <%@ Import Namespace="Microsoft.Win32" %> 
 <%@ Import Namespace="System.IO"%> 
 <%@ Import Namespace="System.Diagnostics" %> 

<div class="well well-large">
<table  cellspacing="2"  class="table">
  <tr class="info">
    <td  height="25" align="center">服务器基本信息</td>
  </tr>
  <tr>
    <td >&nbsp;主机名称:&nbsp;<asp:Label ID="Name" runat="server" /><br />
                          &nbsp;服务器IP:&nbsp;<asp:Label ID="ip" runat="server" /><br />
                          &nbsp;服务端口:&nbsp;<asp:Label ID="Dk" runat="server"/><br />
                          &nbsp;系统时间:&nbsp;<asp:Label ID="Time" runat="server"/><br />
                          &nbsp;操作系统:&nbsp;<asp:Label ID="Os" runat="server"/><br />
                          &nbsp;环境版本:&nbsp;<asp:Label ID="Iis" runat="server"/><br />
                          &nbsp;NET版本:&nbsp;<%
          int build, major, minor, revision;
          build = Environment.Version.Build;
          major = Environment.Version.Major;
          minor = Environment.Version.Minor;
          revision = Environment.Version.Revision;
          Response.Write(major + "." + minor + "." + build + "." + revision);    
      %></td></tr>
   <tr><td>
    <% 
        Response.Write("当前系统用户名：");
        Response.Write(Environment.UserName + "<br />");
        Response.Write("计算机名：");
       Response.Write("http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath + "<br />");
       
      Response.Write("域名：");
        Response.Write(Request.ServerVariables["SERVER_NAME"].ToString() + "<br />");
     
       Response.Write("本文件所在路径：");
        Response.Write(Request.PhysicalApplicationPath + "<br />");
       Response.Write("操作系统：");
       Response.Write(Environment.OSVersion.ToString() + "<br />");
        
        Response.Write("操作系统所在文件夹：");
       Response.Write(Environment.SystemDirectory.ToString()); %>
        
        </td></tr>
        <tr><td>
         <% 
        Response.Write("IE版本：");
        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Version Vector");
        Response.Write(key.GetValue("IE", "未检测到").ToString() + "<br />");
        Response.Write("启动到现在已运行：");
        Response.Write(((Environment.TickCount / 0x3e8) / 60).ToString() + "分钟" + "<br />");
       Response.Write("逻辑驱动器：");
        string[] achDrives = Directory.GetLogicalDrives();
        for (int i = 0; i < Directory.GetLogicalDrives().Length - 1; i++)
        {
            Response.Write(achDrives[i].ToString());
        }
       
       Response.Write("CPU 数量：");
        Response.Write(Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS").ToString() + "<br />");
       Response.Write("CPU类型：");
        Response.Write(Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER").ToString() + "<br />");
        Response.Write("ASP.NET所站内存：");
        Response.Write(((Double)Process.GetCurrentProcess().WorkingSet64 / 1048576).ToString("N2") + "M" + "<br />");
       Response.Write("ASP.NET所占CPU：");
       
       
    %>
  

 </td>
 </tr>
</table>
 </div>  
</asp:Content>
