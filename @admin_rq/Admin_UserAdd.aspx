<%@ Page Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="Admin_UserAdd.aspx.cs" Inherits="Admin_UserAdd" %>
<asp:Content ID="Admin_UserAd" ContentPlaceHolderID="Conut1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
  
<table  class="table" cellspacing="2" cellpadding="0"> 
 
  <tr>
    <td class="Login2">
    <table class="table" cellspacing="2" cellpadding="0" >
   
  <tr class="info">
    <td colspan="2" class="Login1" height="25" align="left"><div align="left">添加用户</div></td>
    </tr>
  <tr>
    <td width="30%" align="right" class="Login2">用户名称:</td>
    <td class="Login2"><asp:TextBox ID="TextBox1"  runat="server"/></td>
  </tr>
  <tr>
    <td align="right" class="Login2">用户密码:</td>
    <td class="Login2"><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"/></td>
  </tr>
  <tr>
    <td align="right" class="Login2">确认密码:</td>
    <td class="Login2"><asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right" class="Login2">
        用户密匙:</td>
    <td class="Login2"><asp:TextBox ID="TextBox4" runat="server" TextMode="Password"/></td>
  </tr>
  <tr>
    <td align="right" class="Login2">确认密匙:</td>
    <td class="Login2"><asp:TextBox ID="TextBox5"  runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td colspan="2" class="Login1" height="25"><asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" class="btn"/></td>
  </tr>
 
</table>
 <br />


<br />
<table  class="table" cellspacing="2" cellpadding="0" align="center" >
<tr>
    <td colspan="5" class="Login1" height="25" align="left"><div align="left">用户管理</div></td>
    </tr>
  <tr>
    <td align="center" class="Login2" height="25" width="150">帐户</td>
    <td align="center" class="Login2">密码</td>
    <td align="center" class="Login2">添加时间</td>
      <td align="center" class="Login2">修改</td>
    <td align="center" class="Login2">删除</td>
    
  </tr>
<asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
  <tr>
    <td align="center" class="Login2" height="25"><%#Eval("UserAdmin") %></td>
    <td align="center" class="Login2">********************</td>
    <td align="center" class="Login2"><%#Eval("Time")%></td>
    <td align="center" class="Login2">
     <asp:LinkButton ID="xiugai" CommandName='<%#Eval("id") %>' runat="server" Text="修改" OnCommand="xiugai_Click"  class="btn"/></td>
    <td align="center" class="Login2">
    <asp:LinkButton ID="LinkButton1" CommandName='<%#Eval("id") %>' OnCommand="DelComm_Click" OnClientClick="return confirm('确定要删除吗?');" runat="server" class="btn">删除</asp:LinkButton></td>
    </tr>
  </ItemTemplate>
  </asp:Repeater>
</table>
     
    </td>
     </tr>
     </table>
   
   
<asp:Panel ID="Panel1" runat="server" Height="150px" Width="125px" Visible="false">
  
<table width="775" border="0" cellspacing="2" cellpadding="0" align="center" >
<tr>
    <td colspan="4" class="Login1" height="25" align="left"><div align="left">修改密码<asp:HiddenField ID="HiddenField1" runat="server" />
    </div></td>
    </tr>
<tr>
<td style="width: 115px">用户：</td><td style="width: 170px">
    <asp:TextBox ID="u_user" runat="server"></asp:TextBox></td><td>密匙：</td><td>
        <asp:TextBox ID="p_pass" runat="server"></asp:TextBox></td></tr>
        <tr>
<td style="width: 115px">新密码：</td><td style="width: 170px">
    <asp:TextBox ID="p_npass" runat="server" TextMode="Password" Width="149px"></asp:TextBox></td><td>确认新密码</td><td>
        <asp:TextBox ID="p_npass2" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td></tr>
        <tr>
<td style="width: 100%; height: 24px;" colspan="4" align="center">
    <asp:Button ID="Button3" runat="server" Text="确定" OnClick="Button3_Click" /></td></tr>
    <tr><td colspan="4">&nbsp;</td></tr>
</table>
  </asp:Panel>

</asp:Content>
