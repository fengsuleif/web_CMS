using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _admin_rq_dirfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower())
        {
            Response.Redirect("./Default.Aspx");          
        }
        if ("del" == Request.QueryString["a"])
        {
            string fileid = Request.QueryString["fid"];
            File.Delete(fileid);
            Response.Redirect("dirfile.aspx");
        }

    }
    public string webUrl ="http://"+ HttpContext.Current.Request.Url.Host.ToString()+"/";
    public void getdir( string rootpath)
    {
        if (Directory.Exists(Server.MapPath(rootpath)))
        {
            rootpath = Server.MapPath(rootpath);
            Response.Write("<i class=\" icon-home\"></i>" + rootpath + "<br />");
            showfile(rootpath);
            showdir(rootpath);
        }

    }

    public void showdir(string rootpath)
    {
        if (Directory.Exists(rootpath))
        {
            string[] mydir = Directory.GetDirectories(rootpath);
            foreach (string subdir in mydir)
            {
                Response.Write("<i class=\" icon-folder-open\"></i>" + subdir + "<br />");              
                showdir(subdir);                
                showfile(subdir);
            }           
        }       
         
    }
    public void showfile(string files)
    {      
        string[] myfiles = Directory.GetFiles(files);
        foreach (string subfile in myfiles)
        {
            Response.Write("<i class=\" icon-file\"></i>" + webUrl + urlconvertor(subfile) + "<a href=" + webUrl + urlconvertor(subfile) + " class='btn' target='_blank'><i class=\"icon-eye-open\"></i>查看</a><a href=dirfile.aspx?a=del&fid=" + subfile + " class='btn' onclick=\"return confirm('确认删除文件！');\"><i class=\"  icon-trash\"></i>删除文件</a><br />");
        }
    }
  
 
 

    //本地路径转换成URL相对路径
    private string urlconvertor(string imagesurl1)
    {
        string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
        string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
        imagesurl2 = imagesurl2.Replace(@"\", @"/");
        //imagesurl2 = imagesurl2.Replace(@"Aspx_Uc/", @"");
        return imagesurl2;
    }
    //相对路径转换成服务器本地物理路径
    private string urlconvertorlocal(string imagesurl1)
    {
        string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
        string imagesurl2 = tmpRootDir + imagesurl1.Replace(@"/", @"/"); //转换成绝对路径
        return imagesurl2;
    }

}