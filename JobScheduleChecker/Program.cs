using System;
using System.IO;

namespace JobScheduleChecker
{
    class Program : Base
    {
        private FileSystemWatcher watcher = null;
        private FileUtil fileUtil;
        private Settings appSettings;

        public Program()
        {
                Init_fw();
                ConfigInit();
                FileInit();
        }

        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            try
            {
                //watcher.EnableRaisingEvents = true;
                logger.Info("監視を開始しました。");
            }
            catch (Exception e)
            {
                logger.Error(String.Format("StackTrace : {0}", e.StackTrace));
                logger.Error(String.Format("Message : {0}", e.Message));
            }
            finally
            {
                Exit_fw();
            }
        }

        private void Init_fw()
        {
            if (watcher != null) return;

            watcher = new System.IO.FileSystemWatcher();
            //監視するディレクトリを指定
            watcher.Path = Common.monitor_path;
            //最終アクセス日時、最終更新日時、ファイル、フォルダ名の変更を監視する
            watcher.NotifyFilter =
                (System.IO.NotifyFilters.LastAccess
                | System.IO.NotifyFilters.LastWrite
                | System.IO.NotifyFilters.FileName
                | System.IO.NotifyFilters.DirectoryName);
            //すべてのファイルを監視
            watcher.Filter = "";

            //イベントハンドラの追加
            watcher.Created += new System.IO.FileSystemEventHandler(watcher_Changed);
        }

        private void Exit_fw()
        {
            try
            {
                if (watcher != null)
                {
                    watcher.EnableRaisingEvents = false;
                    watcher.Dispose();
                    watcher = null;
                }
                logger.Info("監視を終了しました。");
            }
            catch (Exception e)
            {
                logger.Error(String.Format("StackTrace : {0}", e.StackTrace));
                logger.Error(String.Format("Message : {0}", e.Message));
            }
        }

        private void watcher_Changed(Object source, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case System.IO.WatcherChangeTypes.Created:
                    logger.Info("ファイル 「" + e.FullPath + "」が作成されました。");
                    fileUtil.divideProcess(e.FullPath);
                    break;
                default:
                    logger.Error(String.Format("監視外のイベントが発生しました。: {0}", e.ChangeType));
                    break;
            }
        }

        private void ConfigInit()
        {
            ConfigUtil configUtil = new ConfigUtil();
            appSettings = configUtil.GetConfig();
            Common.monitor_path = appSettings.MonitorPath;
            Common.dest_path = appSettings.DestPath;
            Common.target_file = appSettings.TargetFile;
            Common.passphrase = appSettings.Passphrase;
        }

        private void FileInit()
        {
            fileUtil = new FileUtil();
        }
    }
}
