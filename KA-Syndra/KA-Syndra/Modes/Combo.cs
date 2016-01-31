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

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(QE.Range, DamageType.Magical);
            if (target == null || target.IsZombie || target.HasUndyingBuff()) return;

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

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW && Functions.SpheresCount() > 0)
            {
                W.Cast(W.GetPrediction(target).CastPosition);
            }

            if (R.IsReady() && target.IsValidTarget(R.Range) && Settings.UseR &&
                target.Health <= SpellDamage.GetRealDamage(SpellSlot.R, target) && target.Health > Misc.OverkillR)
            {
                R.Cast(target);
            }
        }
    }
}

