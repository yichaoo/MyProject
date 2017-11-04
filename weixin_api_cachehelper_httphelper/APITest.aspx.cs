using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weixin_testcode
{
    public partial class APITest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                this.txtUrl.Text = "http://localhost:8213/api/jzhs_jggs_xzcf";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string responseResult = "";
            if (ddlMethod.SelectedItem.Value == "GET")
            {
                responseResult = HttpHelper.Get(this.txtUrl.Text.Trim(), "UTF-8", ddlContentType.SelectedValue);//application/xml,application/json
            }
            else
            {
                responseResult = HttpHelper.Post(this.txtUrl.Text.Trim(),txtPostContent.Text.Trim(),"UTF-8");
            }

            this.TextBox1.Text = responseResult;
        }
    }
}