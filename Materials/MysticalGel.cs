using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Materials
{
    public class MysticalGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 2, copper: 21);
        }
        public override void AddRecipes()
        {
            CreateRecipe(15)
                .AddIngredient<PaliteSeeds>(5)
                .AddIngredient<VineGel>(10)
                .AddIngredient(ItemID.Gel, 10)
                .AddTile<MysticalAnvilTile>()
                .Register();
        }
    }
}
