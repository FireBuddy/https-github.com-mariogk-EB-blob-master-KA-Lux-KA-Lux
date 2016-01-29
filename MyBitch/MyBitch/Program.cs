using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Color = System.Drawing.Color;

namespace MyBitch
{
    internal class Program
    {
        private static readonly Vector3 place1 = new Vector3(6900f, 1800f, -189f);
        private static readonly Vector3 place2 = new Vector3(7900f, 1800f, -189f);
        private static readonly Vector3 place3 = new Vector3(7900f, 2000f, -189f);
        private static readonly Vector3 place4 = new Vector3(6900f, 2000f, -189f);

        private static Spell.Active Recall;

        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Game_OnTick(EventArgs args)
        {
            
            if (Player.Instance.Distance(place1) > 2000)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place1);
            }

            //Square
            if (Player.Instance.Distance(place1) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place2);
            }

            if (Player.Instance.Distance(place2) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place3);
            }

            if (Player.Instance.Distance(place3) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place4);
            }

            if (Player.Instance.Distance(place4) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place1);
            }
            
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            new Circle { Color = Color.Red, BorderWidth = 4f, Radius = 10 }.Draw(place1);
        }
    }
}
