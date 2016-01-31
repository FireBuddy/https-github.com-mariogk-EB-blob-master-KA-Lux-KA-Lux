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

            if (W.IsReady() && target.IsValidTarget(E.Range) && Settings.UseW)
            {
                W.Cast(Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState == 2
                    ? W.GetPrediction(target).CastPosition
                    : Functions.GrabWPost(false));
            }

        }
    }
}
