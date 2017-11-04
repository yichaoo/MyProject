using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace JLcms.Common
{
    public class JsonToDataTable
    {
        /// <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public DataTable JsonFormatDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",", "*").Replace("\":\"", "\"#\"").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));
            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');
                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = "DataTableInfor";
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');
                        if (strCell[0].Trim().Substring(0, 1) == "\"")  //第一个字母为符号
                        {
                            int a = strCell[0].Trim().Length;

                            if (strCell[0].Trim().Substring(a - 1,1) == "\"")   //最后一个字母为符号
                            {
                                dc.ColumnName = strCell[0].Trim().Substring(1, a -2 );
                            }
                            else
                            {
                                dc.ColumnName = strCell[0].Trim();
                            }
                        }
                        else
                        {
                            dc.ColumnName = strCell[0].Trim();
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }
                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
        }
    }
}
