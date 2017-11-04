<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APITest.aspx.cs" Inherits="weixin_testcode.APITest"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        请 求URL:<asp:TextBox runat="server" ID="txtUrl" Width="600px"></asp:TextBox><br />
        请求方式:<asp:DropDownList runat="server" ID="ddlMethod">
            <asp:ListItem Value="GET">GET</asp:ListItem>
            <asp:ListItem Value="POST">POST</asp:ListItem>
        </asp:DropDownList>
        请求数据类型:<asp:DropDownList runat="server" ID="ddlContentType">
            <asp:ListItem Value="application/xml">application/xml</asp:ListItem>
            <asp:ListItem Value="application/json">application/json</asp:ListItem>
        </asp:DropDownList>
        <br />
        发送内容 <asp:TextBox ID="txtPostContent" runat="server" Height="125px" TextMode="MultiLine" Width="488px"></asp:TextBox>
        <br />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button runat="server" ID="btnSubmit" Text="提交" OnClick="btnSubmit_Click" Width="200px" />
        <br />
    </div>
    返回内容：
    <asp:TextBox ID="TextBox1" runat="server" Height="295px" TextMode="MultiLine" Width="488px"></asp:TextBox>
    </form>
</body>
</html>
