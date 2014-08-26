<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dirfile.aspx.cs" Inherits="_admin_rq_dirfile" MasterPageFile="./MasterPage.master"  %>
<asp:Content ID="Mainx" ContentPlaceHolderID="Conut1" runat="server">
 <script LANGUAGE="javascript"> 
<!--
     function openwin() {
         window.open("upload.aspx", "newwindow", "height=400,width=600,toolbar=no,menubar=no,scrollbars=no,resizable=no, location=no,status=no");
         //写成一行 
     } 
--> 
</script>  
    <div class="hero-unit"> 
    <a href="#" onclick="openwin()" class="btn"><i class=" icon-upload"></i>上传文件</a>
    <hr />
    <%getdir("~/upload");
    
        %>
      
    </div>

</asp:Content>