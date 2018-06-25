using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System;

/// <summary>
/// ** 描述：Http请求通过类,支持POST和GET
/// ** 创始时间：2015-6-8
/// ** 修改时间：2017-6-20
/// ** 作者：lyc
/// </summary>
public class HttpHelper
{
    /// <summary>
    /// 向指定地址发送POST请求
    /// </summary>
    /// <param name="getUrl">指定的网页地址</param>
    /// <param name="postData">POST的数据（格式为：p1=v1&p1=v2）或json格式"{\"path\": \"pages/company_detail/company_detail?ep_id=2\", \"width\": 430}"</param>
    /// <param name="chars_set">可采用如UTF-8,GB2312,GBK等</param>
    /// <returns>页面返回内容字符流,例如json或html类型，application/json、application/xml</returns>
    public static string Post(string postUrl, string postData, string chars_set)
    {
        Encoding encoding = Encoding.GetEncoding(chars_set);
        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(postUrl);
        Request.Method = "POST";
        Request.ContentType = "application/json";//application/json，application/x-www-form-urlencoded
        Request.AllowAutoRedirect = true;
        byte[] postdata = encoding.GetBytes(postData);
        using (Stream newStream = Request.GetRequestStream())
        {
            newStream.Write(postdata, 0, postdata.Length);
        }
        using (HttpWebResponse response = (HttpWebResponse)Request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, encoding, true))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
    /// <summary>
    /// 向指定地址发送POST请求,请求来源为网页中的表单  
    /// </summary>
    /// <param name="getUrl">指定的网页地址</param>
    /// <param name="postData">通过网页表单传的值Request.From</param>
    /// <param name="chars_set">可采用如UTF-8,GB2312,GBK等</param>
    /// <returns>页面返回内容字符流,例如json或html类型，[application/json、application/xml</returns>
    public static string Post(string postUrl, System.Collections.Specialized.NameValueCollection postData, string chars_set)
    {
        Encoding encoding = Encoding.GetEncoding(chars_set);
        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(postUrl);
        Request.Method = "POST";
        Request.ContentType = "application/json";//application/json，application/x-www-form-urlencoded
        Request.AllowAutoRedirect = true;
        byte[] postdata = encoding.GetBytes(ToNameValueString(postData));
        using (Stream newStream = Request.GetRequestStream())
        {
            newStream.Write(postdata, 0, postdata.Length);
        }
        using (HttpWebResponse response = (HttpWebResponse)Request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, encoding, true))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
    /// <summary>
    /// 发送post请求，返回图片二进制数组,页面采用 Response.BinaryWrite(byteStream)方法输出图片
    /// </summary>
    /// <param name="postUrl">请求的URL</param>
    /// <param name="postData">post的数据</param>
    /// <returns></returns>
    public static byte[] PostReturnImgArrary(string postUrl, string postData)
    {
        Encoding encoding = Encoding.GetEncoding("utf-8");
        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(postUrl);
        Request.Method = "POST";
        Request.ContentType = "application/x-www-form-urlencoded";
        Request.AllowAutoRedirect = true;
        byte[] postdata = encoding.GetBytes(postData);
        using (Stream newStream = Request.GetRequestStream())
        {
            newStream.Write(postdata, 0, postdata.Length);
        }
        using (HttpWebResponse response = (HttpWebResponse)Request.GetResponse())
        {
            Stream stream = response.GetResponseStream();
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
    /// <summary>
    /// 想地址发送GET请求
    /// </summary>
    /// <param name="getUrl">地址(格式:http://host/page?p1=v1&p2=v2</param>
    /// <param name="chars_set">可采用如UTF-8,GB2312,GBK等</param>
    /// <returns>页面返回内容</returns>
    public static string Get(string getUrl, string chars_set)
    {
        return Get(getUrl, chars_set, "");
    }


    /// <summary>
    /// 想地址发送GET请求
    /// </summary>
    /// <param name="getUrl">地址(格式:http://host/page?p1=v1&p2=v2</param>)
    /// <param name="chars_set">可采用如UTF-8,GB2312,GBK等</param>
    /// <param name="contentType">请求数据类型</param>
    /// <returns></returns>
    public static string Get(string getUrl, string chars_set, string contentType)
    {
        CookieContainer cookie = new CookieContainer();
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(getUrl);
        myRequest.Method = "GET"; ;
        if (contentType != "")
            myRequest.ContentType = contentType;
        //myRequest.ContentType = "application/x-www-form-urlencoded";//application/x-www-form-urlencoded
        //myRequest.ContentType = "application/xml";
        myRequest.AllowAutoRedirect = true;
        myRequest.CookieContainer = cookie;
        myRequest.Credentials = CredentialCache.DefaultCredentials;
         
        using (HttpWebResponse myresponse = (HttpWebResponse)myRequest.GetResponse())
        {
            myresponse.Cookies = cookie.GetCookies(myRequest.RequestUri);
            using (Stream mystream = myresponse.GetResponseStream())
            {
                using (StreamReader myreader = new StreamReader(mystream, System.Text.Encoding.GetEncoding(chars_set), true))
                {
                    return myreader.ReadToEnd();
                }
            }
        }
    }

    /// <summary>
    /// 将请求的数据保存到指定的文件路径
    /// </summary>
    /// <param name="type">post,get</param>
    /// <param name="requestPath">请求的路径http://xxx.test.com/getfile.aspx</param>
    /// <param name="postData">post的数据</param>
    /// <param name="filePath">d:\dlwonload</param>
    public static void NetRequestToFile(string type, string requestPath, string postData, string filePath)
    {
        System.Net.WebRequest request = System.Net.WebRequest.Create(requestPath);
        Encoding encoding = Encoding.GetEncoding("utf-8");
        if (type.ToUpper() == "POST")
        {
            request.Method = "POST";
            byte[] postdata = encoding.GetBytes(postData);
            using (Stream newStream = request.GetRequestStream())
            {
                newStream.Write(postdata, 0, postdata.Length);
            }
        }
        using (System.Net.WebResponse response = request.GetResponse())
        {
            Stream stream = response.GetResponseStream();
            string fileName = filePath + DateTime.Now.ToString("yyyyMMddhhmmss") + ".";
            if (response.ContentType.IndexOf("image") > -1)
            {
                fileName += response.ContentType.Split('/')[1];
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                MemoryStream ms = new MemoryStream();
                img.Save(fileName);
            }
            else
            {
                fileName += "html";
                StreamReader streamreader = new System.IO.StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8"));
                string content = streamreader.ReadToEnd();
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    sw.WriteLine(content);
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
    /// <summary>
    /// 生成NameValueCollection字符串
    /// 字符串格式如下：p1=v1&p2=v2&p3=v3&p4=v4
    /// </summary>
    /// <param name="data"></param>
    /// <returns>字符串格式如下：p1=v1&p2=v2&p3=v3&p4=v4</returns>
    private static string ToNameValueString(NameValueCollection data)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < data.Count; i++)
        {
            if (i != 0) sb.Append("&");
            sb.Append(data.GetKey(i)).Append("=").Append(data[i]);
        }
        return sb.ToString();
    }
}