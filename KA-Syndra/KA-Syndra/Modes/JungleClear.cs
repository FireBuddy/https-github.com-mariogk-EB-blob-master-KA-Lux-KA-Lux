﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = KA_Syndra.Config.Modes.LaneClear;

namespace KA_Syndra.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }
        public static int lastWCast;
        public override void Execute()
        {
            var jgminion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderByDescending(j => j.Health)
                    .FirstOrDefault(j => j.IsValidTarget(Q.Range));

            if (jgminion == null)return;

            if (Q.IsReady() && jgminion.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast(jgminion);
            }

            if (W.IsReady() && jgminion.IsValidTarget(W.Range) && Settings.UseW)
            {
                if (Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState == 1 && lastWCast + 500 < Game.TicksPerSecond)
                {
                    W.Cast(Functions.GrabWPost(false));
                    lastWCast = Game.TicksPerSecond;
                }
                if (Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState != 1 &&
                    lastWCast + 100 < Game.TicksPerSecond)
                {
                    W.Cast(W.GetPrediction(jgminion).CastPosition);
                }
            }
        }
    }
}