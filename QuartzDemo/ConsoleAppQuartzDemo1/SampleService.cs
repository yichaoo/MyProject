// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace ConsoleAppQuartzDemo1
{
    using System;
    using System.Threading;
    using Topshelf;
    using Topshelf.Logging;

    using Quartz.Impl;
    using log4net;
    using Quartz;
    class SampleService :
        ServiceControl
    {
        IScheduler scheduler = null;
        public bool Start(HostControl hostControl)
        {
          
            //启动xml默认配置任务
            scheduler = new StdSchedulerFactory().GetScheduler();
            Common.LogHelper.log4netObj.Info("SampleService已启动");
            // 任务开始
            scheduler.Start();

            //hostControl.RequestAdditionalTime(TimeSpan.FromSeconds(10));

            //Thread.Sleep(1000);

            //ThreadPool.QueueUserWorkItem(x =>
            //    {
            //        Thread.Sleep(3000);
            //        _log.Info("Requesting stop");
            //        hostControl.Stop();
            //    });
            //_log.Info("SampleService Started");

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Common.LogHelper.log4netObj.Info("SampleService已停止");
            // 任务开始
            scheduler.Start();


            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            Common.LogHelper.log4netObj.Info("SampleService已暂停");

            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            Common.LogHelper.log4netObj.Info("SampleService继续");

            return true;
        }
    }
}