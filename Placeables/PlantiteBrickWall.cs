using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Placeables
{
    public class PlantiteBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<PlantiteBrickWallTile>();
            Item.value = 0;
        }
        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient<PlantiteBrick>()
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}