using EloBuddy;
using EloBuddy.SDK;
using KA_Riven.DMGHandler;

namespace KA_Riven.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            if (Player.Instance.InDanger(80) && E.IsReady())
            {
                E.Cast(Player.Instance.Position.Extend(Player.Instance.Direction, E.Range).To3D());
            }
        }
    }
}
