using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KA_Activator.Maps.SummonersRift.DMGHandler;
using Settings = KA_Activator.Maps.SummonersRift.Config.Types.SummonerSpells;

namespace KA_Activator.Maps.SummonersRift.SummonerSpells.Spells
{
    internal class Barrier
    {
        public static Spell.Active SummonerBarrier;
        public static void Initialize()
        {
            var barrier = Player.Instance.Spellbook.Spells.FirstOrDefault(spell => spell.Name.Contains("barrier"));
            if (barrier != null)
            {
                SummonerBarrier = new Spell.Active(barrier.Slot);
            }
        }

        public static void Execute()
        {
            if (!SummonerBarrier.IsReady() || Activator.lastUsed >= Environment.TickCount || !Settings.UseBarrier) return;

            if (Player.Instance.InDanger(Settings.BarrierHealth))
            {
                SummonerBarrier.Cast();
                Activator.lastUsed = Environment.TickCount + 500;
            }
        }
    }
}
