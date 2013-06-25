using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using System.Threading;
using System.Diagnostics;
using SkypeCore;
using SkypeCore.Log;

namespace SkypeNotifier
{
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Mutex mutex = new Mutex(true, AppDomain.CurrentDomain.BaseDirectory.Replace('\\', '_'));
            if (mutex.WaitOne(100))
            {
                Logger.Instance.WriteMessage("Notifier started.");
                SkypeNotifier.Instance.StartTimer();
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                Application.Run(new Settings());
                SkypeNotifier.Instance.StopTimer();
                Logger.Instance.WriteMessage("Notifier halted.");
            }
            else
            {
                try
                {
                    Process[] allProcesses = Process.GetProcessesByName("SkypeNotifier");
                    if (allProcesses.Length > 0)
                    {
                        Win32.SetForegroundWindow(allProcesses[0].MainWindowHandle);
                    }
                    return;
                }
                catch
                {
                }
            }
            mutex.ReleaseMutex();
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.Instance.WriteMessage(e.Exception.ToString());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            Logger.Instance.WriteMessage((ex ?? new Exception("unhandled exception")).ToString());
        }
    }

    public class Win32
    {
        //Import the FindWindow API to find our window
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindowNative(string className, string windowName);

        //Import the SetForeground API to activate it
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern IntPtr SetForegroundWindowNative(IntPtr hWnd);

        public static IntPtr FindWindow(string className, string windowName)
        {
            return FindWindowNative(className, windowName);
        }

        public static IntPtr SetForegroundWindow(IntPtr hWnd)
        {
            return SetForegroundWindowNative(hWnd);
        }
    }

}
