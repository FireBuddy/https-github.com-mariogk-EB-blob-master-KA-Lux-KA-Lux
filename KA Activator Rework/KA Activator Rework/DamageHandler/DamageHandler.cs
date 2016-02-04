using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace KA_Activator_Rework.DamageHandler
{
    public static class DamageHandler
    {
        public static List<MissileClient> Missiles = new List<MissileClient>();
        public static List<DangerousSpell> DangSpells = new List<DangerousSpell>(); 
        public static bool ReceivingDangSpell;

        public static void Intialize()
        {
            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (Player.Instance.InDanger(80))
            {
                Chat.Print("In Danger");
            }
            EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.Red, Player.Instance.BoundingRadius, 5f, Player.Instance);
            if (Missiles != null)
            {
                foreach (var miss in Missiles)
                {
                    EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.Red, miss.BoundingRadius, 5f, miss);
                }
            }
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if(missile == null) return;

            if (missile.SpellCaster.Type == GameObjectType.AIHeroClient)
            {
                Missiles.Add(missile);
            }
        }

        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null) return;
            if (missile.SpellCaster.Type == GameObjectType.AIHeroClient)
            {
                Missiles.Remove(missile);
            }
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || hero.IsAlly) return;

            var dangerousspell =
                DangerousSpells.Spells.FirstOrDefault(
                    x =>
                        x.Hero == hero.Hero && args.Slot == x.Slot &&
                        Config.Types.SettingsMenu[x.Hero.ToString() + x.Slot].Cast<CheckBox>().CurrentValue);

            if (dangerousspell == null) return;

            if (args.Target == null)
            {
                var projection = Player.Instance.Position.To2D().ProjectOn(args.Start.To2D(), args.End.To2D());

                if (!projection.IsOnSegment || !(projection.SegmentPoint.Distance(Player.Instance.Position) <=
                                                 args.SData.CastRadius + Player.Instance.BoundingRadius + 20)) return;
                DangSpells.Add(dangerousspell);
                Core.DelayAction(() => DangSpells.Remove(dangerousspell), 60);
            }
            //Targetted spell
            else
            {
                if (dangerousspell == null || !args.Target.IsMe) return;
                DangSpells.Add(dangerousspell);
                Core.DelayAction(() => DangSpells.Remove(dangerousspell), 60);
            }
        }

        public static bool InDanger(this Obj_AI_Base target, int HealthPercent)
        {
            if (DangSpells != null) return true;
            if (!(target.HealthPercent <= HealthPercent)) return false;
            return Missiles != null && Missiles.Any(miss => miss.IsInRange(target, target.BoundingRadius + 10) || miss.Target == target);
        }
    }
}
