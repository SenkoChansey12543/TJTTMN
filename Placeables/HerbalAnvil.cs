using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Placeables
{
    public class HerbalAnvil : ModItem
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
            Item.createTile = ModContent.TileType<Tiles.HerbalAnvilTile>();
            Item.width = 12;
            Item.height = 12;
            Item.value = Item.buyPrice(silver: 49, copper: 47);
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            //Iron anvil recipe
            CreateRecipe()
                .AddIngredient(ItemID.IronAnvil, 1)
                .AddIngredient<VineGel>(7)
                .AddTile(TileID.WorkBenches)
                .Register();

            //Lead anvil recipe
            CreateRecipe()
                .AddIngredient(ItemID.LeadAnvil, 1)
                .AddIngredient<VineGel>(7)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}