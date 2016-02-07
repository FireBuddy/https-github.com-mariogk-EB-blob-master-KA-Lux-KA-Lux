using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;

namespace KA_Syndra
{
    internal class Functions
    {
        public static Vector3 GrabWPost(bool onlyQ)
        {
            var sphere =
                ObjectManager.Get<Obj_AI_Base>().FirstOrDefault(a => a.Name == "Seed" && a.IsValid);
            if (sphere != null)
            {
                return sphere.Position;
            }
            if (!onlyQ)
            {
                var minion = EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(SpellManager.W.Range) && m.IsEnemy);
                if (minion != null)
                {
                    return minion.Position;
                }
            }
            return new Vector3();
        }

        public static int SpheresCount()
        { 
            return ObjectManager.Get<Obj_AI_Base>().Count(a => a.Name == "Seed" && a.IsValid);
        }

        public static void QE(Vector3 position)
        {
            if (SpellManager.Q.IsReady() && SpellManager.E.IsReady())
            {
                SpellManager.Q.Cast(Player.Instance.Position.Extend(position, SpellManager.E.Range - 10).To3D());
                SpellManager.E.Cast(Player.Instance.Position.Extend(position, SpellManager.E.Range - 10).To3D());
            }
        }
    }
}
