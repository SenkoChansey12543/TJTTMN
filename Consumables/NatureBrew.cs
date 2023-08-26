using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Consumables
{
    public class NatureBrew : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] 
            {
                new Color(52, 172, 0),
                new Color(64, 207, 2),
                new Color(52, 172, 0)
            };
        }
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 20;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(silver: 8);
            Item.buffType = ModContent.BuffType<Buffs.NatureBrew>();
            Item.buffTime = 14400;

        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater, 1)
                .AddIngredient(ItemID.Daybloom, 1)
                .AddIngredient(ItemID.Shiverthorn, 1)
                .AddIngredient<VineGel>(3)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
