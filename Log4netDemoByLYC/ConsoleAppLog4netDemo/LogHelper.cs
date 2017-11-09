using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace ConsoleApp
{
    
    public static class LogHelper
    {
        public static readonly log4net.ILog log
            = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
     
    }
}
