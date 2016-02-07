using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace KA_Riven
{
    public static class SpellManager
    {
        public static Spell.Active Q { get; private set; }
        public static Spell.Active W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Active R1 { get; private set; }
        public static Spell.Skillshot R2 { get; private set; }

        static SpellManager()
        {
            Q = new Spell.Active(SpellSlot.Q, 280);
            W = new Spell.Active(SpellSlot.W, 240);
            E = new Spell.Skillshot(SpellSlot.E, 350, SkillShotType.Linear, 250, int.MaxValue, 1);
            R1 = new Spell.Active(SpellSlot.R, 600);
            R2 = new Spell.Skillshot(SpellSlot.R, 900, SkillShotType.Cone, 250, 1600, 45)
            {
                AllowedCollisionCount = int.MaxValue
            };
        }

        public static void Initialize()
        {
        }
    }
}
