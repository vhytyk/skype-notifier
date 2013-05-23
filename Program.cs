using System.Windows.Forms;

namespace SkypeNotifier
{
    class Program
    {
        private static void Main(string[] args)
        {
            SkypeNotifier.Instance.StartTimer();
            Application.Run(new Settings());
            SkypeNotifier.Instance.StopTimer();
        }
    }
}
