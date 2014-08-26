<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="Chapter84_Default5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>文件上传</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h4>支持上传文件类型有jpg，gif，png，rar，zip，doc，pdf。</h4>
        <asp:FileUpload ID="myFile" runat="server" Width="400px" />
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上传" /></div>
    </form>
</body>
</html>
