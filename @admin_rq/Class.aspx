<%@ Page Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="Class.aspx.cs" Inherits="Class1" Debug="true" %>

<asp:Content ID="Classq" ContentPlaceHolderID=Conut1 runat="server">

<table  class="table" border="0" cellspacing="2" cellpadding="0" align="center">
  <tr>
    <td align="center" class="Login1"  style="height: 27px; width: 152px;">所有分类</td><td class="Login1"  style="height: 27px" colspan="2"> <asp:DropDownList runat="server" ID="ddllm"   ></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="列出子分类" Width="105px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="列出根分类" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="列出所有分类" /></td>
 </tr>
</table>

  
  <asp:DataList ID="Repeater0" runat="server" RepeatColumns="9" GridLines="both">
      <ItemTemplate>&nbsp;&nbsp;&nbsp;<a href="Class.aspx?id=<%#Eval("id") %>"><%#Eval("Class") %></a>&nbsp;&nbsp;&nbsp;</ItemTemplate>
          </asp:DataList>
<table class="table"  border="0" cellspacing="2" cellpadding="0" align="center">
  <tr>
    <td align="center" class="Login1" width="150" style="height: 27px">分类名称</td>
   <!---- <td align="center" class="Login1" style="height: 27px">排序</td>--->
   <td align="center" class="Login1" width="150" style="height: 27px">英文名称</td>
    <td align="center" class="Login1" style="height: 27px">添加时间</td>
    <td align="center" class="Login1" style="height: 27px">删除</td>
     
  </tr>
<asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
  <tr>
    <td align="center" class="Login2" height="25"><%#Eval("Class")%></td>
    <!---<td align="center" class="Login2"><%#Eval("St")%></td>--->
       <td align="center" class="Login2" height="25"><%#Eval("en")%></td>
    <td align="center" class="Login2"><%#Eval("Time")%></td>
    <td align="center" class="Login2">
	<a href="EditClass.aspx?id=<%#Eval("id")%>" class="btn">编辑</a>
    <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('注意！！！请确定此分类下的文章已删除或已经转到其他栏目下?此处不提供同时删除文章，如需要可在“文章管理”栏目完成，以防误操作删除全部文章。');" runat="server" CommandName='<%# Eval("id") %>' OnCommand="DelComm_Click" class="btn">删除</asp:LinkButton>
    </tr>
  </ItemTemplate>
  </asp:Repeater>
</table>
 </asp:Content>
 

