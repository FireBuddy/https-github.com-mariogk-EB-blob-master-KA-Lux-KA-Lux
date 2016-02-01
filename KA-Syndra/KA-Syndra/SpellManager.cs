using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace KA_Syndra
{
    public static class SpellManager
    {
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Targeted R { get; private set; }
        public static Spell.Skillshot QE { get; private set; }

        static SpellManager()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 820, SkillShotType.Circular, 600, int.MaxValue, 125)
            {
                AllowedCollisionCount = int.MaxValue
            };
            W = new Spell.Skillshot(SpellSlot.W, 925, SkillShotType.Circular, 350 , 1500, 130)
            {
                AllowedCollisionCount = int.MaxValue, MinimumHitChance = HitChance.High
            };
            E = new Spell.Skillshot(SpellSlot.E, 695, SkillShotType.Cone, 250, 2500, 50)
            {
                AllowedCollisionCount = int.MaxValue
            };
            R = new Spell.Targeted(SpellSlot.R, 695);

            QE = new Spell.Skillshot(SpellSlot.W, 980, SkillShotType.Linear, 600, 2400, 18)
            {
                AllowedCollisionCount = int.MaxValue
            };
        }

        public static void Initialize()
        {
        }
    }
}
