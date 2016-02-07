using System.Linq;
using EloBuddy.SDK;

using Settings = KA_Riven.Config.Modes.LaneClear;

namespace KA_Riven.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            var jgminion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderByDescending(j => j.Health)
                    .FirstOrDefault(j => j.IsValidTarget(Q.Range));

            if (jgminion == null)return;

            if (Q.IsReady() && jgminion.IsValidTarget(Q.Range) && Settings.UseQ && EventsManager.CanQ)
            {
                Q.Cast(jgminion);
            }
        }
    }
}
