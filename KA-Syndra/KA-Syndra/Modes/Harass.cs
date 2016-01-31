using EloBuddy;
using EloBuddy.SDK;
using Settings = KA_Syndra.Config.Modes.Harass;

namespace KA_Syndra.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }
        public static int lastWCast;
        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            if (target == null || target.IsZombie) return;

            if (Q.IsReady() && E.IsReady() && target.IsValidTarget(QE.Range) && Settings.UseQ && Settings.UseE)
            {
                Functions.QE(QE.GetPrediction(target).CastPosition);
            }
            else
            {
                if (Q.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseQ)
                {
                    Q.Cast(target);
                }

                if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE)
                {
                    E.Cast(target);
                }
            }

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW)
            {
                if (Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState == 1 && lastWCast + 500 < Game.TicksPerSecond)
                {
                    W.Cast(Functions.GrabWPost(false));
                    lastWCast = Game.TicksPerSecond;
                }
                if (Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState != 1 &&
                    lastWCast + 100 < Game.TicksPerSecond)
                {
                    W.Cast(W.GetPrediction(target).CastPosition);
                }
            }

        }
    }
}
