using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;

namespace CollTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static Spell.Skillshot Q;
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            var range = Player.Instance.Spellbook.GetSpell(SpellSlot.Q).SData.CastRangeDisplayOverride;
            var width = Player.Instance.Spellbook.GetSpell(SpellSlot.Q).SData.LineWidth;

            Q = new Spell.Skillshot(SpellSlot.Q, (uint)range, SkillShotType.Linear, 250, int.MaxValue, (int)width)
            {
                AllowedCollisionCount = 1
            };

            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
            Chat.Print("Loaded");
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.AliceBlue, Q.Range, 3f, Player.Instance);
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.Combo)
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Mixed);
                if (Q.IsReady() && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(target);
                }
            }
        }
    }
}
