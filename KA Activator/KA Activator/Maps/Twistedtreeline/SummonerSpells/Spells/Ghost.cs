using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KA_Activator.Maps.Twistedtreeline.DMGHandler;

using Settings = KA_Activator.Maps.Twistedtreeline.Config.Types.SummonerSpells;

namespace KA_Activator.Maps.Twistedtreeline.SummonerSpells.Spells
{
    internal class Ghost
    {
        public static Spell.Active SummonerGhost;
        public static void Initialize()
        {
            var ghost = Player.Instance.Spellbook.Spells.FirstOrDefault(spell => spell.Name.Contains("ghost"));
            if (ghost != null)
            {
                SummonerGhost = new Spell.Active(ghost.Slot);
            }
        }

        public static void Execute()
        {
            if (!SummonerGhost.IsReady() || Activator.lastUsed + 1000 >= Environment.TickCount || !Settings.UseGhost) return;

            if (Player.Instance.InDanger(20))
            {
                SummonerGhost.Cast();
                Activator.lastUsed = Environment.TickCount + 500;
            }
        }
    }
}
