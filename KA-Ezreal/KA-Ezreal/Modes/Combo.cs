using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Settings = KA_Ezreal.Config.Modes.Combo;

namespace KA_Ezreal.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            if (target == null || target.IsZombie || target.HasUndyingBuff()) return;

            //Q To AA Cancel
            if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range) &&
                !target.IsInRange(Player.Instance, Player.Instance.GetAutoAttackRange()))
            {
                var pred = Q.GetPrediction(target);
                if (pred.HitChance >= HitChance.High)
                {
                    Q.Cast(pred.CastPosition);
                }
            }

            //W To AA Cancel
            if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range) &&
                !target.IsInRange(Player.Instance, Player.Instance.GetAutoAttackRange()))
            {
                var pred = W.GetPrediction(target);
                if (pred.HitChance >= HitChance.Medium)
                {
                    W.Cast(pred.CastPosition);
                }
            }

            //Normal Q and W
            if (Settings.UseQ && EventsManager.CanQCancel && target.IsValidTarget(Q.Range) &&
                target.IsInRange(Player.Instance, Player.Instance.GetAutoAttackRange()))
            {
                var pred = Q.GetPrediction(target);
                if (pred.HitChance >= HitChance.High)
                {
                    Q.Cast(pred.CastPosition);
                }
            }

            if (Settings.UseW && EventsManager.CanWCancel && target.IsValidTarget(W.Range) &&
                target.IsInRange(Player.Instance, Player.Instance.GetAutoAttackRange()))
            {
                var pred = W.GetPrediction(target);
                if (pred.HitChance >= HitChance.Medium)
                {
                    W.Cast(pred.CastPosition);
                }
            }
            //Test R
            if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range))
            {
                var predpos = R.GetPrediction(target).CastPosition;
                if (predpos.CountEnemiesInRange(R.Width) > Settings.MinR)
                {
                    R.Cast(predpos);
                }
            }
        }
    }
}
