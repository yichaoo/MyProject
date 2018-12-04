using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weixin_testcode
{
    public partial class test_weixin_jsapi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblaccess_token.Text = WeXinLib.GetAccessToken(this.txtAppid.Text.Trim(), this.txtSecret.Text.Trim());
            this.lbljsapi_ticket.Text = WeXinLib.GetWXJSAPITicket(this.lblaccess_token.Text);
            this.lbltimestamp.Text = WeXinLib.CreateTimeStamp().ToString();
            this.lblnonceStr.Text = WeXinLib.CreateNonceStr();
            this.lblurl.Text = Request.Url.ToString();
            this.lblsignature.Text = WeXinLib.CreateSignature(lbljsapi_ticket.Text, lblnonceStr.Text, lbltimestamp.Text, lblurl.Text);
        }

      
    }
}