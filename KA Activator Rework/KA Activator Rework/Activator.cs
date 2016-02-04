using System;
using System.Linq;
using EloBuddy;

namespace KA_Activator_Rework
{
    internal class Activator
    {
        public static void Initialize()
        {
            DamageHandler.DamageHandler.Intialize();
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            Console.WriteLine(DamageHandler.DamageHandler.Missiles.Count);
            var hu3 = DamageHandler.DamageHandler.Missiles.FirstOrDefault(m=> m.Target == Player.Instance);
            if(hu3 == null)return;
            Console.WriteLine(hu3);
        }
    }
}
