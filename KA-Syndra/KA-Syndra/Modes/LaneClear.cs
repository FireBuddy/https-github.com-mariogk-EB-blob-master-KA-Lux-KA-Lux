using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = KA_Syndra.Config.Modes.LaneClear;

namespace KA_Syndra.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(Q.Range));

            if (minion == null) return;

            if (Q.IsReady() && minion.IsValidTarget(Q.Range) && Settings.UseQ && Player.Instance.ManaPercent > Settings.LaneMana)
            {
                Q.Cast(minion);
            }

            if (W.IsReady() && minion.IsValidTarget(W.Range) && Settings.UseW && Functions.SpheresCount() > 0 && Player.Instance.ManaPercent > Settings.LaneMana)
            {
                W.Cast(W.GetPrediction(minion).CastPosition);
            }
        }
    }
}
