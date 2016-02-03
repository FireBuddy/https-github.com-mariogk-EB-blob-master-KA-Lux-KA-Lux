using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace KA_Rumble
{
    internal class Functions
    {
        public static bool ShouldOverload(SpellSlot slot)
        {
            switch (slot)
            {
                case SpellSlot.Q:
                    return !SpellManager.W.IsReady() && !SpellManager.E.IsReady() && !SpellManager.R.IsReady();
                case SpellSlot.W:
                    return !SpellManager.Q.IsReady() && !SpellManager.E.IsReady() && !SpellManager.R.IsReady();
                case SpellSlot.E:
                    return !SpellManager.Q.IsReady() && !SpellManager.W.IsReady() && !SpellManager.R.IsReady();
                case SpellSlot.R:
                    return !SpellManager.Q.IsReady() && !SpellManager.W.IsReady() && !SpellManager.E.IsReady();
            }
            return false;
        }

        public static void CastR(AIHeroClient target)
        {
            if (target != null)
            {
                var initPos = target.Position.To2D() + 500* target.Direction.To2D().Perpendicular();
                var endPos = target.Position.Extend(initPos.To3D(), 120);

                var pred = SpellManager.R.GetPrediction(target);

                if (pred.HitChance >= HitChance.High)
                {
                    Player.CastSpell(SpellSlot.R, initPos.To3D(), endPos.To3D());
                }
            }
        }
    }
}
