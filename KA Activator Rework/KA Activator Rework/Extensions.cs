using System.Linq;
using EloBuddy;

namespace KA_Activator_Rework
{
    public class Extensions
    {
        public static bool HasSpell(string s)
        {
            return Player.Spells.FirstOrDefault(o => o.SData.Name.Contains(s)) != null;
        }
    }
}
