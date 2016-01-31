using System;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Color = System.Drawing.Color;

// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KA_Syndra
{
    public static class Config
    {
        private static readonly string MenuName = "KA " + Player.Instance.ChampionName;

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("KA " + Player.Instance.ChampionName);
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu SpellsMenu, FarmMenu, MiscMenu, DrawMenu;

            static Modes()
            {
                SpellsMenu = Menu.AddSubMenu("::SpellsMenu::");
                Combo.Initialize();
                Harass.Initialize();

                FarmMenu = Menu.AddSubMenu("::FarmMenu::");
                LaneClear.Initialize();
                LastHit.Initialize();

                MiscMenu = Menu.AddSubMenu("::Misc::");
                Misc.Initialize();

                DrawMenu = Menu.AddSubMenu("::Drawings::");
                Draw.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    SpellsMenu.AddGroupLabel("Combo Spells:");
                    _useQ = SpellsMenu.Add("comboQ", new CheckBox("Use Q on Combo ?"));
                    _useW = SpellsMenu.Add("comboW", new CheckBox("Use W on Combo ?"));
                    _useE = SpellsMenu.Add("comboE", new CheckBox("Use E on Combo ?"));
                    _useR = SpellsMenu.Add("comboR", new CheckBox("Use R to finish the target on Combo ?"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _manaHarass;
                //Auto
                private static readonly KeyBind _autoHarassKey;
                private static readonly CheckBox _useAutoQ;
                private static readonly CheckBox _useAutoW;
                private static readonly CheckBox _useAutoE;
                private static readonly Slider _manaAutoHarass;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int ManaHarass
                {
                    get { return _manaHarass.CurrentValue; }
                }
                //Auto
                public static bool KeyAutoHarass
                {
                    get { return _autoHarassKey.CurrentValue; }
                }

                public static bool UseAutoQ
                {
                    get { return _useAutoQ.CurrentValue; }
                }

                public static bool UseAutoW
                {
                    get { return _useAutoW.CurrentValue; }
                }

                public static bool UseAutoE
                {
                    get { return _useAutoE.CurrentValue; }
                }

                public static int ManaAutoHarass
                {
                    get { return _manaAutoHarass.CurrentValue; }
                }

                static Harass()
                {
                    SpellsMenu.AddGroupLabel("Harass Spells:");
                    _useQ = SpellsMenu.Add("harassQ", new CheckBox("Use Q on Harass ?"));
                    _useW = SpellsMenu.Add("harassW", new CheckBox("Use W on Harass ?"));
                    _useE = SpellsMenu.Add("harassE", new CheckBox("Use E on Harass ?"));
                    SpellsMenu.AddGroupLabel("Harass Settings:");
                    _manaHarass = SpellsMenu.Add("harassMana", new Slider("It will only cast any harass spell if the mana is greater than ({0}).", 30));
                    SpellsMenu.AddGroupLabel("AutoHarass Spells:");
                    _autoHarassKey = SpellsMenu.Add("autoHarassKey",
                        new KeyBind("Switch On/Off AutoHarass", false, KeyBind.BindTypes.PressToggle, 'Z'));
                    _useAutoQ = SpellsMenu.Add("autoharassQ", new CheckBox("Use Q on AutoHarass ?"));
                    _useAutoW = SpellsMenu.Add("autoharassW", new CheckBox("Use W on AutoHarass ?"));
                    _useAutoE = SpellsMenu.Add("autoharassE", new CheckBox("Use E on AutoHarass ?", false));
                    SpellsMenu.AddGroupLabel("AutoHarass Settings:");
                    _manaAutoHarass = SpellsMenu.Add("autoharassMana", new Slider("It will only cast any harass spell if the mana is greater than ({0}).", 30));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly Slider _laneMana;
                private static readonly Slider _xCount;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static int LaneMana
                {
                    get { return _laneMana.CurrentValue; }
                }

                public static int XCount
                {
                    get { return _xCount.CurrentValue; }
                }

                static LaneClear()
                {
                    FarmMenu.AddGroupLabel("LaneClear Spells:");
                    _useQ = FarmMenu.Add("laneclearQ", new CheckBox("Use Q on Laneclear ?"));
                    _useW = FarmMenu.Add("laneclearW", new CheckBox("Use W on Laneclear ?"));
                    FarmMenu.AddGroupLabel("LaneClear Settings:");
                    _laneMana = FarmMenu.Add("laneMana", new Slider("It will only cast any laneclear spell if the mana is greater than ({0}).", 30));
                    _xCount = FarmMenu.Add("qCount", new Slider("It will only cast Q spell if it`ll hit ({0}).", 3, 1, 6));
                }

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _lastMana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static int LastMana
                {
                    get { return _lastMana.CurrentValue; }
                }

                static LastHit()
                {
                    FarmMenu.AddGroupLabel("LastHit Spells:");
                    _useQ = FarmMenu.Add("lasthitQ", new CheckBox("Use Q on LastHit ?"));
                    FarmMenu.AddGroupLabel("LastHit Settings:");
                    _lastMana = FarmMenu.Add("lastMana", new Slider("It will only cast any laneclear spell if the mana is greater than ({0}).", 30));
                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly CheckBox _interruptSpell;
                private static readonly CheckBox _antiGapCloserSpell;
                private static readonly Slider _miscMana;
                private static readonly CheckBox _useRToKS;
                private static readonly Slider _overKillR;

                public static bool InterruptSpell
                {
                    get { return _interruptSpell.CurrentValue; }
                }

                public static bool AntiGapCloser
                {
                    get { return _antiGapCloserSpell.CurrentValue; }
                }

                public static int MiscMana
                {
                    get { return _miscMana.CurrentValue; }
                }
                //
                public static bool RKS
                {
                    get { return _useRToKS.CurrentValue; }
                }
                public static int OverkillR
                {
                    get { return _overKillR.CurrentValue; }
                }

                static Misc()
                {
                    // Initialize the menu values
                    MiscMenu.AddGroupLabel("Miscellaneous");
                    _interruptSpell = MiscMenu.Add("interruptQE", new CheckBox("Use QE to interrupt spells ?"));
                    _antiGapCloserSpell = MiscMenu.Add("gapcloserQE", new CheckBox("Use QE to antigapcloser spells ?"));
                    _miscMana = MiscMenu.Add("miscMana", new Slider("Min mana to use gapcloser/interrupt spells ?", 20));
                    MiscMenu.AddGroupLabel("R KS Settings");
                    _useRToKS = MiscMenu.Add("useRtoKS", new CheckBox("Use R to kill steal ?"));
                    _overKillR = MiscMenu.Add("overkillR", new Slider("Target`s health must be greater than ({0}) to use R.", 150, 1 , 800));
                }

                public static void Initialize()
                {
                }
            }

            public static class Draw
            {
                private static readonly CheckBox _drawReady;
                private static readonly CheckBox _drawHealth;
                private static readonly CheckBox _drawPercent;
                private static readonly CheckBox _drawStatiscs;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;
                //Spheres
                private static readonly CheckBox _drawSpheres;
                //Color Config
                private static readonly ColorConfig _qColor;
                private static readonly ColorConfig _wColor;
                private static readonly ColorConfig _eColor;
                private static readonly ColorConfig _rColor;
                private static readonly ColorConfig _healthColor;
                //Spheres Color
                private static readonly ColorConfig _drawSpheresColor;

                //CheckBoxes
                public static bool DrawReady
                {
                    get { return _drawReady.CurrentValue; }
                }

                public static bool DrawHealth
                {
                    get { return _drawHealth.CurrentValue; }
                }

                public static bool DrawPercent
                {
                    get { return _drawPercent.CurrentValue; }
                }

                public static bool DrawStatistics
                {
                    get { return _drawStatiscs.CurrentValue; }
                }

                public static bool DrawQ
                {
                    get { return _drawQ.CurrentValue; }
                }

                public static bool DrawW
                {
                    get { return _drawW.CurrentValue; }
                }

                public static bool DrawE
                {
                    get { return _drawE.CurrentValue; }
                }

                public static bool DrawR
                {
                    get { return _drawR.CurrentValue; }
                }
                //Sphere
                public static bool DrawSphere
                {
                    get { return _drawSpheres.CurrentValue; }
                }
                //Colors
                public static Color HealthColor
                {
                    get { return _healthColor.GetSystemColor(); }
                }

                public static SharpDX.Color QColor
                {
                    get { return _qColor.GetSharpColor(); }
                }

                public static SharpDX.Color WColor
                {
                    get { return _wColor.GetSharpColor(); }
                }

                public static SharpDX.Color EColor
                {
                    get { return _eColor.GetSharpColor(); }
                }
                public static SharpDX.Color RColor
                {
                    get { return _rColor.GetSharpColor(); }
                }
                public static SharpDX.Color SphereColor
                {
                    get { return _drawSpheresColor.GetSharpColor(); }
                }

                static Draw()
                {
                    DrawMenu.AddGroupLabel("Spell drawings Settings :");
                    _drawReady = DrawMenu.Add("drawOnlyWhenReady", new CheckBox("Draw the spells only if they are ready ?"));
                    _drawHealth = DrawMenu.Add("damageIndicatorDraw", new CheckBox("Draw damage indicator ?"));
                    _drawPercent = DrawMenu.Add("percentageIndicatorDraw", new CheckBox("Draw damage percentage ?"));
                    _drawStatiscs = DrawMenu.Add("statiscsIndicatorDraw", new CheckBox("Draw damage statistics ?"));
                    DrawMenu.AddSeparator(1);
                    _drawQ = DrawMenu.Add("qDraw", new CheckBox("Draw Q spell range ?"));
                    _drawW = DrawMenu.Add("wDraw", new CheckBox("Draw W spell range ?"));
                    _drawE = DrawMenu.Add("eDraw", new CheckBox("Draw E spell range ?"));
                    _drawR = DrawMenu.Add("rDraw", new CheckBox("Draw R spell range ?"));
                    _drawSpheres = DrawMenu.Add("sphereDraw", new CheckBox("Draw Speheres ?"));

                    _healthColor = new ColorConfig(DrawMenu, "healthColorConfig", Color.Orange, "Color Damage Indicator:");
                    _qColor = new ColorConfig(DrawMenu, "qColorConfig", Color.Blue, "Color Q:");
                    _wColor = new ColorConfig(DrawMenu, "wColorConfig", Color.Red, "Color W:");
                    _eColor = new ColorConfig(DrawMenu, "eColorConfig", Color.DeepPink, "Color E:");
                    _rColor = new ColorConfig(DrawMenu, "rColorConfig", Color.Yellow, "Color R:");
                    _drawSpheresColor = new ColorConfig(DrawMenu, "sphereColorConfig", Color.Purple, "Color Spheres:");
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}