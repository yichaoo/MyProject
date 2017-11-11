﻿using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using Common.Logging;
using Quartz.Impl;
using System.Threading;
using Topshelf;

namespace ConsoleAppQuartzDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
           // Scheduler1();
            //Scheduler2();
           //Scheduler3();
            HostFactory.Run(x => x.Service<SampleService>());
        }

        //WithSimpleSchedule
        private static void Scheduler1()
        {
            try
            {
                Console.ReadLine();

                //开启日志输出
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
                ILog log = LogManager.GetLogger(typeof(Program));

                //从计划器工作实例化一个计划实例；
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                //定义一个job
                IJobDetail job = JobBuilder.Create<Job1>()
                    .WithIdentity("job1", "grop1")
                    .UsingJobData("jobSays", "Hello World!")
                    .UsingJobData("myFloatValue", 3.141f)
                    .Build();

                //定义一个trigger
                ITrigger trigger = null;
                TriggerBuilder triggerBuilder = TriggerBuilder.Create();


                triggerBuilder.WithIdentity("trigger1", "group1");
                triggerBuilder.StartNow();//按当前时间立即执行
                triggerBuilder.WithSimpleSchedule(x => x.WithIntervalInSeconds(3).RepeatForever());//每3秒执行，永远重复
                trigger = triggerBuilder.Build();

                //开始为任务做计划
                DateTimeOffset dto = scheduler.ScheduleJob(job, trigger);

                // 计划任务开始
                scheduler.Start();

                // some sleep to show what's happening
                //Thread.Sleep(TimeSpan.FromSeconds(2));

                // and last shut down the scheduler when you are ready to close your program
                //scheduler.Shutdown();

                //Console.ReadLine();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }

        //WithCronSchedule
        private static void Scheduler2()
        {
            //开启日志输出
            Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
            ILog log = LogManager.GetLogger(typeof(Program));
            StdSchedulerFactory scheduleFac = new StdSchedulerFactory();
            IScheduler scheduler = new StdSchedulerFactory().GetScheduler();

            IJobDetail job = JobBuilder.Create<Job2>()
                       .WithIdentity("job2", "group1")
                       .Build();
            ITrigger trigger = TriggerBuilder.Create()
                //.WithCronSchedule("0 30 7,14,18 ? * *")//每天7:30,14:30,18:30执行一个任务
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(3).RepeatForever())//每3秒执行，永远重复
                .Build();

            //开始为任务做计划
            DateTimeOffset dto = scheduler.ScheduleJob(job, trigger);
            // 计划任务开始
            scheduler.Start();

        }
        //通过配置文件加载Job
        private static void Scheduler3()
        {
            //开启日志输出
            Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
            ILog log = LogManager.GetLogger(typeof(Program));
            IScheduler scheduler = new StdSchedulerFactory().GetScheduler();
            // 计划任务开始
            scheduler.Start();
        }
    }
}
/*字段 允许值 允许的特殊字符 
秒 0-59 , - * / 
分 0-59 , - * / 
小时 0-23 , - * / 
日期 1-31 , - * ? / L W C 
月份 1-12 或者 JAN-DEC , - * / 
星期 1-7 或者 SUN-SAT , - * ? / L C # 
年（可选） 留空, 1970-2099 , - * / 
表达式 意义 
"0 0 12 * * ?" 每天中午12点触发 
"0 15 10 ? * *" 每天上午10:15触发 
"0 15 10 * * ?" 每天上午10:15触发 
"0 15 10 * * ? *" 每天上午10:15触发 
"0 15 10 * * ? 2005" 2005年的每天上午10:15触发 
"0 * 14 * * ?" 在每天下午2点到下午2:59期间的每1分钟触发 
"0 0/5 14 * * ?" 在每天下午2点到下午2:55期间的每5分钟触发 
"0 0/5 14,18 * * ?" 在每天下午2点到2:55期间和下午6点到6:55期间的每5分钟触发 
"0 0-5 14 * * ?" 在每天下午2点到下午2:05期间的每1分钟触发 
"0 10,44 14 ? 3 WED" 每年三月的星期三的下午2:10和2:44触发 
"0 15 10 ? * MON-FRI" 周一至周五的上午10:15触发 
"0 15 10 15 * ?" 每月15日上午10:15触发 
"0 15 10 L * ?" 每月最后一日的上午10:15触发 
"0 15 10 ? * 6L" 每月的最后一个星期五上午10:15触发 
"0 15 10 ? * 6L 2002-2005" 2002年至2005年的每月的最后一个星期五上午10:15触发 
"0 15 10 ? * 6#3" 每月的第三个星期五上午10:15触发 */