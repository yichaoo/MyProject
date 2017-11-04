using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Data;

namespace helloworld
{
    /// <summary>
    /// show_helloworld 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class show_helloworld : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string name)
        {
            return "";
        }
        [WebMethod]
        public string getSwlbjk(string zzjgdm)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("{");
            //sb.AppendLine("    \"count\": 8,");
            //sb.AppendLine("    \"data\": [{");
            //sb.AppendLine("        \"ID\": \"ade4b913a9e343a2b80a648fabb7f7a6\",");
            //sb.AppendLine("        \"WATERSTATIONNAME\": \"大沙\",");
            //sb.AppendLine("        \"WATERSTATIONX\": \"113.82319167\",");
            //sb.AppendLine("        \"WATERSTATIONY\": \"29.92717222\",");
            //sb.AppendLine("        \"TERSERIESNUMBER\": \"13147169851\",");
            //sb.AppendLine("        \"XTYPE\": \"水位站\",");
            //sb.AppendLine("        \"ALARMTYPE\": \"1393\",");
            //sb.AppendLine("        \"DEPARTMENT\": \"32\",");
            //sb.AppendLine("        \"LASTWATERLEVEL\": \"2202\",");
            //sb.AppendLine("        \"TERVOLTAGE\": \"0\"");
            //sb.AppendLine("    }, {");
            //sb.AppendLine("        \"ID\": \"cee570bd5c6d4dd6a8934617b4528c66\",");
            //sb.AppendLine("        \"WATERSTATIONNAME\": \"水洪口\",");
            //sb.AppendLine("        \"WATERSTATIONX\": \"113.87673889\",");
            //sb.AppendLine("        \"WATERSTATIONY\": \"30.07334444\",");
            //sb.AppendLine("        \"TERSERIESNUMBER\": \"13147170672\",");
            //sb.AppendLine("        \"XTYPE\": \"水位站\",");
            //sb.AppendLine("        \"ALARMTYPE\": \"1420\",");
            //sb.AppendLine("        \"DEPARTMENT\": \"312\",");
            //sb.AppendLine("        \"LASTWATERLEVEL\": \"0\",");
            //sb.AppendLine("        \"TERVOLTAGE\": \"0\"");
            //sb.AppendLine("    }],");
            //sb.AppendLine("    \"success\": true,");
            //sb.AppendLine("    \"message\": \"成功\"");
            //sb.AppendLine("}");          


            DataTable dt = JLcms.DBUtility.DbHelperOra.Query("select * from sw_list").Tables[0];
            sb.AppendLine("{");
            sb.AppendLine("    \"count\": "+dt.Rows.Count+",");
            sb.AppendLine("    \"data\": ");
            string jsonData = JLcms.Common.JsonHelper.DataTableToJson(dt);
            sb.AppendLine(jsonData);
            sb.AppendLine(",");
            sb.AppendLine("    \"success\": true,");
            sb.AppendLine("    \"message\": \"成功\"");
            sb.AppendLine("}");
            return sb.ToString();
        }
        [WebMethod]
        public string TestData()
        {
            var anonymous = new
            {
                count = 0,
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
                success = false,
                message = ""
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(anonymous);
        }
    }
}
