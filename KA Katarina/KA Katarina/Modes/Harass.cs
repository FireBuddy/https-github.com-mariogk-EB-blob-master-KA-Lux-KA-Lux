using EloBuddy;
using EloBuddy.SDK;

using Settings = KA_Katarina.Config.Modes.Harass;

namespace KA_Katarina.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical);
            if (target == null) return;

            if (SpellManager.Q.IsReady() && target.IsValidTarget(Q.Range) && PermaActive._ulting == false &&
                Settings.UseQ)
            {
                SpellManager.Q.Cast(target);
            }

            if (SpellManager.E.IsReady() && target.IsValidTarget(E.Range) && PermaActive._ulting == false &&
                Settings.UseE)
            {
                SpellManager.E.Cast(target);
            }

            if (SpellManager.W.IsReady() && target.IsValidTarget(W.Range) && PermaActive._ulting == false &&
                Settings.UseW)
            {
                SpellManager.W.Cast();
            }
        }
    }
}
