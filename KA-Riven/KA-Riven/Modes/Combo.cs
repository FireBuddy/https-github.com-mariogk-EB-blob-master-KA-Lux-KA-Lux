using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Settings = KA_Riven.Config.Modes.Combo;

namespace KA_Riven.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            if (target == null || target.IsZombie || target.HasUndyingBuff()) return;

            if (SpellManager.Q.IsReady() && target.IsValidTarget(Q.Range) && EventsManager.CanQ)
            {
                Core.DelayAction(Functions.CancelAA, 45);
                Q.Cast();
            }

            if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE)
            {
                E.Cast(target);
            }

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW)
            {
                W.Cast();
            }

            if (R1.IsReady() && Settings.UseR)
            {
                var targetR = TargetSelector.GetTarget(R2.Range , DamageType.Physical);
                var spellR = Player.Instance.Spellbook.GetSpell(SpellSlot.R);
                if (targetR.HealthPercent + 10 >= Player.Instance.HealthPercent && spellR.ToggleState != 1)
                {
                    R1.Cast();
                }

                if (target.IsValidTarget(R2.Range) && spellR.ToggleState >= 1 &&
                    Prediction.Health.GetPrediction(targetR, R2.CastDelay) <= SpellDamage.GetTotalDamage(targetR) &&
                    Prediction.Health.GetPrediction(targetR, R2.CastDelay) > 10)
                {
                    var pred = R2.GetPrediction(targetR);
                    if (pred.HitChance >= HitChance.Medium)
                    {
                        R2.Cast(pred.CastPosition);
                    }
                }
            }
        }
    }
}
