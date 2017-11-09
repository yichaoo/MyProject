using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Log4netDemo
    {

        static void Main(string[] args)
        {

            LogHelper.log.Debug("Debug:测试");
            LogHelper.log.Info("Info:测试");
            LogHelper.log.Error("Error:测试");
            try
            {
                string str1 = "teststr111";
                int a = Convert.ToInt32(str1);
            }
            catch (Exception exce)
            {
                LogHelper.log.Error("程序报错了", exce);
            }
        }
    }
}
