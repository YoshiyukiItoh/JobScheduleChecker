using System;
using System.IO;
using System.Reflection;

namespace JobScheduleChecker
{
    class Common
    {
        public static string monitor_path = string.Empty;
        public static string target_file = string.Empty;
        public static string dest_path = string.Empty;
        public static string passphrase = string.Empty;

        public static readonly string exec_path 
            = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string config_filePath
            = Path.Combine(exec_path,"settings.config");
    }
}
