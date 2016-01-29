using System;
using EloBuddy;

namespace KA_Activator
{
    public static class Activator
    {
        public static int lastUsed;
        public static void Init()
        {
            EventsManager.Initialize();

            switch (Game.MapId)
            {
                case GameMapId.CrystalScar:
                    Maps.CrystalScar.Config.Initialize();
                    Game.OnUpdate += CrystalScar;
                    Maps.CrystalScar.DMGHandler.DamageHandler.Initialize();
                    Maps.CrystalScar.SummonerSpells.Initialize.Init();
                    break;
                case GameMapId.HowlingAbyss:
                    Maps.HowlingAbyss.Config.Initialize();
                    Game.OnUpdate += HowlingAbyss;
                    Maps.HowlingAbyss.DMGHandler.DamageHandler.Initialize();
                    Maps.HowlingAbyss.SummonerSpells.Initialize.Init();
                    break;
                case GameMapId.SummonersRift:
                    Maps.SummonersRift.Config.Initialize();
                    Game.OnUpdate += SummonerRift;
                    Maps.SummonersRift.DMGHandler.DamageHandler.Initialize();
                    Maps.SummonersRift.SummonerSpells.Initialize.Init();
                    break;
                case GameMapId.TwistedTreeline:
                    Maps.Twistedtreeline.Config.Initialize();
                    Game.OnUpdate += TwistedTreeline;
                    Maps.Twistedtreeline.DMGHandler.DamageHandler.Initialize();
                    Maps.Twistedtreeline.SummonerSpells.Initialize.Init();
                    break;
            }
        }

        private static void CrystalScar(EventArgs args)
        {
            Maps.CrystalScar.Items.Defensive.Execute();
            Maps.CrystalScar.Items.Offensive.Execute();
            Maps.CrystalScar.Items.Consumables.Execute();

            Maps.CrystalScar.SummonerSpells.Initialize.Execute();
        }

        private static void HowlingAbyss(EventArgs args)
        {
            Maps.HowlingAbyss.Items.Defensive.Execute();
            Maps.HowlingAbyss.Items.Offensive.Execute();
            Maps.HowlingAbyss.Items.Consumables.Execute();

            Maps.HowlingAbyss.SummonerSpells.Initialize.Execute();
        }

        private static void SummonerRift(EventArgs args)
        {
            Maps.SummonersRift.Items.Defensive.Execute();
            Maps.SummonersRift.Items.Offensive.Execute();
            Maps.SummonersRift.Items.Consumables.Execute();

            Maps.SummonersRift.SummonerSpells.Initialize.Execute();
        }

        private static void TwistedTreeline(EventArgs args)
        {
            Maps.Twistedtreeline.Items.Defensive.Execute();
            Maps.Twistedtreeline.Items.Offensive.Execute();
            Maps.Twistedtreeline.Items.Consumables.Execute();

            Maps.Twistedtreeline.SummonerSpells.Initialize.Execute();
        }
    }
}
