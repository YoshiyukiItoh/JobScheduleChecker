using System;
using System.IO;
using System.Reflection;

namespace JobScheduleChecker
{
    class Common
    {
        public static readonly string monitor_path = @"C:\Schedule";
        public static readonly string target_file = "個人別作業予定_";
        public static readonly string dest_path = @"C:\GDrive\jobSchedule";
        public static readonly string exec_path 
            = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string config_filePath
            = Path.Combine(exec_path,"settings.config");
    }
}
