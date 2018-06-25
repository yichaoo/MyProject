using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Threading;

namespace ADServices
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";

            Response.Write("UserDomainName\\UserName:" + Environment.UserDomainName + "\\" + Environment.UserName + "<br/>");

            WindowsPrincipal winPrincipal = (WindowsPrincipal)HttpContext.Current.User;
            Response.Write(string.Format("HttpContext.Current.User.Identity: {0}, {1}<br/>",
                    winPrincipal.Identity.AuthenticationType, winPrincipal.Identity.Name));

            WindowsPrincipal winPrincipal2 = (WindowsPrincipal)Thread.CurrentPrincipal;
            Response.Write(string.Format("Thread.CurrentPrincipal.Identity: {0}, {1}<br/>",
                    winPrincipal2.Identity.AuthenticationType, winPrincipal2.Identity.Name));

            WindowsIdentity winId = WindowsIdentity.GetCurrent();
            Response.Write(string.Format("WindowsIdentity.GetCurrent(): {0}, {1}",
                    winId.AuthenticationType, winId.Name));
            Response.Write(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
            string hostUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            hostUrl = hostUrl + "/GetWinUserServer.aspx";

           //string hostUrl = System.Configuration.ConfigurationManager.AppSettings["WebServerURL"].ToString();
           // //Response.Write(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path));
           // //Response.Write(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Query));
           // //Response.Write(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Scheme));
           // Response.Write(HttpHelper.Get(hostUrl, "utf-8"));

        }
    }
}