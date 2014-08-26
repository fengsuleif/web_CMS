<%@ Page Language="C#"  ValidateRequest="false" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Eaddnew_ti.aspx.cs" Inherits="Eaddnew_ti" Title="添加文章" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" Runat="Server">
<script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
<link href="http://unhr.org/script/rili/styles/glDatePicker.default.css" rel="stylesheet" type="text/css">
<script src="http://zhuanxing.cn/statics/js/jquery.min.js"></script>
<script src="http://unhr.org/script/rili/glDatePicker.min.js"></script>
 <script type="text/javascript">
        
        $(window).load(function()
        {
            $('#ctl00_Conut1_ximg').glDatePicker({
				showAlways : false,
                format: 'yyyy-mm-dd'
            });
			$(".right_dh").pin({
      containerSelector: "#sidebar-left"
	  })
        });
    </script> 
   <table cellspacing="2"  class="table">
  <tr class="info">
    <td colspan="2"   class="Login1"  >添加新闻</td>
  </tr>
   <tr>
    <td   class="Login2" width="15%">排序:</td>
    <td align="left" class="Login2">&nbsp;<asp:TextBox ID="xl" runat="server" MaxLength="10" TextMode="SingleLine" Columns="50" Width="53px"></asp:TextBox></td>
  </tr>
  <tr>
    <td   class="Login2" width="15%">新闻标题:</td>
    <td align="left" class="Login2"><asp:TextBox ID="Titel" runat="server" MaxLength="50" TextMode="SingleLine" Columns="50"></asp:TextBox></td>
  </tr>
<tr>
    <td   class="Login2" width="15%">发表日期:</td>
    <td align="left" class="Login2"><asp:TextBox ID="ximg" runat="server"></asp:TextBox></td>
  </tr>
 <tr>
    <td   class="Login2">新闻分类:</td>
    <td align="left" class="Login2">
      <asp:DropDownList runat="server" ID="ddllm"    ></asp:DropDownList>
    </td>
  </tr>
    <tr>
    <td   class="Login2" width="15%">标签:</td>
    <td align="left" class="Login2"><asp:TextBox ID="ViewFrom" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td   class="Login2" width="15%">作者:</td>
    <td align="left" class="Login2">
        <asp:TextBox ID="authour" runat="server"></asp:TextBox></td>
  </tr>  
  

  <tr>
    <td   class="Login2" width="15%" style="height: 84px">文章摘要:</td>
    <td align="left" class="Login2" style="height: 84px">
        &nbsp;<asp:TextBox ID="zhaiyao" runat="server" Height="74px" Width="640px" TextMode="MultiLine"></asp:TextBox></td>
  </tr>
  <tr>
    <td   class="Login2" style="height: 404px">
        &nbsp;新闻内容:</td>
    <td align="left" class="Login2" style="height: 404px">
     <asp:TextBox  ID="content"  Height="120px" Width="640px" TextMode="MultiLine" runat="server" ></asp:TextBox>
			<script type="text/javascript">	
                            CKEDITOR.replace( 'ctl00_Conut1_zhaiyao',
	{                filebrowserImageBrowseUrl: '../ckfinder/ckfinder.html?Type=Images',                          
                   
                     filebrowserImageUploadUrl: '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',     
		extraPlugins : 'uicolor',
		toolbar : [   ['Source','Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Image','Link', 'Unlink','-','JustifyLeft','JustifyCenter','JustifyRight','JustifyBlock'] ]
	     
                   
                    
                   }      
	);		
				CKEDITOR.replace( 'ctl00$Conut1$content' ,
                              
                 {      
                     filebrowserBrowseUrl: '../ckfinder/ckfinder.html',      
                     filebrowserImageBrowseUrl: '../ckfinder/ckfinder.html?Type=Images',      
                     filebrowserFlashBrowseUrl: '../ckfinder/ckfinder.html?Type=Flash',      
                     filebrowserUploadUrl: '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',      
                     filebrowserImageUploadUrl: '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',      
                     filebrowserFlashUploadUrl: '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'      
                 }      
                ); 
</script>
    </td>
  </tr>
  <tr>
  <td colspan="2"   class="Login1"  >
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="修改"  class="btn btn-primary" /></td>
  </tr>
</table>
<script type="text/javascript">                
                function BrowseServer(inputId)
                {
                var finder = new CKFinder() ;
                finder.basePath = '../ckfinder/';  //导入CKFinder的路径
                finder.selectActionFunction = SetFileField; //设置文件被选中时的函数
                finder.selectActionData = inputId;  //接收地址的input ID
                finder.popup() ;
                }                
                //文件选中时执行
          function SetFileField( fileUrl )
{	document.getElementById( 'ctl00_Conut1_ximg' ).value = fileUrl;}
            </script>   
</asp:Content>

