using System;
using EloBuddy.SDK.Events;
using KA_jax;

namespace KA_jax
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Jax.Initialize();
        }
    }
}
