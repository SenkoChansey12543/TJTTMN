using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Projectiles;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Ammo
{
    public class GelAcorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.knockBack = 2.5f;
            Item.consumable = true;
            Item.value = Item.buyPrice(copper: 9);
            Item.shoot = ProjectileID.BallofFire;
            Item.shootSpeed = 6.5f;
            Item.ammo = Item.type;
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Acorn, 1)
                .AddIngredient(ItemID.Gel, 3)
                .Register();
        }
    }
}
