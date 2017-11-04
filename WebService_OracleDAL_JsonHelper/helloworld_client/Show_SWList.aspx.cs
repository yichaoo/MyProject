using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace helloworld_client
{
    public partial class Show_SWList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        public DataTable get_sw_list()
        {
            webservice_helloworld.show_helloworld show_helloworld = new webservice_helloworld.show_helloworld();
            string jsonStr = show_helloworld.getSwlbjk("1");
            //反序列化
            WaterClass waterClassObject = JLcms.Common.JsonHelper.FromJson<WaterClass>(jsonStr);
            DataTable dt_waterinfo = new DataTable();
            dt_waterinfo.Columns.Add("name");
            dt_waterinfo.Columns.Add("water_deep");
            foreach (WaterData w in waterClassObject.data)
            {
                string name = w.DEPARTMENT;
                string water_deep = w.LASTWATERLEVEL;
                DataRow row = dt_waterinfo.NewRow();
                row["name"] = name;
                row["water_deep"] = water_deep;
                dt_waterinfo.Rows.Add(row);
            }
            return dt_waterinfo;
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
    }
}