<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo_whyyy.aspx.cs" Inherits="weixin_testcode.demo_whyyy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>武汉一医院分享文章demo</title>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://wap.whyyy.com/templates/main/m_file/css/common.css" />
    <link href="js/share.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="js/jquery.share.min.js" type="text/javascript"></script>
    <script type="text/javascript">
    /*
    * 注意：
    * 1. 所有的JS接口只能在公众号绑定的域名下调用，公众号开发者需要先登录微信公众平台进入“公众号设置”的“功能设置”里填写“JS接口安全域名”。
    * 2. 如果发现在 Android 不能分享自定义内容，请到官网下载最新的包覆盖安装，Android 自定义分享接口需升级至 6.0.2.58 版本及以上。
    * 3. 常见问题及完整 JS-SDK 文档地址：http://mp.weixin.qq.com/wiki/7/aaa137b55fb2e0456bf8dd9148dd613f.html
    *
    * 开发中遇到问题详见文档“附录5-常见错误及解决办法”解决，如仍未能解决可通过以下渠道反馈：
    * 邮箱地址：weixin-open@qq.com
    * 邮件主题：【微信JS-SDK反馈】具体问题
    * 邮件内容说明：用简明的语言描述问题所在，并交代清楚遇到该问题的场景，可附上截屏图片，微信团队会尽快处理你的反馈。
    */
    wx.config({
        debug: false,// true为开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        appId: '<%=appid%>', // 必填，公众号的唯一标识
        timestamp: <%=timestamp%>,// 必填，生成签名的时间戳
        nonceStr: '<%=nonceStr%>',// 必填，生成签名的随机串
        signature: '<%=signature%>',// 必填，签名，见附录1
        jsApiList: [ // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        'onMenuShareTimeline',
        'onMenuShareAppMessage'
      ]
    });
    wx.ready(function () {
       wx.onMenuShareTimeline({
            title: '李忠副市长检查市一医院国庆中秋节前安全工作',// 分享标题
            desc: '9月28日上午，武汉市人民政府副市长李忠、副秘书长席丹率市城管委、城建委、卫计委、市安监局、市公安消防局等部门负责人来到武汉市第一医院，检查该院国庆中秋节前安全工作。市一医院院长张红星、党委书记王卫民及相关部门负责人陪同检查。',// 分享描述
            link: 'http://wxtest.xxhjs.com/demo_whyyy.aspx?from=singlemessage&isappinstalled=0',// 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
            imgUrl: 'http://wap.whyyy.com/upload/20170928/3201709281251182760.jpg', // 分享缩略图
            trigger: function (res) {
                // 不要尝试在trigger中使用ajax异步请求修改本次分享的内容，因为客户端分享操作是一个同步操作，这时候使用ajax的回包会还没有返回
               // alert('用户点击发送给朋友');
            },
            success: function (res) {
               // alert('已分享');
            },
            cancel: function (res) {
              //  alert('已取消');
            },
            fail: function (res) {
               // alert(JSON.stringify(res));
            }
        });
  
        wx.onMenuShareAppMessage({
                title: '李忠副市长检查市一医院国庆中秋节前安全工作',// 分享标题
            desc: '9月28日上午，武汉市人民政府副市长李忠、副秘书长席丹率市城管委、城建委、卫计委、市安监局、市公安消防局等部门负责人来到武汉市第一医院，检查该院国庆中秋节前安全工作。市一医院院长张红星、党委书记王卫民及相关部门负责人陪同检查。',// 分享描述
            link: 'http://wxtest.xxhjs.com/demo_whyyy.aspx?from=singlemessage&isappinstalled=0',// 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
            imgUrl: 'http://wap.whyyy.com/upload/20170928/3201709281251182760.jpg', // 分享缩略图
            trigger: function (res) {
                // 不要尝试在trigger中使用ajax异步请求修改本次分享的内容，因为客户端分享操作是一个同步操作，这时候使用ajax的回包会还没有返回
               // alert('用户点击发送给朋友');
            },
            success: function (res) {
               // alert('已分享');
            },
            cancel: function (res) {
              //  alert('已取消');
            },
            fail: function (res) {
               // alert(JSON.stringify(res));
            }
        });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="cont_article">
        <div class="article_title">
            <h3>
                李忠副市长检查市一医院国庆中秋节前安全工作</h3>
            <h4>
                <span>发布人：胡剑明（院办）</span> <span>审核人：胡剑明</span> <span>发布时间：2017-09-28</span> <a href="weixin://profile/gh_34bd692a9835"
                    target="_blank" style="font-size: xx-large">点击跳转到微信公众号（weixin://profile/gh_34bd692a9835）</a><br /> <a href="http://weixin.qq.com/r/0EP743rEKidVrT6A9xbC"
                        style="font-size: xx-large" target="_blank">点击跳转到二维码微信预约挂号（微信二维码http://weixin.qq.com/r/0EP743rEKidVrT6A9xbC）</a><br /><a href="http://mp.weixin.qq.com/s/AkY2LpLQc_P6LbCyxQjB4A"
                        style="font-size: xx-large" target="_blank">点击跳转到跳转到微信文章（http://mp.weixin.qq.com/s/AkY2LpLQc_P6LbCyxQjB4A）</a>
            </h4>
        </div>
        <div class="article_cont">
            <p style="text-indent: 2em;">
                9月28日上午，武汉市人民政府副市长李忠、副秘书长席丹率市城管委、城建委、卫计委、市安监局、市公安消防局等部门负责人来到武汉市第一医院，检查该院国庆中秋节前安全工作。市一医院院长张红星、党委书记王卫民及相关部门负责人陪同检查。
            </p>
            <p style="text-indent: 2em;">
                在市一医院，李忠副市长首先听取了市一医院张红星院长关于节前安全方面工作情况的汇报。紧接着，一行前往了医院监控中心、微型消防站、锅炉房等重点部位进行实地查看。每到一处，李忠副市长认真聆听了相关工作人员的情况介绍，并详细询问了医院在消防、保卫、安全生产等方面所采取的具体措施和落实情况。李忠副市长对市一医院在节前安全方面所做的工作给予了充分肯定，并提出了具体要求。
            </p>
            <p style="text-indent: 2em;">
                他指出，医院一是要清醒认识当前形势，时刻绷紧安全这根弦，从国庆、中秋到党的十九大胜利召开期间，积极组织全院再动员、再部署、再落实，全面贯彻好国家和省、市各级各项安全工作要求。二是要持续开展安全隐患排查，对核心部位、重点部位坚持开展横向到边、纵向到底排查工作，及时发现问题解决问题，不留死角和盲区，坚决防止和杜绝安全隐患及各类事故的发生。
            </p>
            <p style="text-indent: 2em;">
                <br />
            </p>
            <p style="text-indent: 2em;">
                随后，李忠副市长还到医院骨科病区，实地检验了病区医务人员消防应急水平、消防设施运行、安全标识设置、应急疏散通道等情况。最后，他强调安全责任重于泰山，医院要时刻把安全工作放在第一位，节日期间各部门要坚守岗位，切实履职，做到守土有责，守土尽责，失土追责，在为老百姓提供安全、优质的医疗服务的同时，切实保障国家财产和人民群众生命安全。<img
                    src="http://wap.whyyy.com/upload/20170928/3201709281251182760.jpg" title="3.jpg"
                    alt="3.jpg" /><img src="http://wap.whyyy.com//upload/20170928/2201709281251408592.jpg"
                        title="2.jpg" alt="2.jpg" /><img src="http://wap.whyyy.com/upload/20170928/1201709281251294546.jpg"
                            title="1.jpg" alt="1.jpg" />
            </p>
        </div>
    </div>
    <div class="article_bot clearfix">
        <div class="left">
            来源：本站</div>
        <ol>
            <li class="row">
                <div id="share-1">
                </div>
            </li>
            <li class="row">
                <div id="share-2">
                </div>
            </li>
            <li class="row">
                <div id="share-3" data-sites="weibo,qq,qzone,tencent">
                </div>
            </li>
            <li class="row">
                <div id="share-4" data-disabled="wechat , facebook, twitter, google">
                </div>
            </li>
        </ol>
    </form>
    <script>
     
    </script>
</body>
</html>
