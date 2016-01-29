using KA_Activator.Maps.HowlingAbyss.SummonerSpells.Spells;

namespace KA_Activator.Maps.HowlingAbyss.SummonerSpells
{
    internal class Initialize : Extensions
    {
        public static int lastSpell;

        public static void Init()
        {
            if (HasSpell("summonerheal"))
            {
                Heal.Initialize();
            }

            if (HasSpell("summonerbarrier"))
            {
                Barrier.Initialize();
            }

            if (HasSpell("summonerexhaust"))
            {
                Exhaust.Initialize();
            }

            if (HasSpell("summonerghost"))
            {
                Ghost.Initialize();
            }
        }

        public static void Execute()
        {
            if (HasSpell("summonerheal"))
            {
                Heal.Execute();
            }

            if (HasSpell("summonerbarrier"))
            {
                Barrier.Execute();
            }

            if (HasSpell("summonerexhaust"))
            {
                Exhaust.Execute();
            }

            if (HasSpell("summonerghost"))
            {
                Ghost.Execute();
            }
        }
    }
}
