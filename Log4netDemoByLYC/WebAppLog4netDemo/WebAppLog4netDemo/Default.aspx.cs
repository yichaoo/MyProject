using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLog4netDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogHelper.log.Debug("Debug:测试WEB");
            LogHelper.log.Info("Info:测试WEB");
            LogHelper.log.Error("Error:测试WEB");
            try
            {
                string str1 = "teststr111";
                int a = Convert.ToInt32(str1);
            }
            catch (Exception exce)
            {
                LogHelper.log.Error("WEB程序报错了", exce);
            }
        }
    }
}