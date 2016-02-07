using EloBuddy.SDK;

namespace KA_Riven.Modes
{
    public abstract class ModeBase
    {
        protected static Spell.Active Q
        {
            get { return SpellManager.Q; }
        }
        protected static Spell.Active W
        {
            get { return SpellManager.W; }
        }
        protected static Spell.Skillshot E
        {
            get { return SpellManager.E; }
        }
        protected static Spell.Active R1
        {
            get { return SpellManager.R1; }
        }
        protected static Spell.Skillshot R2
        {
            get { return SpellManager.R2; }
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
