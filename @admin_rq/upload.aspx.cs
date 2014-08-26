using System;
using System.IO;
using System.Web;

public partial class Chapter84_Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!checkuser.checkpower())
        {
            Response.Redirect("./Default.Aspx");
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
           if (myFile.HasFile)
        {
            string strFileName = myFile.FileName;
            string strFileExt  = System.IO.Path.GetExtension(strFileName);

            if (strFileExt.ToLower() == ".jpg" || strFileExt.ToLower() == ".gif" || strFileExt.ToLower() == ".png" || strFileExt.ToLower() == ".doc" || strFileExt.ToLower() == ".pdf" || strFileExt.ToLower() == ".rar" || strFileExt.ToLower() == ".docx" || strFileExt.ToLower() == ".zip")
            {
                string strFileNewName = DateTime.Now.ToString("yyyyMMddhhmmss") + strFileExt;
                string mp = Server.MapPath("~/upload/");
                string stryear = ck_fold(mp+strFileNewName.Substring(0, 4));
                string strmon = ck_fold(stryear+"\\"+strFileNewName.Substring(4, 2)+"\\");
                string  strwebpath = "/upload/" + strFileNewName.Substring(0, 4) + "/" + strFileNewName.Substring(4, 2) + "/";
                string strUrl = Request.Url.ToString();
                string strFileDownloadPath = strmon;
               // string strnewFileDownloadPath = 
                int iFileSize = myFile.PostedFile.ContentLength;
                myFile.SaveAs(strmon + strFileNewName);
                Response.Write(string.Format("文件上传成功<br>图片链接地址请复制：<h3>{0}</h3><br>文件大小：{1}字节<br>", "http://" + HttpContext.Current.Request.Url.Host + strwebpath+strFileNewName, iFileSize));
                
            }
            else
            {
                Response.Write("系统只能接受jpg,gif,dox,docx,pdf,rar,zip");
            }
        }
        else
        {
            Response.Write("请选择您要上传的文件");
        }
    }

     
    
    /**根据时间来命名文件夹
         ./当前目录
         /网站主目录
         ../上层目录
         ~/网站虚拟目录
     * **/
    //检查文件夹是否存在,如果不存在着创建
    public string ck_fold(string path_fold)
    {
        if (!Directory.Exists(path_fold))
        {
            // This path is a directory
            Directory.CreateDirectory(path_fold);
            return path_fold;
        }
        else
        {
            return path_fold;
        }
    }
}
