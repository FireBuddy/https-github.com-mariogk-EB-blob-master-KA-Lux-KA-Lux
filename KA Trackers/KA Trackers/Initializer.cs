using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace KA_Trackers
{
    internal class Initializer
    {
        public static void Init()
        {
            Config.Initialize();

            RecallTracker.Initialize();

            SpellsTracker.Initialize();

            #region EventsIntializers
            Drawing.OnEndScene += Drawing_OnEndScene;
            Teleport.OnTeleport += Teleport_OnTeleport;
            //For tracker only
            AppDomain.CurrentDomain.DomainUnload += OnUnload;
            AppDomain.CurrentDomain.ProcessExit += OnUnload;
            #endregion EventsIntializers
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            #region RecallTracker
            RecallTracker.DrawOnEnd(args);
            #endregion RecallTracker

            #region SpellsTracker
            SpellsTracker.OnDrawEnd(args);
            #endregion SpellsTracker
        }

        private static void Teleport_OnTeleport(Obj_AI_Base sender, Teleport.TeleportEventArgs args)
        {
            #region RecallTracker
            var hero = sender as AIHeroClient;

            RecallTracker.OnTeleport(hero, args);
            #endregion RecallTracker
        }

        private static void OnUnload(object sender, EventArgs e)
        {
            #region RecallTracker
            SpellsTracker.OnUnload(sender, e);
            #endregion RecallTracker
        }
    }
}
