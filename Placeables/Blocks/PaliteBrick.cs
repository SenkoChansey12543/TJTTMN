using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Items.Placeables.Walls;
using TJTTMN.Content.Tiles;
using TJTTMN.Content.Tiles.Blocks;

namespace TJTTMN.Content.Items.Placeables.Blocks
{
    public class PaliteBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<PaliteBrickTile>();
            Item.width = 12;
            Item.height = 12;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe(2)
                .AddIngredient(ItemID.StoneBlock, 1)
                .AddIngredient<PaliteBlock>(1)
                .AddTile<MysticalAnvilTile>()
                .Register();

            CreateRecipe()
                .AddIngredient<PaliteBrickWall>(4)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
