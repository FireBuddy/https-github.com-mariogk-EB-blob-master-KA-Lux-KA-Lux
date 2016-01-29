using System;
using System.Linq;
using System.Media;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

// ReSharper disable PossibleLossOfFraction

namespace MLG
{
    internal class Program
    {
        #region Images
        private static Sprite HitMarker;
        private static bool CanDrawHitMarker;
        private static Vector2 HitMarkPosition;
        private static Sprite BrazzerSprite;
        private static bool CanDrawBrazzerSprite;
        private static Sprite SanicSprite;
        #endregion Images

        #region Sounds
        private static readonly SoundPlayer WOWSound = new SoundPlayer(Resource1.WOWwav);
        private static readonly SoundPlayer HitMarkerSound = new SoundPlayer(Resource1.hitmarkersound);
        private static readonly SoundPlayer SadMusicSound = new SoundPlayer(Resource1.sadmusic);
        private static readonly SoundPlayer OhMyGodSound = new SoundPlayer(Resource1.ohmygod);
        private static readonly SoundPlayer FuckSound = new SoundPlayer(Resource1.fuck);
        private static readonly SoundPlayer AkbarSound = new SoundPlayer(Resource1.akbar);
        private static readonly SoundPlayer DunkSound = new SoundPlayer(Resource1.dunk);
        private static readonly SoundPlayer SanicSound = new SoundPlayer(Resource1.sanicSound);
        private static bool PlayingSanic;
        #endregion Sounds

        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static readonly TextureLoader TextureLoader = new TextureLoader();

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            #region Sounds

            WOWSound.LoadAsync();

            HitMarkerSound.LoadAsync();

            SadMusicSound.LoadAsync();

            OhMyGodSound.LoadAsync();

            FuckSound.LoadAsync();

            AkbarSound.LoadAsync();

            DunkSound.LoadAsync();

            SanicSound .LoadAsync();

            #endregion Sounds

            #region Images

            TextureLoader.Load("hitmarker", Resource1.hitmark);
            HitMarker = new Sprite(() => TextureLoader["hitmarker"]);
            
            TextureLoader.Load("brazzer", Resource1.brazzer);
            BrazzerSprite = new Sprite(() => TextureLoader["brazzer"]);

            TextureLoader.Load("sanic", Resource1.Sanic);
            SanicSprite = new Sprite(() => TextureLoader["sanic"]);
            #endregion Images

            Chat.Print("MLG Loaded");

            Game.OnNotify += Game_OnNotify;
            Obj_AI_Base.OnPlayAnimation += Obj_AI_Base_OnPlayAnimation;
            Drawing.OnEndScene += Drawing_OnEndScene;
            AttackableUnit.OnDamage += Obj_AI_Base_OnDamage;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
        }

        private static void Obj_AI_Base_OnDamage(AttackableUnit sender, AttackableUnitDamageEventArgs args)
        {
            /*
            var caster = sender as AIHeroClient;
            var target = args.Target as AIHeroClient;

            if (caster == null || target == null || sender.Distance(Player.Instance) > 1500) return;

            HitMarkPosition = args.Target.Position.WorldToScreen();
            CanDrawHitMarker = true;
            HitMarkerSound.Play();
  
            Core.DelayAction(() => CanDrawHitMarker = false, 200);
            */
        }

        private static void Game_OnNotify(GameNotifyEventArgs args)
        {
            if (args.EventId == GameEventId.OnChampionPentaKill)
            {
                OhMyGodSound.Play();
            }

            if (args.EventId == GameEventId.OnAce)
            {
                WOWSound.Play();
            }

            if (args.EventId == GameEventId.OnFirstBlood)
            {
                FuckSound.Play();
                CanDrawBrazzerSprite = true;
                Core.DelayAction(() => CanDrawBrazzerSprite = false, 1500);
            }
        }

        private static void Obj_AI_Base_OnPlayAnimation(Obj_AI_Base sender, GameObjectPlayAnimationEventArgs args)
        {
            if (sender.IsMe && args.Animation.Equals("Death"))
            {
                SadMusicSound.Play();
            }
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            if (CanDrawHitMarker)
            {
                var pos = new Vector2(HitMarkPosition.X - Resource1.hitmark.Width / 2, HitMarkPosition.Y - Resource1.hitmark.Height / 2 -30);
                HitMarker.Draw(pos);
            }

            if (CanDrawBrazzerSprite)
            {
                var pos1 = new Vector2(450, 280);
                BrazzerSprite.Draw(pos1);
            }

            foreach (var hero in EntityManager.Heroes.AllHeroes.Where(h => h.IsHPBarRendered && !h.IsInShopRange() && h.MoveSpeed > 490))
            {
                if (hero != null && !PlayingSanic)
                {
                    PlayingSanic = true;
                    SanicSound.Play();
                    Core.DelayAction(() => PlayingSanic = false, 15000);
                }

                var pos = new Vector2(hero.Position.WorldToScreen().X - Resource1.Sanic.Width / 2, hero.Position.WorldToScreen().Y - Resource1.Sanic.Height / 2 - 30);
                SanicSprite.Draw(pos);
            }
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null)return;

            var herospell = DunkSpells.Spells.FirstOrDefault(x => x.Hero == Player.Instance.Hero && x.Slot == args.Slot);
            if (hero.IsMe && herospell != null && args.Target.IsEnemy)
            {
                DunkSound.Play();
            }

            var heroakbar = AkbarSpells.Spells.FirstOrDefault(x => x.Hero == Player.Instance.Hero && x.Slot == args.Slot);
            if (hero.IsMe && heroakbar != null && args.Target.IsEnemy)
            {
                AkbarSound.Play();
            }
        }
    }
}
