using System;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KA_Syndra.Config.Modes.Combo;
using Misc = KA_Syndra.Config.Modes.Misc;

namespace KA_Syndra.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        private static int lastWCast;

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(QE.Range, DamageType.Magical);
            if (target == null || target.IsZombie || target.HasUndyingBuff()) return;

            if (R.IsReady() && target.IsValidTarget(R.Range) && Settings.UseR &&
                target.Health <= SpellDamage.GetRealDamage(SpellSlot.R, target) && target.Health > Misc.OverkillR)
            {
                R.Cast(target);
            }

            if (Q.IsReady() && E.IsReady() && target.IsValidTarget(QE.Range) && Settings.UseQ && Settings.UseE)
            {
                Functions.QE(QE.GetPrediction(target).CastPosition);
            }
            else
            {
                if (Q.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseQ)
                {
                    Q.Cast(target);
                }

                if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE)
                {
                    E.Cast(target);
                }
            }

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW)
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

