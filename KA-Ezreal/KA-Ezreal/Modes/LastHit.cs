using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KickassSeries.Champions.Ezreal;

using Settings = KA_Ezreal.Config.Modes.LastHit;

namespace KA_Ezreal.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            var laneMinion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .FirstOrDefault(m => m.IsValidTarget(Q.Range) && m.Health <= SpellDamage.GetRealDamage(SpellSlot.Q, m));

            if (laneMinion == null) return;

            if (Settings.UseQ && Q.IsReady() && Settings.LastMana <= Player.Instance.ManaPercent && !Player.Instance.IsInAutoAttackRange(laneMinion))
            {
                Q.Cast(laneMinion);
            }
        }
    }
}
