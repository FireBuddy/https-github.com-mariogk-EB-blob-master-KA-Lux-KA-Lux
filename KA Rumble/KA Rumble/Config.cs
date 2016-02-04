using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using KA_Rumble.DMGHandler;
using Color = System.Drawing.Color;

// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KA_Rumble
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
            public static readonly Menu SettingsMenu;

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

                SettingsMenu = Menu.AddSubMenu("::Settings::");
                Settings.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                private static readonly Slider _minR;
                private static readonly CheckBox _useRKillable;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int MinR
                {
                    get { return _minR.CurrentValue; }
                }
                public static bool UseRKillable
                {
                    get { return _useRKillable.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    SpellsMenu.AddGroupLabel("Combo Spells:");
                    _useQ = SpellsMenu.Add("comboQ", new CheckBox("Use Q on Combo ?"));
                    _useE = SpellsMenu.Add("comboE", new CheckBox("Use E on Combo ?"));
                    _useR = SpellsMenu.Add("comboR", new CheckBox("Use R on Combo ?"));
                    SpellsMenu.AddLabel("R Settings:");
                    _minR = SpellsMenu.Add("minR", new Slider("Minimun enemies to use R ?",2,0,5));
                    _useRKillable  = SpellsMenu.Add("comboRKill", new CheckBox("Only use R if it will kill at least one ?",false));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                static Harass()
                {
                    SpellsMenu.AddGroupLabel("Harass Spells:");
                    _useQ = SpellsMenu.Add("harassQ", new CheckBox("Use Q on Harass ?"));
                    _useE = SpellsMenu.Add("harassE", new CheckBox("Use E on Harass ?"));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                static LaneClear()
                {
                    FarmMenu.AddGroupLabel("LaneClear Spells:");
                    _useQ = FarmMenu.Add("laneclearQ", new CheckBox("Use Q on Laneclear ?"));
                    _useE = FarmMenu.Add("laneclearE", new CheckBox("Use E on Laneclear ?"));
                }

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                private static readonly CheckBox _useE;

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                static LastHit()
                {
                    FarmMenu.AddGroupLabel("LastHit Spells:");
                    _useE = FarmMenu.Add("lasthitE", new CheckBox("Use E on LastHit ?"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly CheckBox _antiGapCloserSpell;

                public static bool AntiGapCloser
                {
                    get { return _antiGapCloserSpell.CurrentValue; }
                }
                static Misc()
                {
                    // Initialize the menu values
                    MiscMenu.AddGroupLabel("Miscellaneous");
                    _antiGapCloserSpell = MiscMenu.Add("gapcloserE", new CheckBox("Use E to antigapcloser spells ?"));
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
                //Color Config
                private static readonly ColorConfig _qColor;
                private static readonly ColorConfig _wColor;
                private static readonly ColorConfig _eColor;
                private static readonly ColorConfig _rColor;
                private static readonly ColorConfig _healthColor;

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

                    _healthColor = new ColorConfig(DrawMenu, "healthColorConfig", Color.Orange, "Color Damage Indicator:");
                    _qColor = new ColorConfig(DrawMenu, "qColorConfig", Color.Blue, "Color Q:");
                    _wColor = new ColorConfig(DrawMenu, "wColorConfig", Color.Red, "Color W:");
                    _eColor = new ColorConfig(DrawMenu, "eColorConfig", Color.DeepPink, "Color E:");
                    _rColor = new ColorConfig(DrawMenu, "rColorConfig", Color.Yellow, "Color R:");
                }

                public static void Initialize()
                {
                }
            }

            public static class Settings
            {
                //Danger
                private static readonly Slider EnemyRange;
                private static readonly Slider EnemySlider;
                private static readonly CheckBox Spells;
                private static readonly CheckBox Skillshots;
                private static readonly CheckBox AAs;


                public static int RangeEnemy
                {
                    get { return EnemyRange.CurrentValue; }
                }

                public static int EnemyCount
                {
                    get { return EnemySlider.CurrentValue; }
                }

                public static bool ConsiderSpells
                {
                    get { return Spells.CurrentValue; }
                }

                public static bool ConsiderSkillshots
                {
                    get { return Skillshots.CurrentValue; }
                }

                public static bool ConsiderAttacks
                {
                    get { return AAs.CurrentValue; }
                }

                static Settings()
                {
                    SettingsMenu.AddGroupLabel("Danger W Settings");
                    EnemySlider = SettingsMenu.Add("minenemiesinrange", new Slider("Min enemies in the range determined below", 1, 1, 5));
                    EnemyRange = SettingsMenu.Add("minrangeenemy", new Slider("Enemies must be in ({0}) range to be in danger", 1000, 600, 2500));
                    Spells = SettingsMenu.Add("considerspells", new CheckBox("Consider spells ?"));
                    Skillshots = SettingsMenu.Add("considerskilshots", new CheckBox("Consider SkillShots ?"));
                    AAs = SettingsMenu.Add("consideraas", new CheckBox("Consider Auto Attacks ?"));
                    SettingsMenu.AddSeparator();
                    SettingsMenu.AddGroupLabel("Dangerous Spells");
                    foreach (var spell in DangerousSpells.Spells.Where(x => EntityManager.Heroes.Enemies.Any(b => b.Hero == x.Hero)))
                    {
                        SettingsMenu.Add(spell.Hero.ToString() + spell.Slot, new CheckBox(spell.Hero + " - " + spell.Slot + ".", spell.DefaultValue));
                    }
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}