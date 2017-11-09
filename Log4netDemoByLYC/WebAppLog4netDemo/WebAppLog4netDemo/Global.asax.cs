using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebAppLog4netDemo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {      
              // 在出现未处理的错误时运行的代码
            Exception objExp = HttpContext.Current.Server.GetLastError();
            LogHelper.log.Error("<br/><strong>客户机IP</strong>：" + Request.UserHostAddress + "<br /><strong>错误地址</strong>：" + Request.Url , objExp);
            
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}