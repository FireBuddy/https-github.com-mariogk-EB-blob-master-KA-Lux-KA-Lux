using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KickassSeries.Champions.Ezreal;

using Settings = KA_Ezreal.Config.Modes.Misc;
using Configs = KA_Ezreal.Config.Modes.Harass;

namespace KA_Ezreal.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            if (Settings.UseR && R.IsReady())
            {
            }

            if (Configs.UseQAuto && Q.IsReady() && Configs.ManaAutoHarass <= Player.Instance.ManaPercent)
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                if (target == null || target.IsZombie) return;

                if (target.IsValidTarget(Q.Range))
                {
                    Q.Cast(target);
                }
            }

            if (Configs.UseWAuto && W.IsReady() && Configs.ManaAutoHarass <= Player.Instance.ManaPercent)
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
                if (target == null || target.IsZombie) return;

                if (target.IsValidTarget(W.Range))
                {
                    W.Cast(target);
                }
            }
        }
    }
}
