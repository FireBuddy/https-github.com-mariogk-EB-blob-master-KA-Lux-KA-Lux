using System;
using EloBuddy;

namespace KA_Activator_Rework
{
    internal class Activator
    {
        public static void Initialize()
        {
            Config.Initialize();
            DamageHandler.DamageHandler.Intialize();
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            //Console.WriteLine("Missiles = "+DamageHandler.DamageHandler.Missiles.Count);
            //Console.WriteLine("Dang Spells = " + DamageHandler.DamageHandler.DangSpells.Count);
            //Console.WriteLine("Dang Spells = " + DamageHandler.DamageHandler.ReceivingDangSpell);
            //var hu3 = DamageHandler.DamageHandler.Missiles.FirstOrDefault(m=> m.Target == Player.Instance);
            //if(hu3 == null)return;
            //Console.WriteLine(hu3);
        }
    }
}
