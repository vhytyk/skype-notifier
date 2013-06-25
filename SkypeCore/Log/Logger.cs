using System;
using System.IO;

namespace SkypeCore.Log
{
    public class Logger
    {
        #region Singleton
        private static Logger _instance;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get { return _instance ?? (_instance = new Logger()); }
        }
        #endregion

        private const string LOG_FILE_NAME = "notifier.log";
        public delegate void LogMessageHandler(string message);
        public event LogMessageHandler Logged;

        public void WriteMessage(string message)
        {
            DateTime date = DateTime.UtcNow;
            string formattedMessage = string.Format("[{0} {1}]: {2}", date.ToShortDateString(), date.ToShortTimeString(), message);
            using (StreamWriter writer = File.AppendText(LOG_FILE_NAME))
            {
                writer.WriteLine(formattedMessage);
            }

            if (Logged != null)
            {
                Logged(formattedMessage);
            }
        }
    }
}
