using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduleChecker
{
    public class Settings
    {
        private string _monitorPath;
        private string _targetFile;
        private string _destPath;
        private string _passphrase;


        public string MonitorPath
        {
            get { return _monitorPath; }
            set { _monitorPath = value; }
        }

        public string TargetFile
        {
            get { return _targetFile; }
            set { _targetFile = value; }
        }

        public string DestPath
        {
            get { return _destPath; }
            set { _destPath = value; }
        }

        public string Passphrase
        {
            get { return _passphrase; }
            set { _passphrase = value; }
        }



        public Settings()
        {
            _monitorPath = "XXXXX";
            _targetFile = "XXXXX";
            _destPath = "XXXXX";
            _passphrase = "XXXXX";
        }
    }
}
