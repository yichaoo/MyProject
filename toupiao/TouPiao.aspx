<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TouPiao.aspx.cs" Inherits="weixin_testcode.TouPiao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <h1>
            前包人力投票工具</h1>
    </div>
    <div style="display:none">
        请 求URL:<asp:TextBox runat="server" ID="txtUrl" Width="600px">https://es.hbsrcfwj.cn/toupiaos/fabulous?refresh </asp:TextBox>
        &nbsp;&nbsp;Referer URL:<asp:TextBox runat="server" ID="txtRefererUrl" Width="600px"
            OnTextChanged="txtRefererUrl_TextChanged">https://servicewechat.com/wx8bc74c8a76bdf04f/8/page-frame.html</asp:TextBox>
        &nbsp;&nbsp;
        <br />
    </div>
    <div>
        模拟微信用户数：<asp:DropDownList ID="ddlNum" runat="server" Height="50px" Width="52px" Font-Bold="true" Font-Size="Larger">
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>80</asp:ListItem>
            <asp:ListItem>100</asp:ListItem>
            <asp:ListItem>150</asp:ListItem>
            <asp:ListItem>200</asp:ListItem>
        </asp:DropDownList>
        <br />
        （每个微信用户可投3票，100个用户就是300票)<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" ID="btnSubmit" Text="开始投票" OnClick="btnSubmit_Click" Width="345px"
            Font-Bold="True" Font-Size="Medium" Height="58px" />
        <br />
        请求方式:<asp:DropDownList runat="server" ID="ddlMethod">
            <asp:ListItem Value="GET">GET</asp:ListItem>
            <asp:ListItem Value="POST" Selected="True">POST</asp:ListItem>
        </asp:DropDownList>
        请求数据类型:<asp:DropDownList runat="server" ID="ddlContentType">
            <asp:ListItem Value="application/json">application/json</asp:ListItem>
        </asp:DropDownList>
        <br />
        随机生成：<asp:TextBox ID="txtRandomRequest" 
            runat="server" Height="247px" TextMode="MultiLine"
            Width="493px" Style="margin-right: 0px"></asp:TextBox>
        <asp:TextBox ID="TextBox1" runat="server" Height="244px" TextMode="MultiLine" 
            Width="488px"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        返回内容:
        <asp:TextBox ID="txtResponseContent" runat="server" Height="60px" TextMode="MultiLine"
            Width="978px"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    </div>
    统计数据:</form>
</body>
</html>
