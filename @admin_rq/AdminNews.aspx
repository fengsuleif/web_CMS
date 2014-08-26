<%@ Page Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="AdminNews.aspx.cs" Inherits="Admin_AddNews" %>
<asp:Content ID="AdminNews" ContentPlaceHolderID="Conut1"  runat="server" >
<script type="text/javascript" src="../script/jquery.min.js" ></script>
<script type="text/javascript">
    //根据传入的checkbox的选中状态设置所有checkbox的选中状态
    function selectAll(obj)
    {
        var allInput = document.getElementsByTagName("input");
        //alert(allInput.length);
        var loopTime = allInput.length;
        for(i = 0;i < loopTime;i++)
        {
            //alert(allInput[i].type);
            if(allInput[i].type == "checkbox")
            {
                allInput[i].checked = obj.checked;
            }
        }
    }
	


</script>


<table class="table"  border="0" cellspacing="2" cellpadding="0" align="center">
<tr><td>
<asp:DropDownList runat="server" ID="ddllm"></asp:DropDownList>
 <asp:Button class="btn" ID="Button2" runat="server" Text="按此分类查找" OnClick="Button2_Click"/>
 <asp:HiddenField ID="HiddenField1" runat="server" />
<asp:Button class="btn" ID="Button3" runat="server" OnClick="Button3_Click" Text="显示所有分类" />
<asp:TextBox ID="key_word" runat="server"></asp:TextBox>
<asp:Button class="btn" ID="search" runat="server" Text="搜索" OnClick="search_Click" /></td>

<td>
</td></tr>
 </table>
    
<table  class="table table-condensed table-hover"border="0" cellspacing="2" cellpadding="0" align="center">
  <tr class="info">
    <td align="center" height="25" class="Login1" style="width: 38%">新闻名称</td>
    <td align="center" class="Login1" style="width: 154px">分类</td>  
    <td align="center" class="Login1" style="width: 138px">添加时间</td>
    <td align="center" class="Login1" style="width: 30px">选择</td>
    <td align="center" class="Login1" style="width: 200px">编辑/删除</td>
  </tr>
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
  <tr>
    <td align="left" class="Login2" height="25">&nbsp;&nbsp;<a href="../ajaxview.aspx?id=<%#Eval("id") %>" target="_blank"><%#Eval("Titel") %></a></td>
    <td align="center" class="Login2"><%#Eval("Class") %></td>  
    <td align="center" class="Login2"> <%#Eval("S_img").ToString()%></td>
    <td align="center" class="Login2">  <asp:CheckBox ID="CheckBox1" runat="server" /> 
    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("id") %>' runat="server" /> 
</td>
    <td align="center" class="Login1" ><a href="Eaddnew_ti.aspx?id=<%#Eval("id") %>" class="btn">编辑</a> <asp:LinkButton ID="LinkButton1" CommandName='<%#Eval("id") %>' OnCommand="DelComm_Click" OnClientClick="return confirm('确定要删除吗?');" runat="server" class="btn">删除</asp:LinkButton>
</td>
  </tr>
  </ItemTemplate>
  </asp:Repeater>
</table>
<div class="well well-large">
<asp:CheckBox ID="chk_JS" runat="server" Text="全选(JS)" onclick="selectAll(this)"/> <asp:Button ID="Button1" runat="server" Text="删除" OnClientClick="return confirm('确定删除所选吗?')" OnClick="Del_Click" class="btn"/> 
 
<% if(HiddenField1.Value=="0") Fwrite(this.Mpage);     %>
</div>
</ContentTemplate>
</asp:UpdatePanel> 
</asp:Content>




