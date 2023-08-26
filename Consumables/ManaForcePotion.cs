using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Consumables
{
    public class ManaForcePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
            ItemID.Sets.DrinkParticleColors[Type] = new Color[2]
            {
                new Color(85, 51, 255),
                new Color(105, 76, 252),
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
            Item.value = Item.buyPrice(silver: 14);
            Item.buffType = ModContent.BuffType<Buffs.ManaForce>();
            Item.buffTime = 28800;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater, 1)
                .AddIngredient(ItemID.Deathweed, 1)
                .AddIngredient(ItemID.FallenStar, 1)
                .AddIngredient<Plantite>(1)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
