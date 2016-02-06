using System.Collections.Generic;
using EloBuddy;

namespace KA_Activator_Rework.DamageHandler
{
    public class SpecialSpell
    {
        public SpecialSpell(Champion _hero, SpellSlot slot, bool defaultvalue, int delay)
        {
            Slot = slot;
            Hero = _hero;
            DefaultValue = defaultvalue;
            Delay = delay;
        }

        public SpellSlot Slot;
        public Champion Hero;
        public bool DefaultValue;
        public int Delay;
    }

    public class SpecialSpells
    {
        public static List<SpecialSpell> Spells = new List<SpecialSpell>
        {
            new SpecialSpell(Champion.Lux, SpellSlot.R, true, 0),
            //new SpecialSpell(Champion.Xerath, SpellSlot.Q, true, 20),
        };
    }
}

