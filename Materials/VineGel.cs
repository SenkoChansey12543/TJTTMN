using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace TJTTMN.Content.Items.Materials
{
    public class VineGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(silver: 1, copper: 7);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<VineGel>(1);
            recipe.AddRecipeGroup("Wood", 1);
            recipe.ReplaceResult(ItemID.Torch, 3);
            recipe.Register();

            CreateRecipe(5)
                .AddIngredient(ItemID.Vine, 1)
                .AddIngredient(ItemID.Gel, 10)
                .Register();
        }

    }
}
