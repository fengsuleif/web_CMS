<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ajax.cs" Inherits="newview" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>人权捍卫者</title>
<link type="text/css" rel="stylesheet" href="./source_files/css_annzq1por5zLXwLbd5-vpftJX919s8C1XDTGtqa5vGk.css" media="all">
</head>

<body style="background: #dcddde;font-size:13px;padding:10px; text-align:center;">


  <asp:Repeater ID="newslist" runat="server">
        <ItemTemplate>  
<h2 ><A href="#"><%#Eval("Titel")%></A></h2>

   
 <div style="font-size:14px;padding:10px; text-align:left;"><%#rp(Eval("AltView").ToString()) %>  </div>

</ItemTemplate>
        </asp:Repeater>

</body>
</html>