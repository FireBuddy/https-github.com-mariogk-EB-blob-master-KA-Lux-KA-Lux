
using EloBuddy;
using EloBuddy.SDK.Events;

namespace KA_Activator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(System.EventArgs args)
        {
            Activator.Init();
        }
    }
}
