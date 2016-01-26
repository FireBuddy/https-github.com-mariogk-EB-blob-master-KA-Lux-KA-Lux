using System;
using EloBuddy;
using KA_Activator.DMGHandler;
using KA_Activator.Items;
using KA_Activator.SummonerSpells;

namespace KA_Activator
{
    public static class Activator
    {
        public static int lastUsed;
        public static void Init()
        {
            Config.Initialize();

            Game.OnUpdate += Game_OnUpdate;

            Initialize.Init();

            DamageHandler.Initialize();

            EventsManager.Initialize();
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            Defensive.Execute();

            Offensive.Execute();
            Consumables.Execute();

            Initialize.Execute();
        }
    }
}
