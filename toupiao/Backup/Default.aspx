<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="weixin_testcode._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function getCode() {
            var path = document.getElementById("txtPath").value;
            document.getElementById("imgCode").src="Handler.ashx?path=" + path + "?time=" + Math.random();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        路径:
        <asp:TextBox runat="server" ID="txtPath" Width="600px"></asp:TextBox>
        <input type="button" ID="btnGetCode" value="获取小程序入口二维码图片" onclick="getCode()" />
        <br />
        <img id="imgCode" src="" alt="test" />
    </div>
    &nbsp;</form>
</body>
</html>
