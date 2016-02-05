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
        public static List<MissileClient> DangSpells = new List<MissileClient>();
        public static bool ReceivingDangSpell;
        public static bool ReceivingAA;

        public static void Intialize()
        {
            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnBasicAttack;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Obj_AI_Base_OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null) return;
            if (hero.IsAlly) return;

            if (args.Target.IsMe)
            {
                ReceivingAA = true;
                Core.DelayAction(() => ReceivingAA = false, 50);
            }
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (Player.Instance.InDanger(80))
            {
                Chat.Print("In Danger");
            }
            EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.DarkRed, Player.Instance.BoundingRadius, 5f, Player.Instance);

            if (DangSpells != null)
            {
                foreach (var miss in DangSpells)
                {
                    EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.Purple, miss.BoundingRadius +50, 10f, miss);
                }
            }

            if (Missiles != null)
            {
                foreach (var miss in Missiles)
                {
                    EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.Red, miss.BoundingRadius + 40, 10f, miss);
                }
            }
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null) return;

            var champion = missile.SpellCaster as AIHeroClient;
            if (champion == null) return;

            Missiles.Add(missile);

            var spell1 = missile.SpellCaster.Spellbook.Spells.FirstOrDefault(s => s.Name.ToLower().Equals(missile.SData.Name.ToLower()));
            var spell2 = missile.SpellCaster.Spellbook.Spells.FirstOrDefault(s => (s.Name.ToLower() + "missile").Equals(missile.SData.Name.ToLower()));

            var slot = SpellSlot.Unknown;
            if (spell1 != null)
            {
                slot = spell1.Slot;
            }
            else if(spell2 != null)
            {
                slot = spell2.Slot;
            }

            if(slot == SpellSlot.Unknown)return;
            var hero = champion.Hero;

            var dangerousspell =
                DangerousSpells.Spells.FirstOrDefault(
                    x =>
                        x.Hero == hero && slot == x.Slot &&
                        Config.Types.SettingsMenu[x.Hero.ToString() + x.Slot].Cast<CheckBox>().CurrentValue);
            
            if (dangerousspell != null)
            {
                DangSpells.Add(missile);
            }
        }

        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null) return;

            var champion = missile.SpellCaster as AIHeroClient;
            if (champion == null) return;

            Missiles.Remove(missile);

            var spell1 = missile.SpellCaster.Spellbook.Spells.FirstOrDefault(s => s.Name.ToLower().Equals(missile.SData.Name.ToLower()));
            var spell2 = missile.SpellCaster.Spellbook.Spells.FirstOrDefault(s => (s.Name.ToLower() + "missile").Equals(missile.SData.Name.ToLower()));

            var slot = SpellSlot.Unknown;
            if (spell1 != null)
            {
                slot = spell1.Slot;
            }
            else if (spell2 != null)
            {
                slot = spell2.Slot;
            }

            if (slot == SpellSlot.Unknown) return;
            var hero = champion.Hero;

            var dangerousspell =
                DangerousSpells.Spells.FirstOrDefault(
                    x =>
                        x.Hero == hero && slot == x.Slot &&
                        Config.Types.SettingsMenu[x.Hero.ToString() + x.Slot].Cast<CheckBox>().CurrentValue);

            if (dangerousspell != null)
            {
                DangSpells.Remove(missile);
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
            //SkilShot
            if (args.Target == null)
            {
                var projection = Player.Instance.Position.To2D().ProjectOn(args.Start.To2D(), args.End.To2D());

                if (projection.IsOnSegment &&
                    projection.SegmentPoint.Distance(Player.Instance.Position) <=
                    args.SData.CastRadius + Player.Instance.BoundingRadius + 30)
                {
                    if (dangerousspell != null)
                    {
                        ReceivingDangSpell = true;
                        Core.DelayAction(() => ReceivingDangSpell = false, 80);
                    }
                }
            }
            //Targetted spell
            else
            {
                if (dangerousspell != null && args.Target.IsMe)
                {
                    ReceivingDangSpell = true;
                    Core.DelayAction(() => ReceivingDangSpell = false, 80);
                }
            }
        }

        public static bool InDanger(this Obj_AI_Base target, int HealthPercent)
        {
            if (DangSpells.Count > 0)
            {
                return DangSpells != null && DangSpells.Any(miss => miss.IsInRange(target, target.BoundingRadius + 100) || miss.Target == target);
            }
            if (!(target.HealthPercent <= HealthPercent)) return false;
            return Missiles != null && Missiles.Any(miss => miss.IsInRange(target, target.BoundingRadius + 30) || miss.Target == target);
        }
    }
}
