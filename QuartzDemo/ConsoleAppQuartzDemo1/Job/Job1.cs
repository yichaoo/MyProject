using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using Common.Logging;

namespace ConsoleAppQuartzDemo1
{
    class Job1 : IJob
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Job1));
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("我是干活的");
            JobSample1(context);

            JobKey jobKey = context.JobDetail.Key;
            log.InfoFormat("Job1 says: {0} executing at {1}", jobKey, DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
        }

        public void JobSample1(IJobExecutionContext context)
        {
            //JobKey key = context.JobDetail.Key;

            //JobDataMap dataMap = context.JobDetail.JobDataMap;

            //string jobSays = dataMap.GetString("jobSays");
            //float myFloatValue = dataMap.GetFloat("myFloatValue");

            //Console.Error.WriteLine("Instance " + key + " of DumbJob says: " + jobSays + ", and val is: " + myFloatValue);

            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.MergedJobDataMap;  // Note the difference from the previous example

            string jobSays = dataMap.GetString("jobSays");
            float myFloatValue = dataMap.GetFloat("myFloatValue");
            //IList<DateTimeOffset> state = (IList<DateTimeOffset>)dataMap["myStateData"];
            //state.Add(DateTimeOffset.UtcNow);

            Console.Error.WriteLine("Instance " + key + " of DumbJob says: " + jobSays + ", and val is: " + myFloatValue);
        }
    }
}
