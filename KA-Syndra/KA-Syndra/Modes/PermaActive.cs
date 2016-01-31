using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KA_Syndra.Config.Modes.Harass;
using Misc = KA_Syndra.Config.Modes.Misc;

namespace KA_Syndra.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }
        private static int lastWCast;
        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target == null || target.IsZombie || target.HasUndyingBuff()) return;
            Console.WriteLine(SpellDamage.GetRealDamage(SpellSlot.R, target));
            //RKS
            if (SpellManager.R.IsReady() && target.IsValidTarget(R.Range) &&
                target.Health <= SpellDamage.GetRealDamage(SpellSlot.R, target) && target.Health > Misc.OverkillR)
            {
                R.Cast(target);
            }
            //RKS
            //AutoHarass
            var tower = EntityManager.Turrets.Allies.FirstOrDefault(t => t.IsInRange(Player.Instance, 920));
            if (tower == null)
            {
                
                if (Q.IsReady() && E.IsReady() && target.IsValidTarget(QE.Range) && Settings.UseQ && Settings.UseE && Player.Instance.ManaPercent > Settings.ManaAutoHarass)
                {
                    Functions.QE(QE.GetPrediction(target).CastPosition);
                }
                else
                {
                    if (Q.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseQ && Player.Instance.ManaPercent > Settings.ManaAutoHarass)
                    {
                        Q.Cast(target);
                    }

                    if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE && Player.Instance.ManaPercent > Settings.ManaAutoHarass)
                    {
                        E.Cast(target);
                    }
                }

                if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW && Player.Instance.ManaPercent > Settings.ManaAutoHarass)
                {
                    if (Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState != 2 && lastWCast + 500 < Environment.TickCount)
                    {
                        W.Cast(Functions.GrabWPost(false));
                        lastWCast = Environment.TickCount;
                    }
                    if (Player.Instance.Spellbook.GetSpell(SpellSlot.W).ToggleState == 2 &&
                        lastWCast + 100 < Environment.TickCount)
                    {
                        W.Cast(W.GetPrediction(target).CastPosition);
                    }
                }
            }
        }
    }
}
