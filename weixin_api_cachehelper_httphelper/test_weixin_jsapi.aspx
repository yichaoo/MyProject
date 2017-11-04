<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test_weixin_jsapi.aspx.cs"
    Inherits="weixin_testcode.test_weixin_jsapi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        appid：<asp:TextBox ID="txtAppid" runat="server" Width="300px">wx37ea137dca536b64</asp:TextBox><br />
        appsecret：:<asp:TextBox Width="300px" ID="txtSecret" runat="server">a33fcb902f7599fcf77e869229269b14</asp:TextBox><br />
        access_token :<asp:Label ID="lblaccess_token" runat="server"></asp:Label><br />
        jsapi_ticket:<asp:Label ID="lbljsapi_ticket" runat="server"></asp:Label><br />
        nonceStr:<asp:Label ID="lblnonceStr" runat="server"></asp:Label><br />
        timestamp:<asp:Label ID="lbltimestamp" runat="server"></asp:Label><br />
        url:<asp:Label ID="lblurl" runat="server"></asp:Label><br />
        signature:<asp:Label ID="lblsignature" runat="server"></asp:Label><br />
        <a href="/demo_whyyy.aspx?from=singlemessage&isappinstalled=0" target="_blank">点击跳转新闻分享页</a>
        <asp:Button runat="server" ID="btnSubmit" Text="生成" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
