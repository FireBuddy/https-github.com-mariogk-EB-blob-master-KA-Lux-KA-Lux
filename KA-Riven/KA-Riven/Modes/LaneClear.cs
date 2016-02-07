using System.Linq;
using EloBuddy.SDK;

using Settings = KA_Riven.Config.Modes.LaneClear;

namespace KA_Riven.Modes
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
                    .OrderBy(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(Q.Range));

            if (minion == null) return;

            if (SpellManager.Q.IsReady() && minion.IsValidTarget(Q.Range) && EventsManager.CanQ)
            {
                Core.DelayAction(Functions.CancelAA, 70);
                Q.Cast();
            }
        }
    }
}
