using EloBuddy.SDK.Events;

namespace KA_Trackers
{
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(System.EventArgs args)
        {
            Initializer.Init();
        }
    }
}
