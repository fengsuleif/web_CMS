<%@Page Language="C#"   AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Debug="true"  %>
<%@   OutputCache   Duration="1"   VaryByParam="none"   %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理登陆</title>
    <link href="style.Css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server">
    
    
    
    <table align="center" width="100%" height="100%">
    <tr><td ><br>
      <br><br>
        <br><br><br><br><br><br><br><div>
	<table width="755" height="350" border="0" align="center" cellpadding="0" cellspacing="2" background="../images/login.jpg">
  <tr>
    <td colspan="2" height="25"><br><br><br><br><br><br><br><br><br><br /></td>
    </tr>
  <tr>
    <td  align="right" width="45%">管理帐号: </td>
    <td width="55%" ><asp:TextBox ID="Uid" runat="server"/></td>
  </tr>
  <tr>
    <td  align="right">管理密码: </td>
    <td ><asp:TextBox ID="Pwd" runat="server" TextMode="Password"/></td>
  </tr>
 
  <tr>
    <td align="right">密匙: </td>
    <td ><asp:TextBox ID="Mpw" runat="server" TextMode="Password"/></td>
  </tr>
  <tr>
    <td colspan="2" height="25"><br><br><br></td>
    </tr>
  <tr>
    <td colspan="2" align="center"><asp:Button ID="Button1" runat="server" Text="登陆" OnClick="Button1_Click" />
	&nbsp;<input id="Reset1" type="reset" value="重置" /></td>
    </tr>
    <tr>
    <td colspan="2" height="25"></td>
    </tr>
  <tr>
</table>
 </div></td></tr></table>
    
    
    
    
    </form>
</body>
</html>
