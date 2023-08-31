using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;
using TJTTMN.Content.Tiles.Blocks;
using TJTTMN.Content.Items.Placeables.Walls;

namespace TJTTMN.Content.Items.Placeables.Blocks
{
    public class PlantiteBrick : ModItem
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
            Item.createTile = ModContent.TileType<PlantiteBrickTile>();
            Item.width = 12;
            Item.height = 12;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe(2)
                .AddIngredient(ItemID.StoneBlock, 1)
                .AddIngredient<PlantiteBlock>(1)
                .AddTile<HerbalAnvilTile>()
                .Register();

            CreateRecipe()
                .AddIngredient<PlantiteBrickWall>(4)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
