using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using Common.Logging;
namespace ConsoleAppQuartzDemo1
{
    class Job2 : IJob
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Job1));
        public void Execute(IJobExecutionContext context)
        {

            JobKey jobKey = context.JobDetail.Key;
            try
            {
                Console.WriteLine("我是干活的2");
               // Convert.ToInt16("六");
                // JobSample1(context);
                string strMsg = string.Format("{0} executing at {1}", jobKey, DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
                //日志写入到log4net配置目录中
                Common.LogHelper.log4netObj.InfoFormat(strMsg);
                log.Info(strMsg);
            }
            catch (Exception exce)
            {
                log.Error(jobKey + "任务出错", exce);
                Common.LogHelper.log4netObj.Error(jobKey + "任务出错", exce);
            }
        }
    }
}
