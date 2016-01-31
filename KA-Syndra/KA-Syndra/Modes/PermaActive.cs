using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Misc = KA_Syndra.Config.Modes.Misc;

namespace KA_Syndra.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target == null || target.IsZombie || target.HasUndyingBuff()) return;

            if (SpellManager.R.IsReady() && target.IsValidTarget(R.Range) &&
                target.Health <= SpellDamage.GetRealDamage(SpellSlot.R, target) && target.Health > Misc.OverkillR)
            {
                R.Cast(target);
            }
        }
    }
}
