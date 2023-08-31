using System;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Items.Placeables.Blocks;
using TJTTMN.Content.Tiles.Walls;

namespace TJTTMN.Content.Items.Placeables.Walls
{
    public class PaliteBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<PaliteBrickWallTile>();
            Item.value = 0;
        }
        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient<PaliteBrick>()
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
