<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using Newtonsoft.Json.Linq;

    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            string pathUrl = Request.QueryString.Get("path");
            GetWeixinCodePic(pathUrl, context);

        }
        private void GetWeixinCodePic(string pathUrl, HttpContext context)
        {
            //https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxbd2ffa3449ace6ec&secret=ba4cd0a38f25b5fd301fe9136994ca39
            string getwxacodeUrl = "https://api.weixin.qq.com/wxa/getwxacode?access_token=";
            string wxapp_AppID = "wxbd2ffa3449ace6ec";
            string wxapp_Secret = "ba4cd0a38f25b5fd301fe9136994ca39";
            string wxapp_access_token = weixin_testcode.WeXinLib.GetAccessToken(wxapp_AppID, wxapp_Secret);
            var postDataClass = new
            {
                path = pathUrl,
                width = 430
            };
            //string postData = "{\"path\": \"pages/company_detail/company_detail?ep_id=2\", \"width\": 430}";
            string postData = Newtonsoft.Json.JsonConvert.SerializeObject(postDataClass);

            getwxacodeUrl += wxapp_access_token;
            //Response.Buffer = true;
            //Response.ExpiresAbsolute = System.DateTime.Now.AddMilliseconds(0);
            //Response.Expires = 0;
            //Response.CacheControl = "no-cache";
            //Response.AppendHeader("Pragma", "No-Cache");
            //Response.ClearContent();

            context.Response.ContentType = "image/jpeg";
            byte[] byteStream = HttpHelper.PostReturnImgArrary(getwxacodeUrl, postData);
            //string filePath = "J:\\2017\\weixin_test\\weixin_testcode\\weixin_testcode\\";
            //HttpHelper.NetRequestToFile("post", getwxacodeUrl, postData, filePath);
            context.Response.BinaryWrite(byteStream);
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }