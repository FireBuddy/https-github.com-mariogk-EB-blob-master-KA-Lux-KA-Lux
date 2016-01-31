using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = KA_Syndra.Config.Modes.LastHit;

namespace KA_Syndra.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            if (Q.IsReady() && Settings.UseQ)
            {
                var minionQ =
                       EntityManager.MinionsAndMonsters.GetLaneMinions()
                           .OrderByDescending(m => m.Health)
                           .FirstOrDefault(
                               m => m.IsValidTarget(Q.Range) && m.Health <= SpellDamage.GetRealDamage(SpellSlot.Q, m));

                if (minionQ != null && !Player.Instance.IsInAutoAttackRange(minionQ) && Player.Instance.ManaPercent > Settings.LastMana)
                {
                    Q.Cast(minionQ);
                }
            }
        }
    }
}
