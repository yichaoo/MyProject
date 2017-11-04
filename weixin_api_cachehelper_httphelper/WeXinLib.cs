using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json.Linq;

using System.Text;
using System.Security.Cryptography;

namespace weixin_testcode
{
    public class WeXinLib
    {
        /// <summary>
        /// 通过微信AppID和Secret获取access_token
        /// </summary>
        /// <param name="AppID">微信appid</param>
        /// <param name="Secret">微信secret</param>
        /// <returns></returns>
        public static string GetAccessToken(string AppID, string Secret)
        {
            string access_token = "";
            int expires_in;
            if (CacheHelper.Get("wxapp_access_token") == null)
            {
                string getUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
                getUrl = String.Format(getUrl, AppID, Secret);
                string result = HttpHelper.Get(getUrl, "utf-8");
                //正常返回的值为json格式{"access_token":"ffixoFw1_y_GhDER-5B-wRiB0-rQfI13VFyxDgDuzLJuQJxKAxDwUQjPt_sviyNsGTpVHABJRF9F2FI6piJH4J8gHzTsF-4PhoF2YH8dxkm3f4ZlaZTdWg7kN9C3WjuZIOBhAIATZM","expires_in":7200}
                JObject objResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result) as JObject;
                if (objResult.HasValues)
                {
                    access_token = objResult["access_token"].ToString();
                    expires_in = (int)objResult["expires_in"];//单位秒
                    CacheHelper.SetCacheDateTime("wxapp_access_token", access_token, expires_in);//微信的token默认返回7200s的缓存时间
                }
            }
            else
                access_token = CacheHelper.Get("wxapp_access_token").ToString();
            return access_token;

        }
        /// <summary>
        /// 通过微信ACCESS_TOKEN获取JsAPI secret
        /// </summary>
        /// <param name="ACCESS_TOKEN">ACCESS_TOKEN</param>
        /// <returns>secret</returns>
        public static string GetWXJSAPITicket(string ACCESS_TOKEN)
        {
            string getUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
            getUrl = String.Format(getUrl, ACCESS_TOKEN);
            string result = HttpHelper.Get(getUrl, "utf-8");
            string ticket = "";
            int expires_in;
            //正常返回的值为json格式
            //成功返回如下JSON：
            //{
            //"errcode":0,
            //"errmsg":"ok",
            //"ticket":"bxLdikRXVbTPdHSM05e5u5sUoXNKd8-41ZO3MhKoyN5OfkWITDGgnr2fwJ0m9E8NYzWKVZvdVtaUgWvsdshFKA",
            //"expires_in":7200
            //}
            if (CacheHelper.Get("wxapp_wxjs_ticket") == null)
            {
                JObject objResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result) as JObject;
                if (objResult.HasValues)
                {
                    ticket = objResult["ticket"].ToString();
                    expires_in = (int)objResult["expires_in"];//单位秒
                    CacheHelper.SetCacheDateTime("wxapp_wxjs_ticket", ticket, expires_in);//微信的token默认返回7200s的缓存时间
                }
            }
            else
                ticket = CacheHelper.Get("wxapp_wxjs_ticket").ToString();
            return ticket;
        }

        /// <summary>
        /// 生成签名的随机串
        /// </summary>
        /// <returns></returns>
        public static string CreateNonceStr()
        {
            string nonce_str = Guid.NewGuid().ToString();
            return nonce_str.Replace("-", "").Substring(0, 16);
        }

        /// <summary>
        /// 生成时间戳
        /// </summary>
        /// <returns></returns>
        public static int CreateTimeStamp()
        {
            return ConvertDateTimeInt(DateTime.Now);
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="jsapi_ticket">ticket</param>
        /// <param name="noncestr">签名随机串</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="url">分享URL</param>
        /// <returns></returns>
        public static string CreateSignature(string jsapi_ticket, string nonce_str, string timestamp, string url)
        {
            string signature = "";
            //注意这里参数名必须全部小写，且必须有序
            string string1 = "jsapi_ticket=" + jsapi_ticket +
                      "&noncestr=" + nonce_str +
                      "&timestamp=" + timestamp +
                      "&url=" + url;
            signature = EncryptToSHA1(string1);
            return signature;
        }

        /// <summary>
        /// 获取由SHA1加密的字符串
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns>密文</returns>
        private static string EncryptToSHA1(string str)
        {
            //System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            //byte[] str1 = System.Text.Encoding.UTF8.GetBytes(str);
            //byte[] str2 = sha1.ComputeHash(str1);
            //sha1.Clear();
            //(sha1 as IDisposable).Dispose();
            //return Convert.ToBase64String(str2);
            return SHA1(str, Encoding.UTF8);
        }
        /// <summary>  
        /// SHA1 加密，返回大写字符串  
        /// </summary>  
        /// <param name="content">需要加密字符串</param>  
        /// <param name="encode">指定加密编码</param>  
        /// <returns>返回40位大写字符串</returns>  
        public static string SHA1(string content, Encoding encode)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);
                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Clear();
                string result = BitConverter.ToString(bytes_out).ToLower();
                result = result.Replace("-", "");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }
        /// <summary>  
        /// Unix时间戳转为C#格式时间  
        /// </summary>  
        /// <param name="timeStamp">Unix时间戳格式,例如1482115779</param>  
        /// <returns>C#格式时间</returns>  
        private static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        /// <summary>  
        /// DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time"> DateTime时间格式</param>  
        /// <returns>Unix时间戳格式</returns>  
        private static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

    }
}