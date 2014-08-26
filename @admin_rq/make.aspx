<%@ Page Language="C#" MasterPageFile="~/@admin_unhr/MasterPage.master" AutoEventWireup="true" CodeFile="make.aspx.cs" Inherits="_Management_ti_make" Title="静态页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" Runat="Server">
     地址：<asp:TextBox ID="Turl" runat="server"></asp:TextBox>
        文件名： <asp:TextBox ID="Tindex" runat="server"></asp:TextBox>
        <asp:Button ID="B_make" runat="server" Text="生成" OnClick="B_make_Click" />&nbsp;<br />
        <br />
        <asp:Button ID="index" runat="server" Text="全站首页" OnClick="index_Click" />

    <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="生成所有栏目" /><br />     
    <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="全站静态页" />
    <asp:Button ID="Button21" runat="server" OnClick="Button21_Click" Text="全站ajax弹窗页面" /><br />
    <asp:Button ID="Button13" runat="server" Text="只更新最近15条" OnClick="Button13_Click" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
		 <Br />
		 <hr>
		 <asp:DropDownList runat="server" ID="ddllm"   AutoPostBack="true"></asp:DropDownList>
		 <asp:Button ID="sc" runat="server" Text="生成" OnClick="sc_Click" />
        
</asp:Content>

