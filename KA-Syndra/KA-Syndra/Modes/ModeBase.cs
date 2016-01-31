using EloBuddy.SDK;

namespace KA_Syndra.Modes
{
    public abstract class ModeBase
    {
        protected static Spell.Skillshot Q
        {
            get { return SpellManager.Q; }
        }
        protected static Spell.Skillshot W
        {
            get { return SpellManager.W; }
        }
        protected static Spell.Skillshot E
        {
            get { return SpellManager.E; }
        }
        protected static Spell.Targeted R
        {
            get { return SpellManager.R; }
        }
        protected static Spell.Skillshot QE
        {
            get { return SpellManager.QE; }
        }


        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
