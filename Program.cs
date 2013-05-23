using System.Windows.Forms;

namespace SkypeNotifier
{
    class Program
    {
        private static void Main(string[] args)
        {
            SettingsManager.Instance.StartTimer();
            Application.Run(new Settings());
            SettingsManager.Instance.StopTimer();
        }
    }
}
