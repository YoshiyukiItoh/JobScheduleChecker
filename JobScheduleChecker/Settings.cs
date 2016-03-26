using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduleChecker
{
    class Settings
    {
        private string _passphrase;

        public string Passphrase
        {
            get { return _passphrase; }
            set { _passphrase = value; }
        }
    }
}
