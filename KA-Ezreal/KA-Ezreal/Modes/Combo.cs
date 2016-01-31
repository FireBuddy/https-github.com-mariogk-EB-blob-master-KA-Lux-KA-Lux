using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

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
                Q.Cast(Q.GetPrediction(target).CastPosition);
            }

            //W To AA Cancel
            if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range) &&
                !target.IsInRange(Player.Instance, Player.Instance.GetAutoAttackRange()))
            {
                W.Cast(W.GetPrediction(target).CastPosition);
            }

            //Normal Q and W
            if (Settings.UseQ && EventsManager.CanQCancel && target.IsValidTarget(Q.Range) &&
                target.IsInRange(Player.Instance, Player.Instance.GetAutoAttackRange()))
            {
                Q.Cast(Q.GetPrediction(target).CastPosition);
            }

            if (Settings.UseW && EventsManager.CanWCancel && target.IsValidTarget(W.Range) &&
                target.IsInRange(Player.Instance, Player.Instance.GetAutoAttackRange()))
            {
                W.Cast(W.GetPrediction(target).CastPosition);
            }

            if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range))
            {
                var enemies = EntityManager.Heroes.Enemies.Where(e => e.IsValidTarget(Settings.MinR)).ToArray();
                if(enemies.Length == 0)return;

                R.GetPrediction()
            }

        }
    }
}
