using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;

namespace KA_Riven
{
    internal static class EventsManager
    {
        public static bool CanQ;
        public static void Initialize()
        {
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, System.EventArgs args)
        {
            CanQ = SpellManager.Q.IsReady();
            if (CanQ)
            {
                Core.DelayAction(() => CanQ = false, 50);
            }
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (sender.IsValidTarget(SpellManager.W.Range))
            {
                SpellManager.W.Cast(sender);
            }
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (e.DangerLevel == DangerLevel.High && sender.IsValidTarget(SpellManager.W.Range))
            {
                SpellManager.W.Cast(sender);
            }
        }
    }
}
