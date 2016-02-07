using System;
using EloBuddy.SDK.Events;

namespace KA_Riven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Riven.Initialize();
        }
    }
}
