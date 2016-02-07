using System;
using EloBuddy.SDK.Events;

namespace KA_Katarina
{
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Katarina.Initialize();
        }
    }
}
