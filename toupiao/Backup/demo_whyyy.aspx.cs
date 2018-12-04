using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weixin_testcode
{
    public partial class demo_whyyy : System.Web.UI.Page
    {
        public string appid = "wx37ea137dca536b64";
        public string secret = "a33fcb902f7599fcf77e869229269b14";
        public string access_token, api_ticket, timestamp, nonceStr, url, signature;
        protected void Page_Load(object sender, EventArgs e)
        {
            access_token = WeXinLib.GetAccessToken(appid, secret);
            api_ticket = WeXinLib.GetWXJSAPITicket(access_token);
            timestamp = WeXinLib.CreateTimeStamp().ToString();
            nonceStr = WeXinLib.CreateNonceStr();
            url = Request.Url.ToString();
            signature = WeXinLib.CreateSignature(api_ticket, nonceStr, timestamp, url);
        }
    }
}