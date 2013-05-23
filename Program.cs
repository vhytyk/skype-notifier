using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using System.Threading;
using System.Diagnostics;

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
                SkypeNotifier.Instance.StartTimer();
                Application.Run(new Settings());
                SkypeNotifier.Instance.StopTimer();
            }
            else
            {
                try
                {
                    Win32.SetForegroundWindow(Process.GetProcessesByName("SkypeNotifier")[0].MainWindowHandle);
                    return;
                }
                catch
                {
                }
            }
            mutex.ReleaseMutex();
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
