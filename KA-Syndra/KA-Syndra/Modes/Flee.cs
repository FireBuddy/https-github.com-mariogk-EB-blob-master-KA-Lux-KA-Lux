using EloBuddy;
using EloBuddy.SDK;

namespace KA_Syndra.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (Q.IsReady() && E.IsReady())
            {
                Functions.QE(Game.CursorPos);
            }
        }
    }
}
