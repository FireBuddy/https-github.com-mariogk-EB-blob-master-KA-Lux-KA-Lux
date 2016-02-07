using EloBuddy;
using EloBuddy.SDK;

namespace KA_Riven
{
    internal class Functions
    {
        public static void CancelAA()
        {
            Player.DoEmote(Emote.Laugh);
            Orbwalker.ResetAutoAttack();
        }
    }
}
