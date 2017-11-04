using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace helloworld_client
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            webservice_helloworld.show_helloworld show_hello = new webservice_helloworld.show_helloworld();
            string from_service_str = show_hello.HelloWorld("褚博凡");
            Response.Write(from_service_str);
            Response.Write(JsonToDataTable2());
            JsonToDataTable1();

        }
        public DataTable JsonToDataTable1()
        {
            WaterClass water = new WaterClass();
            DataTable dt = new DataTable();
            dt.Columns.Add("wx");
            dt.Columns.Add("lastWaterLevel");
            water = Newtonsoft.Json.JsonConvert.DeserializeObject<WaterClass>(JsonToDataTable2());
            var water_info = new
             {
                 id = "",
                 WATERSTATIONNAME = "",
                 WATERSTATIONX = "",
                 WATERSTATIONY = "",
                 TERSERIESNUMBER = "",
                 XTYPE = "",
                 ALARMTYPE = "",
                 DEPARTMENT = "",
                 LASTWATERLEVEL = "",
                 TERVOLTAGE = ""
             };
            // var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 } };
            var anonymous = new
            {
                count = 0,
                data = new[] {new {
                 id = "",
                 WATERSTATIONNAME = "",
                 WATERSTATIONX = "",
                 WATERSTATIONY = "",
                 TERSERIESNUMBER = "",
                 XTYPE = "",
                 ALARMTYPE = "",
                 DEPARTMENT = "",
                 LASTWATERLEVEL = "",
                 TERVOLTAGE = ""
             } },
                success = false,
                message = ""
            };

            //IEnumerator e = anonymous.data.GetEnumerator();

            var o = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(JsonToDataTable2(), anonymous);
            string s = o.data[0].ALARMTYPE;

            foreach (WaterData w in water.data)
            {
                DataRow row = dt.NewRow();
                row["wx"] = water.data[0].WATERSTATIONNAME;
                row["lastWaterLevel"] = water.data[0].DEPARTMENT;
                dt.Rows.Add(row);
                dt.AcceptChanges();
            }
            foreach (var w in anonymous.data)
            {
                DataRow row = dt.NewRow();
                row["wx"] = water.data[0].WATERSTATIONNAME;
                dt.Rows.Add(row);
            }
            JLcms.Common.JsonToDataTable jtd = new JLcms.Common.JsonToDataTable();
            DataTable tempTbl = jtd.JsonFormatDataTable(JsonToDataTable2());
            //WaterTestList testList = new WaterTestList();
            //foreach (WaterData w in testList)
            //{
            //    //w.ALARMTYPE
            //}
            return dt;

        }
        public string JsonToDataTable2()
        {
            DataTable dt = new DataTable();
            webservice_helloworld.show_helloworld show_hello = new webservice_helloworld.show_helloworld();
            //return show_hello.getSwlbjk("11");
            return show_hello.TestData();

        }

    }

    [Serializable] 
    public class WaterClass
    {
        public int count { get; set; }
        public List<WaterData> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
    [Serializable] 
    public class WaterData
    {
        public string ID { get; set; }
        public string WATERSTATIONNAME { get; set; }
        public string WATERSTATIONX { get; set; }
        public string WATERSTATIONY { get; set; }
        public string TERSERIESNUMBER { get; set; }
        public string XTYPE { get; set; }
        public string ALARMTYPE { get; set; }
        public string DEPARTMENT { get; set; }
        public string LASTWATERLEVEL { get; set; }
        public string TERVOLTAGE { get; set; }
    }
    //public class WaterTestList : IEnumerable
    //{
    //    WaterData[] waterDataArray = new WaterData[4];  //在Garage中定义一个Car类型的数组carArray,其实carArray在这里的本质是一个数组字段  

    //    //启动时填充一些Car对象  
    //    public WaterTestList()
    //    {
    //        //为数组字段赋值  
    //        waterDataArray[0] = new WaterData();
    //        waterDataArray[1] = new WaterData();
    //        waterDataArray[2] = new WaterData();
    //        waterDataArray[3] = new WaterData();
    //    }
    //    public IEnumerator GetEnumerator()
    //    {
    //        return this.waterDataArray.GetEnumerator();
    //    }
    //}
}