using EloBuddy;
using EloBuddy.SDK;

namespace KA_Activator.Items
{
    public abstract class Ids
    {
        #region Consumables
        protected static readonly Item HealthPotion = new Item(2003);
        protected static readonly Item ElixirOfIron = new Item(ItemId.Elixir_of_Iron);
        protected static readonly Item ElixirOfSorcery = new Item(ItemId.Elixir_of_Sorcery);
        protected static readonly Item ElixirOfWrath = new Item(ItemId.Elixir_of_Wrath);
        protected static readonly Item Biscuit = new Item(2010);
        protected static readonly Item HuntersPotion = new Item(2032);
        protected static readonly Item CorruptingPotion = new Item(2033); 
        protected static readonly Item RefilablePotion = new Item(2031);
        #endregion Consumables

        #region Offensive
        protected static readonly Item BilgewaterCutlass = new Item(ItemId.Bilgewater_Cutlass, 550f);
        protected static readonly Item BladeOfTheRuinedKing = new Item(ItemId.Blade_of_the_Ruined_King, 550f);
        protected static readonly Item Hydra = new Item(ItemId.Ravenous_Hydra_Melee_Only, 250f);
        protected static readonly Item Tiamat = new Item(ItemId.Tiamat_Melee_Only, 250f);
        protected static readonly Item TitanicHydra = new Item(3053, Player.Instance.GetAutoAttackRange());
        protected static readonly Item Youmuu = new Item(ItemId.Youmuus_Ghostblade, 600f);
        protected static readonly Item Hextech = new Item(ItemId.Hextech_Gunblade, 700f);
        protected static readonly Item Muramana = new Item(3042);
        #endregion Offensive

        #region Defensive
        protected static readonly Item Zhonyas = new Item(ItemId.Zhonyas_Hourglass);
        protected static readonly Item ArchengelStaff = new Item(3003);
        protected static readonly Item FaceOfTheMountain = new Item(ItemId.Face_of_the_Mountain);
        protected static readonly Item Talisman = new Item(ItemId.Talisman_of_Ascension);
        protected static readonly Item Mikael = new Item(ItemId.Mikaels_Crucible);
        protected static readonly Item Solari = new Item(ItemId.Locket_of_the_Iron_Solari);
        protected static readonly Item Ohm = new Item(ItemId.Ohmwrecker);
        protected static readonly Item Randuin = new Item(ItemId.Randuins_Omen, 500f);
        protected static readonly Item DerbishBlade = new Item(ItemId.Dervish_Blade);
        protected static readonly Item Mercurial = new Item(ItemId.Mercurial_Scimitar);
        protected static readonly Item QuickSilver = new Item(ItemId.Quicksilver_Sash);

        #endregion Defensive

        #region Support Items
        protected static readonly Item FrostQueen = new Item(ItemId.Frost_Queens_Claim, 1000f);
        #endregion Support Items
    }
}
