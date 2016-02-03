using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace CollTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            SpellManager.Initialize();
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
            Chat.Print("Loaded");
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (SpellManager.Q.IsReady())
            {
                EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.AliceBlue, SpellManager.Q.Range, 3f, Player.Instance);
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.Combo)
            {
                var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Mixed);
                if (SpellManager.Q.IsReady() && target.IsValidTarget(SpellManager.Q.Range))
                {
                    SpellManager.Q.Cast(target);
                }
            }
        }
    }
}
