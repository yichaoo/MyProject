using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

namespace ADServices
{
    public partial class GetWinUserServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";

            string DomianName = Environment.UserDomainName;
            string Username = Environment.UserName;
            string ADDomian = System.Configuration.ConfigurationManager.AppSettings["ADDomain"].ToString();
            Response.Write("UserDomainName\\UserName:" + Environment.UserDomainName + "\\" + Environment.UserName + "<br/>");
            if (Environment.UserDomainName.ToLower() != ADDomian.ToLower())
            {
                Response.Write("当前windows登陆账号不是域" + ADDomian + "账号");
            }
            else
            {
                Response.Write("当前windows登陆账号是" + Username + "账号");
                //跳转到OA系统
                Response.Redirect("http://oa.jl.com/index.aspx?user="+GetMd5Hash(Username));
            }
   
        }

#region 单向加密算法
        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        public string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
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
#endregion 单向加密算法
    }

    
}