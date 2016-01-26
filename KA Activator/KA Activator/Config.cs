using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KA_Activator
{
    internal static class Config
    {
        private static readonly Menu FirstMenu;

        static Config()
        {
            // Initialize the menu
            FirstMenu = MainMenu.AddMenu("KA Activator", "kaactivator");
            FirstMenu.AddGroupLabel("KA Activator");
            FirstMenu.AddLabel("Made By: MarioGK", 50);

            // Initialize the modes
            Types.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Types
        {
            private static readonly Menu OffensiveMenu, DefensiveMenu, ConsumablesMenu;
            public static readonly Menu SummonerMenu, SettingsMenu;

            static Types()
            {
                OffensiveMenu = FirstMenu.AddSubMenu("::Offensive Items::");
                OffensiveItems.Initialize();

                DefensiveMenu = FirstMenu.AddSubMenu("::Defensive Items::");
                DeffensiveItems.Initialize();

                ConsumablesMenu = FirstMenu.AddSubMenu("::Consumables Items::");
                ConsumablesItems.Initialize();

                SummonerMenu = FirstMenu.AddSubMenu("::Summoner Spells::");
                SummonerSpells.Initialize();

                SettingsMenu = FirstMenu.AddSubMenu("::Settings::");
                Settings.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class OffensiveItems
            {
                private static readonly CheckBox UseMuramana;
                private static readonly CheckBox UseFrostQueen;

                #region Bilgewater

                private static readonly CheckBox UseBilgewater;
                private static readonly Slider TargetHpBilgewater;

                public static bool Bilgewater
                {
                    get { return UseBilgewater.CurrentValue; }
                }

                public static int BilgewaterTargetHp
                {
                    get { return TargetHpBilgewater.CurrentValue; }
                }

                #endregion Bilgewater

                #region BladeOfTheRuinedKing

                private static readonly CheckBox UseBlade;
                private static readonly Slider MyHpBlade;
                private static readonly Slider TargetHpBlade;

                public static bool Blade
                {
                    get { return UseBlade.CurrentValue; }
                }

                public static int BladeMyHp
                {
                    get { return MyHpBlade.CurrentValue; }
                }

                public static int BladeTargetHp
                {
                    get { return TargetHpBlade.CurrentValue; }
                }

                #endregion BladeOfTheRuinedKing

                #region Tiamat

                private static readonly CheckBox UseTiamat;
                private static readonly Slider TargetHpTiamat;

                public static bool Tiamat
                {
                    get { return UseTiamat.CurrentValue; }
                }

                public static int TiamatTargetHp
                {
                    get { return TargetHpTiamat.CurrentValue; }
                }

                #endregion Tiamat

                #region Hydra

                private static readonly CheckBox UseHydra;
                private static readonly Slider TargetHpHydra;

                public static bool Hydra
                {
                    get { return UseHydra.CurrentValue; }
                }

                public static int HydraTargetHp
                {
                    get { return TargetHpHydra.CurrentValue; }
                }

                #endregion Hydra

                #region Titanic

                private static readonly CheckBox UseTitanicHydra;
                private static readonly Slider TargetHpTitanicHydra;

                public static bool Titanic
                {
                    get { return UseTitanicHydra.CurrentValue; }
                }

                public static int TitanicTargetHp
                {
                    get { return TargetHpTitanicHydra.CurrentValue; }
                }

                #endregion Titanic

                #region Youmuu

                private static readonly CheckBox UseYoumuu;
                private static readonly Slider TargetHpYoumuu;

                public static bool Youmuu
                {
                    get { return UseYoumuu.CurrentValue; }
                }

                public static int YoumuuTargetHp
                {
                    get { return TargetHpYoumuu.CurrentValue; }
                }

                #endregion Youmuu

                #region Hextech

                private static readonly CheckBox UseHextech;
                private static readonly Slider TargetHpHextech;

                public static bool Hextech
                {
                    get { return UseHextech.CurrentValue; }
                }

                public static int HextechTargetHp
                {
                    get { return TargetHpHextech.CurrentValue; }
                }

                #endregion Hextech


                #region Offensive Menu

                static OffensiveItems()
                {
                    // Initialize the menu values
                    OffensiveMenu.AddGroupLabel("Bilgewater Cutlass");
                    UseBilgewater = OffensiveMenu.Add("useBilgewater", new CheckBox("Use Bilgewater Cutlass ?"));
                    TargetHpBilgewater = OffensiveMenu.Add("useBilgewaterTargetHP",
                        new Slider("Use Bilgewater Cutlass When Target`s Health hits X%", 80));

                    OffensiveMenu.AddGroupLabel("Blade Of The Ruined King");
                    UseBlade = OffensiveMenu.Add("useBlade", new CheckBox("Use Blade Of The Ruined King ?"));
                    MyHpBlade = OffensiveMenu.Add("useBladeMyHP",
                        new Slider("Use Blade Of The Ruined King When My Health hits X%", 80));
                    TargetHpBlade = OffensiveMenu.Add("useBladeTargetHP",
                        new Slider("Use Blade Of The Ruined King When Target`s Health hits X%", 80));

                    OffensiveMenu.AddGroupLabel("Tiamat");
                    UseTiamat = OffensiveMenu.Add("useTiamat", new CheckBox("Use Tiamat ?"));
                    TargetHpTiamat = OffensiveMenu.Add("useTiamatTargetHP",
                        new Slider("Use Tiamat When Target`s Health hits X%", 80));

                    OffensiveMenu.AddGroupLabel("Ravenous Hydra");
                    UseHydra = OffensiveMenu.Add("useHydra", new CheckBox("Use Ravenous Hydra ?"));
                    TargetHpHydra = OffensiveMenu.Add("useHydraTargetHP",
                        new Slider("Use Ravenous Hydra When Target`s Health hits X%", 80));

                    OffensiveMenu.AddGroupLabel("Titanic Hydra");
                    UseTitanicHydra = OffensiveMenu.Add("useTitanic", new CheckBox("Use Titanic Hydra ?"));
                    TargetHpTitanicHydra = OffensiveMenu.Add("useTitanicTargetHP",
                        new Slider("Use Titanic Hydra When Target`s Health hits X%", 80));

                    OffensiveMenu.AddGroupLabel("Youmuu");
                    UseYoumuu = OffensiveMenu.Add("useYoumuu ", new CheckBox("Use Youmuu ?"));
                    TargetHpYoumuu = OffensiveMenu.Add("useYoumuuTargetHP",
                        new Slider("Use Youmuu  When Target`s Health hits X%", 80));

                    OffensiveMenu.AddGroupLabel("Hextech");
                    UseHextech = OffensiveMenu.Add("useHextech", new CheckBox("Use Hextech ?"));
                    TargetHpHextech = OffensiveMenu.Add("useHextechTargetHP",
                        new Slider("Use Hextech When Target`s Health hits X%", 80));
                   
                }

                #endregion Offensive Menu

                public static void Initialize()
                {
                }
            }

            public static class DeffensiveItems
            {
                #region Zhonyas

                private static readonly CheckBox UseZhonyas;
                private static readonly Slider HpZhonyas;

                public static bool Zhonyas
                {
                    get { return UseZhonyas.CurrentValue; }
                }

                public static int ZhonyasMyHp
                {
                    get { return HpZhonyas.CurrentValue; }
                }

                #endregion Zhonyas

                #region ArchengelStaff

                private static readonly CheckBox _useArchengelStaff;
                private static readonly Slider _myHPArchengelStaff;

                public static bool UseArchengelStaff
                {
                    get { return _useArchengelStaff.CurrentValue; }
                }

                public static int MYHPArchengelStaff
                {
                    get { return _myHPArchengelStaff.CurrentValue; }
                }

                #endregion ArchengelStaff

                #region FaceOfTheMountain

                private static readonly CheckBox _useFaceOfTheMountain;
                private static readonly Slider _myHPFaceOfTheMountain;

                public static bool UseFaceOfTheMountain
                {
                    get { return _useFaceOfTheMountain.CurrentValue; }
                }

                public static int MYHPFaceOfTheMountain
                {
                    get { return _myHPFaceOfTheMountain.CurrentValue; }
                }

                #endregion FaceOfTheMountain

                #region Talisman

                private static readonly CheckBox _useTalisman;
                private static readonly Slider _myHPTalisman;

                public static bool UseTalisman
                {
                    get { return _useTalisman.CurrentValue; }
                }

                public static int MYHPTalisman
                {
                    get { return _myHPTalisman.CurrentValue; }
                }

                #endregion Talisman

                static DeffensiveItems()
                {
                    DefensiveMenu.AddGroupLabel("Zhonyas");
                    UseZhonyas = DefensiveMenu.Add("useZhonyas", new CheckBox("Use Zhonyas ?"));
                    HpZhonyas = DefensiveMenu.Add("useZhonyasrMyHP",
                        new Slider("Use Zhonyas When My Health hits {0}%", 20));

                    DefensiveMenu.AddGroupLabel("Archengel Staff");
                    _useArchengelStaff = DefensiveMenu.Add("useArchengelStaff", new CheckBox("Use ArchengelStaff ?"));
                    _myHPFaceOfTheMountain = DefensiveMenu.Add("useArchengelStaffMyHP",
                        new Slider("Use ArchengelStaff When My Health hits {0}%", 30));

                    DefensiveMenu.AddGroupLabel("Face Of The Mountain");
                    _useFaceOfTheMountain = DefensiveMenu.Add("useFaceOfTheMountain", new CheckBox("Use ArchengelStaff ?"));
                    _myHPFaceOfTheMountain = DefensiveMenu.Add("useFaceOfTheMountainMyHP",
                        new Slider("Use Face Of The Mountain When My Health hits {0}%", 30));

                    DefensiveMenu.AddGroupLabel("Talisman");
                    _useTalisman = DefensiveMenu.Add("useTalisman", new CheckBox("Use Talisman?"));
                    _myHPTalisman = DefensiveMenu.Add("useTalismanMyHP",
                        new Slider("Use Talisman When My Health hits {0}%", 30));
                }

                public static void Initialize()
                {
                }
                
                }

                public static class ConsumablesItems
            {
                #region HP Pot

                private static readonly CheckBox UseHealthPot;
                private static readonly Slider MinHealthPot;

                public static bool UseHPpot
                {
                    get { return UseHealthPot.CurrentValue; }
                }

                public static int MinHPpot
                {
                    get { return MinHealthPot.CurrentValue; }
                }

                #endregion HP Pot

                #region Biscuit

                private static readonly CheckBox UseBiscuit;
                private static readonly Slider MinHealthBiscuit;
                private static readonly Slider MinManaBiscuit;

                public static bool UseBiscuits
                {
                    get { return UseBiscuit.CurrentValue; }
                }

                public static int MinBiscuitHp
                {
                    get { return MinHealthBiscuit.CurrentValue; }
                }

                public static int MinBiscuitMp
                {
                    get { return MinManaBiscuit.CurrentValue; }
                }

                #endregion Biscuit

                #region Refill

                private static readonly CheckBox UseRefillPotion;
                private static readonly Slider MinHPRefillPotion;

                public static bool UseRefillPOT
                {
                    get { return UseRefillPotion.CurrentValue; }
                }

                public static int MinRefillHp
                {
                    get { return MinHPRefillPotion.CurrentValue; }
                }

                #endregion Refill

                #region Corrupt

                private static readonly CheckBox UseCorrupt;
                private static readonly Slider MinHealthCorrupt;
                private static readonly Slider MinManaCorrupt;

                public static bool UseCorrupts
                {
                    get { return UseCorrupt.CurrentValue; }
                }

                public static int MinCorruptHp
                {
                    get { return MinHealthCorrupt.CurrentValue; }
                }

                public static int MinCorruptMp
                {
                    get { return MinManaCorrupt.CurrentValue; }
                }

                #endregion Corrupt

                #region Hunter`s

                private static readonly CheckBox UseHunter;
                private static readonly Slider MinHealthHunter;
                private static readonly Slider MinManaHunter;
                private static readonly CheckBox UseHunterMinionWillDie;

                public static bool UseHunters
                {
                    get { return UseHunter.CurrentValue; }
                }

                public static int MinHunterHp
                {
                    get { return MinHealthHunter.CurrentValue; }
                }

                public static int MinHunterMp
                {
                    get { return MinManaHunter.CurrentValue; }
                }

                public static bool UseHuntersMinionWillDie
                {
                    get { return UseHunterMinionWillDie.CurrentValue; }
                }

                #endregion Hunter`s

                static ConsumablesItems()
                {
                    ConsumablesMenu.AddGroupLabel("Health Pot");
                    UseHealthPot = ConsumablesMenu.Add("useHealthPot", new CheckBox("Use Health Pot ?"));
                    MinHealthPot = ConsumablesMenu.Add("minHealthPot", new Slider("Min Health to use Health Pot", 30));

                    ConsumablesMenu.AddGroupLabel("Biscuit");
                    UseBiscuit = ConsumablesMenu.Add("useBiscuit", new CheckBox("Use Biscuit ?"));
                    MinHealthBiscuit = ConsumablesMenu.Add("minhpBiscuit", new Slider("Min Health to use Biscuit", 30));
                    MinManaBiscuit = ConsumablesMenu.Add("minmpBiscuit", new Slider("Min Mana to use Biscuit", 30));

                    ConsumablesMenu.AddGroupLabel("Refill Potion");
                    UseRefillPotion = ConsumablesMenu.Add("useRefill", new CheckBox("Use Refill Potion ?"));
                    MinHPRefillPotion = ConsumablesMenu.Add("minhpRefill",
                        new Slider("Min Health to use Refill Potion", 30));

                    ConsumablesMenu.AddGroupLabel("Corrupt Potion");
                    UseCorrupt = ConsumablesMenu.Add("useCorrupt", new CheckBox("Use Corrupt Potion ?"));
                    MinHealthCorrupt = ConsumablesMenu.Add("minhpCorrupt",
                        new Slider("Min Health to use Corrupt Potion", 30));
                    MinManaCorrupt = ConsumablesMenu.Add("minmpCorrupt",
                        new Slider("Min Mana to use Corrupt Potion", 30));

                    ConsumablesMenu.AddGroupLabel("Hunter`s Potion");
                    UseHunter = ConsumablesMenu.Add("useHunter", new CheckBox("Use Hunter`s Potion ?"));
                    MinHealthHunter = ConsumablesMenu.Add("minhpHunter",
                        new Slider("Min Health to use Hunter`s Potion", 30));
                    MinManaHunter = ConsumablesMenu.Add("minmpHunter", new Slider("Min Mana to use Hunter`s Potion", 30));
                    UseHunterMinionWillDie = ConsumablesMenu.Add("useHunterMinionWillDie",
                        new CheckBox("Use Hunter`s Potion when jungle minion will die ?"));
                }

                public static void Initialize()
                {
                }
            }

            public static class SummonerSpells
            {
                #region Smite

                private static readonly CheckBox UseSmite;
                private static readonly CheckBox UseSmiteDuel;
                private static readonly CheckBox UseSmiteKs;


                public static bool Smite
                {
                    get { return UseSmite.CurrentValue; }
                }

                public static bool DuelSmite
                {
                    get { return UseSmiteDuel.CurrentValue; }
                }

                public static bool KsSmite
                {
                    get { return UseSmiteKs.CurrentValue; }
                }

                #endregion Smite

                #region Heal

                private static readonly CheckBox _useHeal;
                private static readonly Slider _healHealth;
                private static readonly CheckBox _useHealAlly;
                private static readonly Slider _healAllyHealth;

                public static bool UseHeal
                {
                    get { return _useHeal.CurrentValue; }
                }
                
                public static int HealHealth
                {
                    get { return _healHealth.CurrentValue; }
                }

                public static bool UseHealAlly
                {
                    get { return _useHealAlly.CurrentValue; }
                }

                public static int HealAllyHealth
                {
                    get { return _healAllyHealth.CurrentValue; }
                }

                #endregion Heal

                #region Barrier

                private static readonly CheckBox _useBarrier;
                private static readonly Slider _healthBarrier;

                public static bool UseBarrier
                {
                    get { return _useBarrier.CurrentValue; }
                }
                
                public static int BarrierHealth
                {
                    get { return _healthBarrier.CurrentValue; }
                }

                #endregion Barrier

                #region Ghost

                private static readonly CheckBox Ghost;

                public static bool UseGhost
                {
                    get { return Ghost.CurrentValue; }
                }

                #endregion Ghost


                static SummonerSpells()
                {
                    #region SmiteMenu

                    if (KickassSeries.Activator.SummonerSpells.Extensions.HasSpell("summonersmite"))
                    {
                        // Initialize the menu values
                        SummonerMenu.AddGroupLabel("Smite");
                        UseSmite = SummonerMenu.Add("useSmite", new CheckBox("Use Smite ?"));
                        SummonerMenu.AddLabel("Epic Camps");
                        SummonerMenu.Add("SRU_Baron", new CheckBox("Baron"));
                        SummonerMenu.Add("SRU_Dragon", new CheckBox("Dragon"));
                        SummonerMenu.AddLabel("Normal Camps");
                        SummonerMenu.Add("SRU_Blue", new CheckBox("Blue"));
                        SummonerMenu.Add("SRU_Red", new CheckBox("Red"));
                        SummonerMenu.Add("Sru_Crab", new CheckBox("Skuttles(Crab)"));
                        SummonerMenu.AddLabel("Small Camps");
                        SummonerMenu.Add("SRU_Gromp", new CheckBox("Gromp", false));
                        SummonerMenu.Add("SRU_Murkwolf", new CheckBox("Murkwolf", false));
                        SummonerMenu.Add("SRU_Krug", new CheckBox("Krug", false));
                        SummonerMenu.Add("SRU_Razorbeak", new CheckBox("Razerbeak", false));
                        SummonerMenu.AddSeparator();

                        UseSmiteDuel = SummonerMenu.Add("useSmiteDuel", new CheckBox("Use Red Smite(Duel) ?"));
                        UseSmiteKs = SummonerMenu.Add("useSmiteKS", new CheckBox("Use Blue Smite(KS) ?"));
                        SummonerMenu.AddSeparator();
                    }

                    #endregion SmiteMenu

                    #region HealMenu

                    if (KickassSeries.Activator.SummonerSpells.Extensions.HasSpell("summonerheal"))
                    {
                        SummonerMenu.AddGroupLabel("Summoner Heal Settings:");
                        _useHeal = SummonerMenu.Add("useHeal", new CheckBox("Use heal ?"));
                        _healHealth = SummonerMenu.Add("healthHeal", new Slider("Use Heal when health hits {0}%", 20));
                        _useHealAlly = SummonerMenu.Add("useHealAlly", new CheckBox("Use heal in allies ?"));
                        _healAllyHealth = SummonerMenu.Add("healthAllyHeal", new Slider("Use Heal when ally health hits {0}%", 30));
                    }

                    #endregion HealMenu

                    #region BarrierMenu

                    if (KickassSeries.Activator.SummonerSpells.Extensions.HasSpell("summonerbarrier"))
                    {
                        SummonerMenu.AddGroupLabel("Summoner Barrier Settings:");
                        _useBarrier = SummonerMenu.Add("useBarrier", new CheckBox("Use barrier ?"));
                        _healthBarrier = SummonerMenu.Add("healthBarrier", new Slider("Use Barrier when health hits {0}%", 30));
                    }

                    #endregion BarrierMenu

                    #region GhostMenu

                    if (KickassSeries.Activator.SummonerSpells.Extensions.HasSpell("summonerghost"))
                    {
                        SummonerMenu.AddGroupLabel("Ghost");
                        Ghost = SummonerMenu.Add("Ghostuse", new CheckBox("Use ghost when you are in danger ?"));
                        SummonerMenu.AddLabel("You can configure when you are in danger in the settings menu");
                        SummonerMenu.AddSeparator();
                    }

                    #endregion GhostMenu
                }

                public static void Initialize()
                {
                }
            }

            public static class Settings
            {
                //Offensive
                private static readonly CheckBox _AAcancel;
                private static readonly Slider _DelayOff;

                public static bool AACancel
                {
                    get { return _AAcancel.CurrentValue; }
                }

                public static int DelayBetweenOff
                {
                    get { return _DelayOff.CurrentValue; }
                }

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
                    SettingsMenu.AddGroupLabel("Offensive Settings");
                    _AAcancel = SettingsMenu.Add("aacanceloff", new CheckBox("Cancel AA animation with items ?"));
                    _DelayOff = SettingsMenu.Add("delayoffbetween", new Slider("Delay between each offensive item used(in MS)", 1000, 100, 5000));
                    SettingsMenu.AddGroupLabel("Danger Settings");
                    EnemySlider = SettingsMenu.Add("minenemiesinrange", new Slider("Min enemies in the range determined below", 1, 1, 5));
                    EnemyRange = SettingsMenu.Add("minrangeenemy", new Slider("Enemies must be in ({0}) range to be in danger", 1000, 600, 2500));
                    Spells = SettingsMenu.Add("considerspells", new CheckBox("Consider spells ?"));
                    Skillshots = SettingsMenu.Add("considerskilshots", new CheckBox("Consider SkillShots ?"));
                    AAs = SettingsMenu.Add("consideraas", new CheckBox("Consider Auto Attacks ?"));
                    SettingsMenu.AddSeparator();
                    SettingsMenu.AddGroupLabel("Dangerous Spells");
                    foreach (var spell in DMGHandler.DangerousSpells.Spells.Where(x => EntityManager.Heroes.Enemies.Any(b => b.Hero == x.Hero)))
                    {
                        SettingsMenu.Add(spell.Hero.ToString() + spell.Slot,new CheckBox(spell.Hero + " - " + spell.Slot + ".", spell.DefaultValue));
                    }
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}


