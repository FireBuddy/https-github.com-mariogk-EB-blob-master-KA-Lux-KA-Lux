using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

namespace LelBlanc.Modes
{
    class Flee
    {
        public static void Run()
        {
            if (Program.W.IsReady())
            {
                Program.W.Cast(Player.Instance.Position.Extend(Game.CursorPos, Program.W.Range).To3D());
            }
        }
    }
}
