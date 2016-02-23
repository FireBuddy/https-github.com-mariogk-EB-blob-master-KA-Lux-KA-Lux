using System;
using EloBuddy;
using EloBuddy.SDK;
using Settings = KA_Syndra.Config.Modes.Harass;

namespace KA_Syndra.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }
        private static int lastWCast;
        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            if (target == null || target.IsZombie) return;

            if (Q.IsReady() && E.IsReady() && target.IsValidTarget(QE.Range) && Settings.UseQ && Settings.UseE && Player.Instance.ManaPercent > Settings.ManaHarass)
            {
                Functions.QE(QE.GetPrediction(target).CastPosition);
            }
            else
            {
                if (Q.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseQ && Player.Instance.ManaPercent > Settings.ManaHarass)
                {
                    Q.Cast(target);
                }

                if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE && Player.Instance.ManaPercent > Settings.ManaHarass)
                {
                    E.Cast(target);
                }
            }

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW && Player.Instance.ManaPercent > Settings.ManaHarass)
            {
                if (Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState != 2 &&
                    lastWCast + 700 < Environment.TickCount)
                {
                    W.Cast(Functions.GrabWPost(true));
                    lastWCast = Environment.TickCount;
                }
                if (Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState >= 1 &&
                    lastWCast + 300 < Environment.TickCount)
                {
                    W.Cast(W.GetPrediction(target).CastPosition);
                }
            }
        }
    }
}
