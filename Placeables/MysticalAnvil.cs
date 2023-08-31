using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Placeables
{
    public class MysticalAnvil : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<MysticalAnvilTile>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 2, silver: 3);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MysticalGel>(20)
                .AddIngredient<PaliteSeeds>(3)
                .AddIngredient<HerbalAnvil>(1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}