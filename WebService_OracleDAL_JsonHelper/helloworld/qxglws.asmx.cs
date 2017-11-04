using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Text;

namespace helloworld
{
    /// <summary>
    /// qxglws 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class qxglws : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string getSwlbjk()
        //{
        //    return "Hello World";
        //}
        [WebMethod]
        public string GetSWList()
        {
            //取数据 
            StringBuilder sb = new StringBuilder();
            DataTable dt = JLcms.DBUtility.DbHelperOra.Query("select * from sw_list").Tables[0];
            sb.Append("{\"count\":" + dt.Rows.Count + ",\"data\":");
            //序列化
            string result = JLcms.Common.JsonHelper.DataTableToJson(dt);
            sb.Append(result);
            sb.Append(",\"success\":true,\"message\":\"成功\"}");

            //  string demoStr1 = "{\"count\":\"8\",\"success\":\"true\",\"message\":\"成功\"}";
            return sb.ToString();
        }

        public class SW_Test
        {
            public string count { get; set; }
            public string success { get; set; }
            public List<SW> data { get; set; }
            public string message { get; set; }
        }
        public class SW
        {
            public string id { get; set; }
            public string WATERSTATIONNAME { get; set; }
            public string WATERSTATIONX { get; set; }
            public string WATERSTATIONY { get; set; }
            public string TERSERIESNUMBER { get; set; }
        }
        public string WaterTestData()
        {
            SW swObject = new SW();
            swObject.id = "sf23423423423";
            swObject.WATERSTATIONNAME = "大沙";
            swObject.WATERSTATIONX = "113.82319167";
            swObject.WATERSTATIONY = "29.92717222";
            swObject.TERSERIESNUMBER = "32";
            return Newtonsoft.Json.JsonConvert.SerializeObject(swObject);


            var anonymous = new
            {
                count = "0",
                data = new[] {new {
                 id = "ade4b913a9e343a2b80a648fabb7f7a6",
                 WATERSTATIONNAME = "大沙",
                 WATERSTATIONX = "113.82319167",
                 WATERSTATIONY = "29.92717222",
                 TERSERIESNUMBER = "13147169851",
                 XTYPE = "水位站",
                 ALARMTYPE = "1393",
                 DEPARTMENT = "32",
                 LASTWATERLEVEL = "2202",
                 TERVOLTAGE = "0"
             },new {
                 id = "ade4b913a9e343a2b80a648fabb7f7a6",
                 WATERSTATIONNAME = "大沙",
                 WATERSTATIONX = "113.82319167",
                 WATERSTATIONY = "29.92717222",
                 TERSERIESNUMBER = "13147169851",
                 XTYPE = "水位站",
                 ALARMTYPE = "1393",
                 DEPARTMENT = "32",
                 LASTWATERLEVEL = "2202",
                 TERVOLTAGE = "0"
             } },
                success = "false",
                message = ""
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(anonymous);
        }
    }
}
