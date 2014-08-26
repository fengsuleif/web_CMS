<%@ Page Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="EditClass.aspx.cs" Inherits="EditClass" Debug="true" %>

<asp:Content ID="EditClasss" ContentPlaceHolderID="Conut1" runat="server">
<script LANGUAGE="javascript"> 
<!-- 
function openwin(){ 
window.open("upload.aspx","newwindow","height=400,width=600,toolbar=no,menubar=no,scrollbars=no,resizable=no, location=no,status=no") ;
//写成一行 
} 
--> 
</script>      
<table width="775" border="0" cellspacing="2" cellpadding="0"  align="center">

<tr>
    <td align="center" class="Login1" height="25">修改成一级分类</td>
  </tr>
  <tr>
    <td align="center" class="Login2">分类名称: <asp:TextBox ID="TextBoxFclass" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="center" class="Login2">英文名称: <asp:TextBox ID="Fen" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="center" class="Login2">排列顺序: <asp:TextBox ID="TextBoxFst" runat="server"></asp:TextBox></td>
  </tr>
   <tr>
    <td align="center" class="Login2">文件链接: <asp:TextBox ID="durl" runat="server"></asp:TextBox><a href="#" onclick="openwin()">上传文件</a> </td>
  </tr>
   <tr>
    <td align="center" class="Login2">分类介绍: <asp:TextBox ID="summary" runat="server" TextMode="MultiLine" Rows="5" Columns="20"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="center" class="Login2"><asp:Button ID="Buttonf" runat="server" Text="更新" OnClick="Buttonf_Click" /> <input id="Reset2" type="reset" value="清空" /></td>
  </tr>
  <tr>
    <td align="center" class="Login1" height="25">编辑子分类</td>
  </tr>
  <tr>
    <td align="center" class="Login2">分类名称: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
   <td align="center" class="Login2">以上分类隶属于:    
   <asp:DropDownList runat="server" ID="ddllm"   AutoPostBack="true"></asp:DropDownList></td>
    
        <asp:HiddenField ID="HiddenField1" runat="server" />
  </tr>
  <tr>
    <td align="center" class="Login2">英文名称: <asp:TextBox ID="Ten" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="center" class="Login2" >排列顺序: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
  </tr>
  
    
    
  <tr>
    <td align="center" class="Login2"><asp:Button ID="Button1" runat="server" Text="更新" OnClick="Button1_Click" /> <input id="Reset1" type="reset" value="清空" /></td>
  </tr>
</table>
</asp:Content>

