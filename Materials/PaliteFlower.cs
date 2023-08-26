using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Materials
{
    public class PaliteFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 4, copper: 87);
        }
        public override void AddRecipes()
        {
            CreateRecipe(2)
                .AddIngredient<PaliteSeeds>(5)
                .AddIngredient<MysticalGel>(2)
                .AddCondition(Condition.NearLava)
                .AddTile<MysticalAnvilTile>()
                .Register();
        }
    }
}
