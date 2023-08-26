using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Projectiles;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Ammo
{
    public class WeedtiteArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 14;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.knockBack = 3.5f;
            Item.consumable = true;
            Item.value = 20;
            Item.shoot = ModContent.ProjectileType<WeedtiteArrowProjectile>();
            Item.shootSpeed = 10;
            Item.ammo = AmmoID.Arrow;
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<Items.Ammo.WeedtiteArrow>(), 15)
                .AddIngredient(ItemID.GrassSeeds, 10)
                .AddIngredient(ItemID.Wood, 1)
                .AddIngredient<VineGel>(1)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
