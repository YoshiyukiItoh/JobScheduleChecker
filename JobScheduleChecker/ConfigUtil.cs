using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace JobScheduleChecker
{
    class ConfigUtil : Base
    {
        private Settings appSettings;
        private XmlSerializer serializer;

        public ConfigUtil()
        {
            appSettings = new Settings();
            serializer = new XmlSerializer(typeof(Settings));
            Init();
        }

        private void Init()
        {
            if(File.Exists(Common.config_filePath))
            {
                ReadConfig();
            }
            else
            {
                CreateConfig();
                MessageBox.Show("create conig\r\nplwase edit the config.");
                logger.Info("create conig file. plwase edit the config file.");
                Application.Exit();
            }
        }

        private void CreateConfig()
        {
            StreamWriter sw 
                = new StreamWriter(Common.config_filePath, false, new UTF8Encoding(false));
            serializer.Serialize(sw, appSettings);
            sw.Close();
        }

        private void ReadConfig()
        {
            StreamReader sr 
                = new StreamReader(Common.config_filePath, new UTF8Encoding(false));
            appSettings = (Settings)serializer.Deserialize(sr);
            sr.Close();
        }


    }
}
