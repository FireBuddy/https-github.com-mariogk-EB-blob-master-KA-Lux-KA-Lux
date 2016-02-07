using EloBuddy;
using EloBuddy.SDK;

namespace KA_Riven
{
    public static class SpellDamage
    {
        public static float GetTotalDamage(AIHeroClient target)
        {
            // Auto attack
            var damage = Player.Instance.GetAutoAttackDamage(target);

            // Q
            if (SpellManager.Q.IsReady())
            {
                damage += SpellManager.Q.GetRealDamage(target);
            }

            // W
            if (SpellManager.W.IsReady())
            {
                damage += SpellManager.W.GetRealDamage(target);
            }

            // E
            if (SpellManager.E.IsReady())
            {
                damage += SpellManager.E.GetRealDamage(target);
            }

            // R
            if (SpellManager.R2.IsReady())
            {
                damage += SpellManager.R2.GetRealDamage(target);
            }

            return damage;
        }

        public static float GetRealDamage(this Spell.SpellBase spell, Obj_AI_Base target)
        {
            return spell.Slot.GetRealDamage(target);
        }

        public static float GetRealDamage(this SpellSlot slot, Obj_AI_Base target)
        {
            var spellLevel = Player.Instance.Spellbook.GetSpell(slot).Level;
            const DamageType damageType = DamageType.Magical;
            float damage = 0;

            if (spellLevel == 0)
            {
                return 0;
            }
            spellLevel--;

            switch (slot)
            {
                case SpellSlot.Q:

                    damage = new float[] { 10, 30, 50, 70, 90 }[spellLevel] + 1.2f * Player.Instance.TotalAttackDamage;
                    break;

                case SpellSlot.W:

                    damage = new float[] { 50, 80, 110, 140, 170 }[spellLevel] + 1f * Player.Instance.FlatPhysicalDamageMod;
                    break;

                case SpellSlot.E:

                    damage = new float[] { 0, 0, 0, 0, 0 }[spellLevel] + 0.0f * Player.Instance.FlatMagicDamageMod;
                    break;

                case SpellSlot.R:
                    damage = new float[] {80, 120, 160}[spellLevel] +
                             0.6f*Player.Instance.FlatPhysicalDamageMod*
                             (float) (target.HealthPercent < 25 ? 3 : (100 - target.HealthPercent*2.67)/100 + 1);
                    break;
            }

            if (damage <= 0)
            {
                return 0;
            }

            return Player.Instance.CalculateDamageOnUnit(target, damageType, damage) - 10;
        }
    }
}