using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = KA_jax.Config.Modes.Misc;

namespace KA_jax.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            var enemy =
                EntityManager.Heroes.Enemies.FirstOrDefault(
                    e =>
                        e.Health <=
                        SpellDamage.GetRealDamage(SpellSlot.Q, e) + SpellDamage.GetRealDamage(SpellSlot.W, e));

            if (W.IsReady() && Q.IsReady() && Settings.QWKillSteal &&
                Player.Instance.ManaPercent >= Settings.KillStealMana && enemy.IsValidTarget(Q.Range))
            {
                W.Cast();
                Q.Cast(enemy);
            }
        }
    }
}
