using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace JobScheduleChecker
{
    class FileUtil : Base
    {
        public FileUtil()
        {
            Init();
        }

        private void Init()
        {
            string[] files = getFiles(Common.monitor_path);
            foreach (string file in files)
            {
                divideProcess(file);
            }
        }

        public void divideProcess(string file)
        {

            if (file.IndexOf(Common.target_file) >= 0)
            {
                UploadFile(file);
            }
            else
            {
                DeleteFile(file);
            }
        }

        private string[] getFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        private void DeleteFile(string path)
        {
            logger.Info(String.Format("Delete : {0}", path));
            File.Delete(path);
        }

        private void MoveFile(string srcPath, string destPath)
        {
            logger.Info(String.Format("Move : {0} -> {1}", srcPath, destPath));
            File.Move(srcPath, destPath);
        }

        private void DecryptFile(string passphrase, string filename)
        {
            string arg = String.Format("-d -k \"{0}\" \"{1}\"", passphrase, filename);
            logger.Info(String.Format("Decrypt Target File : {0}", filename));
            ExecCmd("Axcrypt", arg);
        }

        private void ExecCmd(string cmd, string arg)
        {
            logger.Info(String.Format("Exec command : {0} {1}", cmd, arg));
            Process.Start(cmd, arg);
        }

        private void UploadFile(string filePath)
        {
            string filename = Path.GetFileName(filePath);
            string destFilePath = Path.Combine(Common.dest_path, filename);

            MoveFile(filePath, destFilePath);
            DecryptFile(Common.passphrase, destFilePath);
        }
    }
}
