using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TJTTMN.Content.Items.Weapons.Ranger
{
    public class Crushotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.damage = 28;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 7f;
            Item.useTime = 160;
            Item.useAnimation = 160;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item36;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.knockBack = 9f;
            Item.value = 2500;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 5;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(7));
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<ArmotiteBar>(12)
                .AddIngredient(ItemID.IllegalGunParts, 1)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }

}
