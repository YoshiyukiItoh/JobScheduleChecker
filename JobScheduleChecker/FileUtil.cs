using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace JobScheduleChecker
{
    class FileUtil
    {
        public FileUtil() { }

        private void Init()
        {
            string[] files =getFiles(Common.monitor_path);

        }

        private string[] getFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        private void MoveFile(string srcPath, string destPath)
        {
            File.Move(srcPath,destPath);
        }

        public void DecryptFile(string passphrase, string filename)
        {
            string arg = String.Format("-d -k \"{0}\" {1}", passphrase,filename);
            ExecCmd("Axcrypt", arg);
        }

        private void ExecCmd(string cmd, string arg)
        {
            Process.Start(cmd, arg);
        }
    }
}
