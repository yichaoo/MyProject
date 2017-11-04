using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace JLcms.Common
{
    public class FormatToJson
    {
        #region 为easyUI生成的json数据
        /// <summary>
        /// 专门生成为EasyUI生成json数据(List->json)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static string EasyUIListToJson<T>(IList<T> list, int total)
        {
            StringBuilder Json = new StringBuilder();
            Json.AppendLine("{\"total\":" + total + ",");
            Json.Append("\"rows\":[");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    PropertyInfo[] pi = obj.GetType().GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pi.Length; j++)
                    {
                        Type type = pi[j].GetValue(list[i], null).GetType();
                        Json.Append("\"" + pi[j].Name.ToString() + "\":" + StringFormat(pi[j].GetValue(list[i], null).ToString(), type));

                        if (j < pi.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < list.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();

        }
        /// <summary>
        /// 专门生成为DataGrid的json数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="jsonName"></param>
        /// <returns></returns>
        public static string EasyUIDataGridToJson(DataTable dt, string jsonName, int total)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
                jsonName = dt.TableName;
            Json.Append("{\"total\":" + total + ",\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type type = dt.Rows[i][j].GetType();
                        Json.Append("\"" + dt.Columns[j].ColumnName.Trim() + "\":" + StringFormat(dt.Rows[i][j].ToString().Trim(), type));

                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }

                    }

                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]" + "}");
            return Json.ToString();
        }

        /// <summary>
        /// 专门生成为DataGrid的json数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="jsonName"></param>
        /// <param name="total"></param>
        /// <param name="more">1生成foot</param>
        /// <returns></returns>
        public static string EasyUIDataGridToJson(DataTable dt, string jsonName, int total, string more)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
            {
                jsonName = dt.TableName;
            }
            Json.Append("{\"total\":" + total + ",\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type type = dt.Rows[i][j].GetType();
                        Json.Append("\"" + dt.Columns[j].ColumnName.Trim() + "\":" + StringFormat(dt.Rows[i][j].ToString().Trim(), type));

                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }

                    }

                    //追加编辑
                    //Json.Append(",\"opt\":\"" + more + "\"");

                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            if (more == "1")  //生成统计脚本
            {
                Json.Append("]" + ShowFooter() + "}");
            }
            else
            {
                Json.Append("]" + "}");
            }
            return Json.ToString();
        }

        public static string ShowFooter()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(",");
            sb.AppendLine("\"footer\":[");
            sb.AppendLine("	{\"Sage\":198.00,\"Ssex\":\"统计:\"}");
            sb.AppendLine("]");

            return sb.ToString();
        }

        /// <summary>  
        /// 格式化字符型、日期型、布尔型  
        /// </summary>  
        /// <param name="str"></param>  
        /// <param name="type"></param>  
        /// <returns></returns>  
        private static string StringFormat(string str, Type type)
        {
            if (str == "")
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                DateTime dt = DateTime.Parse(str);
                str = "\"" + dt.ToString("yyyy-MM-dd HH:mm") + "\"";
                // str = + str + ;
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            return str;
        }

        /// <summary>  
        /// 过滤特殊字符  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        private static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    case '\v':
                        sb.Append("\\n"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }

        /// <summary>   
        /// Datatable转换为Json   
        /// </summary>   
        /// <param name="table">Datatable对象</param>   
        /// <returns>Json字符串</returns>   
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey.Trim() + "\":");
                    strValue = StringFormat(strValue.Trim(), type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
        #endregion
    }
}
