using System;
using System.IO;

namespace JobScheduleChecker
{
    class Program
    {
        // TODO log4j

        FileSystemWatcher watcher = null;
        string moniter_path;
        string mv_dest_path;

        public Program()
        {
            Init_fw();
        }

        static void Main(string[] args)
        {
            Program exec = new Program();
            FileUtil fu = new FileUtil();
            try
            {
                //fu.DecryptFile(@"C:\Users\yoshi\Desktop\個人別作業予定_20160328v1-xlsx.axx");
                //exec.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                exec.Exit_fw();
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

        private void Run()
        {
            watcher.EnableRaisingEvents = true;
            //Console.WriteLine("監視を開始しました。");
        }

        private void Exit_fw()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            watcher = null;
            //Console.WriteLine("監視を終了しました。");
        }

        private void watcher_Changed(Object source, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case System.IO.WatcherChangeTypes.Changed:
                    Console.WriteLine(
                        "ファイル 「" + e.FullPath + "」が変更されました。");
                    break;
                case System.IO.WatcherChangeTypes.Created:
                    Console.WriteLine(
                        "ファイル 「" + e.FullPath + "」が作成されました。");
                    break;
                case System.IO.WatcherChangeTypes.Deleted:
                    Console.WriteLine(
                        "ファイル 「" + e.FullPath + "」が削除されました。");
                    break;
            }
        }
    }
}
